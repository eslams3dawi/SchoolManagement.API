using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Identity
{
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public string? JwtId { get; set; }

        public string? RefreshToken { get; set; }
        public string? Token { get; set; }

        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [InverseProperty(nameof(ApplicationUser.UserRefreshTokens))]
        public virtual ApplicationUser? User { get; set; }
    }
}
