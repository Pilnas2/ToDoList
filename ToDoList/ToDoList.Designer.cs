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
            monthCalendar1 = new MonthCalendar();
            todoListGridView = new DataGridView();
            saveButton = new Button();
            deleteButton = new Button();
            editButton = new Button();
            newButton = new Button();
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
            label4.Location = new Point(10, 208);
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
            // monthCalendar1
            // 
            monthCalendar1.BackColor = Color.Red;
            monthCalendar1.Location = new Point(10, 257);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 8;
            // 
            // todoListGridView
            // 
            todoListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            todoListGridView.BackgroundColor = Color.Silver;
            todoListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            todoListGridView.Location = new Point(591, 113);
            todoListGridView.Name = "todoListGridView";
            todoListGridView.RowTemplate.Height = 25;
            todoListGridView.Size = new Size(515, 364);
            todoListGridView.TabIndex = 9;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(343, 470);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(108, 23);
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
            // ToDoList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(1140, 534);
            Controls.Add(newButton);
            Controls.Add(editButton);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(todoListGridView);
            Controls.Add(monthCalendar1);
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
        private MonthCalendar monthCalendar1;
        private DataGridView todoListGridView;
        private Button saveButton;
        private Button deleteButton;
        private Button editButton;
        private Button newButton;
    }
}