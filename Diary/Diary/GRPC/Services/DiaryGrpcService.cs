using Diary.Core.Domain.Diary;
using Diary.DataAccess.Abstractions;
using Grpc.Core;
using Magazine.Message;
using GrpcDiary;
using Diary.Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace Diary.GRPC.Services
{
    public class DiaryGrpcService(
        IHabitDiaryRepository _diaryRepository,
        IHabitDiaryLineRepository _diaryLineRepository,
        ILogger<DiaryGrpcService> _logger) : GrpcDiary.DiaryGrpcService.DiaryGrpcServiceBase
    {
        public override async Task<Empty> CreateDiaryLineFromMagazine(
            MagazineLineMessageGrpc request,
            ServerCallContext context)
        {
            try
            {
                var diary = await _diaryRepository.GetFirstWhere(
                    r => r.RoomId == Guid.Parse(request.RoomId) &&
                         r.DiaryOwnerId == Guid.Parse(request.UserId))
                    ?? throw new NotFoundException(
                        $"Diary not found for room {request.RoomId} and user {request.UserId}");

                if (diary.TotalCost == 0)
                {
                    throw new RpcException(
                        new Status(
                            StatusCode.FailedPrecondition,
                            "User has zero total cost"));
                }

                var diaryLine = new HabitDiaryLine()
                {
                    DiaryId = diary.Id,
                    EntityId = Guid.Parse(request.RewardId),
                    EventDescription = request.EventDescription,
                    CreatedDate = DateTime.Parse(request.CreatedDate),
                    ModifiedDate = DateTime.Parse(request.ModifiedDate),
                    Cost = (decimal)-request.Cost,
                };

                await _diaryLineRepository.AddAsync(diaryLine, context.CancellationToken);
                await _diaryLineRepository.SaveChangesAsync(context.CancellationToken);

                return new Empty();
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex, "Invalid format in request data");
                throw new RpcException(
                    new Status(
                        StatusCode.InvalidArgument,
                        "Invalid data format in request"));
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                throw new RpcException(
                    new Status(
                        StatusCode.NotFound,
                        ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error creating diary line");
                throw new RpcException(
                    new Status(
                        StatusCode.Internal,
                        "Internal server error"));
            }
        }
    }
}