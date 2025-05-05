namespace Helsi
{
    partial class DoctorForAdminUserControl
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
            doctor_dataGridView = new DataGridView();
            updateDataInAllForm_button = new Button();
            updateDoctor_Button = new Button();
            deleteDoctor_Button = new Button();
            addDoctor_Button = new Button();
            label1 = new Label();
            label4 = new Label();
            idDodctor_TextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            fullNameDoctor_TextBox = new TextBox();
            label5 = new Label();
            specializationDoctor_TextBox = new TextBox();
            label6 = new Label();
            phoneNumberDoctor_TextBox = new TextBox();
            idDepartmentDoctor_ComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)doctor_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // doctor_dataGridView
            // 
            doctor_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            doctor_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            doctor_dataGridView.Location = new Point(384, 171);
            doctor_dataGridView.Name = "doctor_dataGridView";
            doctor_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            doctor_dataGridView.Size = new Size(542, 413);
            doctor_dataGridView.TabIndex = 18;
            doctor_dataGridView.CellContentClick += doctor_dataGridView_CellContentClick;
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 547);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 43;
            updateDataInAllForm_button.Text = "Оовити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateDoctor_Button
            // 
            updateDoctor_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDoctor_Button.Location = new Point(18, 467);
            updateDoctor_Button.Name = "updateDoctor_Button";
            updateDoctor_Button.Size = new Size(360, 36);
            updateDoctor_Button.TabIndex = 42;
            updateDoctor_Button.Text = "Оновити";
            updateDoctor_Button.UseVisualStyleBackColor = true;
            updateDoctor_Button.Click += updateDoctor_Button_Click;
            // 
            // deleteDoctor_Button
            // 
            deleteDoctor_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteDoctor_Button.Location = new Point(18, 509);
            deleteDoctor_Button.Name = "deleteDoctor_Button";
            deleteDoctor_Button.Size = new Size(360, 32);
            deleteDoctor_Button.TabIndex = 41;
            deleteDoctor_Button.Text = "Видалити";
            deleteDoctor_Button.UseVisualStyleBackColor = true;
            deleteDoctor_Button.Click += deleteDoctor_Button_Click;
            // 
            // addDoctor_Button
            // 
            addDoctor_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addDoctor_Button.Location = new Point(18, 427);
            addDoctor_Button.Name = "addDoctor_Button";
            addDoctor_Button.Size = new Size(360, 36);
            addDoctor_Button.TabIndex = 40;
            addDoctor_Button.Text = "Додати";
            addDoctor_Button.UseVisualStyleBackColor = true;
            addDoctor_Button.Click += addDoctor_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(327, 27);
            label1.Name = "label1";
            label1.Size = new Size(210, 30);
            label1.TabIndex = 44;
            label1.Text = "Робота з доктором";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(18, 104);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 49;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // idDodctor_TextBox
            // 
            idDodctor_TextBox.Location = new Point(18, 132);
            idDodctor_TextBox.Name = "idDodctor_TextBox";
            idDodctor_TextBox.Size = new Size(360, 23);
            idDodctor_TextBox.TabIndex = 48;
            idDodctor_TextBox.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(18, 167);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 51;
            label2.Text = "Відділення";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(18, 231);
            label3.Name = "label3";
            label3.Size = new Size(45, 25);
            label3.TabIndex = 53;
            label3.Text = "ПІБ";
            // 
            // fullNameDoctor_TextBox
            // 
            fullNameDoctor_TextBox.Location = new Point(18, 259);
            fullNameDoctor_TextBox.Name = "fullNameDoctor_TextBox";
            fullNameDoctor_TextBox.Size = new Size(360, 23);
            fullNameDoctor_TextBox.TabIndex = 52;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(18, 298);
            label5.Name = "label5";
            label5.Size = new Size(136, 25);
            label5.TabIndex = 55;
            label5.Text = "Спеціалізація";
            // 
            // specializationDoctor_TextBox
            // 
            specializationDoctor_TextBox.Location = new Point(18, 326);
            specializationDoctor_TextBox.Name = "specializationDoctor_TextBox";
            specializationDoctor_TextBox.Size = new Size(360, 23);
            specializationDoctor_TextBox.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(18, 356);
            label6.Name = "label6";
            label6.Size = new Size(170, 25);
            label6.TabIndex = 57;
            label6.Text = "Номер телефону";
            // 
            // phoneNumberDoctor_TextBox
            // 
            phoneNumberDoctor_TextBox.Location = new Point(18, 384);
            phoneNumberDoctor_TextBox.Name = "phoneNumberDoctor_TextBox";
            phoneNumberDoctor_TextBox.Size = new Size(360, 23);
            phoneNumberDoctor_TextBox.TabIndex = 56;
            // 
            // idDepartmentDoctor_ComboBox
            // 
            idDepartmentDoctor_ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idDepartmentDoctor_ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idDepartmentDoctor_ComboBox.FormattingEnabled = true;
            idDepartmentDoctor_ComboBox.Location = new Point(18, 195);
            idDepartmentDoctor_ComboBox.Name = "idDepartmentDoctor_ComboBox";
            idDepartmentDoctor_ComboBox.Size = new Size(360, 23);
            idDepartmentDoctor_ComboBox.TabIndex = 58;
            // 
            // DoctorForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(idDepartmentDoctor_ComboBox);
            Controls.Add(label6);
            Controls.Add(phoneNumberDoctor_TextBox);
            Controls.Add(label5);
            Controls.Add(specializationDoctor_TextBox);
            Controls.Add(label3);
            Controls.Add(fullNameDoctor_TextBox);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(idDodctor_TextBox);
            Controls.Add(label1);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateDoctor_Button);
            Controls.Add(deleteDoctor_Button);
            Controls.Add(addDoctor_Button);
            Controls.Add(doctor_dataGridView);
            Name = "DoctorForAdminUserControl";
            Size = new Size(929, 587);
            Load += DoctorForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)doctor_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView doctor_dataGridView;
        private Button updateDataInAllForm_button;
        private Button updateDoctor_Button;
        private Button deleteDoctor_Button;
        private Button addDoctor_Button;
        private Label label1;
        private Label label4;
        private TextBox idDodctor_TextBox;
        private Label label2;
        private Label label3;
        private TextBox fullNameDoctor_TextBox;
        private Label label5;
        private TextBox specializationDoctor_TextBox;
        private Label label6;
        private TextBox phoneNumberDoctor_TextBox;
        private ComboBox idDepartmentDoctor_ComboBox;
    }
}
