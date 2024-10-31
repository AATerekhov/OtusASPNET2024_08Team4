using AutoMapper;
using BookOfHabits.Requests.Cains;
using BookOfHabits.Responses.Coins;
using BookOfHabitsMicroservice.Application.Models.Coins;

namespace BookOfHabits.Mapping
{
    public class CoinsMapping:Profile
    {
        public CoinsMapping()
        {
            CreateMap<CreateCoinsRequest, CreateCoinsModel>();
            CreateMap<UpdateCoinsRequest, CoinsModel>();
            CreateMap<CoinsModel, CoinsShortResponse>();
            CreateMap<CoinsModel, CoinsDetailedResponse>();
        }
    }
}
