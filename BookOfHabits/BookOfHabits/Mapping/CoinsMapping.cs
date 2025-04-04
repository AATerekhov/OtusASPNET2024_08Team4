using AutoMapper;
using BookOfHabits.Requests.Cains;
using BookOfHabits.Responses.Coins;
using BookOfHabitsMicroservice.Application.Models.Coins;
using System.Xml.Linq;

namespace BookOfHabits.Mapping
{
    public class CoinsMapping:Profile
    {
        public CoinsMapping()
        {
            
            CreateMap<UpdateCoinsRequest, UpdateCoinsModel>();
            CreateMap<ChooseHabitRequest, ChooseHabitModel>();
            CreateMap<CoinsModel, CoinsShortResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Habit.Name));
            CreateMap<CoinsModel, CoinsDetailedResponse>();
        }
    }
}
