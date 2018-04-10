using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolidayBooking.Employee.Contract.Employee.Commands;
using HolidayBooking.Employee.Contract.Employee.Queries;
using Domain.Commands;
using Domain.Queries;

namespace HolidayBooking.Service.Controllers
{
    [Route("v1/[controller]/{id}")]
    public class EmployeeController:Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public EmployeeController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet]
        public Task<EmployeeItem> Get(Guid id)
        {
            return _queryBus.Send<GetEmployee, EmployeeItem>(new GetEmployee(id));
        }
    }
}