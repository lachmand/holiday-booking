using System;
namespace Holidaybooking.Vacation.Domain.Vacation
{
    public class VacationPeriod
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        protected VacationPeriod(){}

        public VacationPeriod(DateTime start, DateTime end)
        {
            Start=start;
            End=end;
        }
    }
}