using Domain;
using System;
using System.Collections.Generic;
using Domain.Aggregates;

namespace HolidayBooking.Employee.Domain.Employee
{    
    public class Employee : IAggregate
    {
         public Guid Id { get; }
         public Name Name {get;}
         public String Email {get;}
    }
}