namespace SchoolManagement.Data.Helpers
{
    public class JwtAuthResponse
    {
        public string AcessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string RefershTokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
