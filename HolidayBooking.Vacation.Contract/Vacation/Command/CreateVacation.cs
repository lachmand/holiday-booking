using System;
using Domain.Commands;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;
namespace HolidayBooking.Vacation.Contract.Vacation.Command
{
    public class CreateVacation : ICommand
    {
        public int EmployeeId { get; set; }
        public VacationInfo Data { get; set; }

        public CreateVacation(int employeeId, VacationInfo data)
        {
            EmployeeId=employeeId;
            Data = data;
        }
    }//class
}//ns