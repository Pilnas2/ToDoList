using System.Data;
using System.Data.SQLite;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        DataTable todoList = new DataTable();
        bool isEditing = false;
        string allPlaceholder = "Všechny";
        private string connectionString = "Data Source=C:\\Skola\\C# II\\ToDoList\\ToDoList\\ToDoList\\todoList.db";


        public ToDoList()
        {
            InitializeComponent();

        }




        public void ToDoList_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Název");
            todoList.Columns.Add("Popis");
            todoList.Columns.Add("Datum splnìní");
            todoList.Columns.Add("Kategorie");
            todoList.Columns.Add("Stav");


            todoListGridView.DataSource = todoList;

            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.MinDate = DateTime.Today;
            categoryComboBox1.Items.Add(allPlaceholder);
            categoryComboBox1.SelectedItem = allPlaceholder;
            filtrCategoryComboBox.Items.Add(allPlaceholder);
            filtrCategoryComboBox.SelectedItem = allPlaceholder;

            string connectionString = "Data Source=C:\\Skola\\C# II\\ToDoList\\ToDoList\\ToDoList\\todoList.db"; // Zmìòte cestu k vaší SQLite databázi
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open();

                string selectCategoriesQuery = "SELECT name FROM Categories";
                using (SQLiteCommand selectCategoriesCommand = new SQLiteCommand(selectCategoriesQuery, connection))
                {
                    using (SQLiteDataReader reader = selectCategoriesCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoryName = reader["name"].ToString();

                            categoryComboBox1.Items.Add(categoryName);
                            filtrCategoryComboBox.Items.Add(categoryName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba pøi pøipojení k databázi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            categoryComboBox1.SelectedItem = allPlaceholder;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            titleTextBox.Text = todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
            DateTime selectedDate = Convert.ToDateTime(todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[2]);
            dateTimePicker1.Value = selectedDate;
            string selectedCategory = todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
            categoryComboBox1.SelectedItem = selectedCategory;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[todoListGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Název"] = titleTextBox.Text;
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Popis"] = descriptionTextBox.Text;
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Datum splnìní"] = dateTimePicker1.Value;
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Kategorie"] = categoryComboBox1.SelectedItem.ToString();
                //todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Stav"] = "nesplnìno";

            }
            else
            {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text, dateTimePicker1.Value, categoryComboBox1.SelectedItem.ToString() /*, "nesplnìno" */);
            }
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            categoryComboBox1.SelectedItem = allPlaceholder;
            isEditing = false;
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            string novaKategorie = addCategoryTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS Categories (Id INTEGER PRIMARY KEY, Name TEXT)";
                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                string insertCategoryQuery = "INSERT INTO Categories (Name) VALUES (@name)";
                using (SQLiteCommand insertCategoryCommand = new SQLiteCommand(insertCategoryQuery, connection))
                {
                    insertCategoryCommand.Parameters.AddWithValue("@name", novaKategorie);
                    insertCategoryCommand.ExecuteNonQuery();
                }
            }

            categoryComboBox1.Items.Add(novaKategorie);
            filtrCategoryComboBox.Items.Add(novaKategorie);

            addCategoryTextBox.Clear();
        }
    }
}