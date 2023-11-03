using System;
using System.Data.SQLite;

namespace ToDoList

{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ToDoList());


            //string connectionString = "Data Source=C:\\Skola\\C# II\\ToDoList\\ToDoList\\ToDoList.db;Version=3;";
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();

            //    string sql = "SELECT * FROM ukol";
            //    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            //    {
            //        using (SQLiteDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = reader.GetInt32(0);
            //                string taskName = reader.GetString(1);
            //                string popis = reader.GetString(2);
            //                string datumDokonceni = reader.GetString(3);
            //                int stav = reader.GetInt32(4);


            //                Console.WriteLine($"ID: {id}, Task Name: {taskName}, popis: {popis}, datumUkonceni {datumDokonceni}, Completed: {stav}");
            //            }
            //        }
            //    }
            //}
        }
    }
}