using AutoMapper;
using BookOfHabits.Requests.Person;
using BookOfHabits.Responses.Person;
using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabits.Mapping
{
    public class PersonMapping:Profile
    {
        public PersonMapping() 
        {
            CreateMap<CreatePersonRequest, CreatePersonModel>();
            CreateMap<UpdatePersonRequest, UpdatePersonModel>();
            CreateMap<PersonModel, PersonShortResponse>();
            CreateMap<PersonModel, PersonDetailedResponse>();
        }
    }
}
