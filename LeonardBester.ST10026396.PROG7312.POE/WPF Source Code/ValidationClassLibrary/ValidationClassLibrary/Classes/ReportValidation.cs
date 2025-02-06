using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValidationClassLibrary
{
    public class ReportValidation
    {
        //==========================================================================================//
        /// <summary>
        /// Default constructor of ReportValidation Class
        /// </summary>
        public ReportValidation()
        {

        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Checks for empty space or null in a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckForNullOrEmptyStrings(String input)
        {
            bool result = false;
            String checkedInput = input;
            if (string.IsNullOrWhiteSpace(checkedInput))
            {
                result = true;
            }
            return result;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Checks for empty bytes
        /// </summary>
        /// <param name="attachement"></param>
        /// <returns></returns>
        public bool CheckForNullByte(byte[] attachement)
        {
            byte[] checkedByte = attachement;
            bool result = false;

            if (checkedByte == null || checkedByte.Length == 0)
            {
                result = true;
            }
            return result;
        }
        //==========================================================================================//


        //==========================================================================================//
        /// <summary>
        /// Checks the string to be equal to "None"
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool CHeckForNoneCommand(String command)
        {
            bool result = false;

            if (command.Equals("None"))
                result = true;

            return result;
        }
        //==========================================================================================//
    }
}
//========================================== END OF FILE ================================================//
//========================================== See you next time ================================================//