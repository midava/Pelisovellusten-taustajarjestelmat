using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_2
{
    public class CatchMeIfYouCanAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) 
        {
            JsonResult error = new JsonResult(context.Exception.Message);
            error.StatusCode = StatusCodes.Status422UnprocessableEntity;

            context.ExceptionHandled = true;
            context.Result = error;
        }
    }
}