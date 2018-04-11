using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Commands;
using Domain.Queries;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using HolidayBooking.Service.Model;

namespace HolidayBooking.Service.Controllers
{
    [Route("v1/[controller]")]
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
        public async Task AddVacation([FromBody] VacationRequestDto vacationRequestDto)
        {
            CreateVacation command = new CreateVacation(vacationRequestDto.EmployeeId,
                                                       new Vacation.Contract.Vacation.ValueObject.VacationInfo()
                                                       {
                                                           EmployeeId = vacationRequestDto.EmployeeId,
                                                           Start = vacationRequestDto.StartDate,
                                                           End = vacationRequestDto.EndDate,
                                                           Status = Vacation.Contract.Vacation.ValueObject.Status.Pending
                                                       });
                                                       
            await _commandBus.Send(command);

        }

        [HttpPut]
        public async Task UpdateVacation([FromBody] UpdateVacation command)
        {
            await _commandBus.Send(command);
        }
    }//class
}//ns

