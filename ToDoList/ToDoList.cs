using System.Data;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Název");
            todoList.Columns.Add("Popis");
            todoList.Columns.Add("Datum splnìní");

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
            titleTextBox.Text = todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
            DateTime selectedDate = Convert.ToDateTime(todoList.Rows[todoListGridView.CurrentCell.RowIndex].ItemArray[2]);
            monthCalendar1.SetDate(selectedDate);
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
                todoList.Rows[todoListGridView.CurrentCell.RowIndex]["Datum splnìní"] = monthCalendar1.SelectionRange.Start;

            }
            else
            {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text, monthCalendar1.SelectionRange.Start);
            }
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            monthCalendar1.SetDate(DateTime.Today);
            isEditing = false;
        }
    }
}