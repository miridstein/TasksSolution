using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasks.Web.Models;
using Tasks.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Tasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Authorize]
        public IActionResult Index()
        {

            var authDb = new UserRepository(_connectionString);
            var user = authDb.GetIdForEmail(User.Identity.Name);

            var repo = new TaskRepository(_connectionString);
            var a = repo.GetOpenAssignments();
            return View(a);
        }

        [HttpPost]
        public IActionResult AddTask(string name)
        {
            var a = new Assignment { Name = name, Status = Status.Incomplete };
            var repo = new TaskRepository(_connectionString);
            repo.AddAssignment(a);
            return Redirect("/home/index");
        }




    }
}
