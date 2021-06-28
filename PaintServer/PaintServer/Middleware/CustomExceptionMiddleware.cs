using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Askme.Api.Middleware
{
    public class CustomExceptionMiddleware
    {
        /// <summary>
        ///  A function that can process an HTTP request.
        /// </summary>
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Method that check HttpContext.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// A method that checks for all possible exceptions in a project.
        /// </summary>
        /// <remarks>
        /// Accept HttpContext and Exception; If condition is not met in structure then return status code "500" and
        /// description: "The server encountered an internal error or misconfiguration and was unable to complete your request.".
        /// If the condition is met, the method will return the corresponding error description and status code.
        /// </remarks>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns>
        /// HttpContext.
        /// </returns>
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var errorDescription = exception.GetType() == typeof(AggregateException) ? exception.InnerException?.Message : exception.Message;
            var exceptionType = exception.GetType() == typeof(AggregateException) ? exception.InnerException?.GetType() : exception.GetType();
            
            if (exceptionType == typeof(ArgumentNullException)) code = HttpStatusCode.BadRequest;
            else if (exceptionType == typeof(ArgumentException)) code = HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/text";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(errorDescription);
        }
    }
}