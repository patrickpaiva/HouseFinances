using HouseFinances.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return Ok();
        }
    }
}
