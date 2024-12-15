using AutoMapper;
using Broadcaster.Application.Models.Base;
using Broadcaster.Application.Models.HabitNotification;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.ValueObject;

namespace Broadcaster.Application.Services.Implementations.Mapping
{
    public class HabitNotificationMapping : Profile
    {
        public HabitNotificationMapping()
        {
            CreateMap<NotificationMessage, NotificationMessageModel>();
            CreateMap<HabitNotifucationMongo, HabitNotificationModel>()
                .ForMember(dest => dest.ObjectId, opt => opt.MapFrom(src => src.ObjectId))
                .ForMember(dest => dest.NotificationMessage, opt => opt.MapFrom(src => src.Object.NotificationMessage))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Object.Id))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.Object.IsDeleted))
                .ForMember(dest => dest.Beforehand, opt => opt.MapFrom(src => src.Object.Beforehand))
                .ForMember(dest => dest.FinishHabit, opt => opt.MapFrom(src => src.Object.FinishHabit));
        }
    }
}
