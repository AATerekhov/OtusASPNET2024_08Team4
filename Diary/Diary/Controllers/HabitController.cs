using AutoMapper;
using Diary.BusinessLogic.Models.Habit;
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
    /// Habit
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitController(IHabitService      _service,
                                 IMapper            _mapper,
                                 IDistributedCache  _distributedCache) : ControllerBase
    {
        
        /// <summary>
        /// Получение привычки через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetHabit/{id}")]
        public async Task<ActionResult<HabitResponse>> GetHabitByIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.HabitKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }
            }

            var response = _mapper.Map<HabitResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted));

            await _distributedCache.SetStringAsync(
                key: KeyForCache.HabitKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });

            return Ok(response);
        }

        /// <summary>
        /// Получение всех привычек
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllHabits")]
        public async Task<ActionResult<HabitShortResponse>> GetAllAsync()
        {
            var habits = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitShortResponse>>(habits);

            return Ok(response);
        }


        /// <summary>
        /// Получение всех привычек по гуиду дневника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetHabitsByDiaryId/{id}")]
        public async Task<ActionResult<HabitShortResponse>> GetHabitsByDiaryIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.HabitsByDiaryIdKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitDiaryShortResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }
            var lines = await _service.GetAllByDiaryIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitShortResponse>>(lines);

            await _distributedCache.SetStringAsync(
                key: KeyForCache.HabitsByDiaryIdKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Создание привычки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateHabit")]
        public async Task<ActionResult<HabitShortResponse>> CreateHabitAsync(CreateHabitRequest request)
        {
            var diary = await _service.CreateAsync(_mapper.Map<CreateHabitDto>(request), HttpContext.RequestAborted);
            return Ok(_mapper.Map<HabitShortResponse>(diary));
        }

        /// <summary>
        /// Изменение привычки по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">EditHabitRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateHabit/{id}")]
        public async Task<ActionResult<HabitResponse>> EditHabitAsync(Guid id, EditHabitRequest request)
        {
            var diary = await _service.UpdateAsync(id, _mapper.Map<EditHabitRequest, EditHabitDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitResponse>(diary));
        }

        /// <summary>
        /// Удаление привычки по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteHabit/{id}")]
        public async Task<IActionResult> DeleteHabit(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Привычка с id {id} удалена");
        }
    }
}
