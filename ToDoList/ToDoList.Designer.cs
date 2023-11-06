namespace ToDoList
{
    partial class ToDoList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            titleTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            todoListGridView = new DataGridView();
            saveButton = new Button();
            deleteButton = new Button();
            editButton = new Button();
            newButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            categoryComboBox1 = new ComboBox();
            filtrCategoryComboBox = new ComboBox();
            label7 = new Label();
            addCategoryTextBox = new TextBox();
            addCategoryButton = new Button();
            checkBox1 = new CheckBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)todoListGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(128, 128, 255);
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(1118, 62);
            label1.TabIndex = 0;
            label1.Text = "To Do List";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(1116, 40);
            label2.TabIndex = 1;
            label2.Text = "Název:";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(1116, 40);
            label3.TabIndex = 2;
            label3.Text = "Popis:";
            // 
            // titleTextBox
            // 
            titleTextBox.BackColor = Color.Silver;
            titleTextBox.Location = new Point(12, 113);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(456, 23);
            titleTextBox.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.BackColor = Color.Silver;
            descriptionTextBox.Location = new Point(12, 182);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(456, 23);
            descriptionTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 283);
            label4.Name = "label4";
            label4.Size = new Size(1116, 40);
            label4.TabIndex = 6;
            label4.Text = "Datum:";
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(571, 89);
            label5.Name = "label5";
            label5.Size = new Size(1, 413);
            label5.TabIndex = 7;
            // 
            // todoListGridView
            // 
            todoListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            todoListGridView.BackgroundColor = Color.Silver;
            todoListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            todoListGridView.Location = new Point(588, 129);
            todoListGridView.Name = "todoListGridView";
            todoListGridView.RowTemplate.Height = 25;
            todoListGridView.Size = new Size(515, 364);
            todoListGridView.TabIndex = 9;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(343, 470);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(222, 23);
            saveButton.TabIndex = 13;
            saveButton.Text = "Uložit";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(232, 470);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(105, 23);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Vymazat";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(122, 470);
            editButton.Name = "editButton";
            editButton.Size = new Size(104, 23);
            editButton.TabIndex = 15;
            editButton.Text = "Upravit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // newButton
            // 
            newButton.Location = new Point(10, 470);
            newButton.Name = "newButton";
            newButton.Size = new Size(106, 23);
            newButton.TabIndex = 16;
            newButton.Text = "Nový";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.AllowDrop = true;
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(14, 326);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 17;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 208);
            label6.Name = "label6";
            label6.Size = new Size(555, 40);
            label6.TabIndex = 18;
            label6.Text = "Kategorie";
            // 
            // categoryComboBox1
            // 
            categoryComboBox1.FormattingEnabled = true;
            categoryComboBox1.Location = new Point(14, 251);
            categoryComboBox1.Name = "categoryComboBox1";
            categoryComboBox1.Size = new Size(121, 23);
            categoryComboBox1.TabIndex = 19;
            // 
            // filtrCategoryComboBox
            // 
            filtrCategoryComboBox.FormattingEnabled = true;
            filtrCategoryComboBox.Items.AddRange(new object[] { "Všechny" });
            filtrCategoryComboBox.Location = new Point(588, 100);
            filtrCategoryComboBox.Name = "filtrCategoryComboBox";
            filtrCategoryComboBox.Size = new Size(121, 23);
            filtrCategoryComboBox.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(588, 82);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 21;
            label7.Text = "Kategorie:";
            // 
            // addCategoryTextBox
            // 
            addCategoryTextBox.Location = new Point(274, 251);
            addCategoryTextBox.Name = "addCategoryTextBox";
            addCategoryTextBox.Size = new Size(136, 23);
            addCategoryTextBox.TabIndex = 22;
            // 
            // addCategoryButton
            // 
            addCategoryButton.Location = new Point(436, 251);
            addCategoryButton.Name = "addCategoryButton";
            addCategoryButton.Size = new Size(100, 23);
            addCategoryButton.TabIndex = 23;
            addCategoryButton.Text = "Přidat kategorii";
            addCategoryButton.UseVisualStyleBackColor = true;
            addCategoryButton.Click += addCategoryButton_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(436, 332);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 19);
            checkBox1.TabIndex = 24;
            checkBox1.Text = "Upozornění";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(307, 332);
            label8.Name = "label8";
            label8.Size = new Size(118, 15);
            label8.TabIndex = 25;
            label8.Text = "Zapnout upozornění:";
            // 
            // ToDoList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(1140, 534);
            Controls.Add(label8);
            Controls.Add(checkBox1);
            Controls.Add(addCategoryButton);
            Controls.Add(addCategoryTextBox);
            Controls.Add(label7);
            Controls.Add(filtrCategoryComboBox);
            Controls.Add(categoryComboBox1);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(newButton);
            Controls.Add(editButton);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(todoListGridView);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(descriptionTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ToDoList";
            Text = "To Do List";
            Load += ToDoList_Load;
            ((System.ComponentModel.ISupportInitialize)todoListGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private Label label4;
        private Label label5;
        private DataGridView todoListGridView;
        private Button saveButton;
        private Button deleteButton;
        private Button editButton;
        private Button newButton;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private ComboBox categoryComboBox1;
        private ComboBox filtrCategoryComboBox;
        private Label label7;
        private TextBox addCategoryTextBox;
        private Button addCategoryButton;
        private CheckBox checkBox1;
        private Label label8;
    }
}