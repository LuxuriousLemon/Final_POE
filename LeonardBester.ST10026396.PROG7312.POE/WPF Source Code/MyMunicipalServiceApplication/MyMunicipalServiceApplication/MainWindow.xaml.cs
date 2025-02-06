using MyMunicipalServiceApplication.Views.User_Control;
using System;
using System.Collections.Generic;
using System.Windows;
using ValidationClassLibrary;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using MyMunicipalServiceApplication.Classes;
using System.Threading.Tasks;

namespace MyMunicipalServiceApplication
{
    public partial class MainWindow : Window
    {
 
        public String ConnectionString = string.Empty;

        private ServiceRequestPageUserControl serviceUserControl;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Initialize and set the HomeUserControl as the default content in the bottom row
            var homeUserControl = new HomeUserControl(ConnectionString);
            ReportContentControl.Content = homeUserControl;

            // Subscribe to the ReportButtonClicked event from TopBannerUserControl
            TopBannerControl.ReportButtonClicked += TopBanner_ReportButtonClicked;

            // Subscribe to the HomeButtonClicked event from TopBannerUserControl
            TopBannerControl.HomeButtonClicked += TopBanner_HomeButtonClicked;

            TopBannerControl.EventsButtonCLicked += TopBannerControl_EventsButtonCLicked;

            TopBannerControl.ServiceStatusClicked += TopBannerControl_ServiceStatusClicked;


            ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString; ;
            serviceUserControl = new ServiceRequestPageUserControl(ConnectionString);

            this.Loaded += MainWindow_Loaded;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Async method to start the background updatting process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Application Loaded and starting Async thread");

            // Run the background task without blocking the UI thread
            await StartStatusUpdateBackground();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Calls updating class to function on a different thread
        /// </summary>
        /// <returns></returns>
        private async Task StartStatusUpdateBackground()
        {
            StatusUpdaterClass update = new StatusUpdaterClass(ConnectionString, serviceUserControl);
            await update.UpdateStatusesAsync();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Handling event from from TopBanner Controll for page change to Service Status Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBannerControl_ServiceStatusClicked(object sender, EventArgs e)
        {
            
            ReportContentControl.Content = serviceUserControl;
            serviceUserControl.ServiceRequestBack += ServiceUserControl_ServiceRequestBack; 

        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Handling event from Service Resquest to go back to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceUserControl_ServiceRequestBack(object sender, EventArgs e)
        {
            var homeUserControl = new HomeUserControl(ConnectionString);
            ReportContentControl.Content = homeUserControl;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Handling event from TopBanner to change to the Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBannerControl_EventsButtonCLicked(object sender, EventArgs e)
        {
            var eventsUserControl = new EventsUserControl();
            ReportContentControl.Content = eventsUserControl;
            eventsUserControl.EventsBackButton += EventsUserControl_EventsBackButton;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Handling event from Events to go back to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventsUserControl_EventsBackButton(object sender, EventArgs e)
        {
            var homeUserControl = new HomeUserControl(ConnectionString);
            ReportContentControl.Content = homeUserControl;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Opens the Report page when the report button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBanner_ReportButtonClicked(object sender, EventArgs e)
        {
            var reportUserControl = new ReportUserControl(ConnectionString);
            reportUserControl.BackButtonClicked += ReportUserControl_BackButtonClicked;
            ReportContentControl.Content = reportUserControl;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Opens the home page when the home button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBanner_HomeButtonClicked(object sender, EventArgs e)
        {
            var homeUserControl = new HomeUserControl(ConnectionString);
            ReportContentControl.Content = homeUserControl;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Opens the home page when the back button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportUserControl_BackButtonClicked(object sender, EventArgs e)
        {
            var homeUserControl = new HomeUserControl(ConnectionString);
            ReportContentControl.Content = homeUserControl;
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//
