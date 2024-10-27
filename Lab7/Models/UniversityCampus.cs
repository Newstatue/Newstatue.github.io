namespace Lab7.Models;

public class UniversityCampus
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>(); // 默认初始化为空列表
}