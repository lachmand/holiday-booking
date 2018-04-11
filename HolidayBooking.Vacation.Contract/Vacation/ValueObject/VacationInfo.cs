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
    public class VacationInfo
    {
        public int EmployeeId { get;  set; }
        public DateTime Start { get;  set; }
        public DateTime End { get;  set; }
        public Status Status { get;  set; }
        public int ApprovedBy { get;  set; }
    }
}