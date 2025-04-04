using System.Text.Json;

namespace Diary.Middlewares
{
    public class LoggingMiddleware(RequestDelegate _next, ILogger<LoggingMiddleware> _logger)
    {      
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Логирование входящего запроса
                LogRequest(context);

                var startTime = DateTime.UtcNow;

                await _next(context);

                // Логирование успешного выполнения
                LogResponse(context, startTime, successful: true);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                _logger.LogError(ex, "Произошла непредвиденная ошибка");

                // Обработка ошибки и возврат клиенту
                await HandleExceptionAsync(context, ex);
            }
        }

        private void LogRequest(HttpContext context)
        {
            _logger.LogInformation($"Запрос: {context.Request.Method} {context.Request.Path}" +
                                 $"{context.Request.QueryString}");

            // Дополнительное логгирование заголовков при необходимости
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                foreach (var header in context.Request.Headers)
                {
                    _logger.LogDebug($"Header: {header.Key}: {header.Value}");
                }
            }
        }

        private void LogResponse(HttpContext context, DateTime startTime, bool successful)
        {
            var duration = DateTime.UtcNow - startTime;
            _logger.LogInformation($"Запрос {context.Request.Path} " +
                                 $"{(successful ? "успешно обработан" : "завершился с ошибкой")}. " +
                                 $"Статус: {context.Response.StatusCode}. " +
                                 $"Время выполнения: {duration.TotalMilliseconds} мс");
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                ArgumentNullException _ => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException _ => StatusCodes.Status401Unauthorized,
                NotImplementedException _ => StatusCodes.Status501NotImplemented,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = statusCode,
                Message = exception.Message
            }.ToString());
        }
    }

    // Класс для форматирования ошибок
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    // Метод расширения
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
