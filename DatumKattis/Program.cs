using System;

namespace DatumKattis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datum Kattis
            // https://open.kattis.com/problems/datum 
            // return day name during year 2009 
            // ----------------------------------------------------
            
            var myDatum = EnterDatumLine();

            Console.WriteLine(GiveDayName(DayOrderInTheYear(myDatum)));
        }

        private static string GiveDayName(int dayOrder)
        {
            int temp = dayOrder % 7;
            switch (temp)
            {
                case 1:
                    return "Thursday";
                case 2:
                    return "Friday";
                case 3:
                    return "Saturday";
                case 4:
                    return "Sunday";
                case 5:
                    return "Monday";
                case 6:
                    return "Tuesday";
                case 0:
                default:
                    return "Wednesday";
            }
        }
        private static int DayOrderInTheYear(int[] yourDatum)
        {
            // year 2009
            int day = yourDatum[0];
            int month = yourDatum[1];

            int temp = GiveAllDays(month - 1);
            int result = temp + day;
            return result;
        }
        private static int GiveAllDays(int MonthOrder)
        {
            // give all days till this month
            int sum = 0;
            for (int j = 1; j <= MonthOrder; j++)
            {
                if (j < 8)
                {
                    if (j == 2)
                        sum = sum + 28;

                    else if (j % 2 == 0) // even
                        sum = sum + 30;

                    else // odd
                        sum = sum + 31;
                }
                else if (j >= 8)
                {
                    if (j % 2 == 0) // even
                        sum = sum + 31;

                    else // odd
                        sum = sum + 30;
                }
            }
            return sum;
        }
        private static int[] EnterDatumLine()
        {
            var arr = new string[2];
            var res = new int[2];
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int k = 0; k < arr.Length; k++)
                {
                    res[k] = int.Parse(arr[k]);
                }
                if (DatumFirstCondition(res) == false)
                    throw new ArgumentException();
                if (DatumSecondCondition(res) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterDatumLine();
            }
            return res;
        }
        private static bool DatumFirstCondition(int[] yourDatum)
        {
            int day = yourDatum[0];
            int month = yourDatum[1];
            if (day <= 0 || day > 31)
                return false;
            else if (month <= 0 || month > 12)
                return false;
            else return true;
        }
        private static bool DatumSecondCondition(int[] yourDatum)
        {
            int day = yourDatum[0];
            int month = yourDatum[1];

            if (month ==2  && day > 28)
                return false;
            else if (month == 4 && day > 30)
                return false;
            else if (month == 6 && day > 30)
                return false;
            //.....................................
            else if (month == 9 && day > 30)
                return false;
            else if (month == 11 && day > 30)
                return false;

            else return true;
        }
    }
}
