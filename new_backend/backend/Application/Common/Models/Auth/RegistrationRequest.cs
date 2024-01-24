namespace Application.Common.Models.Auth
{
    public class RegistrationRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? ContactNo { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
