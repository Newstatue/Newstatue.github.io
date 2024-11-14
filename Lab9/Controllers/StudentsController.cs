using Lab8.Data;
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

        // 显示学生列表并实现分页和过滤
        public IActionResult Index(string campusName, string studentName, int page = 1, int pageSize = 10)
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

            // 添加分页
            var totalStudents = students.Count;
            students = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // 设置分页信息
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalStudents / (double)pageSize);

            // 返回视图
            return View(students);
        }

        // 新建学生视图
        public IActionResult Create()
        {
            var campuses = _dataService.GetCampuses();
            ViewBag.Campuses = campuses;
            return View();
        }

        // 处理新建学生表单提交
        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            // 校验模型
            if (ModelState.IsValid)
            {
                _dataService.AddStudent(newStudent);
                return RedirectToAction(nameof(Index));
            }

            // 如果模型验证失败，则重新显示表单
            ViewBag.Campuses = _dataService.GetCampuses();
            return View(newStudent);
        }

        // 分页导航按钮功能
        public IActionResult NextPage(string campusName, string studentName, int page, int pageSize)
        {
            return RedirectToAction(nameof(Index), new { campusName, studentName, page = page + 1, pageSize });
        }

        public IActionResult PreviousPage(string campusName, string studentName, int page, int pageSize)
        {
            return RedirectToAction(nameof(Index), new { campusName, studentName, page = page - 1, pageSize });
        }
    }