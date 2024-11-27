namespace AquaProWeb.Common.Models
{
    public class UserSession
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
