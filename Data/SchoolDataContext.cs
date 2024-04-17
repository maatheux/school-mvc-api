using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Mappings;
using SchoolSystem.Models;

namespace SchoolSystem.Data;

public class SchoolDataContext(DbContextOptions<SchoolDataContext> options) : DbContext(options)
{
    public DbSet<SchoolClass> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Test> Tests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClassMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
        modelBuilder.ApplyConfiguration(new SubjectMap());
        modelBuilder.ApplyConfiguration(new TeacherMap());
        modelBuilder.ApplyConfiguration(new TestMap());
    }
}