using AutoMapper;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.BusinessLogic.Services;
using Diary.Models.Request;
using Diary.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    /// <summary>
    /// Diary Lines
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitDiaryLineController : ControllerBase
    {
        private readonly IHabitDiaryLineService _service;
        private readonly IMapper _mapper;

        public HabitDiaryLineController(IHabitDiaryLineService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка строк дневников
        /// </summary>
        /// <param name="request"><DiaryLineFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<HabitDiaryLineResponse>> GetDiaryLinePagedAsync(HabitDiaryLineFilterRequest request)
        {
            var filterModel = _mapper.Map<HabitDiaryLineFilterRequest, HabitDiaryLineFilterDto>(request);
            var response = _mapper.Map<List<HabitDiaryLineResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение строки дневника через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDiaryLine/{id}")]
        public async Task<ActionResult<HabitDiaryLineResponse>> GetDiaryLineAsync(Guid id)
        {
            return Ok(_mapper.Map<HabitDiaryLineResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Получение всех строк дневника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDiaryLinesByDiaryId/{id}")]
        public async Task<ActionResult<HabitDiaryLineResponse>> GetDiaryLinesByDiaryIdAsync(Guid id)
        {
            var lines = await _service.GetAllByDiaryIdAsync(id, HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitDiaryLineResponse>>(lines);
            return Ok(response);
        }

        /// <summary>
        /// Получение всех строк дневников
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllDiaryLines")]
        public async Task<ActionResult<HabitDiaryLineResponse>> GetAllAsync()
        {
            var lines = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitDiaryLineResponse>>(lines);
            return Ok(response);
        }

        /// <summary>
        /// Создание дневника
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDiaryLine")]
        public async Task<ActionResult<HabitDiaryLineResponse>> CreateDiaryAsync(CreateOrEditHabitDiaryLineRequest request)
        {
            var diaryLine = await _service.CreateAsync(_mapper.Map<CreateOrEditHabitDiaryLineDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitDiaryLineResponse>(diaryLine));
        }

        /// <summary>
        /// Изменение дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditDiaryRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateDiaryLine/{id}")]
        public async Task<ActionResult<HabitDiaryLineResponse>> EditJournalAsync(Guid id, CreateOrEditHabitDiaryLineRequest request)
        {
            var diaryLine = await _service.UpdateAsync(id, _mapper.Map<CreateOrEditHabitDiaryLineRequest, CreateOrEditHabitDiaryLineDto>(request), HttpContext.RequestAborted);

            return Ok(_mapper.Map<HabitDiaryLineResponse>(diaryLine));
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
            return Ok($"Сотрудник с id {id} удален");
        }
    }
}
