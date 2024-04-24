using Plugin.LocalNotification;
using System;
using System.Timers;
using ToDoList;
using ToDoList.Models;

namespace MyApp
{
    public class DatabaseChecker : ContentPage
    {
        private readonly System.Timers.Timer _timer;

        public DatabaseChecker()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = true;
            _timer.Elapsed += CheckDatabaseAsync;
            _timer.Interval = TimeSpan.FromSeconds(60).TotalMilliseconds;
            _timer.Start();
        }

        private async void CheckDatabaseAsync(object sender, ElapsedEventArgs e)
        {
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            var matchingItems = await database.GetItemsNotDoneAsync();

            foreach (var item in matchingItems)
            {
                Console.WriteLine($"ID: {item.ID}, Název: {item.Name}, Datum: {item.DueDate}");
                var request = new NotificationRequest
                {
                    Title = "Je na čase splnit váš úkol: \n" + item.Name,
                    Description = "termín splnění: " + item.DueDate.ToString(),
                };
                await LocalNotificationCenter.Current.Show(request);
            }
        }
    }
}

