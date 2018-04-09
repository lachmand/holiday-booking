using System;
using System.Collections.Generic;
namespace Holidaybooking.Vacation.Domain.Vacation
{
    enum VacationStatus
    {
      Pending,
      Approved,
      Declined,
      AwaitingFurtherDetails      
    }

    public class Vacation
    {
        Guid Id {get;}
        Guid EmployeeId {get;}
        VacationPeriod VacationPeriod{get;}
        VacationStatus Status{get;}
        Guid ApprovedBy {get;}
    }
}