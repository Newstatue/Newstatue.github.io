namespace Lab8.Models;

public class UniversityCampus
{
    public int ID { get; set; }
    public string? Name { get; set; } // 允许为 null
    public List<Student> Students { get; set; } = new(); // 初始化空集合
}