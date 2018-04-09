using System;
using Domain.Queries;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;

namespace HolidayBooking.Vacation.Contract.Vacation.Query
{
    public class GetVacationByEmployee : IQuery<EmployeeVacations>
    {
        public Guid EmployeeId { get; private set; }
        public GetVacationByEmployee(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}