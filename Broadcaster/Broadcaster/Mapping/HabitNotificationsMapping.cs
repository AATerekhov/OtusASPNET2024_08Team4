using AutoMapper;
using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Requests.HabitNotification;
using Broadcaster.Responses.HabitNotification;

namespace Broadcaster.Mapping
{
    public class HabitNotificationsMapping : Profile
    {
        public HabitNotificationsMapping()
        {
            CreateMap<CreateHabitNotiticationRequest,CreateHabitNotificationModel>();
            CreateMap<HabitNotificationModel, HabitNotificationDetailedResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.NotificationMessage.Message))
                .ForMember(dest => dest.Addressee, opt => opt.MapFrom(src => src.NotificationMessage.Addressee))
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.NotificationMessage.Sender)); 
            CreateMap<HabitNotificationModel, HabitNotificationShortResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.NotificationMessage.Message))
                .ForMember(dest => dest.Addressee, opt => opt.MapFrom(src => src.NotificationMessage.Addressee))
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.NotificationMessage.Sender));
        }
    }
}
