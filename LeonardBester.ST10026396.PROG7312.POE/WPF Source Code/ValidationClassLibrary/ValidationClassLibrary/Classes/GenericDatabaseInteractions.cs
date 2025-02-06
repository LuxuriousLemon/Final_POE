using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationClassLibrary.Classes
{
    public class GenericDatabaseInteractions
    {
        public string ConnectionString { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public string Status { get; set; } = "Pending"; 
        public string Priority { get; set; }
        public enum Priorities { High, Medium, Low };



        //==========================================================================================//
        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        /// <param name="connectionString"></param>
        public GenericDatabaseInteractions(string connectionString)
        {
            ConnectionString = connectionString;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Determines Priority and status based on inputed data
        /// </summary>
        private void DeterminePriorityAndStatus()
        {
            switch(Category)
            {
                case "Sanitation":
                    Priority = Priorities.High.ToString();
                    break;
                case "Utilities":
                    Priority = Priorities.Medium.ToString();
                    break;
                case "Roads":
                    Priority = Priorities.Low.ToString();
                    break;
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Method to add report data to the database
        /// </summary>
        public void AddReportToDatabase(string location, string description, string category, byte[] attachment)
        {
            Location = location;
            Description = description;
            Category = category;
            Attachment = attachment;
            DeterminePriorityAndStatus();
            // Create the SQL INSERT statement
            string query = @"
                INSERT INTO Reports (Location, Category, Description, Bitmap, Status, Priority)
                VALUES (@Location, @Category, @Description, @BitmapData, @Status, @Priority)";

            // Create a connection using the SQLite connection string
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Location", Location);
                        command.Parameters.AddWithValue("@Category", Category);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@BitmapData", Attachment);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@Priority", Priority);

                        // Execute the command (this inserts the data)
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log any exceptions (could also throw or handle as needed)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Clears all records in database
        /// </summary>
        public void ClearDatabase()
        {
            // Create the SQL DELETE statement
            string query = "DELETE FROM Reports";

            // Create a connection using the SQLite connection string
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Execute the command (this deletes all records from the Reports table)
                        int rowsAffected = command.ExecuteNonQuery();

                        // Log the number of rows affected (optional)
                        Console.WriteLine($"Successfully deleted {rowsAffected} rows from the Reports table.");
                    }
                }
                catch (Exception ex)
                {
                    // Log any exceptions (could also throw or handle as needed)
                    Console.WriteLine("An error occurred while clearing the database: " + ex.Message);
                }
            }
        }
        //==========================================================================================//

    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//