using DiverseTraining.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.DemoSample.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex, _logger).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception, ILogger<ExceptionHandlerMiddleware> _logger)
        {
            _logger.LogError(exception, exception.Message);
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(new ErrorDto()
            {
                StatusCode = statusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}

