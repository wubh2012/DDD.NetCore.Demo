﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Application.ViewModel;
using DDD.NetCore.Domain.CommandHandlers;
using DDD.NetCore.Domain.Commands;
using DDD.NetCore.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.NetCore.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService studentAppService;
        // 将领域通知处理程序注入Controller
        private readonly DomainNotificationHandler notifications;
        public StudentController(IStudentAppService _studentAppService, INotificationHandler<DomainNotification> _notifications)
        {
            studentAppService = _studentAppService;
            notifications = (DomainNotificationHandler)_notifications;

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
                ViewBag.ErrorData = null;
                if (!ModelState.IsValid)
                {
                    return View(studentViewModel);
                }

                #region 删除 -- 使用命令验证，采用构造函数方法实例
                // 
                //RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate);
                //// 如果命令无效，证明有错误
                //if (!registerStudentCommand.IsValid())
                //{
                //    List<string> errorInfo = new List<string>();
                //    //获取到错误，请思考这个Result从哪里来的 
                //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                //    {
                //        errorInfo.Add(error.ErrorMessage);
                //    }
                //    //对错误进行记录，还需要抛给前台
                //    ViewBag.ErrorData = errorInfo;
                //    return View(studentViewModel);
                //}
                #endregion


                studentAppService.Register(studentViewModel);

                if (!notifications.HasNotifications())
                {
                    ViewBag.Success = "Student Registered!";
                }

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