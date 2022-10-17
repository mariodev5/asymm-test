using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AysmmTest.WebAPI.Common;
using AysmmTest.WebAPI.Dtos;
using AysmmTest.WebAPI.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AysmmTest.WebAPI.Middlewares
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

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ServiceAuthenticationException ex)
            {
                await SetResponse(httpContext, ex, (int)HttpStatusCode.Unauthorized);
            }
            catch (NotFoundException ex)
            {
                await SetResponse(httpContext, ex, (int)HttpStatusCode.NotFound);
            }
            catch (DataFormatException ex)
            {
                await SetResponse(httpContext, ex, (int)HttpStatusCode.BadRequest);
            }
            catch (ExternalServiceException ex)
            {
                await SetResponse(httpContext, ex, (int)HttpStatusCode.BadGateway);
            }
            catch (Exception ex)
            {
                await SetResponse(httpContext, ex, (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task SetResponse(HttpContext httpContext, Exception ex, int httpStatusCode)
        {
            httpContext.Response.StatusCode = httpStatusCode;

            var acceptHeader = httpContext.Request.Headers["Accept"];
            var responseBody = string.Empty;

            if (acceptHeader == "application/xml")
            {
                httpContext.Response.ContentType = "application/xml";
                responseBody = XmlUtility.Serialize<ErrorResponseDto>(new ErrorResponseDto { Message = ex?.Message });
            }
            else
            {
                httpContext.Response.ContentType = "application/json";
                responseBody = JsonSerializer.Serialize(new ErrorResponseDto { Message = ex?.Message });
            }

            _logger.LogError(ex, ex.Message);

            await httpContext.Response.WriteAsync(responseBody);
        }
    }
}
