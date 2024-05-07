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
                CreateTableResult result2 = await Database.CreateTableAsync<ToDoListCategory>();
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
        public Task<List<ToDoItem>> GetItemsAsync(int categoryId)
        {
            return Database.Table<ToDoItem>().Where(item => item.ToDoListCategoryId == categoryId).ToListAsync();
        }

        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            return Database.Table<ToDoItem>().Where(i => !i.IsCompleted).ToListAsync();
        }
        public Task<List<ToDoItem>> GetItemsDoneAsync()
        {
            return Database.Table<ToDoItem>().Where(i => i.IsCompleted).ToListAsync();
        }

        public Task<List<ToDoItem>> GetItemsMatching()
        {
            long reminderDate = DateTime.Now.Date.Ticks;
            DateTime now = DateTime.Now;

            long reminderTime = now.Hour * TimeSpan.TicksPerHour + now.Minute * TimeSpan.TicksPerMinute;

            return Database.QueryAsync<ToDoItem>("SELECT * FROM [TodoItem] WHERE ReminderDate = ? AND ReminderTime = ?", reminderDate, reminderTime);
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

        public Task<List<ToDoListCategory>> GetCategoriesAsync()
        {
            return Database.Table<ToDoListCategory>().ToListAsync();
        }

        public Task<ToDoListCategory> GetCategoryAsync(int id)
        {
            return Database.Table<ToDoListCategory>().Where(c => c.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoryAsync(ToDoListCategory category)
        {
            if (category.ID != 0)
            {
                return Database.UpdateAsync(category);
            }
            else
            {
                return Database.InsertAsync(category);
            }
        }

        public Task<int> DeleteCategoryAsync(ToDoListCategory category)
        {
            return Database.DeleteAsync(category);
        }

    }
}
