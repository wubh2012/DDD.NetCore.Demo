using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.NetCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.NetCore.UI.Controllers
{
    public class StudentController : Controller
    {
        IStudentAppService studentAppService;
        public IActionResult Index()
        {
            return View();
        }
    }
}