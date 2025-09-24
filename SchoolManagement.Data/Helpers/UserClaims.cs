namespace SchoolManagement.Data.Helpers
{
    public class UserClaims
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> roles { get; set; }
    }
}
