using BasicEcommerce_BackEnd.Util.Exceptions;
using BasicEcommerce_BackEnd.Util.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BasicEcommerce_BackEnd.Util
{
    public static class Helper
    {
        public static ObjectResult GetExectionResponse(Exception ex)
        {
            IDictionary<Type, int?> exception = new Dictionary<Type, int?>()
            {
                { typeof(JsonSerializationException), (int?)HttpStatusCode.BadRequest },
                { typeof(UnauthorizedException), (int?)HttpStatusCode.Unauthorized }
            };
            bool successGet = exception.TryGetValue(ex.GetType(), out int? statusCode);
            if (!successGet)
            {
                statusCode = (int?)HttpStatusCode.InternalServerError;
            }
            return new ObjectResult(new ErrorResponse() { Message = ex.Message, Details = ex.InnerException?.Message })
            {
                StatusCode = statusCode
            };

        }

        public static string HashSHA256(string text)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
