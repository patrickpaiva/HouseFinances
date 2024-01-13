using AutoMapper;
using HouseFinances.DTO;
using HouseFinances.Entities;
using HouseFinances.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinances.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<Expense> CreateExpense(CreateExpenseRequestDTO expense)
        {
            Expense newExpense = _mapper.Map<Expense>(expense);

            await _expenseRepository.AddExpenseAsync(newExpense);

            return newExpense;
        }

        public async Task<IEnumerable<Expense>> GetLastExpenses()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }
    }
}
