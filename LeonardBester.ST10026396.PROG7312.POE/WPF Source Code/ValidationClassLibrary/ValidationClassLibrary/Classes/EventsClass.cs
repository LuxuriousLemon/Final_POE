using System;
using System.Collections.Generic;
using System.IO;

namespace ValidationClassLibrary
{
    public class EventsClass
    {
        // A HashSet to store unique event dates
        private HashSet<DateTime> eventDates;


        //==========================================================================================//
        /// <summary>
        /// Default constructor
        /// </summary>
        public EventsClass()
        {
            eventDates = new HashSet<DateTime>();
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Reading text file data structures 
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, Dictionary<string, string>> ExtractEventsData()
        {
            // Construct the relative path to the EventsData.txt file
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "EventsData.txt");

            var eventsData = new SortedDictionary<string, Dictionary<string, string>>();

            if (File.Exists(filePath))
            {
                var lines = ReadFileLines(filePath);
                eventsData = ParseEventLines(lines);
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return eventsData;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Reading all lines in the text file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string[] ReadFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Parses the event lines into a sorted dictionary of event data
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private SortedDictionary<string, Dictionary<string, string>> ParseEventLines(string[] lines)
        {
            var eventsData = new SortedDictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> currentEvent = null;
            var fieldNamesQueue = GetFieldNamesQueue();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) // End of an event entry
                {
                    AddEventToDictionary(eventsData, currentEvent);
                    currentEvent = null;
                }
                else
                {
                    currentEvent = ProcessEventLine(line, currentEvent, fieldNamesQueue);
                }
            }

            // Handle the last event in the file if no blank line at the end
            AddEventToDictionary(eventsData, currentEvent);

            return eventsData;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Processes a single line and adds the field-value pair to the current event dictionary
        /// </summary>
        /// <param name="line"></param>
        /// <param name="currentEvent"></param>
        /// <param name="fieldNamesQueue"></param>
        /// <returns></returns>
        private Dictionary<string, string> ProcessEventLine(string line, Dictionary<string, string> currentEvent, Queue<string> fieldNamesQueue)
        {
            string[] splitLine = line.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

            if (splitLine.Length == 2)
            {
                string field = splitLine[0];
                string value = splitLine[1];

                if (currentEvent == null)
                {
                    currentEvent = new Dictionary<string, string>();
                }

                if (fieldNamesQueue.Contains(field)) // Validate field
                {
                    currentEvent[field] = value;

                    // If the field is Date, try parsing and add it to the set of dates
                    if (field == "Date" && DateTime.TryParse(value, out DateTime eventDate))
                    {
                        eventDates.Add(eventDate);  // Add to HashSet of dates
                    }
                }
            }

            return currentEvent;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Ammends a complete event to the Datastructers
        /// </summary>
        /// <param name="eventsData"></param>
        /// <param name="currentEvent"></param>
        private void AddEventToDictionary(SortedDictionary<string, Dictionary<string, string>> eventsData, Dictionary<string, string> currentEvent)
        {
            if (currentEvent != null && currentEvent.ContainsKey("Name"))
            {
                eventsData[currentEvent["Name"]] = new Dictionary<string, string>(currentEvent);
            }
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Returns a queue of data field names
        /// </summary>
        /// <returns></returns>
        private Queue<string> GetFieldNamesQueue()
        {
            return new Queue<string>(new[] { "Name", "Description", "Category", "Type", "Date" });
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Filters the events by date
        /// </summary>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public SortedDictionary<string, Dictionary<string, string>> FilterEventsByDate(DateTime filterDate)
        {
            var allEvents = ExtractEventsData();
            var filteredEvents = new SortedDictionary<string, Dictionary<string, string>>();

            foreach (var eventEntry in allEvents)
            {
                if (eventEntry.Value.TryGetValue("Date", out string eventDateString) &&
                    DateTime.TryParse(eventDateString, out DateTime eventDate))
                {
                    if (eventDate.Date == filterDate.Date) // Compare only the date part
                    {
                        filteredEvents.Add(eventEntry.Key, eventEntry.Value);
                    }
                }
            }

            return filteredEvents;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Gets all unique dates
        /// </summary>
        /// <returns></returns>
        public HashSet<DateTime> GetAllEventDates()
        {
            return eventDates;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Filters events by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public SortedDictionary<string, Dictionary<string, string>> FilterEventsByCategory(string category)
        {
            var allEvents = ExtractEventsData();
            var filteredEvents = new SortedDictionary<string, Dictionary<string, string>>();

            foreach (var eventEntry in allEvents)
            {
                if (eventEntry.Value.TryGetValue("Category", out string eventCategory))
                {
                    if (string.Equals(eventCategory, category, StringComparison.OrdinalIgnoreCase)) // Case-insensitive comparison
                    {
                        filteredEvents.Add(eventEntry.Key, eventEntry.Value);
                    }
                }
            }

            return filteredEvents;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Filters events by Description and titles against user input
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public SortedDictionary<string, Dictionary<string, string>> FilterEventsBySearchString(string searchString)
        {
            var allEvents = ExtractEventsData();
            var filteredEvents = new SortedDictionary<string, Dictionary<string, string>>();

            // Normalize the search string for case-insensitive comparison
            string normalizedSearchString = searchString.ToLower();

            foreach (var eventEntry in allEvents)
            {
                // Check Name
                if (eventEntry.Value.TryGetValue("Name", out string eventName) &&
                    eventName.ToLower().Contains(normalizedSearchString))
                {
                    filteredEvents.Add(eventEntry.Key, eventEntry.Value);
                    continue; // Add the event and continue to the next one
                }

                // Check Description
                if (eventEntry.Value.TryGetValue("Description", out string eventDescription) &&
                    eventDescription.ToLower().Contains(normalizedSearchString))
                {
                    filteredEvents.Add(eventEntry.Key, eventEntry.Value);
                }
            }

            return filteredEvents;
        }
        //==========================================================================================//
    }
}
//==========================================================================================//
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//