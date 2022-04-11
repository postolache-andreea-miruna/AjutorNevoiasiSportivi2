using MongoDB.Bson;
using Realms.Sync.Exceptions;
using ServiceStack;
using System.Net;

namespace AjutorNevoiasiSportivi2.Entities
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware>logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError("Mesaj: " + ex.Message + "Mesaj: " + ex.InnerException, "S-a prins o exceptie");
                HttpStatusCode status;
                ApiResponse response;
                
                if (ex is UnauthorizedAccessException)
                {
                    response = new ApiResponse("Acces neautorizat!");
                    status = HttpStatusCode.Unauthorized;
                }
                else if (ex is KeyNotFoundException)
                {
                    response = new ApiResponse("Nu exista date ne pare rau!");
                    status = HttpStatusCode.NotFound;
                }

                else if (ex is AppException)
                {
                    response = new ApiResponse(ex.Message);
                    status = HttpStatusCode.InternalServerError;
                }
                else if (ex is NotImplementedException)
                {
                    response = new ApiResponse("Eroare de server!");
                    status = HttpStatusCode.NotImplemented;
                }
                else
                {
                    logger.LogCritical("Mesaj: " + ex.Message + "Mesaj: " + ex.InnerException, "S-a prins o eroare neasteptata");
                    response = new ApiResponse(ex.Message);
                    status = HttpStatusCode.InternalServerError;
                }
                context.Response.StatusCode = (int)status;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToJson());
            }
        }
    }
}
