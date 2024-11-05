using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.JournalOwner;
using Diary.BusinessLogic.Services;
using Diary.BusinessLogic.Services.Implementation;
using Diary.Models.Request;
using Diary.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    /// <summary>
    /// Diary
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JournalOwnerController : ControllerBase
    {
        private readonly IJournalOwnerService _service;
        private readonly IMapper _mapper;

        public JournalOwnerController(IJournalOwnerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка владельцев журналов постранично
        /// </summary>
        /// <param name="request">JournalOwnerFilterRequest</param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<JournalOwnerResponse>> GetJournalOwnersPagedAsync(JournalOwnerFilterRequest request)
        {
            var filterModel = _mapper.Map<JournalOwnerFilterRequest, JournalOwnerFilterDto>(request);
            var response = _mapper.Map<List<JournalOwnerResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение владельца журнала через гуид
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpGet("GetJournalOwner{id}")]
        public async Task<ActionResult<JournalOwnerResponse>> GetJournalOwnerAsync(Guid id)
        {
            return Ok(_mapper.Map<JournalOwnerResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Получение всех владельцев журнала
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllJournalOwners")]
        public async Task<ActionResult<JournalOwnerResponse>> GetAllAsync()
        {
            var journalOwners = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<JournalOwnerResponse>>(journalOwners);
            return Ok(response);
        }

        /// <summary>
        /// Создание владельца журнала 
        /// </summary>
        /// <param name="request">CreateOrEditJournalOwnerRequest</param>
        /// <returns></returns>
        [HttpPost("CreateJournalOwner")]
        public async Task<ActionResult<JournalOwnerResponse>> CreateJournalOwnerAsync(CreateOrEditJournalOwnerRequest request)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreateOrEditJournalOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Изменение владельца журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditJournalOwnerRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateJournalOwner/{id}")]
        public async Task<ActionResult<JournalOwnerResponse>> EditJournalOwnerAsync(Guid id, CreateOrEditJournalOwnerRequest request)
        {
            return Ok(await _service.UpdateAsync(id, _mapper.Map<CreateOrEditJournalOwnerRequest, CreateOrEditJournalOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Удаление владельца журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("DeleteJournalOwner/{id}")]
        public async Task<IActionResult> DeleteJournalOwner(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Сотрудник с id {id} удален");
        }

    }
}
