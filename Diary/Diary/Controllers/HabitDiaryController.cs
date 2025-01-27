using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.HabitDiary;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.BusinessLogic.Services;
using Diary.Cache;
using Diary.Models.Request;
using Diary.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Diary.Controllers
{
    /// <summary>
    /// Diary
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitDiaryController(IHabitDiaryService _service,
                                      IMapper            _mapper,
                                      IDistributedCache  _distributedCache) : ControllerBase
    {

        /// <summary>
        /// Получение списка дневников постранично
        /// </summary>
        /// <param name="request"><DiaryFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<HabitDiaryShortResponse>> GetDiaryPagedAsync(HabitDiaryFilterRequest request)
        {
            var filterModel = _mapper.Map<HabitDiaryFilterRequest, HabitDiaryFilterDto>(request);
            var response = _mapper.Map<List<HabitDiaryShortResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение дневника через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDiary/{id}")]
        public async Task<ActionResult<HabitDiaryResponse>> GetDiaryAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.DiaryKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitDiaryResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }
            }

            var response = _mapper.Map<HabitDiaryResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted));

            await _distributedCache.SetStringAsync(
                key: KeyForCache.DiaryKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });

            return Ok(response);
        }

        /// <summary>
        /// Получение всех дневников
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllDiaries")]
        public async Task<ActionResult<HabitDiaryShortResponse>> GetAllAsync()
        {
            var journals = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitDiaryShortResponse>>(journals);

            return Ok(response);
        }



        /// <summary>
        /// Получение всех дневников по коду владельца
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDiariesByDiaryOwnerId/{id}")]
        public async Task<ActionResult<HabitDiaryShortResponse>> GetDiariesByDiaryOwnerIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.DiariesByDiaryOwnerIdKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitDiaryShortResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }
            var lines = await _service.GetAllByDiaryOwnerIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitDiaryShortResponse>>(lines);

            await _distributedCache.SetStringAsync(
                key: KeyForCache.DiariesByDiaryOwnerIdKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Создание дневника
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDiary")]
        public async Task<ActionResult<HabitDiaryResponse>> CreateDiaryAsync(CreateHabitDiaryRequest request)
        {
            var diary = await _service.CreateAsync(_mapper.Map<CreateHabitDiaryDto>(request), HttpContext.RequestAborted);
            return Ok(_mapper.Map<HabitDiaryResponse>(diary));
        }

        /// <summary>
        /// Изменение дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">EditHabitDiaryRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateDiary/{id}")]
        public async Task<ActionResult<HabitDiaryResponse>> EditDiaryAsync(Guid id, EditHabitDiaryRequest request)
        {
            var diary = await _service.UpdateAsync(id, _mapper.Map<EditHabitDiaryRequest, EditHabitDiaryDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitDiaryResponse>(diary));
        }

        /// <summary>
        /// Удаление дневника по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDiary/{id}")]
        public async Task<IActionResult> DeleteDiary(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Дневник с id {id} удален");
        }
    }
}
