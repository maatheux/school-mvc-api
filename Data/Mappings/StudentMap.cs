using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student", "dbo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(seed: 100000);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Age)
            .IsRequired()
            .HasColumnName("Age")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasMaxLength(255);

        builder.HasIndex(x => x.Email, "IX_Student_Email")
            .IsUnique();

        builder.HasMany(x => x.Classes)
            .WithMany(x => x.Students)
            .UsingEntity<Dictionary<string, object>>(
                "StudentClass",
                classModel => classModel.HasOne<SchoolClass>()
                    .WithMany()
                    .HasForeignKey("ClassId")
                    .HasConstraintName("FK_StudentClass_ClassId")
                    .OnDelete(DeleteBehavior.Cascade),
                student => student.HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .HasConstraintName("FK_StudentClass_StudentId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

    }
}