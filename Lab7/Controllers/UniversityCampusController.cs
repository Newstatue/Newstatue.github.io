using Lab7.Models;

namespace Lab7.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

    public class UniversityCampusController : Controller
    {
        private List<UniversityCampus> _campuses;

        public UniversityCampusController()
        {
            // 初始化模拟数据
            _campuses = new List<UniversityCampus>
            {
                new UniversityCampus
                {
                    ID = 1,
                    Name = "Main Campus",
                    Students = new List<Student>
                    {
                        new Student { ID = 1, Name = "Alice", Address = "123 Main St" },
                        new Student { ID = 2, Name = "Bob", Address = "456 Maple St" }
                    }
                },
                new UniversityCampus
                {
                    ID = 2,
                    Name = "Downtown Campus",
                    Students = new List<Student>
                    {
                        new Student { ID = 3, Name = "Charlie", Address = "789 Oak St" }
                    }
                },
                new UniversityCampus
                {
                    ID = 3,
                    Name = "Suburban Campus",
                    Students = new List<Student>() // 空列表，确保非null
                }
            };
        }

        public IActionResult Index()
        {
            return View(_campuses);
        }
    }
