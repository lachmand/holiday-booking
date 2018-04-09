using System;
namespace HolidayBooking.Employee.Contract.Employee.ValueObjects
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
    }
}