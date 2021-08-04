using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceMentor1.Server.Storage;
using FinanceMentor1.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinanceMentor1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expenseRepository;

        public ExpensesController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: api/<ExpensesController>
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseRepository.GetAll().OrderBy(expense => expense.Date);
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public Expense Get(Guid id)
        {
            return _expenseRepository.GetAll().Single(item => item.ID == id);
        }

        // POST api/<ExpensesController>
        [HttpPost]
        public void Post(Expense expense)
        {
            _expenseRepository.Add(expense);
        }


        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var entity = _expenseRepository.GetAll().Single(item => item.ID == id);
            _expenseRepository.Remove(entity);
        }
    }
}
