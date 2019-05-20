using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Data
{
    public class TaskContext : DbContext
    {

        private string _connectionString;

        public TaskContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
        }
    }
}
