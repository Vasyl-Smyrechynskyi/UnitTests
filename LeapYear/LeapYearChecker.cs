using System;

namespace TDD
{
    internal class LeapYearChecker
    {
        public bool CheckIfLeapYear(string stringYear)
        {
            var year = Int64.Parse(stringYear);

            return year % 4 == 0 && (!(year % 100 == 0) || year % 400 == 0);
        }
    }
}