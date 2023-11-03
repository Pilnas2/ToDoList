using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    internal class Reminders
    {
        public int reminder_id { get; set; }
        public int task_id { get; set; }
        public DateTime date_of_reminder { get; set; }

    }
}
