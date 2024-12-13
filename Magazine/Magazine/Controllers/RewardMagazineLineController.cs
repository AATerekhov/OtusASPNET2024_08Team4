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

namespace MagazineHost.Controllers
{
    /// <summary>
    /// Magazine Lines
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RewardMagazineLineController(IRewardMagazineLineService _service, IMapper _mapper,
                                              IDistributedCache _distributedCache) : ControllerBase
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
        public async Task<ActionResult<RewardMagazineLineResponse>> CreateMagazineLineAsync(CreateOrEditRewardMagazineLineRequest request)
        {
            var diaryLine = await _service.CreateAsync(_mapper.Map<CreateOrEditRewardMagazineLineDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<RewardMagazineLineResponse>(diaryLine));
        }

        /// <summary>
        /// Изменение строки журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditRewardMagazineLineRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateMagazineLine/{id}")]
        public async Task<ActionResult<RewardMagazineLineResponse>> EditMagazineLineAsync(Guid id, CreateOrEditRewardMagazineLineRequest request)
        {
            var diaryLine = await _service.UpdateAsync(id, _mapper.Map<CreateOrEditRewardMagazineLineRequest, CreateOrEditRewardMagazineLineDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<RewardMagazineLineResponse>(diaryLine));
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
            return Ok($"Строка журнала с id {id} удален");
        }
    }
}
