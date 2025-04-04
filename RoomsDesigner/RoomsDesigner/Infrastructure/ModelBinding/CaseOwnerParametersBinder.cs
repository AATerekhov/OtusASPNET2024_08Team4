using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using RoomsDesigner.Api.Requests.Case;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RoomsDesigner.Api.Infrastructure.ModelBinding
{
    public class CaseOwnerParametersBinder : IModelBinder
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
                if (string.IsNullOrEmpty(name)) 
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "The name is empty");
                    return;
                }

                CreateCaseRequest resultModel = new()
                {
                    OwnerId = new Guid(userId),
                    UserMail = userMail,
                    Name = name
                };

                bindingContext.Result = ModelBindingResult.Success(resultModel);
                return;
            }   
        }
    }
}
