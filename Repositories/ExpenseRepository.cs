using HouseFinances.Data;
using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseFinances.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Expense> GetExpenseByIdAsync(int expenseId)
        {
            return await _context.Expenses.FindAsync(expenseId);
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
            var expense = await _context.Expenses.FindAsync(expenseId);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}
