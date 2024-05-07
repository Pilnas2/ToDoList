using Plugin.LocalNotification;
using System;
using System.Threading;
using System.Timers;
using ToDoList;
using ToDoList.Models;
using ToDoList.Views;

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

            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }
        private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        {
            if (e.IsDismissed)
            {
                LocalNotificationCenter.Current.Cancel(e.Request.NotificationId);
            }
        }

        private async void CheckDatabaseAsync(object sender, ElapsedEventArgs e)
        {
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            var matchingItems = await database.GetItemsMatching();

            foreach (var item in matchingItems)
            {
                var request = new NotificationRequest
                {
                    Title = "Je na čase splnit váš úkol: \n" + item.Name,
                    Description = "termín splnění: " + (item.DueDate != null ? item.DueDate.Value.Date.ToString("yyyy-MM-dd") : "N/A"),
                };
                await LocalNotificationCenter.Current.Show(request);
            }
        }
    }
}

