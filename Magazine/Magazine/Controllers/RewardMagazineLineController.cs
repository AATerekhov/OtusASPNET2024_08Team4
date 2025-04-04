using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazineLine;
using Magazine.BusinessLogic.Services;
using Magazine.Core.Domain.Magazines;
using MagazineHost.Cache;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using MassTransit;
using Magazine.Message;
using MagazineHost.Mappers;
using GrpcDiaryClient;

namespace MagazineHost.Controllers
{
    /// <summary>
    /// Magazine Lines
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RewardMagazineLineController(IRewardMagazineLineService _service,
                                              IRewardMagazineService     _magazineService,
                                              IMapper                    _mapper,
                                              IDistributedCache _distributedCache,
                                              IBusControl      _busControl,
                                              DiaryGrpcService.DiaryGrpcServiceClient _diaryGrpcClient) : ControllerBase
    {
       
        /// <summary>
        /// Получение списка строк журнала наград
        /// </summary>
        /// <param name="request"><RewardMagazineLineFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<RewardMagazineLineResponse>> GetMagazineLinePagedAsync(RewardMagazineLineFilterRequest request)
        {
            var filterModel = _mapper.Map<RewardMagazineLineFilterRequest, RewardMagazineLineFilterDto>(request);
            var response = _mapper.Map<List<RewardMagazineLine>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение строки журнала наград через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMagazineLine/{id}")]
        public async Task<ActionResult<RewardMagazineLine>> GetRewardMagazineLineAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.MagazineLineKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<RewardMagazineLine>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }
            }

            var response = _mapper.Map<RewardMagazineLine>(await _service.GetByIdAsync(id, HttpContext.RequestAborted));

            await _distributedCache.SetStringAsync(
                key: KeyForCache.MagazineLineKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Получение всех строк журнала наград
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMagazineLinesByMagazineId/{id}")]
        public async Task<ActionResult<RewardMagazineLineResponse>> GetLinesByMagazineIdAsync(Guid id)
        {         
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.MagazineLinesByMagazineIdKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<RewardMagazineLineResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }

            var lines = await _service.GetAllByMagazineIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<RewardMagazineLineResponse>>(lines);

            await _distributedCache.SetStringAsync(
                key: KeyForCache.MagazineLinesByMagazineIdKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Получение всех строк журналов наград
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMagazineLines")]
        public async Task<ActionResult<RewardMagazineLineResponse>> GetAllAsync()
        {
            var lines = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<RewardMagazineLineResponse>>(lines);
            return Ok(response);
        }

        /// <summary>
        /// Создание строки журнала
        /// </summary>
        /// <param name="request">CreateOrEditRewardMagazineLineRequest</param>
        /// <returns></returns>
        [HttpPost("CreateMagazineLine")]
        public async Task<ActionResult<RewardMagazineLineResponse>> CreateMagazineLineAsync(CreateRewardMagazineLineRequest request)
        {
            var magazineLine = await _service.CreateAsync(_mapper.Map<CreateRewardMagazineLineDto>(request), HttpContext.RequestAborted);
            var magazine    = await _magazineService.GetByIdAsync(magazineLine.MagazineId, HttpContext.RequestAborted);

            //await _busControl.Publish<MagazineLineMessage>(MagazineLineMessageMapper.MapInMessage(magazine, magazineLine), HttpContext.RequestAborted);
            await _diaryGrpcClient.CreateDiaryLineFromMagazineAsync(MagazineLineMessageMapper.MapInMessage(magazine, magazineLine));

            await _distributedCache.RemoveAsync(KeyForCache.MagazineLinesByMagazineIdKey(magazine.Id));

            return Ok(_mapper.Map<RewardMagazineLineResponse>(magazineLine));
        }

        /// <summary>
        /// Изменение строки журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">EditRewardMagazineLineRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateMagazineLine/{id}")]
        public async Task<ActionResult<RewardMagazineLineResponse>> EditMagazineLineAsync(Guid id, EditRewardMagazineLineRequest request)
        {
            var magazineLine = await _service.UpdateAsync(id, _mapper.Map<EditRewardMagazineLineRequest, EditRewardMagazineLineDto>(request), HttpContext.RequestAborted);
            var magazine     = await _magazineService.GetByIdAsync(magazineLine.MagazineId, HttpContext.RequestAborted);

            //await _busControl.Publish<MagazineLineMessage>(MagazineLineMessageMapper.MapInMessage(magazine, magazineLine), HttpContext.RequestAborted);
            await _diaryGrpcClient.CreateDiaryLineFromMagazineAsync(MagazineLineMessageMapper.MapInMessage(magazine, magazineLine));

            await _distributedCache.RemoveAsync(KeyForCache.MagazineLineKey(id));
            await _distributedCache.RemoveAsync(KeyForCache.MagazineLinesByMagazineIdKey(magazine.Id));

            return Ok(_mapper.Map<RewardMagazineLineResponse>(magazineLine));
        }

        /// <summary>
        /// Удаление строки журнала по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteMagazineLine/{id}")]
        public async Task<IActionResult> DeleteMagazineLine(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            await _distributedCache.RemoveAsync(KeyForCache.MagazineLineKey(id));
            return Ok($"Строка журнала с id {id} удален");
        }
    }
}
