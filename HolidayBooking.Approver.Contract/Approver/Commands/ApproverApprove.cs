using Domain.Commands;
using System;
using HolidayBooking.Vacation.Domain;
using HolidayBooking.Vacation.Contract.Vacation.ValueObjects;

namespace HolidayBooking.Approver.Contract.Approver.Commands
{
    public class ApproveVacation:ICommand
    {
        public Guid? VacationId { get; }
        public Guid? ApprovedBy{get;}
        public Status Status{get;}
        public ApproveVacation(Guid vacationId, Guid approvedBy, Status status)
        {
            VacationId = vacationId;
            ApprovedBy=approvedBy;
            Status=status;
        }
    }
}