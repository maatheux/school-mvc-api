namespace SchoolSystem.Models;

public class SchoolClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public TimeOnly StartTime { get; set; } = new TimeOnly(0, 0);
    public TimeOnly EndTime { get; set; } = new TimeOnly(0, 0);
    public Subject Subject { get; set; } = null!;

    public List<Student> Students { get; set; } = new();
}