using ToDoList.Models;

namespace ToDoList.Views;

public partial class ToDoItemDetail : ContentPage
{
    public ToDoItemDetail(ToDoItem item)
    {
        InitializeComponent();
        BindingContext = item;
    }
}