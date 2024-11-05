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
    /// UserJournal
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _service;
        private readonly IMapper _mapper;

        public JournalController(IJournalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка журналов постранично
        /// </summary>
        /// <param name="request"><JournalFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<JournalResponse>> GetJournalPagedAsync(JournalFilterRequest request)
        {
            var filterModel = _mapper.Map<JournalFilterRequest, JournalFilterDto>(request);
            var response = _mapper.Map<List<JournalResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение журнала через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetJournal/{id}")]
        public async Task<ActionResult<JournalResponse>> GetJournaAsync(Guid id)
        {
            return Ok(_mapper.Map<JournalResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Получение всех  журналов
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllJournals")]
        public async Task<ActionResult<JournalResponse>> GetAllAsync()
        {
            var journals = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<JournalResponse>>(journals);
            return Ok(response);
        }

        /// <summary>
        /// Создание журнала
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateJournal")]
        public async Task<ActionResult<JournalResponse>> CreateJournalAsync(CreateOrEditJournalRequest request)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreateOrEditJournalDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Изменение  журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditJournalRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateJournal/{id}")]
        public async Task<ActionResult<JournalResponse>> EditJournalAsync(Guid id, CreateOrEditJournalRequest request)
        {
            return Ok(await _service.UpdateAsync(id, _mapper.Map<CreateOrEditJournalRequest, CreateOrEditJournalDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Удаление журнала по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteJournal/{id}")]
        public async Task<IActionResult> DeleteJournal(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Сотрудник с id {id} удален");
        }
    }
}
