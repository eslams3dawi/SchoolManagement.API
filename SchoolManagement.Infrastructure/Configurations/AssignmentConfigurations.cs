using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
                .HasKey(x => x.AssignmentId);
            builder
                .Property(x => x.AssignmentUrl)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
