using System;
using System.Threading.Tasks;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AnswerOnline.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                if (statusCode != StatusCodes.Status200OK)
                {
                    await HandleExceptionAsync(context);
                }
            }
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception exception = null)
        {
            var errorMessage = exception != null
                ? exception.InnerException == null
                    ? exception.Message
                    : exception.InnerException.Message
                : string.Empty;

            _logger.LogError(errorMessage);

            var response = Result.Failed(errorMessage).ToJsonString();

            context.Response.ContentType = "application/json;charset=utf-8";

            return context.Response.WriteAsync(response);
        }
    }
}