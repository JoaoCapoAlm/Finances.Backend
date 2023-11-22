using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;
using Finances.Backend.Data.ViewModel;

namespace Finances.Backend.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch(ArgumentException ex) {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            } catch (Exception ex)
            {
                string message = Helper.System.IsDevelopment()
                    ? $"{ex.Message} {ex?.InnerException?.Message}"
                    : "Aconteceu um erro inesperado!";
                await HandleExceptionAsync(context, message, HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode httpStatusCode)
        {
            ErrorResponseVM errorResponseVM = new ErrorResponseVM(httpStatusCode.ToString(), message);

            var result = JsonSerializer.Serialize(errorResponseVM);

            context.Response.StatusCode = httpStatusCode.GetHashCode();
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
