namespace SchoolSystem.Models;

public class Student
{
    public uint Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
    public string PasswordHash { get; set; } = null!;

    public List<SchoolClass> Classes { get; set; } = new();
    public List<Test> Tests { get; set; } = new();
}