using RoomsDesigner.BusinessLogic.Models;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services.Implementation
{
	public class DiaryService : BaseService, IDiaryService
	{
		private readonly IRepository<Diary, Guid> _diaryRepository;

		public DiaryService(IRepository<Diary, Guid> diaryRepository)
		{
			_diaryRepository = diaryRepository;
		}

		public async Task<List<DiaryDto>> GetAllAsync()
			=> (await _diaryRepository.GetAllAsync(asNoTracking: true)).Select(x => new DiaryDto
			{
				Id = x.Id,
				Name = x.Name,
			}).ToList();

		public async Task<DiaryDto> GetByIdAsync(Guid id)
		{
			var diary = await _diaryRepository.GetByIdAsync(x => x.Id.Equals(id), asNoTracking: true)
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Diary)));

			return new DiaryDto
			{
				Id = diary.Id,
				Name = diary.Name,
			};
		}

		public async Task UpdateAsync(Guid id, string name)
		{
			var diary = await _diaryRepository.GetByIdAsync(x => x.Id.Equals(id))
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Diary)));

			diary.Name = name;

			_diaryRepository.Update(diary);
			await _diaryRepository.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var diary = await _diaryRepository.GetByIdAsync(x => x.Id.Equals(id))
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Diary)));

			_diaryRepository.Delete(diary);
			await _diaryRepository.SaveChangesAsync();
		}
	}
}
