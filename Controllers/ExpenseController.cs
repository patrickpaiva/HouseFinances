using AutoMapper;
using HouseFinances.DTO;
using HouseFinances.Entities;
using HouseFinances.Repositories;
using HouseFinances.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpensesInDateRange(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate,
            [FromQuery] int personId,
            [FromQuery] int expenseTypeId,
            [FromQuery] int carrierId
            )
        {
            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
            {
                return BadRequest("As datas de início e término são obrigatórias.");
            }
            var expenses = await _expenseService.GetExpensesInDateRange(startDate, endDate, personId, expenseTypeId, carrierId);
            return Ok(expenses);
            
        }

        [HttpGet("last")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetLastExpenses()
        {
            return Ok(await _expenseService.GetLastExpenses());
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
