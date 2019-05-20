using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasks.Web.Models;
using Tasks.Data;
using Microsoft.Extensions.Configuration;

namespace Tasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            var repo = new TaskRepository(_connectionString);
           var a= repo.GetOpenAssignments();
            return View(a);
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult AddTask(string name)
        {
            

            return View();
        }


        
    }
}
