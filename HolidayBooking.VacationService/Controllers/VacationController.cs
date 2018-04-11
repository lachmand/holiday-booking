using System;
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
    [Route("v1/api/vacationHandler/[controller]")]
    public class VacationController : Controller
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationController(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Vacation>> Get()
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
                Id = vacation.EmployeeId.ToString() //todo
            });
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Vacation.Contract.Vacation.ValueObject.VacationInfo value)
        {
            Model.Vacation vacation = new Model.Vacation()
            {

                Id = id,
                EmployeeId = value.EmployeeId,
                VacationPeriod = new Model.VacationPeriod() { StartDate = value.Start, EndDate = value.End },
                Status = Model.Vacation.MapStatus(value.Status),
                ApprovedBy = value.ApprovedBy,
                ChangedOn = DateTime.UtcNow
            };

            _vacationRepository.UpdateVacation(id, vacation);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _vacationRepository.RemoveVacation(id);
        }
    }//class
}//ns
