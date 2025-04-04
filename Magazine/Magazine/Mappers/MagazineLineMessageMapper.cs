using GrpcDiaryClient;
using Magazine.Core.Domain.Magazines;
using Magazine.Message;

namespace MagazineHost.Mappers
{
    public class MagazineLineMessageMapper
    {
        public static MagazineLineMessageGrpc MapInMessage(RewardMagazine _rewardMagazine, RewardMagazineLine _rewardMagazineLine)
        {
            return new MagazineLineMessageGrpc()
            {
                RoomId = _rewardMagazine.RoomId.ToString(),
                UserId = _rewardMagazine.UserId.ToString(),
                RewardId = _rewardMagazineLine.RewardId.ToString(),
                EventDescription = _rewardMagazineLine.EventDescription,
                CreatedDate = _rewardMagazineLine.CreatedDate.ToString(),
                ModifiedDate = _rewardMagazineLine.ModifiedDate.ToString(),
                Cost = (double)_rewardMagazineLine.Cost              
            };
        }
    }
}
