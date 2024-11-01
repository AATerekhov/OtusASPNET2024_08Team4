using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Domain.Entity;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Mapping
{
    public class CoinsMapping : Profile
    {
        public CoinsMapping()
        {
            CreateMap<Coins, CoinsModel>();                
        }
    }
}
