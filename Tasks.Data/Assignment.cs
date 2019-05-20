using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Data
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public Status Status { get; set; }
        public string UserName { get; set; }
    }
}
