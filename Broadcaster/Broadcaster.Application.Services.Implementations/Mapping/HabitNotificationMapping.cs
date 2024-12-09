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
            CreateMap<HabitNotifucationMongo, HabitNotificationModel>();
        }
    }
}
