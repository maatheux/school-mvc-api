namespace SchoolSystem.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Teacher Teacher { get; set; } = null!;

    public List<SchoolClass> Classes { get; set; } = new();
    public List<Test> Tests { get; set; } = new();
}