using AutoMapper;
using BookOfHabits.Requests.Person;
using BookOfHabits.Responses.Person;
using BookOfHabitsMicroservice.Application.Models.Person;
using BookOfHabitsMicroservice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping() 
        {
            CreateMap<Person, PersonModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
        }
    }
}
