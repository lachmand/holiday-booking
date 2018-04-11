using Domain.Aggregates;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;
using System;

namespace Holidaybooking.Vacation.Domain.Vacation
{
    public enum VacationStatus
    {
      Pending,
      Approved,
      Declined,
      AwaitingFurtherDetails      
    }

    public class Vacation
    {
        Guid Id { get; set; }
        int EmployeeId { get; set; }
        VacationPeriod VacationPeriod { get; set; }
        VacationStatus Status { get; set; }
        int ApprovedBy { get; set; }

        public Vacation()
        {

        }

        public Vacation(Guid id, int employeeId, VacationPeriod vacationPeriod, VacationStatus status, int approvedBy)
        {
            Id = id;
            EmployeeId = employeeId;
            VacationPeriod = vacationPeriod;
            Status = status;
            ApprovedBy = approvedBy;

        }

        public void Update(VacationInfo vacationInfo)
        {
            
            Status = MapStatus(vacationInfo.Status);
            VacationPeriod = new VacationPeriod(vacationInfo.Start, vacationInfo.End);
            ApprovedBy = vacationInfo.ApprovedBy;
        }

        public static VacationStatus MapStatus(HolidayBooking.Vacation.Contract.Vacation.ValueObject.Status status)
        {
            VacationStatus returnStatus= VacationStatus.Pending;

            switch (status)
            {                
                case HolidayBooking.Vacation.Contract.Vacation.ValueObject.Status.Approved:
                    returnStatus = VacationStatus.Approved;
                    break;
                                   
                case HolidayBooking.Vacation.Contract.Vacation.ValueObject.Status.AwaitingFurtherDetails:
                    returnStatus = VacationStatus.AwaitingFurtherDetails;
                    break;
                case HolidayBooking.Vacation.Contract.Vacation.ValueObject.Status.Declined:
                    returnStatus = VacationStatus.Declined;
                    break;
                default:
                    returnStatus = VacationStatus.Pending;
                    break;
            }
            return returnStatus;
        }
    }
}