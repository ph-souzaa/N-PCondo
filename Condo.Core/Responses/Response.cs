using System.Text.Json.Serialization;

namespace Condo.Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response()
            => _code = Configuration.DefaultStatusCode;

        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            Message = message;
            _code = code;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess
            => _code is >= 200 and <= 299;

        public static Response<TData> SuccessMessage(TData? data, string? message = "Success")
        {
            return new Response<TData>(data, 200, message);
        }

        public static Response<TData> Error(string message, int statusCode = 400)
        {
            return new Response<TData>(default, statusCode, message);
        }
    }
}
