using MyMunicipalServiceApplication.Views.User_Control;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyMunicipalServiceApplication.Classes
{
    public class StatusUpdaterClass
    {
        // Connection string to the database
        private string ConnectionString { get; set; } = string.Empty;

        // Reference to an object of ServiceRequestPageUserControl
        ServiceRequestPageUserControl Build;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="build"></param>
        public StatusUpdaterClass(string connectionString, ServiceRequestPageUserControl build)
        {
            this.ConnectionString = connectionString;
            Build = build;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Begins the updating rocess to the status of each record
        /// </summary>
        /// <returns></returns>
        public async Task UpdateStatusesAsync()
        {
            while (true)
            {
                ServiceRequestGraph graph = BuildServiceRequestTree();

                // If there are no nodes or all nodes are completed, wait for 15 seconds before checking again
                if (!graph.Nodes.Any() || graph.Nodes.All(n => n.Status == "Complete"))
                {
                    Console.WriteLine("No tasks available or all tasks are completed. Waiting for 15000 ms...");
                    await Task.Delay(15000); // Wait for 15 seconds before checking again
                    continue; // Check again after the wait
                }

                // Look for nodes with 'Pending' or 'In Progress' status
                var highestPriorityNode = graph.Nodes
                    .Where(n => n.Status == "Pending" || n.Status == "In Progress")
                    .OrderByDescending(n => n.Priority)
                    .FirstOrDefault();

                if (highestPriorityNode != null)
                {
                    // If there's a node that is either Pending or In Progress, simulate progress
                    await SimulateProgressAsync(highestPriorityNode);
                }
                else
                {
                    // If no tasks are found to be in Pending or In Progress, wait 1 second and recheck
                    await Task.Delay(15000);
                }
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Simulates the time it would take to complete a service request
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private async Task SimulateProgressAsync(ServiceRequestNode node)
        {
            // Ensure the node is either in 'Pending' or 'In Progress' before updating
            if (node.Status != "Pending" && node.Status != "In Progress")
            {
                Console.WriteLine($"Node {node.Id} is not in a valid state to update. Current status: {node.Status}");
                return; // Exit if the node is not in a valid state to process
            }

            string[] stages = { "Pending", "In Progress", "Complete" };

            foreach (var stage in stages)
            {
                // Only update status if it's the next valid stage
                if (stage == "Pending" && node.Status == "Pending" ||
                    stage == "In Progress" && node.Status == "Pending" ||
                    stage == "Complete" && node.Status == "In Progress")
                {
                    node.Status = stage;
                    UpdateDatabaseNodeStatus(node); // Update the database with the new status
                    Debug.WriteLine($"Updated node {node.Id} status to: {stage}");
                    await Task.Delay(15000); // Simulate delay for stage transition
                }
            }

            // After completing the simulation for a node, check if the task is completed
            if (node.Status == "Complete")
            {
                Debug.WriteLine($"Node {node.Id} has been completed. Checking for the next task...");
                return; // End this cycle and go back to `UpdateStatusesAsync()` to check the database again
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Updates the status field in the database
        /// </summary>
        /// <param name="node"></param>
        private void UpdateDatabaseNodeStatus(ServiceRequestNode node)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Reports SET Status = @Status WHERE Id = @Id";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", node.Status);
                    command.Parameters.AddWithValue("@Id", node.Id);
                    command.ExecuteNonQuery();
                }
            }

            // Ensure LoadServiceRequests() is called on the UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Assuming ServiceRequestPageUserControl is your main UI control
                ServiceRequestPageUserControl build = new ServiceRequestPageUserControl(ConnectionString);
                Build.LoadServiceRequests();
            });
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Builds the graph that contains the nodes reperesenting records in the database
        /// </summary>
        /// <returns></returns>
        private ServiceRequestGraph BuildServiceRequestTree()
        {
            ServiceRequestGraph graph = new ServiceRequestGraph();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, Status, Priority FROM Reports";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        string priority = reader.GetString(2);

                        var newNode = new ServiceRequestNode(id, status, priority);
                        graph.AddNode(newNode);
                    }
                }
            }

            return graph;
        }
        //==========================================================================================//


        //======================================= Class Seperation ===================================================//
        /// <summary>
        /// Internal class to help build the graph
        /// </summary>
        internal class ServiceRequestGraph
        {
            // List of nodes for the graph
            public List<ServiceRequestNode> Nodes { get; set; } = new List<ServiceRequestNode>();


            //==========================================================================================//
            /// <summary>
            /// Adds a node to the graph from a list
            /// </summary>
            /// <param name="node"></param>
            public void AddNode(ServiceRequestNode node)
            {
                Nodes.Add(node);
            }
            //==========================================================================================//
        }
        //==========================================================================================//

        //======================================= Class Seperation ===================================================//
        /// <summary>
        /// Internal class that sets variables to enter the graphs
        /// </summary>
        internal class ServiceRequestNode
        {
            public int Id { get; set; }
            public string Status { get; set; }
            public string Priority { get; set; }
            public List<ServiceRequestNode> Neighbors { get; set; } = new List<ServiceRequestNode>();

            public ServiceRequestNode(int id, string status, string priority)
            {
                Id = id;
                Status = status;
                Priority = priority;
            }
            //==========================================================================================//
        }
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//