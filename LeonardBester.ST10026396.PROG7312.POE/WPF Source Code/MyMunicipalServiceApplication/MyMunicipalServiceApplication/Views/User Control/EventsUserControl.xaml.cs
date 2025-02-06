using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ValidationClassLibrary;

namespace MyMunicipalServiceApplication.Views.User_Control
{
    public partial class EventsUserControl : UserControl
    {
        /// <summary>
        /// Event of the back button
        /// </summary>
        public event EventHandler EventsBackButton;

        /// <summary>
        /// Object of the EventClass class
        /// </summary>
        private EventsClass eventsClass = new EventsClass();

        /// <summary>
        /// Data structores to sstore event data
        /// </summary>
        private SortedDictionary<string, Dictionary<string, string>> allEventsData;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        public EventsUserControl()
        {
            InitializeComponent();
            StartUpPopulateEvents();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Populates the rich text box with the default data
        /// </summary>
        private void StartUpPopulateEvents()
        {
            // Extract the event data from EventsClass
            allEventsData = eventsClass.ExtractEventsData();
            PopulateEvents(allEventsData);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Populates rich text box with particular data.
        /// </summary>
        /// <param name="eventsData"></param>
        private void PopulateEvents(SortedDictionary<string, Dictionary<string, string>> eventsData)
        {
            // Using Lamba to iterate through the event
            eventsData.ToList().ForEach(eventEntry =>
            {
                // Add the event name as a heading with larger font size and bold
                var eventName = eventEntry.Key;
                var title = new Run(eventName)
                {
                    FontSize = 20,
                    FontWeight = FontWeights.Bold
                };
                rtbEventDetails.Document.Blocks.Add(new Paragraph(title)
                {
                    Margin = new Thickness(0, 20, 0, 10) // Add space above and below the title
                });

                // Add the details of the event with different formatting
                eventEntry.Value.ToList().ForEach(detail =>
                {
                    var field = detail.Key;
                    var value = detail.Value;

                    // Customize how each field is presented
                    var fieldRun = new Run($"{field}: ")
                    {
                        FontWeight = FontWeights.Bold
                    };
                    var valueRun = new Run(value);

                    var paragraph = new Paragraph();
                    paragraph.Inlines.Add(fieldRun);
                    paragraph.Inlines.Add(valueRun);

                    rtbEventDetails.Document.Blocks.Add(paragraph);
                });

                // Add a separator line for readability
                var separator = new Paragraph(new Run(new string('-', 50)))
                {
                    Foreground = System.Windows.Media.Brushes.Gray,
                    Margin = new Thickness(0, 10, 0, 10) // Add space before and after the separator
                };
                rtbEventDetails.Document.Blocks.Add(separator);
            });
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Invokes an event to open the home page (Going back)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EventsBackButton?.Invoke(this, EventArgs.Empty);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Clears all text from the rich text body
        /// </summary>
        public void ClearEventsOutput()
        {
            // Clear the RichTextBox content
            rtbEventDetails.Document.Blocks.Clear();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// When text is inputed on the search bar filtering is applied to event data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Get the search string from the TextBox
            string searchString = txtSearch.Text;
            ReportValidation validateSearch = new ReportValidation();

            if (!validateSearch.CheckForNullOrEmptyStrings(searchString))
            {
                // Filter the events based on the search string
                var filteredEvents = eventsClass.FilterEventsBySearchString(searchString);

                ClearEventsOutput();
                // Populate the RichTextBox with the filtered events
                PopulateEvents(filteredEvents);
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Filters event data with the drop down box for categories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected category from the ComboBox
            var selectedCategory = (cmbEventType.SelectedItem as ComboBoxItem)?.Content.ToString();
            ReportValidation validateSearch = new ReportValidation();

            if (!validateSearch.CHeckForNoneCommand(selectedCategory))
            {
                // Filter the events by the selected category
                var filteredEvents = eventsClass.FilterEventsByCategory(selectedCategory);

                // Clear existing event data and populate with filtered events
                ClearEventsOutput();
                PopulateEvents(filteredEvents);
            }
            else
            {
                ClearEventsOutput();
                StartUpPopulateEvents();
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Event data is filtered with selected date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpEventDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected date
            if (dpEventDate.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpEventDate.SelectedDate.Value;

                // Filter the events by the selected date
                var filteredEvents = eventsClass.FilterEventsByDate(selectedDate);

                // Clear existing event data
                ClearEventsOutput();

                // Populate with filtered events
                PopulateEvents(filteredEvents);
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Clears the currently selected date on dpEventDate date picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearDate_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selected date
            dpEventDate.SelectedDate = null;

            // Reset the event list to show all events
            StartUpPopulateEvents();
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//