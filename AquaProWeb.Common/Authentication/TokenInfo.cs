namespace AquaProWeb.Common.Authentication
{
    public class TokenInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }
}
