using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers;

public class StudentsController : Controller
{
    private readonly DataService _dataService;

    public StudentsController(IWebHostEnvironment env)
    {
        _dataService = new DataService(env);
    }

    public IActionResult Index(string campusName, string studentName)
    {
        var students = _dataService.GetStudents();
        var campuses = _dataService.GetCampuses();

        ViewBag.Campuses = campuses;

        // 根据校园名称过滤学生
        if (!string.IsNullOrEmpty(campusName))
        {
            var selectedCampusId = campuses.FirstOrDefault(c => c.Name == campusName)?.ID;
            if (selectedCampusId.HasValue)
            {
                students = students.Where(s => s.CampusID == selectedCampusId.Value).ToList();
            }
        }

        // 根据学生姓名进行顺序匹配过滤
        if (!string.IsNullOrEmpty(studentName))
        {
            students = students
                .Where(s => s.Name != null && s.Name.StartsWith(studentName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        return View(students);
    }
}