using System.Text.Json;
using Lab8.Models;

namespace Lab8.Data;
public class DataService
    {
        private readonly IWebHostEnvironment _env;
        private List<Student> students;
        private List<UniversityCampus> campuses;

        public DataService(IWebHostEnvironment env)
        {
            _env = env;
            students = LoadStudents();
            campuses = LoadCampuses();
        }

        // 加载学生数据
        private List<Student> LoadStudents()
        {
            var studentsPath = Path.Combine(_env.WebRootPath, "students.json");
            if (File.Exists(studentsPath))
            {
                var json = File.ReadAllText(studentsPath);
                try
                {
                    var studentList = JsonSerializer.Deserialize<StudentList>(json);
                    return studentList?.students ?? new List<Student>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Error: {ex.Message}");
                    return new List<Student>();
                }
            }
            return new List<Student>();
        }

        // 加载校园数据
        private List<UniversityCampus> LoadCampuses()
        {
            var campusesPath = Path.Combine(_env.WebRootPath, "campuses.json");
            if (File.Exists(campusesPath))
            {
                var json = File.ReadAllText(campusesPath);
                try
                {
                    return JsonSerializer.Deserialize<List<UniversityCampus>>(json) ?? new List<UniversityCampus>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Error: {ex.Message}");
                    return new List<UniversityCampus>();
                }
            }
            return new List<UniversityCampus>();
        }

        // 获取学生列表
        public List<Student> GetStudents() => students;

        // 获取校园列表
        public List<UniversityCampus> GetCampuses() => campuses;

        // 添加新学生并保存到文件
        public void AddStudent(Student newStudent)
        {
            // 为新学生分配唯一 ID，使用当前最大 ID + 1
            if (students.Any())
            {
                newStudent.ID = students.Max(s => s.ID) + 1;
            }
            else
            {
                newStudent.ID = 1; // 如果没有学生，ID 从 1 开始
            }

            students.Add(newStudent);
            SaveStudents();
        }

        // 保存学生列表到 JSON 文件
        private void SaveStudents()
        {
            var studentsPath = Path.Combine(_env.WebRootPath, "students.json");
            var json = JsonSerializer.Serialize(new StudentList { students = students });
            File.WriteAllText(studentsPath, json);
        }
    }

    // 学生列表的包装类
    public class StudentList
    {
        public List<Student> students { get; set; }
    }