namespace SchoolSystem.Models;

public class Test
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime TestDate { get; set; } = new DateTime(2020, 1, 1);
    public float Grade { get; set; }
    public Student Student { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}