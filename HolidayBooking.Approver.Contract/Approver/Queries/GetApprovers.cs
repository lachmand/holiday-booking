using Domain.Queries;
using System;
namespace HolidayBooking.Approver.Contract.Approver.Queries
{
 public class ApproverItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class GetApprover : IQuery<ApproverItem>
    {
        public Guid Id { get; }

        public GetApprover(Guid id)
        {
            Id = id;
        }

    }}