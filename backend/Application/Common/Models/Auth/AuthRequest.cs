namespace Application.Common.Models.Auth
{
    public class AuthRequest
    {
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
