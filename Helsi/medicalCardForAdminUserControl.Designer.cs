﻿namespace Helsi
{
    partial class medicalCardForAdminUserControl
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
            medicalCardForAdmin_dataGridView = new DataGridView();
            updateMedicalCardForAdmin_button = new Button();
            deleteMedicalCardForAdmin_button = new Button();
            addMedicalCardForAdmin_button = new Button();
            declarationDoctorTextBox_MedicalCardForAdmin = new TextBox();
            idMedicalCardTextBox_MedicalCardForAdmin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            idPatientComboBox_MedicalCardForAdmin = new ComboBox();
            label5 = new Label();
            updateDataInAllForm_button = new Button();
            label6 = new Label();
            textBoxSearch = new TextBox();
            clearAllField_Button = new Button();
            create_dateTimePicker1 = new DateTimePicker();
            statusCard_comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)medicalCardForAdmin_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // medicalCardForAdmin_dataGridView
            // 
            medicalCardForAdmin_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            medicalCardForAdmin_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            medicalCardForAdmin_dataGridView.Location = new Point(378, 171);
            medicalCardForAdmin_dataGridView.Name = "medicalCardForAdmin_dataGridView";
            medicalCardForAdmin_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            medicalCardForAdmin_dataGridView.Size = new Size(542, 413);
            medicalCardForAdmin_dataGridView.TabIndex = 17;
            medicalCardForAdmin_dataGridView.CellContentClick += medicalCardForAdmin_dataGridView_CellContentClick;
            // 
            // updateMedicalCardForAdmin_button
            // 
            updateMedicalCardForAdmin_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateMedicalCardForAdmin_button.Location = new Point(12, 447);
            updateMedicalCardForAdmin_button.Name = "updateMedicalCardForAdmin_button";
            updateMedicalCardForAdmin_button.Size = new Size(360, 36);
            updateMedicalCardForAdmin_button.TabIndex = 36;
            updateMedicalCardForAdmin_button.Text = "Оновити";
            updateMedicalCardForAdmin_button.UseVisualStyleBackColor = true;
            updateMedicalCardForAdmin_button.Click += updateMedicalCardForAdmin_button_Click;
            // 
            // deleteMedicalCardForAdmin_button
            // 
            deleteMedicalCardForAdmin_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteMedicalCardForAdmin_button.Location = new Point(12, 489);
            deleteMedicalCardForAdmin_button.Name = "deleteMedicalCardForAdmin_button";
            deleteMedicalCardForAdmin_button.Size = new Size(360, 32);
            deleteMedicalCardForAdmin_button.TabIndex = 35;
            deleteMedicalCardForAdmin_button.Text = "Видалити";
            deleteMedicalCardForAdmin_button.UseVisualStyleBackColor = true;
            deleteMedicalCardForAdmin_button.Click += deleteMedicalCardForAdmin_button_Click;
            // 
            // addMedicalCardForAdmin_button
            // 
            addMedicalCardForAdmin_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addMedicalCardForAdmin_button.Location = new Point(12, 407);
            addMedicalCardForAdmin_button.Name = "addMedicalCardForAdmin_button";
            addMedicalCardForAdmin_button.Size = new Size(360, 36);
            addMedicalCardForAdmin_button.TabIndex = 34;
            addMedicalCardForAdmin_button.Text = "Додати";
            addMedicalCardForAdmin_button.UseVisualStyleBackColor = true;
            addMedicalCardForAdmin_button.Click += addMedicalCardForAdmin_button_Click;
            // 
            // declarationDoctorTextBox_MedicalCardForAdmin
            // 
            declarationDoctorTextBox_MedicalCardForAdmin.Location = new Point(12, 256);
            declarationDoctorTextBox_MedicalCardForAdmin.Name = "declarationDoctorTextBox_MedicalCardForAdmin";
            declarationDoctorTextBox_MedicalCardForAdmin.Size = new Size(360, 23);
            declarationDoctorTextBox_MedicalCardForAdmin.TabIndex = 38;
            // 
            // idMedicalCardTextBox_MedicalCardForAdmin
            // 
            idMedicalCardTextBox_MedicalCardForAdmin.Location = new Point(12, 103);
            idMedicalCardTextBox_MedicalCardForAdmin.Name = "idMedicalCardTextBox_MedicalCardForAdmin";
            idMedicalCardTextBox_MedicalCardForAdmin.Size = new Size(360, 23);
            idMedicalCardTextBox_MedicalCardForAdmin.TabIndex = 40;
            idMedicalCardTextBox_MedicalCardForAdmin.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 342);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 41;
            label1.Text = "Статус картки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 232);
            label2.Name = "label2";
            label2.Size = new Size(196, 21);
            label2.TabIndex = 42;
            label2.Text = "Декларація з доктором";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 166);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 43;
            label3.Tag = "";
            label3.Text = "Пацієнт";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 79);
            label4.Name = "label4";
            label4.Size = new Size(25, 21);
            label4.TabIndex = 44;
            label4.Tag = "";
            label4.Text = "id";
            label4.Visible = false;
            // 
            // idPatientComboBox_MedicalCardForAdmin
            // 
            idPatientComboBox_MedicalCardForAdmin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idPatientComboBox_MedicalCardForAdmin.AutoCompleteSource = AutoCompleteSource.ListItems;
            idPatientComboBox_MedicalCardForAdmin.FormattingEnabled = true;
            idPatientComboBox_MedicalCardForAdmin.Location = new Point(15, 191);
            idPatientComboBox_MedicalCardForAdmin.Name = "idPatientComboBox_MedicalCardForAdmin";
            idPatientComboBox_MedicalCardForAdmin.Size = new Size(357, 23);
            idPatientComboBox_MedicalCardForAdmin.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 292);
            label5.Name = "label5";
            label5.Size = new Size(133, 21);
            label5.TabIndex = 47;
            label5.Text = "Дата створення";
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.AllowDrop = true;
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(12, 527);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 48;
            updateDataInAllForm_button.TabStop = false;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(347, 29);
            label6.Name = "label6";
            label6.Size = new Size(350, 30);
            label6.TabIndex = 49;
            label6.Text = "Управління медичними картами";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(378, 142);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(360, 23);
            textBoxSearch.TabIndex = 51;
            // 
            // clearAllField_Button
            // 
            clearAllField_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            clearAllField_Button.Location = new Point(759, 135);
            clearAllField_Button.Name = "clearAllField_Button";
            clearAllField_Button.Size = new Size(152, 32);
            clearAllField_Button.TabIndex = 50;
            clearAllField_Button.Text = "Очистити поля";
            clearAllField_Button.UseVisualStyleBackColor = true;
            clearAllField_Button.Click += clearAllField_Button_Click;
            // 
            // create_dateTimePicker1
            // 
            create_dateTimePicker1.Location = new Point(12, 316);
            create_dateTimePicker1.Name = "create_dateTimePicker1";
            create_dateTimePicker1.Size = new Size(360, 23);
            create_dateTimePicker1.TabIndex = 52;
            // 
            // statusCard_comboBox
            // 
            statusCard_comboBox.FormattingEnabled = true;
            statusCard_comboBox.Location = new Point(12, 366);
            statusCard_comboBox.Name = "statusCard_comboBox";
            statusCard_comboBox.Size = new Size(360, 23);
            statusCard_comboBox.TabIndex = 53;
            // 
            // medicalCardForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusCard_comboBox);
            Controls.Add(create_dateTimePicker1);
            Controls.Add(textBoxSearch);
            Controls.Add(clearAllField_Button);
            Controls.Add(label6);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(label5);
            Controls.Add(idPatientComboBox_MedicalCardForAdmin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(idMedicalCardTextBox_MedicalCardForAdmin);
            Controls.Add(declarationDoctorTextBox_MedicalCardForAdmin);
            Controls.Add(updateMedicalCardForAdmin_button);
            Controls.Add(deleteMedicalCardForAdmin_button);
            Controls.Add(addMedicalCardForAdmin_button);
            Controls.Add(medicalCardForAdmin_dataGridView);
            Name = "medicalCardForAdminUserControl";
            Size = new Size(929, 587);
            Load += medicalCardForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)medicalCardForAdmin_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView medicalCardForAdmin_dataGridView;
        private Button updateMedicalCardForAdmin_button;
        private Button deleteMedicalCardForAdmin_button;
        private Button addMedicalCardForAdmin_button;
        private TextBox declarationDoctorTextBox_MedicalCardForAdmin;
        private TextBox idMedicalCardTextBox_MedicalCardForAdmin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox idPatientComboBox_MedicalCardForAdmin;
        private Label label5;
        private Button updateDataInAllForm_button;
        private Label label6;
        private TextBox textBoxSearch;
        private Button clearAllField_Button;
        private DateTimePicker create_dateTimePicker1;
        private ComboBox statusCard_comboBox;
    }
}
