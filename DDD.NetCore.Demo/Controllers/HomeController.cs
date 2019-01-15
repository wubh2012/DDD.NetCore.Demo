using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDD.NetCore.UI.Models;
using DDD.NetCore.Application.Interfaces;

namespace DDD.NetCore.UI.Controllers
{
    public class HomeController : Controller
    {
        IStudentAppService studentAppService;

        public HomeController(IStudentAppService _studentAppService)
        {
            studentAppService = _studentAppService;

        }
        public IActionResult Index()
        {
            for (int i = 0; i < 5; i++)
            {
                studentAppService.Register(new Application.ViewModel.StudentViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = $"TestName{i}",
                    Email = $"aabbccdd0{i}@qq.com",
                    BirthDate = DateTime.Now.AddMonths(0 - i)
                });
            }

            var students = studentAppService.GetAll();
            return View(students);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
