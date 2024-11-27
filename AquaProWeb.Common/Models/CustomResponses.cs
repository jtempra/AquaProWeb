namespace AquaProWeb.Common.Models
{
    public class CustomResponses
    {
        public record RegistrationResponse(bool Flag = false, string Message = null!);
        public record LoginResponse(bool Flag = false, string Message = null!, UserSession UserSession = null!);
    }
}
