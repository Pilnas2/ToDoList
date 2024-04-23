using Plugin.LocalNotification;
using ToDoList.Models;

namespace ToDoList.Views;

public partial class ToDoItemDetail : ContentPage
{
    public ToDoItemDetail(ToDoItem item)
    {
        InitializeComponent();
        BindingContext = item;
    }

    async void UpdateItemAsync(object sender, EventArgs e)
    {
        var todoItem = (ToDoItem)BindingContext;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.SaveItemAsync(todoItem);
        await Navigation.PushAsync(new TodoItemPage());
    }
    async void DeleteItemAsync(object sender, EventArgs e)
    {
        var todoItem = (ToDoItem)BindingContext;
        if (todoItem is null) return;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.DeleteItemAsync(todoItem);
        await Navigation.PushAsync(new TodoItemPage());
    }
    //void InitalizeChecker(ToDoItem item)
    //{
    //    if (item.DueDate.HasValue)
    //    {
    //        reminderDatePickerEdit = new DateTime(item.DueDate);
    //    }
    //}
}