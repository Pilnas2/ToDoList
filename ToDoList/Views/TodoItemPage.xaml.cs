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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }


        void btnAddTask(object sender, EventArgs e)
        {
            AddTask.IsVisible = true;
        }
        void hideKeyboard(object sender, EventArgs e)
        {
            entryAddTask.IsEnabled = false;
            entryAddTask.IsEnabled = true;
        }

        async void OnEntryCompletedAsync(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            hideKeyboard(sender, e);
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

    }
}
