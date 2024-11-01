using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Person;
using BookOfHabitsMicroservice.Domain.Entity;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping() 
        {
            CreateMap<Person, PersonModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
        }
    }
}
