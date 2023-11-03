using System;
using System.Data;
using ServiceStack.OrmLite;
using System.Data.SQLite;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess
{


    internal class DbContext
    {
        private static IDbConnection _db;
        public static Exception Exception;

        public static IDbConnection GetInstance()
        {

            var dbFactory = new OrmLiteConnectionFactory(
                "Data Source=Database\\todoApp.db;Version=3;", SqliteDialect.Provider);

            try
            {
                if (_db == null)
                {
                    _db = dbFactory.Open();
                    Migrate();
                }

                if (_db.State == ConnectionState.Broken || _db.State == ConnectionState.Closed)
                    _db = dbFactory.Open();

                return _db;
            }
            catch (Exception err)
            {
                Exception = err;
                return null;
            }
        }

        private static void Migrate()
        {
            var db = GetInstance();

            if (db.CreateTableIfNotExists<Category>())
            {
                db.Save(new Category() { CategoryName = "Personal" });
                db.Save(new Category() { CategoryName = "Work" });
                db.Save(new Category() { CategoryName = "School" });
            }

            if (db.CreateTableIfNotExists<ToDoItem>())
            {
                db.Save(new ToDoItem()
                {

                    CategoryId = 1,
                    Description = "udelej obed"

                });
                db.Save(new ToDoItem()
                {

                    CategoryId = 1,
                    Description = "uklid doma"

                });
            }
        }
    }
}
