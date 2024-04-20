using System.Collections.ObjectModel;
using System.ComponentModel;
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
            reminderDatePicker.MinimumDate = DateTime.Today;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }


        void BtnAddTask(object sender, EventArgs e)
        {
            if (AddTask.IsVisible)
            {
                OnEntryCompletedAsync(sender, e);
            }
            AddTask.IsVisible = true;

        }
        void HideKeyboard(object sender, EventArgs e)
        {
            entryAddTask.IsEnabled = false;
            //entryAddTask.IsEnabled = true;
        }
        void OnAddNoteClicked(object sender, EventArgs e)
        {
            AddNote.IsVisible = true;
        }
        void OnDueDateButtonClicked(object sender, EventArgs e)
        {
            AddDueDate.IsVisible = true;
        }
        void OnReminderDateButtonClicked(object sender, EventArgs e)
        {
            AddReminderDatePicker.IsVisible = true;
        }
        void Back(object sender, EventArgs e)
        {
            AddDueDatePicker.IsVisible = false;
            AddReminderDatePicker.IsVisible = false;
            AddNote.IsVisible = false;
        }

        void OnDueDatePickerButtonClicked(object sender, EventArgs e)
        {
            AddDueDatePicker.IsVisible = true;
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
        void OnReminderDateDone(object sender, EventArgs e)
        {
            AddReminderDatePicker.IsVisible = false;
        }
        void OnDueDateDone(object sender, EventArgs e)
        {
            AddDueDate.IsVisible = false;
            AddDueDatePicker.IsVisible = false;
        }
        void OnReminderDateimTimeDone(object sender, EventArgs e)
        {
            AddReminderDatePicker.IsVisible = false;
        }

        void OnAddNoteDone(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            todoItem.Note = EditorNote.Text;
            Back(sender, e);
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
        void OnPickDateDueDateDone(object sender, DateChangedEventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            todoItem.DueDate = e.NewDate;
            OnDueDateDone(sender, e);
        }
        void OnPickDateReminderDone(object sender, DateChangedEventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            todoItem.ReminderDate = e.NewDate;
        }

        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                HandleTimeChange();
                OnReminderDateimTimeDone(sender, e);
            }
        }
        private void HandleTimeChange()
        {
            var todoItem = (ToDoItem)BindingContext;
            todoItem.ReminderTime = tpReminderTime.Time;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedItem = (ToDoItem)e.SelectedItem;
                await Navigation.PushAsync(new ToDoItemDetail(selectedItem));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
