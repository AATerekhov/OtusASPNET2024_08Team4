using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services.Implementatios
{
    public class BaseService
    {
        public string FormatFullNotFoundErrorMessage(Guid id, string nameOfEntity)
        => $"The {nameOfEntity} with Id {id} has not been found.";
    }
}
