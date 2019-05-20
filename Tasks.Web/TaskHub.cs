using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Data;

namespace Tasks.Web
{
    public class TaskHub : Hub
    {

        private string _connectionString;
        private static int _count;

        public TaskHub(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }


        public void UpdateAssignment(int taskId,Status status)
        {
            TaskRepository repo = new TaskRepository(_connectionString);
            UserRepository ur = new UserRepository(_connectionString);
            int userId = ur.GetIdForEmail(Context.User.Identity.Name);
            string userName = (Context.User.Identity.Name);
            repo.UpdateAssignment(taskId, status, userId,userName);
            var tasks = repo.GetOpenAssignments();
            //Context.User.Identity.Name
            Clients.All.SendAsync("TasksUpdate", tasks);
        }
        
        public void NewUser()
        {
            _count++;
            Clients.All.SendAsync("NewCount", new { count = _count });
        }
    }
}


