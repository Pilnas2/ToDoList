using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.VisualBasic;
using ToDoList.Models;

namespace ToDoList.Views
{
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
            BindingContext = new ToDoItem();
            dueDatePicker.MinimumDate = DateTime.Today;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }


        void BtnAddTask(object sender, EventArgs e)
        {
            if (AddTask.IsVisible == true)
            {
                OnEntryCompletedAsync(sender, e);
            }
            AddTask.IsVisible = true;

        }
        void HideKeyboard(object sender, EventArgs e)
        {
            entryAddTask.IsEnabled = false;
            entryAddTask.IsEnabled = true;
        }
        void OnDueDateButtonClicked(object sender, EventArgs e)
        {
            AddDueDate.IsVisible = true;
        }

        void OnDueDatePickerButtonClicked(object sender, EventArgs e)
        {
            DueDatePicker.IsVisible = true;
        }

        async void OnEntryCompletedAsync(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            HideKeyboard(sender, e);
            await Navigation.PushAsync(new TodoItemPage());
        }
        async void OnItemDeletedAsync(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item is null) return;
            var todoItem = item.BindingContext as ToDoItem;
            if (todoItem is null) return;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PushAsync(new TodoItemPage());
        }
        void OnDueDateDone(object sender, EventArgs e)
        {
            AddDueDate.IsVisible = false;
        }
        void OnTodayDueDateDone(object sender, EventArgs e)
        {
            var date = DateTime.Today;
            var todoItem = (ToDoItem)BindingContext;
            todoItem.DueDate = date;
            OnDueDateDone(sender, e);
        }

        void OnTomorrowDueDateDone(object sender, EventArgs e)
        {
            var date = DateTime.Today.AddDays(1);
            var todoItem = (ToDoItem)BindingContext;
            todoItem.DueDate = date;
            OnDueDateDone(sender, e);
        }
        void OnPickDateDone(object sender, DateChangedEventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            todoItem.DueDate = e.NewDate;
            DueDatePicker.IsVisible = false;
            AddDueDate.IsVisible = false;
        }

    }
}
