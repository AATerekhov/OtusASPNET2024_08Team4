using RoomsDesigner.BusinessLogic.Models.Administration;
using RoomsDesigner.BusinessLogic.Models.Administration.User;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.Core.Exceptions;
using RoomsDesigner.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services.Implementation
{
	public class ParticipantService : BaseService, IParticipantService
	{
		private readonly IRepository<User, Guid> _userRepository;
		private readonly IRoleRepository _roleRepository;

		public ParticipantService(
			IRepository<User, Guid> userRepository,
			IRoleRepository roleRepository)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
		}

		public async Task<List<UserDto>> GetAllAsync()
			=> (await _userRepository.GetAllAsync(includes: $"{nameof(User.Roles)}", asNoTracking: true))
			.Select(x => new UserDto
			{
				Id = x.Id,
				Name = x.Name,
				Email = x.Email,
				Roles = x.Roles.Select(x => new RoleDto
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
				}).ToList(),
			}).ToList();

		public async Task<UserDto> GetByIdAsync(Guid id)
		{
			var user = await _userRepository.GetByIdAsync(x => x.Id.Equals(id), includes: $"{nameof(User.Roles)}", asNoTracking: true)
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(User)));

			return new UserDto
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				Roles = user.Roles.Select(x => new RoleDto
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
				}).ToList(),
			};
		}

		public async Task<UserDto> CreateAsync(CreateOrEditUserRequestDto model)
		{
			var roles = await _roleRepository.GetSelectedRoles(model.Roles);
			var user = await _userRepository.AddAsync(new User
			{
				Name = model.Name,
				Email = model.Email,
				Roles = roles,
			});

			await _userRepository.SaveChangesAsync();

			return new UserDto
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				Roles = user.Roles.Select(x => new RoleDto
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
				}).ToList(),
			};
		}

		public async Task UpdateAsync(Guid id, CreateOrEditUserRequestDto model)
		{
			var user = await _userRepository.GetByIdAsync(x => x.Id.Equals(id))
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(User)));

			var roles = await _roleRepository.GetSelectedRoles(model.Roles);

			user.Name = model.Name;
			user.Email = model.Email;
			user.Roles = roles;

			_userRepository.Update(user);
			await _userRepository.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var user = await _userRepository.GetByIdAsync(x => x.Id.Equals(id))
				?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(User)));

			_userRepository.Delete(user);
			await _userRepository.SaveChangesAsync();
		}
	}
}
