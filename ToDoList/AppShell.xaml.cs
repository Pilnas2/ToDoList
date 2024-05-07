using ToDoList.Models;
using ToDoList.Views;

namespace ToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new ToDoListCategory();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            CategoryListView.ItemsSource = await database.GetCategoriesAsync();
        }

        private void OnSeznamClicked(object sender, EventArgs e)
        {
            AddCategory.IsVisible = true;
        }
        async void OnCategoryDelete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item is null) return;
            var category = item.BindingContext as ToDoListCategory;
            if (category is null) return;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.DeleteCategoryAsync(category);
            OnAppearing();
        }

        async void OnCategoryAdd(object sender, EventArgs e)
        {
            var category = (ToDoListCategory)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveCategoryAsync(category);
            AddCategoryEntry.Text = "";
            OnAppearing();
            BindingContext = new ToDoListCategory();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedCategory = (ToDoListCategory)e.SelectedItem;
                var todoItemPage = new TodoItemPage();
                todoItemPage.CategoryId = selectedCategory.ID;
                await Navigation.PushAsync(todoItemPage);
                ((ListView)sender).SelectedItem = null;
            }
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
