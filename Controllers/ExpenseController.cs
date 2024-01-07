using AutoMapper;
using HouseFinances.DTO;
using HouseFinances.Entities;
using HouseFinances.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> CreateExpense([FromBody] CreateExpenseRequestDTO expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdExpense = await _expenseService.CreateExpense(expense);

            return Ok(createdExpense);
        }
    }
}
