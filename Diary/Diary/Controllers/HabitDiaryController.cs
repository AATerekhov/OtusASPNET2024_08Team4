using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.BusinessLogic.Services;
using Diary.Models.Request;
using Diary.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    /// <summary>
    /// Diary
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitDiaryController : ControllerBase
    {
        private readonly IHabitDiaryService _service;
        private readonly IMapper _mapper;

        public HabitDiaryController(IHabitDiaryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

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
            return Ok(_mapper.Map<HabitDiaryResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
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
        /// Создание дневника
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDiary")]
        public async Task<ActionResult<HabitDiaryResponse>> CreateDiaryAsync(CreateOrEditHabitDiaryRequest request)
        {
            var diary = await _service.CreateAsync(_mapper.Map<CreateOrEditHabitDiaryDto>(request), HttpContext.RequestAborted);
            return Ok(_mapper.Map<HabitDiaryResponse>(diary));
        }

        /// <summary>
        /// Изменение дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditDiaryRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateDiary/{id}")]
        public async Task<ActionResult<HabitDiaryResponse>> EditJournalAsync(Guid id, CreateOrEditHabitDiaryRequest request)
        {
            var diary = await _service.UpdateAsync(id, _mapper.Map<CreateOrEditHabitDiaryRequest, CreateOrEditHabitDiaryDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitDiaryResponse>(diary));
        }

        /// <summary>
        /// Удаление журнала по гуиду
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
