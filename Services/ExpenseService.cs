using AutoMapper;
using HouseFinances.DTO;
using HouseFinances.Entities;

namespace HouseFinances.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;

        public ExpenseService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<Expense> CreateExpense(CreateExpenseRequestDTO expense)
        {
            Expense newExpense = _mapper.Map<Expense>(expense);
            return Task.FromResult(newExpense);
        }
    }
}
