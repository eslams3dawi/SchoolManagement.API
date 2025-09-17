﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class InstructorSubjectConfigurations : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder
                .HasKey(x => new { x.InstructorId, x.SubjectId });

            builder
                .HasOne(x => x.Instructor)
                .WithMany(x => x.InstructorSubjects)
                .HasForeignKey(x => x.InstructorId);
            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.InstructorSubjects)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
