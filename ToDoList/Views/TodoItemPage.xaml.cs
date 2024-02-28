using Microsoft.VisualBasic;
using ToDoList.Models;

namespace ToDoList.Views;

public partial class TodoItemPage : ContentPage
{
    public TodoItemPage()
    {
        InitializeComponent();

        List<ToDoItems> myList = new List<ToDoItems>
        {
            new ToDoItems{Name = "�kol1", DueDate = "2021"},
            new ToDoItems{Name = "�kol2", DueDate = "2022"},
            new ToDoItems{Name = "�kol3", DueDate = "2023"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
            new ToDoItems{Name = "�kol4", DueDate = "2024"},
        };
        myListView.ItemsSource = myList;
    }
}