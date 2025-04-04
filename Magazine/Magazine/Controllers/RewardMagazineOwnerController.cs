using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazineOwner;
using Magazine.BusinessLogic.Services;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace MagazineHost.Controllers
{
    /// <summary>
    /// Magazine Owner
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RewardMagazineOwnerController : ControllerBase
    {
        private readonly IRewardMagazineOwnerService _service;
        private readonly IMapper _mapper;

        public RewardMagazineOwnerController(IRewardMagazineOwnerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка владельцев журналов наград постранично
        /// </summary>
        /// <param name="request">RewardMagazineOwnerFilterRequest</param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<RewardMagazineOwnerShortResponse>> GetMagazineOwnersPagedAsync(RewardMagazineOwnerFilterRequest request)
        {
            var filterModel = _mapper.Map<RewardMagazineOwnerFilterRequest, RewardMagazineOwnerFilterDto>(request);
            var response = _mapper.Map<List<RewardMagazineOwnerShortResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение владельца журнала через гуид
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpGet("GetMagazineOwner{id}")]
        public async Task<ActionResult<RewardMagazineOwnerResponse>> GetMagazineOwnerAsync(Guid id)
        {
            return Ok(_mapper.Map<RewardMagazineOwnerResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Получение всех владельцев журналов
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMagazineOwners")]
        public async Task<ActionResult<RewardMagazineOwnerResponse>> GetAllAsync()
        {
            var journalOwners = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<RewardMagazineOwnerResponse>>(journalOwners);
            return Ok(response);
        }

        /// <summary>
        /// Создание владельца журнала наград
        /// </summary>
        /// <param name="request">CreateOrEditRewardMagazineOwnerRequest</param>
        /// <returns></returns>
        [HttpPost("CreateMagazineOwner")]
        public async Task<ActionResult<RewardMagazineOwnerResponse>> CreateMagazineOwnerAsync(CreateOrEditRewardMagazineOwnerRequest request)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreateOrEditRewardMagazineOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Изменение владельца журнала по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditRewardMagazineOwnerReques</param>
        /// <returns></returns>

        [HttpPut("UpdateMagazineOwner/{id}")]
        public async Task<ActionResult<RewardMagazineOwnerResponse>> EditMagazineOwnerAsync(Guid id, CreateOrEditRewardMagazineOwnerRequest request)
        {
            return Ok(await _service.UpdateAsync(id, _mapper.Map<CreateOrEditRewardMagazineOwnerRequest, CreateOrEditRewardMagazineOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Удаление владельца дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("DeleteMagazineOwner/{id}")]
        public async Task<IActionResult> DeleteMagazineOwner(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Владелец журнала с id {id} удален");
        }

    }
}
