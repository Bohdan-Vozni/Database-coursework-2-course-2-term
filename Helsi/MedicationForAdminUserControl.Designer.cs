namespace Helsi
{
    partial class MedicationForAdminUserControl
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
            medication_dataGridView = new DataGridView();
            label5 = new Label();
            updateDataInAllForm_button = new Button();
            updateMedication_Button = new Button();
            deleteMedication_Button = new Button();
            addMedication_Button = new Button();
            idMedication_TextBox = new TextBox();
            manufacturerMedication_TextBox = new TextBox();
            descriptionMedication_TextBox = new TextBox();
            expirationDateMedication_TextBox = new TextBox();
            nameMedication_TextBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            textBoxSearch = new TextBox();
            clearAllField_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)medication_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // medication_dataGridView
            // 
            medication_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            medication_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            medication_dataGridView.Location = new Point(384, 171);
            medication_dataGridView.Name = "medication_dataGridView";
            medication_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            medication_dataGridView.Size = new Size(542, 413);
            medication_dataGridView.TabIndex = 51;
            medication_dataGridView.CellContentClick += medication_dataGridView_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(291, 28);
            label5.Name = "label5";
            label5.Size = new Size(273, 30);
            label5.TabIndex = 52;
            label5.Text = "Робота з медикаментами";
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 543);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 62;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateMedication_Button
            // 
            updateMedication_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateMedication_Button.Location = new Point(18, 463);
            updateMedication_Button.Name = "updateMedication_Button";
            updateMedication_Button.Size = new Size(360, 36);
            updateMedication_Button.TabIndex = 61;
            updateMedication_Button.Text = "Оновити";
            updateMedication_Button.UseVisualStyleBackColor = true;
            updateMedication_Button.Click += updateMedication_Button_Click;
            // 
            // deleteMedication_Button
            // 
            deleteMedication_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteMedication_Button.Location = new Point(18, 505);
            deleteMedication_Button.Name = "deleteMedication_Button";
            deleteMedication_Button.Size = new Size(360, 32);
            deleteMedication_Button.TabIndex = 60;
            deleteMedication_Button.Text = "Видалити";
            deleteMedication_Button.UseVisualStyleBackColor = true;
            deleteMedication_Button.Click += deleteMedication_Button_Click;
            // 
            // addMedication_Button
            // 
            addMedication_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addMedication_Button.Location = new Point(18, 423);
            addMedication_Button.Name = "addMedication_Button";
            addMedication_Button.Size = new Size(360, 36);
            addMedication_Button.TabIndex = 59;
            addMedication_Button.Text = "Додати";
            addMedication_Button.UseVisualStyleBackColor = true;
            addMedication_Button.Click += addMedication_Button_Click;
            // 
            // idMedication_TextBox
            // 
            idMedication_TextBox.Location = new Point(18, 114);
            idMedication_TextBox.Name = "idMedication_TextBox";
            idMedication_TextBox.Size = new Size(360, 23);
            idMedication_TextBox.TabIndex = 63;
            idMedication_TextBox.Visible = false;
            // 
            // manufacturerMedication_TextBox
            // 
            manufacturerMedication_TextBox.Location = new Point(18, 263);
            manufacturerMedication_TextBox.Name = "manufacturerMedication_TextBox";
            manufacturerMedication_TextBox.Size = new Size(360, 23);
            manufacturerMedication_TextBox.TabIndex = 64;
            // 
            // descriptionMedication_TextBox
            // 
            descriptionMedication_TextBox.Location = new Point(18, 328);
            descriptionMedication_TextBox.Name = "descriptionMedication_TextBox";
            descriptionMedication_TextBox.Size = new Size(360, 23);
            descriptionMedication_TextBox.TabIndex = 65;
            // 
            // expirationDateMedication_TextBox
            // 
            expirationDateMedication_TextBox.Location = new Point(18, 394);
            expirationDateMedication_TextBox.Name = "expirationDateMedication_TextBox";
            expirationDateMedication_TextBox.Size = new Size(360, 23);
            expirationDateMedication_TextBox.TabIndex = 66;
            // 
            // nameMedication_TextBox
            // 
            nameMedication_TextBox.Location = new Point(18, 195);
            nameMedication_TextBox.Name = "nameMedication_TextBox";
            nameMedication_TextBox.Size = new Size(360, 23);
            nameMedication_TextBox.TabIndex = 67;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(18, 86);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 68;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(18, 167);
            label3.Name = "label3";
            label3.Size = new Size(198, 25);
            label3.TabIndex = 69;
            label3.Text = "Назва медикаменту";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 235);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 70;
            label1.Text = "Виробник";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(18, 300);
            label2.Name = "label2";
            label2.Size = new Size(190, 25);
            label2.TabIndex = 71;
            label2.Text = "Опис медикаменту";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(18, 368);
            label6.Name = "label6";
            label6.Size = new Size(175, 25);
            label6.TabIndex = 72;
            label6.Text = "Дата придатності";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(393, 140);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(360, 23);
            textBoxSearch.TabIndex = 74;
            // 
            // clearAllField_Button
            // 
            clearAllField_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            clearAllField_Button.Location = new Point(774, 133);
            clearAllField_Button.Name = "clearAllField_Button";
            clearAllField_Button.Size = new Size(152, 32);
            clearAllField_Button.TabIndex = 73;
            clearAllField_Button.Text = "Очистити поля";
            clearAllField_Button.UseVisualStyleBackColor = true;
            clearAllField_Button.Click += clearAllField_Button_Click;
            // 
            // MedicationForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxSearch);
            Controls.Add(clearAllField_Button);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(nameMedication_TextBox);
            Controls.Add(expirationDateMedication_TextBox);
            Controls.Add(descriptionMedication_TextBox);
            Controls.Add(manufacturerMedication_TextBox);
            Controls.Add(idMedication_TextBox);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateMedication_Button);
            Controls.Add(deleteMedication_Button);
            Controls.Add(addMedication_Button);
            Controls.Add(label5);
            Controls.Add(medication_dataGridView);
            Name = "MedicationForAdminUserControl";
            Size = new Size(929, 644);
            Load += MedicationForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)medication_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView medication_dataGridView;
        private Label label5;
        private Button updateDataInAllForm_button;
        private Button updateMedication_Button;
        private Button deleteMedication_Button;
        private Button addMedication_Button;
        private TextBox idMedication_TextBox;
        private TextBox manufacturerMedication_TextBox;
        private TextBox descriptionMedication_TextBox;
        private TextBox expirationDateMedication_TextBox;
        private TextBox nameMedication_TextBox;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label6;
        private TextBox textBoxSearch;
        private Button clearAllField_Button;
    }
}
