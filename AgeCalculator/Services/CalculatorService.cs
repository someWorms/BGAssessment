using AgeCalculator.Models;
using AgeCalculator.Services.Interfaces;
using System.Runtime.InteropServices;

namespace AgeCalculator.Services
{
    /// <summary>
    /// Calculate service, performing operations with dates.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// Calculates accurate age, including years, months, days, hours, minutes and seconds.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public AgeViewModel CalculateDate(AgeViewModel data)
        {
            int years = 0;
            int months = 0;
            int days = 0;

            DateTime bday = data.Birthday;
            DateTime currentDate = data.CurrDate;

            DateTime tmpBd = new DateTime(bday.Year, bday.Month, 1);
            DateTime tmpCurrentDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            while (tmpBd.AddYears(years).AddMonths(months) < tmpCurrentDate)
            {
                months++;
                if (months >= 12)
                {
                    years++;
                    months = months - 12;
                }
            }

            if (currentDate.Day >= bday.Day)
                days = days + currentDate.Day - bday.Day;

            else
            {
                months--;
                if (months < 0)
                {
                    years--;
                    months = months + 12;
                }
                days = days + (DateTime.DaysInMonth(currentDate.AddMonths(-1).Year, currentDate.AddMonths(-1).Month) + currentDate.Day) - bday.Day;

            }

            //add an extra day if the dob is a leap day
            if (DateTime.IsLeapYear(bday.Year) && bday.Month == 2 && bday.Day == 29)
            {
                //but only if the future date is less than 1st March
                if (currentDate >= new DateTime(currentDate.Year, 3, 1))
                    days++;
            }

            data.Years = years;
            data.Months = months;
            data.Days = days;
            data.Hours = currentDate.Subtract(bday).Hours;
            data.Minutes = currentDate.Subtract(bday).Minutes;
            data.Seconds = currentDate.Subtract(bday).Seconds;

            return data;

        }
    }
}
