using HouseFinances.DTO;
using HouseFinances.Entities;

namespace HouseFinances.Services
{
    public interface IExpenseService
    {
        Task<Expense> CreateExpense(CreateExpenseRequestDTO expense);
    }
}
