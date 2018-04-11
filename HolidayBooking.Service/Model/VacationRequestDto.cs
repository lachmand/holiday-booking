using System;

namespace HolidayBooking.Service.Model
{
    public class VacationRequestDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}