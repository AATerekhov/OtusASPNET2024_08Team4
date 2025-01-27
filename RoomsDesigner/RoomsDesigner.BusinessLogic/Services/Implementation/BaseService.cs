using System;

namespace RoomsDesigner.BusinessLogic.Services.Implementation
{
	public abstract class BaseService
	{
		public string FormatFullNotFoundErrorMessage(Guid id, string nameOfEntity)
			=> $"The {nameOfEntity} with Id {id} has not been found.";
	}
}
