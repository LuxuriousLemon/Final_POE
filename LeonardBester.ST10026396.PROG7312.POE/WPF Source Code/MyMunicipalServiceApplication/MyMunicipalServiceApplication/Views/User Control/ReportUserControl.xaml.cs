using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using ValidationClassLibrary;
using System.Collections.Generic;
using ValidationClassLibrary.Classes;

namespace MyMunicipalServiceApplication.Views.User_Control
{
    public partial class ReportUserControl : UserControl
    {
        // Event to notify when the Back button is clicked
        public event EventHandler BackButtonClicked;


        /// <summary>
        /// Object of ReportValidation Class
        /// </summary>
        private ReportValidation reportValidation = new ReportValidation();

        /// <summary>
        /// Object of StringMessages class
        /// </summary>
        private StringMessagesClass Messages = new StringMessagesClass();

      

        // Variables to recieve user inputs
        string Location {  get; set; } = string.Empty;
        string Description {  get; set; } = string.Empty;
        string Category { get; set; } = string.Empty;
        Byte[] Attachment = null;
        string ConnectionString { get; set; } = string.Empty;


        // Total number of input fields to track
        private const int TotalFields = 5; 

        private int filledFields = 0;


        //========================================== END OF FILE ================================================//
        /// <summary>
        /// Default constructer
        /// </summary>
        public ReportUserControl(string connectionString)
        {
            InitializeComponent();;
            ConnectionString = connectionString;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Invokes event to take user back to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Attaches a media file to a variable from file explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                rtbFileDescription.Document.Blocks.Clear();
                rtbFileDescription.Document.Blocks.Add(new Paragraph(new Run(selectedFilePath)));

                string fileExtension = Path.GetExtension(selectedFilePath).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
                {
                    imgPrieview.Source = new BitmapImage(new Uri(selectedFilePath));
                    imgPrieview.Visibility = Visibility.Visible;
                }
                else
                {
                    imgPrieview.Visibility = Visibility.Collapsed;
                }

                UpdateProgressBar();
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Event that calls UpdateProgressBar method to update progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFieldChanged(object sender, RoutedEventArgs e)
        {
            UpdateProgressBar();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Updates the visual progress bar
        /// </summary>
        private void UpdateProgressBar()
        {
            filledFields = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) filledFields++;
            if (cmbCategory.SelectedItem != null) filledFields++;
            if (!string.IsNullOrWhiteSpace(new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim())) filledFields++;
            if (!string.IsNullOrWhiteSpace(new TextRange(rtbFileDescription.Document.ContentStart, rtbFileDescription.Document.ContentEnd).Text.Trim())) filledFields++;
            if (imgPrieview.Source != null) filledFields++;

            // Update progress bar value (percentage of fields filled)
            prgEngagement.Value = (double)filledFields / TotalFields * 100;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Disables digits from being entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLocation_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Check if the input is a digit
            if (char.IsDigit(e.Text, 0))
            {
                // Prevent the input if it's a number
                e.Handled = true;
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Calls validation method and Saves the input into a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(CheckValidationResults())
            {
                AddReport();
                ClearInputFields();
            }       
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Clears all user input fields
        /// </summary>
        private void ClearInputFields()
        {
            txtLocation.Text = string.Empty;
            rtbDescription.Document.Blocks.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbFileDescription.Document.Blocks.Clear();
            imgPrieview.Source = null;
            prgEngagement.Value = 0;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Creates user feedback for successful report entry
        /// </summary>
        private void ReportSuccessfullyAddedUserFeedback()
        {
            MessageBox.Show(Messages.GetReportAddedSuccesfully(), "Report Document", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Adds a report to the list
        /// </summary>
        private void AddReport()
        {

            GenericDatabaseInteractions reportsClass = new GenericDatabaseInteractions(ConnectionString );
            reportsClass.AddReportToDatabase(Location, Description, Category, Attachment);
            ReportSuccessfullyAddedUserFeedback();
        }
        //==========================================================================================//


        //======================================= Input Validation Section ===================================================//


        //==========================================================================================//
        /// <summary>
        /// Validates all user inputs
        /// </summary>
        private bool CheckValidationResults()
        {
            // Retrieve values from the fields
            Location = txtLocation.Text;
            Description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim();
            Category = cmbCategory.SelectionBoxItem.ToString();
            Attachment = SaveSelectedImage();
            var value = false;

            try
            {
                // Validate the location field
                if (reportValidation.CheckForNullOrEmptyStrings(Location))
                {
                    throw new Exception(Messages.GetLocationErrorMessage());
                }

                // Validate the description field
                if (reportValidation.CheckForNullOrEmptyStrings(Description))
                {
                    throw new Exception(Messages.GetDescriptionErrorMessage());
                }

                // Validate the category field
                if (reportValidation.CheckForNullOrEmptyStrings(Category))
                {
                    throw new Exception(Messages.GetCategoryErrorMessage());
                }

                // Validate the attachment field
                if (reportValidation.CheckForNullByte(Attachment))
                {
                    throw new Exception(Messages.GetAttachementErrorMessage());
                }
                value = true;
            }
            catch (Exception ex)
            {
                // Handle the validation exception and display the error message
                MessageBox.Show($"Validation error: {ex.Message}", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return value;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Turns the bitmap attachments into a Byte[]
        /// </summary>
        /// <returns></returns>
        private byte[] SaveSelectedImage()
        {
            if (imgPrieview.Source != null)
            {
                // Cast the image source to a BitmapImage
                BitmapImage selectedImage = imgPrieview.Source as BitmapImage;

                if (selectedImage != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        // Use an appropriate encoder for the image format
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(selectedImage));
                        encoder.Save(memoryStream);

                        // Return the image as a byte array
                        return memoryStream.ToArray();
                    }
                }
            }

            return null; // Return null if no image is selected
        }
        //==========================================================================================//
        //======================================= Input Validation Section END ===================================================//

    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//