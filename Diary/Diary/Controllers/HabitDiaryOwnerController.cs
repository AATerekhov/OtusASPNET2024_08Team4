﻿using AutoMapper;
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
    /// DiaryOwner
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitDiaryOwnerController : ControllerBase
    {
        private readonly IHabitDiaryOwnerService _service;
        private readonly IMapper _mapper;

        public HabitDiaryOwnerController(IHabitDiaryOwnerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка владельцев дневникнов постранично
        /// </summary>
        /// <param name="request">DiaryOwnerFilterRequest</param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<HabitDiaryOwnerShortResponse>> GetDiaryOwnersPagedAsync(HabitDiaryOwnerFilterRequest request)
        {
            var filterModel = _mapper.Map<HabitDiaryOwnerFilterRequest, HabitDiaryOwnerFilterDto>(request);
            var response = _mapper.Map<List<HabitDiaryOwnerShortResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение владельца дневника через гуид
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpGet("GetDiaryOwner{id}")]
        public async Task<ActionResult<HabitDiaryOwnerResponse>> GetDiaryOwnerAsync(Guid id)
        {
            return Ok(_mapper.Map<HabitDiaryOwnerResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Получение всех владельцев дневника
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllDiaryOwners")]
        public async Task<ActionResult<HabitDiaryOwnerShortResponse>> GetAllAsync()
        {
            var journalOwners = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<HabitDiaryOwnerShortResponse>>(journalOwners);
            return Ok(response);
        }

        /// <summary>
        /// Создание владельца дневника
        /// </summary>
        /// <param name="request">CreateOrEditDiaryOwnerRequest</param>
        /// <returns></returns>
        [HttpPost("CreateDiaryOwner")]
        public async Task<ActionResult<HabitDiaryOwnerResponse>> CreateJournalOwnerAsync(CreateOrEditHabitDiaryOwnerRequest request)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreateOrEditHabitDiaryOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Изменение владельца дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">CreateOrEditDiaryOwnerRequest</param>
        /// <returns></returns>

        [HttpPut("UpdateDiaryOwner/{id}")]
        public async Task<ActionResult<HabitDiaryOwnerResponse>> EditJournalOwnerAsync(Guid id, CreateOrEditHabitDiaryOwnerRequest request)
        {
            return Ok(await _service.UpdateAsync(id, _mapper.Map<CreateOrEditHabitDiaryOwnerRequest, CreateOrEditHabitDiaryOwnerDto>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Удаление владельца дневника по гуиду
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("DeleteDiaryOwner/{id}")]
        public async Task<IActionResult> DeleteJournalOwner(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Владелец дневника с id {id} удален");
        }

    }
}