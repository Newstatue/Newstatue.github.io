namespace Lab8.Models;

public class Student
{
    public int ID { get; set; }
    public string? Name { get; set; } // 允许为 null
    public string? Address { get; set; } // 允许为 null
    public int CampusID { get; set; }
}
public class StudentList
{
    public List<Student> students { get; set; } = new();
}