namespace HolidayBooking.Service.Model
{
    public class VacationRequestDto
    {
        Guid EmployeeId {get;private set;}
        VacationPeriod Vacation {get;private set;}

        protected EmployeeId()
        {
            
        }
        public VacationPeriod(Guid employeeId, DateTime start, DateTime end)
        {
            this.EmployeeId=employeeId;
            Vacation = new VacationPeriod(start, end);
        }
    }
}