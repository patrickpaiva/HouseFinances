using HouseFinances.Entities;

namespace HouseFinances.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseByIdAsync(int expenseId);
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int expenseId);
    }
}