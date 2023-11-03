using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    internal class Tasks
    {
        public int task_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime completion_date { get; set; }
        public string status { get; set; }
        public int list_id { get; set; }
    }
}
