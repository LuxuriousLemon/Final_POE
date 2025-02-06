using System;
using System.Windows;
using System.Windows.Controls;

namespace MyMunicipalServiceApplication.Views.User_Control
{
    /// <summary>
    /// Interaction logic for TopBannerUserControl.xaml
    /// </summary>
    public partial class TopBannerUserControl : UserControl
    {
        // Event to notify when the Home button is clicked
        public event EventHandler HomeButtonClicked;
        // Event to notify when the report button is clicked
        public event EventHandler ReportButtonClicked;
        // Event to notify when the Events button is clicked
        public event EventHandler EventsButtonCLicked;
        // Event to notify when the Service button is clicked
        public event EventHandler ServiceStatusClicked;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        public TopBannerUserControl()
        {
            InitializeComponent();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Invokes the event to take user to the home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            // Raise the HomeButtonClicked event when the Home button is clicked
            HomeButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Event that signalls main form to change to the events UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            // Raise the EventsButtonClicked event when the Events button is clicked
            EventsButtonCLicked?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Event that signalls main form to change to the Service UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            // Raise the ServiceStatusClicked event when the Events button is clicked
            ServiceStatusClicked?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Event that takes user to the reports page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            // Raise the ReportButtonClicked event when the Report button is clicked
            ReportButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//