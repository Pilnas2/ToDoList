using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReminderDate { get; set; }

        public TimeSpan? ReminderTime { get; set; }
    }
}
