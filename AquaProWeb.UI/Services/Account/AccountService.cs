using AquaProWeb.Common.Models;
using AquaProWeb.UI.Services.Contracts;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static AquaProWeb.Common.Models.CustomResponses;

namespace AquaProWeb.UI.Services.Account
{
    public class AccountService : IAccountService
    {
        // Constructor with Local Storage and Token-Free HttpClient.
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        public AccountService(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authentication/Login", model);
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            return response!;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/register", model);
            var response = await result.Content.ReadFromJsonAsync<RegistrationResponse>();
            return response!;
        }


        private async Task<bool> GetNewToken()
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
                return false;

            var getNetTokenAndRefreshToken = await _httpClient.PostAsJsonAsync("api/authentication/GetNewToken", DeSerializedUserSession(token));
            var response = await getNetTokenAndRefreshToken.Content.ReadFromJsonAsync<UserSession>();

            if (response is null)
                return false;

            var serializedUserSession = SerializedUserSession(response!);
            await _localStorageService.RemoveItemAsync("token");
            await _localStorageService.SetItemAsync("token", serializedUserSession);
            await SecuredClient();
            return true;
        }

        private async Task<HttpClient> SecuredClient()
        {
            var client = new HttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            var userSession = DeSerializedUserSession(token);
            if (userSession is null)
                return client;

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userSession.Token);
            return client;
        }

        private static UserSession DeSerializedUserSession(string SerialisedString)
        {
            return JsonConvert.DeserializeObject<UserSession>(SerialisedString)!;
        }

        private static string SerializedUserSession(UserSession userSession)
        {
            return JsonConvert.SerializeObject(userSession);
        }
    }
}
