using System;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1.Utils
{
    class ConvertingString
    {
        public static int StringToInt(string input)
        {

            int enteredNumber;
            bool resultParse = int.TryParse(input, out enteredNumber);

            if (resultParse)
            {
                return enteredNumber;
            }
            else
            {
                Console.WriteLine("Invalid value for int!");
                return 0;
            }
        }

        public static DateTime StringToDateTime(string inputDate)
        {
            DateTime enteredDate;
            bool resultParse = DateTime.TryParse(inputDate, out enteredDate);

            if (resultParse)
            {
                return enteredDate;
            }
            else
            {
                Console.WriteLine("Invalid value for DateTime!");
                return DateTime.Today;
            }
        }

        public static bool StringToBoolean(string inputBool)
        {
            bool enteredBool;
            bool resultParse = bool.TryParse(inputBool, out enteredBool);

            if (resultParse)
            {
                return enteredBool;
            }
            else
            {
                Console.WriteLine("Invalid value for bool value!");
                return false;
            }
        }
    }
}
