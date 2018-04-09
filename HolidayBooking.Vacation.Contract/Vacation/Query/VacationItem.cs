using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;

namespace HolidayBooking.Vacation.Contract.Vacation.Query
{
    public class VacationItem
    {
        Guid Id { get; set; }
        VacationInfo Data { get; set; }
    }//class
}//ns