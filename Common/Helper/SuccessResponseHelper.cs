using Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Common.Helper
{
    public static class SuccessResponseHelper<T> where T : class
    {
        public static IActionResult GetSuccessResponse(int statusCode, List<string> messages, Dictionary<string, object>? Metadata, T? data = null)
        {
            ApiResponse<T> successResponse = new(true, statusCode, messages, data, null, Metadata);

            return new ObjectResult(successResponse)
            {
                StatusCode = statusCode,
            };
        }
        public static IActionResult GetSuccessResponse(int statusCode, string message, T? data = null)
        {
            ApiResponse<T> successApiResponse = new(true, statusCode, new List<string>() { message }, data, null, null);

            return new ObjectResult(successApiResponse)
            {
                StatusCode = statusCode,
            };
        }
        public static IActionResult GetSuccessResponse(int statusCode, string message, List<T>? data = null)
        {
            ApiResponse<T> successApiResponse = new(true, statusCode, new List<string>() { message },null, data, null);

            return new ObjectResult(successApiResponse)
            {
                StatusCode = statusCode,
            };
        }
        public static IActionResult GetSuccessResponse(int statusCode, string message)
        {
            ApiResponse<T> successApiResponse = new(true, statusCode, new List<string>() { message }, null, null, null);

            return new ObjectResult(successApiResponse)
            {
                StatusCode = statusCode,
            };
        }
        public static IActionResult GetSuccessResponse(int statusCode, T? content = null)
        {
            ApiResponse<T> successApiResponse = new(true, statusCode, new List<string>(), content,null, null);

            return new ObjectResult(successApiResponse)
            {
                StatusCode = statusCode,
            };
        }
    }
}
