using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Mappings;

public class ClassMap : IEntityTypeConfiguration<SchoolClass>
{
    public void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.ToTable("Class", "dbo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.StartTime)
            .IsRequired()
            .HasColumnName("StartTime")
            .HasColumnType("TIME");
        
        builder.Property(x => x.EndTime)
            .IsRequired()
            .HasColumnName("EndTime")
            .HasColumnType("TIME");

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Classes)
            .HasConstraintName("FK_Class_Subject")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Students)
            .WithMany(x => x.Classes)
            .UsingEntity<Dictionary<string, object>>(
                "StudentClass",
                student => student.HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .HasConstraintName("FK_StudentClass_StudentId")
                    .OnDelete(DeleteBehavior.Cascade),
                classModel => classModel.HasOne<SchoolClass>()
                    .WithMany()
                    .HasForeignKey("ClassId")
                    .HasConstraintName("FK_StudentClass_ClassId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}