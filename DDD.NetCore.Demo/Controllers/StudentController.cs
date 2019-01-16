using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Application.ViewModel;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(studentViewModel);
                }
                studentAppService.Register(studentViewModel);
                ViewBag.Success = "Student Registered !";
                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = studentAppService.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }
            studentAppService.Update(studentViewModel);
            ViewBag.Success = "Student Updated!";

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            studentAppService.Remove(id.Value);
            return Json("delete success");
        }
    }
}