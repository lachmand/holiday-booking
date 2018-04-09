using System;
using System.Collections.Generic;
namespace HolidayBooking.Vacation.Contract.Vacation.ValueObject
{
    public enum Status
    {
      Pending,
      Approved,
      Declined,
      AwaitingFurtherDetails      
    }
    public class VacationDto
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public Status Status { get; private set; }
        public Guid ApprovedBy { get; private set; }
    }
}