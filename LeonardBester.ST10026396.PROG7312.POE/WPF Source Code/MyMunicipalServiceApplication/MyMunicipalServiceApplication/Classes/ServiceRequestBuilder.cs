using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Media.Imaging;
using MyMunicipalServiceApplication.Views.User_Control;

namespace MyMunicipalServiceApplication.Classes
{
    internal class ServiceRequestNode
    {
        // Unique Identifier for a record from the database
        public int Id { get; set; }
        // Location field of record
        public string Location { get; set; }
        // Category field of record
        public string Category { get; set; }
        // Description field of record
        public string Description { get; set; }
        // Image in byte array of record
        public BitmapImage Image { get; set; }
        // Status field of record
        public string Status { get; set; }
        //Priority field of record
        public string Priority { get; set; }

        // Left branch of tree
        public ServiceRequestNode Left { get; set; }
        // Right branhc of tree
        public ServiceRequestNode Right { get; set; }


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="image"></param>
        /// <param name="status"></param>
        /// <param name="priority"></param>
        public ServiceRequestNode(int id, string location, string category, string description, BitmapImage image, string status, string priority)
        {
            Id = id;
            Location = location;
            Category = category;
            Description = description;
            Image = image;
            Status = status;
            Priority = priority;
        }
        //==========================================================================================//
    }

    //======================================= Class Seperation ===================================================//

    public class ServiceRequestBuilder
    {
        // Connection string to database
        private string ConnectionString { get; set; } = string.Empty;
        // Root of the tree
        private ServiceRequestNode root;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public ServiceRequestBuilder(string connectionString)
        {
            ConnectionString = connectionString;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Public method to be called by other classes to get filtered reports
        /// </summary>
        /// <param name="status"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public IEnumerable<ServiceRequestUserControl> GetFilteredServiceRequests(string status, string priority)
        {
            // Ensure the tree is built
            BuildServiceRequestTree();

            // Perform the search and return results
            return SearchTree(status, priority);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Builds the service request tree from the database
        /// </summary>
        private void BuildServiceRequestTree()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                // Opening connection to database
                connection.Open();
                string query = "SELECT Id, Location, Category, Description, Bitmap, Status, Priority FROM Reports";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string location = reader.GetString(1);
                        string category = reader.GetString(2);
                        string description = reader.GetString(3);
                        byte[] imageBytes = reader["Bitmap"] as byte[];
                        string status = reader.GetString(5);
                        string priority = reader.GetString(6);

                        BitmapImage image = LoadImageFromByteArray(imageBytes);

                        var newNode = new ServiceRequestNode(id, location, category, description, image, status, priority);
                        root = InsertNode(root, newNode);
                    }
                }
                // closing connection to database
                connection.Close();
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Inserts a new node into the tree based on Id (Binary Search Tree logic)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        private ServiceRequestNode InsertNode(ServiceRequestNode current, ServiceRequestNode newNode)
        {
            if (current == null)
                return newNode;

            if (newNode.Id < current.Id)
                current.Left = InsertNode(current.Left, newNode);
            else
                current.Right = InsertNode(current.Right, newNode);

            return current;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Searches the tree for nodes matching the given status and priority
        /// </summary>
        /// <param name="status"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        private IEnumerable<ServiceRequestUserControl> SearchTree(string status, string priority)
        {
            return SearchTreeHelper(root, status, priority);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Helper function to traverse the tree recursively
        /// </summary>
        /// <param name="node"></param>
        /// <param name="status"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        private IEnumerable<ServiceRequestUserControl> SearchTreeHelper(ServiceRequestNode node, string status, string priority)
        {
            if (node == null)
                yield break;

            // Check if status is "Any" or matches the node status
            bool statusMatch = (status.Equals("Any", StringComparison.OrdinalIgnoreCase)) || node.Status.Equals(status, StringComparison.OrdinalIgnoreCase);

            // Check if priority is "Any" or matches the node priority
            bool priorityMatch = (priority.Equals("Any", StringComparison.OrdinalIgnoreCase)) || node.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase);

            // If either status or priority is "Any", we ignore that filter condition and show all records
            if (statusMatch && priorityMatch)
            {
                var serviceRequestControl = new ServiceRequestUserControl
                {
                    IdTextBlock = { Text = node.Id.ToString() },
                    LocationRun = { Text = node.Location },
                    CategoryRun = { Text = node.Category },
                    DescriptionRun = { Text = node.Description },
                    ImageControl = { Source = node.Image },
                    StatusRun = { Text = node.Status },
                    PriorityRun = { Text = node.Priority },
                };

                yield return serviceRequestControl;
            }

            // Recursively search in the left and right subtrees
            foreach (var leftResult in SearchTreeHelper(node.Left, status, priority))
                yield return leftResult;

            foreach (var rightResult in SearchTreeHelper(node.Right, status, priority))
                yield return rightResult;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Converts a byte array (image data) to a BitmapImage
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        private BitmapImage LoadImageFromByteArray(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (MemoryStream stream = new MemoryStream(imageData))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//
