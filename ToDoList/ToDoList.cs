using ServiceStack.OrmLite;
using System.Data;
using System.Windows.Forms;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        private DateTime _date = DateTime.Today;
        private string _category = "All";
        public ToDoList()
        {
            InitializeComponent();


            var db = DbContext.GetInstance();

            List<string> catItems = new List<string>();
            foreach (var category in db.Select<Category>())
                catItems.Add(category.CategoryName);

            categoriesComboBox.DataSource = catItems;
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {

            todoListGridView.DataSource = todoList;

            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.Width = 500;

        }

        private void ToDoList_Shown(object sender, EventArgs e)
        {
            RelodData();
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

        void RelodData()
        {
            var db = DbContext.GetInstance();

            var data = db.Select<ToDoItem>(r => r.StartDate >= this._date && r.EndDate <= this._date);

            if (this._category != "All")
                data = data.Where(r => r.CategoryId == Category.GetCategoryByName(this._category).id).ToList();



            todoListGridView.AutoGenerateColumns = true; // Nastavte automatické generování sloupcù
            todoListGridView.DataSource = data;

            // Pøi editaci buòky
            todoListGridView.CellValueChanged += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var editedItem = (ToDoItem)todoListGridView.Rows[e.RowIndex].DataBoundItem;
                    if (editedItem != null)
                    {
                        // Uložte zmìny v databázi (pøedpokládáme, že máte DbContext)
                        db.Save(editedItem);

                        MessageBox.Show("Data saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };
        }



        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this._date = monthCalendar1.SelectionRange.Start;
            RelodData();
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._category = sender.ToString();
            RelodData();
        }

        private void todoListGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}