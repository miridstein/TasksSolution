using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Data
{
    public class TaskRepository
    {
        private string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Assignment> GetOpenAssignments()
        {
            using (var cc = new TaskContext(_connectionString))
            {
                return cc.Assignments.Where(a=>a.Status!=Status.Complete).ToList();
            }
        }
        public void AddAssignment(Assignment assignment)
        {
            using (var cc = new TaskContext(_connectionString))
            {
                cc.Assignments.Add(assignment);
                cc.SaveChanges();
            }
        }
        public void UpdateAssignment(int taskId,Status s,int userId,string userName)
        {
            using (var tc = new TaskContext(_connectionString))
            {
               var assignment= tc.Assignments.Where(t => t.Id == taskId).FirstOrDefault();
                assignment.Status = s;
                assignment.UserId = userId;
                assignment.UserName = userName;
                tc.SaveChanges();
            }
        }
    }
}
