using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Models
{

    [Alias("categories")]
    internal class Category
    {
        [PrimaryKey]
        [AutoIncrement]
        public int id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public static Category GetCategoryByName(string name)
        {
            return DbContext.GetInstance()
        .Single<Category>(r => string.Equals(r.CategoryName, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
