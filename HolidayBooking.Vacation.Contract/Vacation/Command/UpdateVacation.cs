using System;
using Domain.Commands;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;
namespace HolidayBooking.Vacation.Contract.Vacation.Command
{
    public class UpdateVacation : ICommand
    {
        public Guid? Id { get; }
        public VacationInfo Data { get; }

        public UpdateVacation(Guid id, VacationInfo data)
        {
            Id = id;
            Data = data;
        }
    }//class
}//ns