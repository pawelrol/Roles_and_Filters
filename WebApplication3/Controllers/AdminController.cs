using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]                        //do tego kontrolera wpusci tylko uzytkownika z rolą admin
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}