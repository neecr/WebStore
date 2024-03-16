using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Exceptions;

namespace WebStore
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;


        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
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
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.StackTrace);
                await HandleExceptionAsync(context, exception);
            }
        }
        
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)GetStatusCode(exception),
                Title = exception.Message,
            };

            return context.Response.WriteAsJsonAsync(problemDetails);
        }
        
        private static HttpStatusCode GetStatusCode(Exception exception) => exception switch
        {
            DbUpdateException => HttpStatusCode.InternalServerError,
            NotFoundException => HttpStatusCode.NotFound,
            WrongCredentialsException => HttpStatusCode.Unauthorized,
            ValidationException => HttpStatusCode.Forbidden,
            _ => HttpStatusCode.InternalServerError,
        };
    }
}
