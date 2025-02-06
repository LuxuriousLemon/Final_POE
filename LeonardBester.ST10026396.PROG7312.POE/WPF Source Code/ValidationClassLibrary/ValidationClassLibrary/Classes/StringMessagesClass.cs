using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationClassLibrary
{
    public class StringMessagesClass
    {
        // String messages for input errors on Report page
        private String LocationErrorMessage = "Location field cannot be empty.";
        private String CategoryErrorMessage = "Category field cannot be empty.";
        private String DescriptionErrorMessage = "Description field cannot be empty.";
        private String AttachementErrorMessage = "No image file selected or the selected image is empty.";

        // String message for successful entry of a report
        private String ReportAddedSuccesfully = " Your report has been documented. Thank you.";


        //==========================================================================================//
        /// <summary>
        /// Returns the String for a successful report
        /// </summary>
        /// <returns></returns>
        public String GetReportAddedSuccesfully()
        {
            return ReportAddedSuccesfully;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Returns the string for a location input error
        /// </summary>
        /// <returns></returns>
        public String GetLocationErrorMessage()
        {
            return LocationErrorMessage;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// eturns the string for a category input error
        /// </summary>
        /// <returns></returns>
        public String GetCategoryErrorMessage()
        {
            return CategoryErrorMessage;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// eturns the string for a description input error
        /// </summary>
        /// <returns></returns>
        public String GetDescriptionErrorMessage()
        {
            return DescriptionErrorMessage;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// eturns the string for an attachement input error
        /// </summary>
        /// <returns></returns>
        public String GetAttachementErrorMessage()
        {
            return AttachementErrorMessage;
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//