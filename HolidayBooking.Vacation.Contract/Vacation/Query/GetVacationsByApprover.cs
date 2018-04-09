using System;
using Domain.Queries;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;

namespace HolidayBooking.Vacation.Contract.Vacation.Query
{
    public class GetVacationByApprover:IQuery<ApproverEmployeeVacations>
    {
        public Guid ApproverId { get; private set; }
        public GetVacationByApprover(Guid approverId)
        {
            ApproverId = approverId;
        }
    }
}