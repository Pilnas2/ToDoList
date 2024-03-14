using System.Collections.ObjectModel;
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
            myCollectionView.ItemsSource = await database.GetItemsAsync();
        }

        void btnAddTask(object sender, EventArgs e)
        {
            AddTask.IsVisible = true;
        }

        async void OnEntryCompletedAsync(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }
    }
}
