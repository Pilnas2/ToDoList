using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Models
{
    [Alias("todo_list")]
    internal class ToDoItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int id { get; set; }

        public string Description { get; set; } = string.Empty;

        [References(typeof(Category))]
        public int CategoryId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

        public bool Done { get; set; } = false;

        public Category GetCategory() => DbContext.GetInstance().SingleById<Category>(this.CategoryId);
    }
}
