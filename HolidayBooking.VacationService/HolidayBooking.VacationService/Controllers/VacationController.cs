﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching;
using HolidayBooking.Vacation.Contract.Vacation.Event;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using HolidayBooking.Vacation.Contract.Vacation.Query;

namespace HolidayBooking.VacationService.Controllers
{
    [Route("api/[controller]")]
    public class VacationController : Controller
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationController(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Note>> Get()
        {
            return await _vacationRepository.GetAllVacations();
        }

        [HttpGet("{id}")]
        public async Task<Model.Vacation> Get(string id)
        {
            return await _vacationRepository.GetVacation(id) ?? new Model.Vacation();
        }

        [HttpPost]
        public void Post([FromBody] Vacation.Contract.Vacation.Command.CreateVacation vacation)
        {
            _vacationRepository.AddVacation(new Model.Vacation
            {
                Id = vacation.Id.ToString() //todo
            });
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Vacation.Contract.Vacation.ValueObject.VacationInfo value)
        {
            _vacationRepository.UpdateVacation(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _vacationRepository.RemoveVacation(id);
        }
    }//class
}//ns