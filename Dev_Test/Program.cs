using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sbOutDate = new StringBuilder(); // for building the output string

            int iDaysAdded = 0; // contains the number of days to add to the date
            int iMonth = 0;
            int iDay = 0;
            int iYear = 0;
            int iNewDate = 0;

            Console.WriteLine(" Enter a date using this format: \"dd/mm/yyyy\". \r\n");
            
            try
            {
                // get date from user
                string sInput = Console.ReadLine();
                string[] sParts = sInput.Split('/'); // extract the day, month and year         
               
                // basic field validation
                if (sParts.Count() != 3 || sParts[0].Length != 2 || sParts[1].Length != 2 || sParts[2].Length != 4)
                    throw new Exception();

                // get each part of the input date
                iDay = Convert.ToInt32(sParts[0].Trim()); // dd
                iMonth = Convert.ToInt32(sParts[1].Trim()); // mm
                iYear = Convert.ToInt32(sParts[2].Trim()); // yyyy

                // range validation
                if (iDay < 1 || iDay > 31 || iMonth < 1 || iMonth > 12 || iYear < 1 || iYear > 9999)
                    throw new Exception();

                Console.WriteLine(" Add any number of days to this date. \r\n");

                // get the number of days to add... 
                iDaysAdded = Convert.ToInt32(Console.ReadLine());          

                // Find the number of days in the entered month (and check if a leap year)

                int iDaysInMonth = 0;
                switch (iMonth)
                {
                    case 1:
                        iDaysInMonth = 31;
                        break;
                    case 2:
                        if (IsLeapYear(iYear))
                            iDaysInMonth = 29;
                        else
                            iDaysInMonth = 28;
                        break;
                    case 3:
                        iDaysInMonth = 31;
                        break;
                    case 4:
                        iDaysInMonth = 30;
                        break;
                    case 5:
                        iDaysInMonth = 31;
                        break;
                    case 6:
                        iDaysInMonth = 30;
                        break;
                    case 7:
                        iDaysInMonth = 31;
                        break;
                    case 8:
                        iDaysInMonth = 31;
                        break;
                    case 9:
                        iDaysInMonth = 30;
                        break;
                    case 10:
                        iDaysInMonth = 31;
                        break;
                    case 11:
                        iDaysInMonth = 30;
                        break;
                    case 12:
                        iDaysInMonth = 31;
                        break;  
                }

                // The number of days added goes over to the next month
                if ((iDay + iDaysAdded) > iDaysInMonth)
                {
                    if (iMonth == 12) // reset to January if passed end of year
                    {
                        iMonth = 1;
                        iYear++;

                        iNewDate = (iDay + iDaysAdded) - iDaysInMonth;
                    }                     
                    else
                    {
                        iNewDate = (iDay + iDaysAdded) - iDaysInMonth;
                        iMonth++;
                    }                  
                }
                else if ((iDay + iDaysAdded) <= iDaysInMonth) // still within the same month
                {
                    iNewDate = iDay + iDaysAdded;
                }

                sbOutDate.Append(iNewDate.ToString("D2") + "/");
                sbOutDate.Append(iMonth.ToString("D2") + "/");
                sbOutDate.Append(iYear.ToString());

                // final output...
                Console.WriteLine(" New Date: {0:dd/MM/yyyy}", sbOutDate);

                // pause to show console
                Console.ReadKey();
            }
            catch(Exception excep)
            {
                Console.WriteLine(" Error: One or more inputs was not in the correct format " + excep.Message);
                Console.ReadKey();
                return;
            }            
        }

        /// <summary>
        /// Returns true, if the provided year is a leap year, otherwise returns false.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeapYear(int year)
        {
            if (year < 1 || year > 9999)            
                throw new ArgumentOutOfRangeException("year");
                       
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
