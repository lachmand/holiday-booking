using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HolidayBooking.Service.Controllers
{
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
        public IEnumerable<EmployeeItem> Get()
        {
            return new List(){New EmployeeItem(), New EmployeeItem()}; 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public EmployeeItem Get(int id)
        {
            return new EmployeeItem();
        }
    }
}