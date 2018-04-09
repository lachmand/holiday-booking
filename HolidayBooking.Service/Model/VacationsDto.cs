namespace HolidayBooking.Service.Model
{
    public class VacationsDto
    {
        Guid EmployeeId {get;}
        IEnumerable<VacationPeriod> Vacations {get;}
    }
}