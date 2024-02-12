using HouseFinances.DTO;
using HouseFinances.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinances.Services
{
    public interface IExpenseService
    {
        Task<Expense> CreateExpense(CreateExpenseRequestDTO expense);
        Task<IEnumerable<Expense>> GetLastExpenses();
        Task<IEnumerable<Expense>> GetExpensesInDateRange(DateTime startDate, DateTime endDate, int personId, int expenseTypeId, int carrierId);
    }
}
