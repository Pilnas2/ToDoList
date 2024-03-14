using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList
{
    public class TodoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TodoItemDatabase> Instance = new AsyncLazy<TodoItemDatabase>(async () =>
        {
            var instance = new TodoItemDatabase();
            try
            {
                CreateTableResult result = await Database.CreateTableAsync<ToDoItem>();
            }
            catch (Exception ex)
            {
                throw;
            }

            return instance;
        });

        public TodoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<ToDoItem>> GetItemsAsync()
        {
            return Database.Table<ToDoItem>().ToListAsync();
        }

        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ToDoItem>("SELECT * FROM [TodoItem]");
        }

        public Task<ToDoItem> GetItemAsync(int id)
        {
            return Database.Table<ToDoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDoItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ToDoItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
