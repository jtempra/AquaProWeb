using AquaProWeb.Common.Models;
using static AquaProWeb.Common.Models.CustomResponses;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IAccountService
    {
        //public Task<FormResult> RegisterAsync(string email, string password);
        //public Task<FormResult> LoginAsync(string email, string password);
        //public Task LogoutAsync();
        //public Task<bool> CheckAuthenticatedAsync();


        Task<RegistrationResponse> RegisterAsync(RegisterModel model);
        Task<LoginResponse> LoginAsync(LoginModel model);
    }
}
