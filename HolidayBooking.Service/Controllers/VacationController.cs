using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolidayBooking.Service.Employee.Domain;

namespace HolidayBooking.Service.Controllers
{
    [Route("api/[controller]/{id}")]
    public class VacationController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public VacationController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        //Request a vacation
        [HttpPost]
        public void Post([FromBody]VacationRequestDto value)
        {
        }


        [HttpGet]
        public Task<List<VacationListItem>> Get()
        {
            return _queryBus.Send<GetClients, List<ClientListItem>>(new GetClients());
        }


        [HttpGet("{id}")]
        public Task<ClientItem> Get(Guid id)
        {
            return _queryBus.Send<GetClient, ClientItem>(new GetClient(id));
        }

        [HttpGet]
        public VacationRequestDto Get(Guid employeeId)
        {
            return _queryBus.Send<GetAccount, AccountSummary>(new GetAccount(accountId));        }
        }
}
