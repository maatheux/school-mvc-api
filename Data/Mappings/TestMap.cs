using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Mappings;

public class TestMap : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.ToTable("Test", "dbo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.Grade)
            .IsRequired()
            .HasColumnName("Grade")
            .HasColumnType("FLOAT");

        builder.HasIndex(x => x.Id, "IX_Test_Id")
            .IsUnique();

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Tests)
            .HasConstraintName("FK_Test_Student")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Tests)
            .HasConstraintName("FK_Test_Subject")
            .OnDelete(DeleteBehavior.Cascade);
    }
}