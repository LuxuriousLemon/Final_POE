using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValidationClassLibrary;
using ValidationClassLibrary.Classes;

namespace MyMunicipalServiceApplication.Views.User_Control
{
    /// <summary>
    /// Interaction logic for HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        // Connection string for database
        private string ConnectionString { get; set; } = string.Empty;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="report"></param>
        public HomeUserControl(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;

        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Clears all recrods from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearReports_Click(object sender, RoutedEventArgs e)
        {
            GenericDatabaseInteractions clear = new GenericDatabaseInteractions(ConnectionString);
            clear.ClearDatabase();
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//