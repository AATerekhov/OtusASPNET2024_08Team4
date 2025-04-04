using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using RoomsDesigner.Api.Requests.Case;
using System.IO;
using System.Security.Claims;
using System;
using System.Threading.Tasks;

namespace RoomsDesigner.Api.Infrastructure.ModelBinding
{
    public class CaseUpdateOwnerParametersBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null) throw new ArgumentNullException(nameof(bindingContext));
            var userId = bindingContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userMail = bindingContext.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                if (string.IsNullOrEmpty(body))
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "body missed");
                    return;
                }

                JObject jsonObject = JObject.Parse(body);
                string name = jsonObject["name"].ToString();
                string id = jsonObject["id"].ToString();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "The some prorerty is empty");
                    return;
                }

                UpdateCaseRequest resultModel = new()
                {
                    OwnerId = new Guid(userId),
                    UserMail = userMail,
                    Name = name,
                    Id = new Guid(id)
                };

                bindingContext.Result = ModelBindingResult.Success(resultModel);
                return;
            }
        }
    }
}
