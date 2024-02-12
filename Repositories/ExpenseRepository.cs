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

        public async Task<IEnumerable<Expense>> GetLastExpensesAsync()
        {
            return await _context.Expenses
                .OrderByDescending(e => e.Date)
                .Take(100)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesInDateRangeAsync(
            DateTime startDate, 
            DateTime endDate, 
            int? personId = null,
            int? expenseTypeId = null,
            int? carrierId = null
            )
        {
            var query = _context.Expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate);

            if (personId.HasValue)
            {
                query = query.Where(e => e.PersonID == personId);
            }
            if (expenseTypeId.HasValue)
            {
                query = query.Where(e => e.ExpenseTypeID == expenseTypeId);
            }
            if (carrierId.HasValue)
            {
                query = query.Where(e => e.CarrierID == carrierId);
            }

            return await query.ToListAsync();
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
