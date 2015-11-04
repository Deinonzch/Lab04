using System;

namespace UamTTA
{
    public class BudgetFactory
    {
        public Budget CreateBudget(BudgetTemplate template, DateTime startDate)
        {
            DateTime endDate = default(DateTime);
            switch (template.DefaultDuration)
            {
                case Duration.Weekly:
                    endDate = AddWeek(startDate);
                    break;

                case Duration.Monthly:
                    endDate = AddMonth(startDate);
                    break;

                case Duration.Quarterly:
                    endDate = AddQuarterly(startDate);
                    break;

                case Duration.Yearly:
                    endDate = AddYearly(startDate);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Budget(startDate, endDate);
        }

        private static DateTime AddWeek(DateTime startDate)
        {
            return startDate.AddDays(6);
        }

        private static DateTime AddMonth(DateTime startDate)
        {
            DateTime endDate = startDate.AddMonths(1);
            int daysInStartDate = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            int daysInNextMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month);
            if (daysInNextMonth >= 30 && (endDate.Day < daysInNextMonth || daysInNextMonth == daysInStartDate))
                endDate = endDate.AddDays(-1);
            return endDate;
        }

        private static DateTime AddQuarterly(DateTime startDate)
        {
            DateTime endDate = startDate.AddMonths(2);
            int daysInSecondMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month);
            endDate = endDate.AddDays(daysInSecondMonth - 1);
            return endDate;
        }

        private static DateTime AddYearly(DateTime startDate)
        {
            DateTime endDate = startDate;
            if ((((startDate.Year % 4 == 0 && startDate.Year % 100 != 0) || startDate.Year % 400 == 0) && startDate.Month <= 2) || ((((startDate.Year + 1) % 4 == 0 && (startDate.Year + 1) % 100 != 0) || (startDate.Year + 1) % 400 == 0)) && startDate.Month >= 3)
                endDate = endDate.AddDays(365);
            else
                endDate = endDate.AddDays(364);
            return endDate;
        }
    }
}