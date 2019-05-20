using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
