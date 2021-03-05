using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeZoneConversion
{
    class Program
    {
       /// <summary>
       /// main method
       /// </summary>
       /// <param name="args"></param>
        static void Main(string[] args)
        {
            //get current time in utc format
            DateTime currentDateTime = DateTime.UtcNow;

            //read input time zone
            string inputType = "";
            Console.WriteLine("Enter Required Time Zone:");
            inputType = Console.ReadLine();

            //convert input time zone into full string
            string fullTimeZone = ConvertZoneIdToString(inputType.ToLower());

            //convert current time to specified input time zone
            DateTime finalDateTime = default(DateTime);
            if (!fullTimeZone.Equals(""))
                finalDateTime = GetSpecificDateTime(currentDateTime, fullTimeZone);
            else
                Console.WriteLine("Invalid Time zone");

            //display converted date time
            if (!finalDateTime.Equals(default(DateTime)))
                Console.WriteLine("Converted Date Time: " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", finalDateTime));
            Console.ReadLine();
        }

        private static string ConvertZoneIdToString(string inputZone)
        {
            string inputFullZone = "";
            switch (inputZone)
            {
                case "est":
                    inputFullZone = "Eastern Standard Time";
                    break;
                case "cst":
                    inputFullZone = "Central Standard Time";
                    break;
                case "pst":
                    inputFullZone = "Pacific Standard Time";
                    break;
                case "ist":
                    inputFullZone = "India Standard Time";
                    break;
                default:
                    break;
            }
            return inputFullZone;
        } 
        private static DateTime GetSpecificDateTime(DateTime currentDateTime, string inputFullZone)
        {
            DateTime convertedTime = default(DateTime);
            try
            {
                TimeZoneInfo inputZone = TimeZoneInfo.FindSystemTimeZoneById(inputFullZone);
                convertedTime = TimeZoneInfo.ConvertTimeFromUtc(currentDateTime, inputZone);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in conversion: " + ex.Message);
            }

            return convertedTime;
        }
    }

}
