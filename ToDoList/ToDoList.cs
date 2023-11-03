using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        private SQLiteConnection connection; // Initialize your SQLite connection
        private SQLiteDataAdapter dataAdapter;
        private DataTable todoList;
        private bool isEditing = false;

        public ToDoList()
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=C:\\Skola\\C# II\\ToDoList\\ToDoList\\ToDoList\\easy.db"); // Replace with the path to your SQLite database
            todoList = new DataTable();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            dataAdapter = new SQLiteDataAdapter("SELECT title, description, completion_date, status, list_id FROM Tasks", connection);

            // Manually define the update, insert, and delete commands
            SQLiteCommand updateCommand = new SQLiteCommand("UPDATE Tasks SET title = @title, description = @description, completion_date = @completion_date, status = @status WHERE list_id = @list_id", connection);
            SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO Tasks (title, description, completion_date, status) VALUES (@title, @description, @completion_date, @status)", connection);
            SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM Tasks WHERE list_id = @list_id", connection);

            // Define parameters for the commands
            updateCommand.Parameters.Add("@title", DbType.String, 255, "title");
            updateCommand.Parameters.Add("@description", DbType.String, 255, "description");
            updateCommand.Parameters.Add("@completion_date", DbType.Date, 0, "completion_date");
            updateCommand.Parameters.Add("@status", DbType.Int32, 0, "status");
            updateCommand.Parameters.Add("@list_id", DbType.Int32, 0, "list_id");

            insertCommand.Parameters.Add("@title", DbType.String, 255, "title");
            insertCommand.Parameters.Add("@description", DbType.String, 255, "description");
            insertCommand.Parameters.Add("@completion_date", DbType.Date, 0, "completion_date");
            insertCommand.Parameters.Add("@status", DbType.Int32, 0, "status");

            deleteCommand.Parameters.Add("@list_id", DbType.Int32, 0, "list_id");

            // Assign the custom commands to the data adapter
            dataAdapter.UpdateCommand = updateCommand;
            dataAdapter.InsertCommand = insertCommand;
            dataAdapter.DeleteCommand = deleteCommand;

            dataAdapter.Fill(todoList);
            todoListGridView.DataSource = todoList;

            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.Width = 500;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            monthCalendar1.SetDate(DateTime.Today);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            titleTextBox.Text = todoListGridView.CurrentRow.Cells["title"].Value.ToString();
            descriptionTextBox.Text = todoListGridView.CurrentRow.Cells["description"].Value.ToString();
            DateTime selectedDate = Convert.ToDateTime(todoListGridView.CurrentRow.Cells["completion_date"].Value);
            monthCalendar1.SetDate(selectedDate);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = todoListGridView.CurrentRow.Index;
                DataRow row = todoList.Rows[rowIndex];
                row.Delete();
                dataAdapter.Update(todoList); // This will update the database
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
                int rowIndex = todoListGridView.CurrentRow.Index;
                DataRow row = todoList.Rows[rowIndex];

                // Naètìte aktuální data z databáze pro porovnání
                DataTable originalData = new DataTable();
                dataAdapter.Fill(originalData);
                DataRow originalRow = originalData.Rows[rowIndex];

                // Porovnejte data s aktuálními daty v databázi
                if (AreRowsEqual(row, originalRow))
                {
                    // Data nebyla zmìnìna, mùžete provést aktualizaci
                    row["title"] = titleTextBox.Text;
                    row["description"] = descriptionTextBox.Text;
                    row["completion_date"] = monthCalendar1.SelectionRange.Start;
                    dataAdapter.Update(todoList); // This will update the database
                }
                else
                {
                    // Data byla již zmìnìna jiným procesem
                    MessageBox.Show("Data byla již zmìnìna jiným procesem. Zpracujte konflikt.");
                }
            }
            else
            {
                DataRow newRow = todoList.NewRow();
                newRow["title"] = titleTextBox.Text;
                newRow["description"] = descriptionTextBox.Text;
                newRow["completion_date"] = monthCalendar1.SelectionRange.Start;
                todoList.Rows.Add(newRow);
                dataAdapter.Update(todoList); // This will insert a new record into the database
            }
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            monthCalendar1.SetDate(DateTime.Today);
            isEditing = false;
        }

        private bool AreRowsEqual(DataRow row1, DataRow row2)
        {
            for (int i = 0; i < row1.ItemArray.Length; i++)
            {
                if (!row1.ItemArray[i].Equals(row2.ItemArray[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
