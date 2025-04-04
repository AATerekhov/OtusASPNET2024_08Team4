using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazine;
using Magazine.BusinessLogic.Services;
using MagazineHost.Cache;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MagazineHost.Controllers
{
    /// <summary>
    /// Magazine
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RewardMagazineController(IRewardMagazineService _service,
                                          IMapper                _mapper,
                                          IDistributedCache     _distributedCache) : ControllerBase
    {      

        /// <summary>
        /// Получение списка журналов наград постранично
        /// </summary>
        /// <param name="request"><RewardMagazineFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<RewardMagazineShortResponse>> GetMagazinePagedAsync(RewardMagazineFilterRequest request)
        {
            var filterModel = _mapper.Map<RewardMagazineFilterRequest, RewardMagazineFilterDto>(request);
            var response = _mapper.Map<List<RewardMagazineShortResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение журнала наград через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMagazine/{id}")]
        public async Task<ActionResult<RewardMagazineResponse>> GetMagazineAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.MagazineKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<RewardMagazineResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }

            var response = _mapper.Map<RewardMagazineResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted));

            await _distributedCache.SetStringAsync(
                key: KeyForCache.MagazineKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Получение всех журналов наград
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMagazines")]
        public async Task<ActionResult<RewardMagazineShortResponse>> GetAllAsync()
        {                      
            var journals = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<RewardMagazineShortResponse>>(journals);

            return Ok(response);
        }

        /// <summary>
        /// Создание журнала наград
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateMagazine")]
        public async Task<ActionResult<RewardMagazineResponse>> CreateMagazineAsync(CreateRewardMagazineRequest request)
        {
            var diary = await _service.CreateAsync(_mapper.Map<CreateRewardMagazineDto>(request), HttpContext.RequestAborted);
            return Ok(_mapper.Map<RewardMagazineResponse>(diary));
        }

        /// <summary>
        /// Изменение журнала наград по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">EditRewardMagazineRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateMagazine/{id}")]
        public async Task<ActionResult<RewardMagazineResponse>> EditMagazineAsync(Guid id, EditRewardMagazineRequest request)
        {
            var diary = await _service.UpdateAsync(id, _mapper.Map<EditRewardMagazineRequest, EditRewardMagazineDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<RewardMagazineResponse>(diary));
        }

        /// <summary>
        /// Удаление журнала наград по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteMagazine/{id}")]
        public async Task<IActionResult> DeleteMagazine(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Журнал наград с id {id} удален");
        }

        /// <summary>
        /// Получение всех журналов по коду владельца
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllByMagazineOwnerId/{id}")]
        public async Task<ActionResult<RewardMagazineShortResponse>> GetMagazinesByMagazineOwnerIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.MagazinesByMagazineOwnerIdKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<RewardMagazineShortResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }
            var lines = await _service.GetAllByMagazineOwnerIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<RewardMagazineShortResponse>>(lines);

            await _distributedCache.SetStringAsync(
                key: KeyForCache.MagazinesByMagazineOwnerIdKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }
    }
}

