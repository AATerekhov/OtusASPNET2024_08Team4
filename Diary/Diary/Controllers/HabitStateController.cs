using AutoMapper;
using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.HabitState;
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
    /// HabitState
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitStateController(IHabitStateService _service,
                                      IMapper _mapper,
                                      IDistributedCache _distributedCache) : ControllerBase
    { 
      /// <summary>
      /// Получение состояния привычки через гуид
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        [HttpGet("GetHabitState/{id}")]
        public async Task<ActionResult<HabitStateResponse>> GetHabitStateByIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.HabitStateKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitShortResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }
            }

            var response = _mapper.Map<HabitStateResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted));

            await _distributedCache.SetStringAsync(
                key: KeyForCache.HabitStateKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });

            return Ok(response);
        }

        /// <summary>
        /// Получение всех состояний привычек
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllHabitStates")]
        public async Task<ActionResult<HabitStateResponse>> GetAllAsync()
        {
            var habits = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitStateResponse>>(habits);

            return Ok(response);
        }


        /// <summary>
        /// Получение состояний привычки по гуиду привычки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetHabitStatesByHabitId/{id}")]
        public async Task<ActionResult<HabitStateResponse>> GetHabitStatesByHabitIdAsync(Guid id)
        {
            string? serialized = await _distributedCache.GetStringAsync(KeyForCache.HabitStatesByHabitIdKey(id), HttpContext.RequestAborted);

            if (serialized is not null)
            {
                var cachResult = JsonSerializer.Deserialize<IEnumerable<HabitDiaryShortResponse>>(serialized);

                if (cachResult is not null)
                {
                    return Ok(cachResult);
                }

            }
            var lines = await _service.GetAllByHabitIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitStateResponse>>(lines);

            await _distributedCache.SetStringAsync(
                key: KeyForCache.HabitStatesByHabitIdKey(id),
                value: JsonSerializer.Serialize(response),
                options: new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });


            return Ok(response);
        }

        /// <summary>
        /// Создание состояния привычки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateHabitState")]
        public async Task<ActionResult<HabitStateResponse>> CreateHabitAsync(CreateHabitStateRequest request)
        {
            var diary = await _service.CreateAsync(_mapper.Map<CreateHabitStateDto>(request), HttpContext.RequestAborted);
            return Ok(_mapper.Map<HabitStateResponse>(diary));
        }

        /// <summary>
        /// Изменение состояния привычки по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">EditHabitStateRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateHabitState/{id}")]
        public async Task<ActionResult<HabitStateResponse>> EditHabitAsync(Guid id, EditHabitStateRequest request)
        {
            var diary = await _service.UpdateAsync(id, _mapper.Map<EditHabitStateRequest, EditHabitStateDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitStateResponse>(diary));
        }

        /// <summary>
        /// Удаление состояния привычки по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteHabitState/{id}")]
        public async Task<IActionResult> DeleteHabitState(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Состояние привычки с id {id} удалено");
        }
    }
}
