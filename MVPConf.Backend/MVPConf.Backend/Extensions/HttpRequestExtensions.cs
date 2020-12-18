using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace MVPConf.Backend.Extensions
{
    public static class HttpRequestExtensions
    {

        public static async Task<HttpResponseBody<T>> GetBodyAsync<T>(this HttpRequest request)
        {
            HttpResponseBody<T> body = new HttpResponseBody<T>();

            string bodyStr = await request.ReadAsStringAsync();

            body.Value = JsonConvert.DeserializeObject<T>(bodyStr);

            List<ValidationResult> validations = new List<ValidationResult>();

            body.IsValid = Validator.TryValidateObject(body.Value, new ValidationContext(body.Value, null, null), validations, true);
            body.ValidationResults = validations;

            return body;
        }
    }

    public class HttpResponseBody<T>
    {
        public bool IsValid { get; set; }

        public T Value { get; set; }

        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
