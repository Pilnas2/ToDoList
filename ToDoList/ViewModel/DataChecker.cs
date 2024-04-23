using Plugin.LocalNotification;
using System;
using System.Timers;
using ToDoList;

namespace MyApp
{
    public class DatabaseChecker : ContentPage
    {
        private readonly System.Timers.Timer _timer;
        private readonly TodoItemDatabase _databaseService; // Nahraďte tím, co používáte pro přístup k databázi

        public DatabaseChecker()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = true;
            _timer.Elapsed += CheckDatabase;
            _timer.Interval = TimeSpan.FromSeconds(10).TotalMilliseconds;
            _timer.Start();
        }

        private void CheckDatabase(object sender, ElapsedEventArgs e)
        {

            var request = new NotificationRequest
            {
                Title = "AHOJ",
                Subtitle = "hello",
                Description = "nevim",
                Schedule = new NotificationRequestSchedule
                {

                    NotifyTime = DateTime.Now,
                    NotifyRepeatInterval = TimeSpan.FromDays(1),
                }
            };
            LocalNotificationCenter.Current.Show(request);

            //DateTime currentDate = DateTime.Now.Date; // Aktuální datum bez času

            //DateTime cas = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 03, 0);
            //int porovnani = DateTime.Compare(currentDate, cas);
            //if (porovnani == -1)
            //{
            //    var request = new NotificationRequest
            //    {
            //        Title = "AHOJ",
            //        Schedule = new NotificationRequestSchedule
            //        {
            //            NotifyTime = DateTime.Now,
            //            NotifyRepeatInterval = TimeSpan.FromDays(1),
            //        }
            //    };
            //    LocalNotificationCenter.Current.Show(request);
            //}
        }
    }
}
