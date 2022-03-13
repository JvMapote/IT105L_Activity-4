using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapote_Activity4_C11_IT105L
{
    internal class UnitClass
    {
        public string[] Username { get { return username; } set { username = value; } }
        private string[] username = new string[2];

        public string[] Birthmonth { get { return birthmonth; } set { birthmonth = value; } }
        private string[] birthmonth = new string[3];

        public string[] Results { get { return results; } set { results = value; } }
        private string[] results = new string[5];

        public string yearlevel(int unit)
        {
            string CurrentyearLevel = string.Empty;

            if (unit > 200 && unit <= 250)
            {
                CurrentyearLevel = "First Year";
            }
            else if (unit > 150 && unit <= 200)
            {
                CurrentyearLevel = "Second Year";
            }
            else if (unit > 100 && unit <= 150)
            {
                CurrentyearLevel = "Third Year";
            }
            else if (unit > 50 && unit <= 100)
            {
                CurrentyearLevel = "Fourth Year";
            }
            else if (unit <= 50)
            {
                CurrentyearLevel = "Fifth Year";
            }
            return CurrentyearLevel;
        }

        public UnitClass(string[] name, string[] mon, int[] Units)
        {
            birthmonth = mon;
            username = name;
            birthmonth[0] = Birthdate(Convert.ToInt32(mon[0]));
            DateTime bday;
            if (!DateTime.TryParse(results[2], out bday)) { }
            DateTime today = DateTime.Today;
            int age = today.Year - Convert.ToInt32(birthmonth[2]);
            if (bday > today.AddYears(-age)) age--;

            results[0] = ($"{username[0]} {username[1]} {username[2]}");
            results[1] = ($"{username[0]} {username[2]}");
            results[2] = ($"{birthmonth[0]} {birthmonth[1]} {birthmonth[2]}");
            results[3] = ($"{age}");
            results[4] = ($"{yearlevel(Units[1])}");
        }
        public string Birthdate(int mon)
        {
            String birthmonth = CultureInfo.CurrentCulture.
                DateTimeFormat.GetMonthName
                (mon);
            return birthmonth;
        }
    }
}
