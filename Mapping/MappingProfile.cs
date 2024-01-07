using AutoMapper;
using HouseFinances.DTO;
using HouseFinances.Entities;

namespace HouseFinances.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateExpenseRequestDTO, Expense>();
        }
    }
}
