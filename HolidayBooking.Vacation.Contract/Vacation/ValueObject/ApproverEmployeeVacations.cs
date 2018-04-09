using System;
using System.Collections.Generic;
namespace HolidayBooking.Vacation.Contract.Vacation.ValueObject
{
    public class ApproverEmployeeVacations
    {
        public Guid ApproverId { get; set; }
        public IEnumerable<VacationInfo> Vacations { get; set; }
    }
}