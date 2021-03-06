using Domain.Events;
using System;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;

namespace HolidayBooking.Vacation.Contract.Vacation.Event
{
    public class VacationCreated : IEvent
    {
        public Guid Id { get; }
        public VacationInfo Data { get; }

        public VacationCreated( VacationInfo data)
        {
            Id = Guid.NewGuid();
            Data = data;
        }
    }
}