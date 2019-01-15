using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.NetCore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DDD.NetCore.UI.Controllers
{
    public class StudentController : Controller
    {
        IStudentAppService studentAppService;
        public StudentController(IStudentAppService _studentAppService)
        {
            studentAppService = _studentAppService;

        }

        public IActionResult InitData()
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
            return Json("初始化数据成功");
        }
        public IActionResult Index()
        {

            var students = studentAppService.GetAll();
            return View(students);
        }
    }
}