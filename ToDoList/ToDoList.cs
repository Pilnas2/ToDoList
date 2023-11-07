using ServiceStack.OrmLite;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        DataTable todoList = new DataTable();
        bool isEditing = false;
        string allPlaceholder = "Vöechny";
        private string connectionString = "Data Source=C:\\Skola\\C# II\\ToDoList\\ToDoList\\ToDoList\\todoList.db";
        private int tasksId;
        private string customFormat = "dd.MM.yyyy HH:mm";

        public ToDoList()
        {
            InitializeComponent();

        }




        public void ToDoList_Load(object sender, EventArgs e)
        {
            todoListGridView.DataSource = todoList;

            todoList.Columns.Add("N·zev");
            todoList.Columns.Add("Popis");
            todoList.Columns.Add("Datum splnÏnÌ");
            todoList.Columns.Add("Kategorie");
            todoList.Columns.Add("Id");
            todoListGridView.Columns["Id"].Visible = false;

            dateTimePicker1.CustomFormat = customFormat;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            categoryComboBox1.Items.Add(allPlaceholder);
            categoryComboBox1.SelectedItem = allPlaceholder;
            filtrCategoryComboBox.Items.Add(allPlaceholder);
            filtrCategoryComboBox.SelectedItem = allPlaceholder;

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
                string selectTasksQuery = "SELECT * FROM Tasks";
                using (SQLiteCommand selectTasksCommand = new SQLiteCommand(selectTasksQuery, connection))
                {
                    using (SQLiteDataReader reader = selectTasksCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            string description = reader["description"].ToString();
                            DateTime dueDate = Convert.ToDateTime(reader["due_date"]);
                            int categoryId = Convert.ToInt32(reader["category_id"]);
                            int id = Convert.ToInt32(reader["id"]);
                            tasksId = id;
                            string categoryTitle = GetCategoryNameById(categoryId);

                            // P¯idejte data do datovÈho zdroje (todoList)
                            todoList.Rows.Add(title, description, dueDate, categoryTitle, id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba p¯i p¯ipojenÌ k datab·zi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ToDoList_Shown(object sender, EventArgs e)
        {
            RelodData();
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
                int selectedRowIndex = todoListGridView.CurrentCell.RowIndex;
                int taskId = Convert.ToInt32(todoList.Rows[selectedRowIndex]["Id"]);

                todoList.Rows.RemoveAt(selectedRowIndex);

                DeleteTaskFromDatabase(taskId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DeleteTaskFromDatabase(int taskId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Tasks WHERE id = @TaskID";
                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, connection))
                {
                    deleteCmd.Parameters.AddWithValue("@TaskID", taskId);

                    deleteCmd.ExecuteNonQuery();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryComboBox1.SelectedItem.ToString();
            int categoryId = GetCategoryIdByName(categoryName);


            if (isEditing)
            {

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "UPDATE Tasks SET title = @Title, description = @Description, due_date = @DueDate, category_id = @CategoryID WHERE id = @TaskID";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", titleTextBox.Text);
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@DueDate", dateTimePicker1.Value.ToString(customFormat));
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        cmd.Parameters.AddWithValue("@TaskID", tasksId);

                        // Spusùte SQL dotaz
                        cmd.ExecuteNonQuery();
                    }
                }
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["N·zev"] = titleTextBox.Text;
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Popis"] = descriptionTextBox.Text;
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Datum splnÏnÌ"] = dateTimePicker1.Value.ToString(customFormat);
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Kategorie"] = categoryComboBox1.SelectedItem.ToString();
                //todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Stav"] = "nesplnÏno";


            }
            else
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Tasks (title, description, due_date, category_id) VALUES (@Title, @Description, @DueDate, @CategoryID)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", titleTextBox.Text);
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@DueDate", dateTimePicker1.Value.ToString(customFormat));
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                        cmd.ExecuteNonQuery();
                    }
                    int newTaskID = GetLastInsertedTaskID(connection);

                    if (checkBox1.Checked)
                    {
                        InsertReminderToDatabase(newTaskID, dateTimePicker1.Value);
                    }
                }
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text, dateTimePicker1.Value.ToString(customFormat), categoryComboBox1.SelectedItem.ToString() /*, "nesplnÏno" */);

            }
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            categoryComboBox1.SelectedItem = allPlaceholder;
            isEditing = false;

            todoList = new DataTable();
            todoListGridView.DataSource = todoList;


            ToDoList_Load(sender, e);


        }


        private int GetLastInsertedTaskID(SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertReminderToDatabase(int taskId, DateTime reminderDateTime)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Reminders (task_id, reminder_date_time) VALUES (@TaskID, @ReminderDateTime)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TaskID", taskId);
                    cmd.Parameters.AddWithValue("@ReminderDateTime", reminderDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetCategoryIdByName(string categoryName)
        {
            int categoryId = -1;

            string selectCategoryQuery = "SELECT id FROM Categories WHERE Name = @name";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand selectCategoryCommand = new SQLiteCommand(selectCategoryQuery, connection))
                {
                    selectCategoryCommand.Parameters.AddWithValue("@name", categoryName);
                    object result = selectCategoryCommand.ExecuteScalar();

                    if (result != null)
                    {
                        categoryId = Convert.ToInt32(result);
                    }
                }
            }

            return categoryId;
        }
        private string GetCategoryNameById(int categoryId)
        {
            string categoryName = "Vöechny"; // Pokud kategorie nenÌ nalezena, v˝chozÌ hodnota je pr·zdn˝ ¯etÏzec

            string selectCategoryQuery = "SELECT Name FROM Categories WHERE id = @categoryId";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand selectCategoryCommand = new SQLiteCommand(selectCategoryQuery, connection))
                {
                    selectCategoryCommand.Parameters.AddWithValue("@categoryId", categoryId);
                    object result = selectCategoryCommand.ExecuteScalar();

                    if (result != null)
                    {
                        categoryName = result.ToString();
                    }
                }
            }

            return categoryName;
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