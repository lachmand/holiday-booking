using Domain.Commands;
using System;
using HolidayBooking.Employee.Contract.Employee.ValueObjects;
namespace HolidayBooking.Employee.Contract.Employee.Commands
{
public class CreateEmployee : ICommand
    {
        public Guid? Id { get; }
        public EmployeeDto Data { get; }

        public CreateEmployee(Guid id, EmployeeDto data)
        {
            Id = id;
            Data = data;
        }
    }
}