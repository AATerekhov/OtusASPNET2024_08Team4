using RoomsDesigner.BusinessLogic.Models.Administration;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services.Implementation
{
	public class RoleService : IRoleService
	{
		private readonly IRepository<Role, int> _roleRepository;

		public RoleService(IRepository<Role, int> roleRepository)
		{
			_roleRepository = roleRepository;
		}

		public async Task<List<RoleDto>> GetAllAsync()
			=> (await _roleRepository.GetAllAsync(asNoTracking: true)).Select(x => new RoleDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
	}
}
