using System;
using System.Collections.Generic;
namespace HolidayBooking.Vacation.Contract.Vacation.ValueObject
{
    public class EmployeeVacations
    {
        public Guid EmployeeId { get; set; }
        public IEnumerable<VacationDto> Vacations { get; }
    }
}