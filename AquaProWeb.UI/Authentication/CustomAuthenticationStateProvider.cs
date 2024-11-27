using AquaProWeb.Common.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AquaProWeb.UI.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        //Constructor with instances.
        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly ILocalStorageService localStorageService;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        // Override Default Method to authenticate and deauthenticate user during page navigations.
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
                return await Task.FromResult(new AuthenticationState(anonymous));

            try
            {
                var userSession = DeSerializedUserSession(token);
                var (name, email, role) = await GetClaimsFromJWT(userSession.Token!);
                return await Task.FromResult(new AuthenticationState(SetClaimsPrincipal(name, email, role)));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }

        }

        // Update Token by setting up or deleting from local storage
        public async Task UpdateAuthenticationState(UserSession userSession)
        {

            ClaimsPrincipal claimsPrincipal;
            if (!string.IsNullOrEmpty(userSession.Token))
            {
                await localStorageService.SetItemAsync("token", SerializedUserSession(userSession));
                var (name, email, role) = await GetClaimsFromJWT(userSession.Token!);
                claimsPrincipal = SetClaimsPrincipal(name, email, role);
            }
            else
            {
                claimsPrincipal = anonymous;
                await localStorageService.RemoveItemAsync("token");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        // General methods
        private static ClaimsPrincipal SetClaimsPrincipal(string name, string email, string role)
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new(ClaimTypes.Name, name),
                    new(ClaimTypes.Email, email),
                    new(ClaimTypes.Role, role)
                }, "JwtAuth"));
            return claimsPrincipal;
        }

        private static async Task<(string name, string email, string role)> GetClaimsFromJWT(string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                var claims = token.Claims;

                var role = claims.First(_ => _.Type == ClaimTypes.Role).Value;
                var name = claims.First(_ => _.Type == ClaimTypes.Name).Value;
                var email = claims.First(_ => _.Type == ClaimTypes.Email).Value;

                return (name.ToString(), email.ToString(), role.ToString());
            }
            catch { throw new Exception("something happened"); }
        }

        private static string SerializedUserSession(UserSession userSession)
        {
            return JsonConvert.SerializeObject(userSession);
        }

        private static UserSession DeSerializedUserSession(string SerialisedString)
        {
            return JsonConvert.DeserializeObject<UserSession>(SerialisedString)!;
        }

    }
}
