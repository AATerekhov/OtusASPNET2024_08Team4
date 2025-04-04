using Magazine.Core.Domain.Magazines;
using Magazine.Message;

namespace MagazineHost.Mappers
{
    public class MagazineLineMessageMapper
    {
        public static MagazineLineMessage MapInMessage(RewardMagazine _rewardMagazine, RewardMagazineLine _rewardMagazineLine)
        {
            return new MagazineLineMessage()
            {
                RoomId = _rewardMagazine.RoomId,
                UserId = _rewardMagazine.UserId,
                RewardId = _rewardMagazineLine.RewardId,
                EventDescription = _rewardMagazineLine.EventDescription,
                CreatedDate = _rewardMagazineLine.CreatedDate,
                ModifiedDate = _rewardMagazineLine.ModifiedDate,
                Cost = _rewardMagazineLine.Cost              
            };
        }
    }
}
