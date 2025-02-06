using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using MyMunicipalServiceApplication.Classes;
using MyMunicipalServiceApplication.Views.User_Control;

namespace MyMunicipalServiceApplication.Views.User_Control
{
    /// <summary>
    /// Interaction logic for ServiceRequestPageUserControl.xaml
    /// </summary>
    public partial class ServiceRequestPageUserControl : UserControl
    {
        // Variable representing the status field
        public string Status { get; set; } = string.Empty;

        // Variable representing the priority field
        public string Priority { get; set; } = string.Empty;

        // Event to singal to go back to homepage
        public event EventHandler ServiceRequestBack;

        // Connection string to database
        private string ConnectionString { get; set; } = string.Empty;


        //==========================================================================================//
        /// <summary>
        /// Default constructor 
        /// </summary>
        public ServiceRequestPageUserControl(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            // Subscribe to the Loaded event to ensure controls are initialized
            Loaded += ServiceRequestPageUserControl_Loaded;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Handle the Loaded event, ensuring controls are initialized before proceeding
        /// </summary>
        private void ServiceRequestPageUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Get default values only when the control is loaded
            var (status, priority) = GetDefaultSearchValues();

            if (!status.Equals("Error") || !priority.Equals("Error"))
            {
                Status = status;
                Priority = priority;
                Debug.WriteLine("Default values successfully loaded: " + Status + " " + Priority);

                LoadServiceRequests();
            }
            else
            {
                ShowLoadingError();
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Sets the Status and Priority values based on user selection
        /// </summary>
        private (string, string) GetDefaultSearchValues()
        {
            try
            {
                string status = cmbStatus.SelectionBoxItem?.ToString() ?? "Unknown";
                string priority = cmbPriority.SelectionBoxItem?.ToString() ?? "Unknown";
                return (status, priority);
            }
            catch (Exception ex)
            {
                // Handle exception and log if needed
                Console.WriteLine($"An error occurred while getting default search values: {ex.Message}");
                return ("Error", "Error");
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Displays error message box for user
        /// </summary>
        private void ShowLoadingError()
        {
            MessageBox.Show("Failed to load Status or Priority value. Ensure both have selected values", "Failed to start data load", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Loads service requests based on the selected status and priority
        /// </summary>
        public void LoadServiceRequests()
        {
            // Ensure that UserControlContainer is not null before accessing it
            if (UserControlContainer == null)
            {
                MessageBox.Show("UserControlContainer is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create an instance of the ServiceRequestBuilder class
            ServiceRequestBuilder builder = new ServiceRequestBuilder(ConnectionString);

            // Get the filtered service requests based on Status and Priority
            IEnumerable<ServiceRequestUserControl> serviceRequestControls = builder.GetFilteredServiceRequests(Status, Priority);

            // Clear the existing items in the container before adding new ones
            UserControlContainer.Children.Clear();

            // Add each filtered user control to the container
            foreach (var control in serviceRequestControls)
            {
                UserControlContainer.Children.Add(control);
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Takes user back to Home Page
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestBack?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//
 
        
        //==========================================================================================//
        /// <summary>
        /// Checks if input is succesfully gathered and applies value to filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_DropDownClosed(object sender, EventArgs e)
        {
            if (SetStatus())
                LoadServiceRequests();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Sets the Status if there is no error
        /// </summary>
        /// <returns></returns>
        private bool SetStatus()
        {
            bool value = false;

            try
            {
                Status = cmbStatus.SelectionBoxItem.ToString();
                value = true;
            }
            catch (Exception)
            {

                throw;
            }

            return value;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Checks if input is succesfully gathered and applies value to filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPriority_DropDownClosed(object sender, EventArgs e)
        {
            if(SetPriority())
                LoadServiceRequests();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Sets the Status if there is no error
        /// </summary>
        /// <returns></returns>
        private bool SetPriority()
        {
            bool value = false;

            try
            {
                Priority = cmbPriority.SelectionBoxItem.ToString();
                value = true;
            }
            catch (Exception)
            {

                throw;
            }

            return value;
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//