namespace Helsi
{
    partial class DepartmentForAdminUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            department_dataGridView = new DataGridView();
            label5 = new Label();
            descriptionDepartment_TextBox = new TextBox();
            nameDepartment_TextBox = new TextBox();
            idDepartment_TextBox = new TextBox();
            updateDataInAllForm_button = new Button();
            updateDepartment_Button = new Button();
            deleteDepartment_Button = new Button();
            addDepartment_Button = new Button();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            textBoxSearch = new TextBox();
            clearAllField_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)department_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // department_dataGridView
            // 
            department_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            department_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            department_dataGridView.Location = new Point(384, 171);
            department_dataGridView.Name = "department_dataGridView";
            department_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            department_dataGridView.Size = new Size(542, 413);
            department_dataGridView.TabIndex = 50;
            department_dataGridView.CellContentClick += department_dataGridView_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(311, 16);
            label5.Name = "label5";
            label5.Size = new Size(235, 30);
            label5.TabIndex = 51;
            label5.Text = "Робота з відділенням";
            // 
            // descriptionDepartment_TextBox
            // 
            descriptionDepartment_TextBox.Location = new Point(18, 260);
            descriptionDepartment_TextBox.Name = "descriptionDepartment_TextBox";
            descriptionDepartment_TextBox.Size = new Size(360, 23);
            descriptionDepartment_TextBox.TabIndex = 52;
            // 
            // nameDepartment_TextBox
            // 
            nameDepartment_TextBox.Location = new Point(18, 195);
            nameDepartment_TextBox.Name = "nameDepartment_TextBox";
            nameDepartment_TextBox.Size = new Size(360, 23);
            nameDepartment_TextBox.TabIndex = 53;
            // 
            // idDepartment_TextBox
            // 
            idDepartment_TextBox.Location = new Point(18, 112);
            idDepartment_TextBox.Name = "idDepartment_TextBox";
            idDepartment_TextBox.Size = new Size(360, 23);
            idDepartment_TextBox.TabIndex = 54;
            idDepartment_TextBox.Visible = false;
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 420);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 58;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateDepartment_Button
            // 
            updateDepartment_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDepartment_Button.Location = new Point(18, 340);
            updateDepartment_Button.Name = "updateDepartment_Button";
            updateDepartment_Button.Size = new Size(360, 36);
            updateDepartment_Button.TabIndex = 57;
            updateDepartment_Button.Text = "Оновити";
            updateDepartment_Button.UseVisualStyleBackColor = true;
            updateDepartment_Button.Click += updateDepartment_Button_Click;
            // 
            // deleteDepartment_Button
            // 
            deleteDepartment_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteDepartment_Button.Location = new Point(18, 382);
            deleteDepartment_Button.Name = "deleteDepartment_Button";
            deleteDepartment_Button.Size = new Size(360, 32);
            deleteDepartment_Button.TabIndex = 56;
            deleteDepartment_Button.Text = "Видалити";
            deleteDepartment_Button.UseVisualStyleBackColor = true;
            deleteDepartment_Button.Click += deleteDepartment_Button_Click;
            // 
            // addDepartment_Button
            // 
            addDepartment_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addDepartment_Button.Location = new Point(18, 300);
            addDepartment_Button.Name = "addDepartment_Button";
            addDepartment_Button.Size = new Size(360, 36);
            addDepartment_Button.TabIndex = 55;
            addDepartment_Button.Text = "Додати";
            addDepartment_Button.UseVisualStyleBackColor = true;
            addDepartment_Button.Click += addDepartment_Button_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(18, 84);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 59;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(18, 167);
            label3.Name = "label3";
            label3.Size = new Size(173, 25);
            label3.TabIndex = 60;
            label3.Text = "Назва відділення";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 232);
            label1.Name = "label1";
            label1.Size = new Size(165, 25);
            label1.TabIndex = 61;
            label1.Text = "Опис відділення";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(384, 140);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(360, 23);
            textBoxSearch.TabIndex = 63;
            // 
            // clearAllField_Button
            // 
            clearAllField_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            clearAllField_Button.Location = new Point(765, 133);
            clearAllField_Button.Name = "clearAllField_Button";
            clearAllField_Button.Size = new Size(152, 32);
            clearAllField_Button.TabIndex = 62;
            clearAllField_Button.Text = "Очистити поля";
            clearAllField_Button.UseVisualStyleBackColor = true;
            clearAllField_Button.Click += clearAllField_Button_Click;
            // 
            // DepartmentForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxSearch);
            Controls.Add(clearAllField_Button);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateDepartment_Button);
            Controls.Add(deleteDepartment_Button);
            Controls.Add(addDepartment_Button);
            Controls.Add(idDepartment_TextBox);
            Controls.Add(nameDepartment_TextBox);
            Controls.Add(descriptionDepartment_TextBox);
            Controls.Add(label5);
            Controls.Add(department_dataGridView);
            Name = "DepartmentForAdminUserControl";
            Size = new Size(929, 587);
            Load += DepartmentForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)department_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView department_dataGridView;
        private Label label5;
        private TextBox descriptionDepartment_TextBox;
        private TextBox nameDepartment_TextBox;
        private TextBox idDepartment_TextBox;
        private Button updateDataInAllForm_button;
        private Button updateDepartment_Button;
        private Button deleteDepartment_Button;
        private Button addDepartment_Button;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox textBoxSearch;
        private Button clearAllField_Button;
    }
}
