using System.Threading;
using ToDoList.ViewModel;

namespace ToDoList
{
    public partial class App : Application
    {
        TheTheme theme;
        public App(TheTheme theme)
        {
            InitializeComponent();
            MainPage = new AppShell();
            this.theme = theme;
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                theme.SetTheme();

            }
            catch (Exception)
            {

            }
        }

        protected override void OnSleep()
        {
            theme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            theme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                theme.SetTheme();
            });
        }
    }
}
