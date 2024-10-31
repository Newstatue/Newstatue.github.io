using System.Text.Json;

namespace Lab8.Models;
public class DataService
{
    private readonly List<Student> students;
    private readonly List<UniversityCampus> campuses;

    public DataService(IWebHostEnvironment env)
    {
        students = LoadStudents(env);
        campuses = LoadCampuses(env);
    }

    private List<Student> LoadStudents(IWebHostEnvironment env)
    {
        var studentsPath = Path.Combine(env.WebRootPath, "students.json");
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

    private List<UniversityCampus> LoadCampuses(IWebHostEnvironment env)
    {
        var campusesPath = Path.Combine(env.WebRootPath, "campuses.json");
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

    public List<Student> GetStudents()
    {
        return students;
    }

    public List<UniversityCampus> GetCampuses()
    {
        return campuses;
    }
}