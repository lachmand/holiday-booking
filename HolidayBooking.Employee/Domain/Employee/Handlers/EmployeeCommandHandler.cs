using MediatR;
using System.Threading.Tasks;
using HolidayBooking.Employee.Contract.Employee.Commands;
using Domain.Commands;
using System.Threading;

namespace HolidayBooking.Employee.Domain.Employees.Handlers
{
    public class EmployeeCommandHandler :
        ICommandHandler<CreateEmployee>
    {
        public Task Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}