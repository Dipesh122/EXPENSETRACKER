using AutoMapper;
using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;

namespace ExpenseTracker.Infrastructure.Mappers
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseViewModel>()
                .ReverseMap();
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();
        }
    }
}