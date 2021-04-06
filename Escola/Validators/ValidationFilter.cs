using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new ContentResult()
            //    {
            //        StatusCode = 400,
            //        Content = JsonConvert.SerializeObject(context.ModelState.Values.SelectMany(m => m.Errors)
            //                     .Select(e => e.ErrorMessage))
            //    };
            //}
        }
    }
}
