using Domain;
using System;
using System.Collections.Generic;
using Domain.Aggregates;

namespace HolidayBooking.Employee.Domain.Employee
{    
    public class Employee : IAggregate
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public String Email { get; set; }
    }
}