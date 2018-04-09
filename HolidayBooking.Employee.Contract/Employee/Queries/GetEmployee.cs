using System;
using Domain.Queries;
using HolidayBooking.Employee.Contract.Employee.ValueObjects;

namespace HolidayBooking.Employee.Contract.Employee.Queries
{
     public class EmployeeItem
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public string Email { get; set; }
    }

    public class GetEmployee : IQuery<EmployeeItem>
    {
        public Guid Id { get; }

        public GetEmployee(Guid id)
        {
            Id = id;
        }
    }
}