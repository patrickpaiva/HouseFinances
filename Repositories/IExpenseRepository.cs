using HouseFinances.Entities;

namespace HouseFinances.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseByIdAsync(int expenseId);
        Task<IEnumerable<Expense>> GetLastExpensesAsync();
        Task<IEnumerable<Expense>> GetExpensesInDateRangeAsync(DateTime startDate, DateTime endDate, int? personId, int? expenseTypeId, int? carrierId);
        Task AddExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int expenseId);
    }
}