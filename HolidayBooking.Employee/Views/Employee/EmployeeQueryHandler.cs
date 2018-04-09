using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Queries;
using HolidayBooking.Employee.Contract.Employee.Queries;
using HolidayBooking.Employee.Domain.Employee;
using HolidayBooking.Employee.Storage;
using Microsoft.EntityFrameworkCore;

namespace HolidayBooking.Employee.Views.Employee
{
    public class EmployeeQueryHandler:
        IQueryHandler<GetEmployees, List<EmployeeListItem>>,
        IQueryHandler<GetEmployee, EmployeeItem>
    {
        private IQueryable<HolidayBooking.Employee.Domain.Employee.Employee> Employees;

        public EmployeeQueryHandler(Storage.EmployeeDbContext dbContext)
        {
            Employees = dbContext.Employees;
        }

        public Task<List<EmployeeListItem>> Handle(GetEmployees query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Employees
                .Select(employee => new EmployeeListItem
                {
                })
                .ToListAsync(cancellationToken);
        }

        public Task<EmployeeItem> Handle(GetEmployee query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Employees
                .Select(employee => new EmployeeItem
                {
                    Id = employee.Id,
                Name = new HolidayBooking.Employee.Contract.Employee.ValueObjects.Name(employee.Name.ChristianName,employee.Name.Surname),
                    Email = employee.Email
                })
                .SingleOrDefaultAsync(employee => employee.Id == query.Id, cancellationToken);
        }
    }
}