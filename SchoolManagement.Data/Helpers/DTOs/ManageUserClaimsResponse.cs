namespace SchoolManagement.Data.Helpers.DTOs
{
    public class ManageUserClaimsResponse
    {
        public string UserId { get; set; }
        public List<Claims> Claims { get; set; }
    }
    public class Claims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
