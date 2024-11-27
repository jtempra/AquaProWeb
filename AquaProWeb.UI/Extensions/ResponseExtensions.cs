using AquaProWeb.Common.Wrapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AquaProWeb.UI.Extensions
{
    public static class ResponseExtensions
    {
        public static async Task<ResponseWrapper<T>> ToResponse<T>(this HttpResponseMessage responseMessage)
        {
            var responseAsString = await responseMessage.Content.ReadAsStringAsync();

            var responseObject = JsonSerializer.Deserialize<ResponseWrapper<T>>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return responseObject;
        }
    }
}
