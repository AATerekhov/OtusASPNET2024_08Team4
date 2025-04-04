using Broadcaster.Application.Models.HabitNotification;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadcaster.Application.Services.Implementations.FactoryMethodDomain
{
    public class HabitNotificationCreator : DomainCreator<CreateHabitNotificationModel, HabitNotifucationMongo>
    {
        public override HabitNotifucationMongo? FactoryMethod(CreateHabitNotificationModel entity)
        {
            var notification = new HabitNotification(entity.Id, entity.Message, entity.Addressee, entity.FinishHabit, entity.Beforehand);
            return new HabitNotifucationMongo(notification);
        }
    }
}
