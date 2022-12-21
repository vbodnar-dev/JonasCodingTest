using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace WebApi.ExceptionHandlers
{
    public class CustomExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Logger.LogError(context.Exception);
        }
    }
}