using System;
using System.Collections.Generic;
using Domain.Queries;

namespace HolidayBooking.Employee.Contract.Employee.Queries
{
     public class EmployeeListItem
    {
        public Guid Id { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
    }

    public class GetEmployees : IQuery<List<EmployeeListItem>>
    {
    }
}