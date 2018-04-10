using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Commands;
using Domain.Queries;
using HolidayBooking.Vacation.Contract.Vacation.Command;

namespace HolidayBooking.Service.Controllers
{
    [Route("v1/[controller]/{id}")]
    public class VacationsController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public VacationsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }


        [HttpPost]
        public async Task AddVacation([FromBody] CreateVacation command)
        {
            await _commandBus.Send(command);
        }

        [HttpPut]
        public async Task UpdateVacation([FromBody] UpdateVacation command)
        {
            await _commandBus.Send(command);
        }
    }//class
}//ns

