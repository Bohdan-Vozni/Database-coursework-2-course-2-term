namespace Helsi
{
    partial class Add_newMedicalCard
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
            button1 = new Button();
            addressPatient_textBox = new TextBox();
            addressPatient_label = new Label();
            phoneNumber_textBox = new TextBox();
            phoneNumber_label = new Label();
            dateOfBirth_textBox = new TextBox();
            dateOfBirth_label = new Label();
            fullName_textBox = new TextBox();
            fullName_label = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(259, 355);
            button1.Name = "button1";
            button1.Size = new Size(317, 42);
            button1.TabIndex = 17;
            button1.Text = "Додати дані про медичну картку";
            button1.UseVisualStyleBackColor = true;
            // 
            // addressPatient_textBox
            // 
            addressPatient_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            addressPatient_textBox.Location = new Point(362, 280);
            addressPatient_textBox.Name = "addressPatient_textBox";
            addressPatient_textBox.Size = new Size(358, 35);
            addressPatient_textBox.TabIndex = 16;
            // 
            // addressPatient_label
            // 
            addressPatient_label.AutoSize = true;
            addressPatient_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addressPatient_label.Location = new Point(90, 283);
            addressPatient_label.Name = "addressPatient_label";
            addressPatient_label.Size = new Size(201, 30);
            addressPatient_label.TabIndex = 15;
            addressPatient_label.Text = "Статус мед картки";
            // 
            // phoneNumber_textBox
            // 
            phoneNumber_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phoneNumber_textBox.Location = new Point(362, 228);
            phoneNumber_textBox.Name = "phoneNumber_textBox";
            phoneNumber_textBox.Size = new Size(358, 35);
            phoneNumber_textBox.TabIndex = 14;
            // 
            // phoneNumber_label
            // 
            phoneNumber_label.AutoSize = true;
            phoneNumber_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            phoneNumber_label.Location = new Point(90, 231);
            phoneNumber_label.Name = "phoneNumber_label";
            phoneNumber_label.Size = new Size(174, 30);
            phoneNumber_label.TabIndex = 13;
            phoneNumber_label.Text = "Дата створення";
            // 
            // dateOfBirth_textBox
            // 
            dateOfBirth_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateOfBirth_textBox.Location = new Point(362, 173);
            dateOfBirth_textBox.Name = "dateOfBirth_textBox";
            dateOfBirth_textBox.Size = new Size(358, 35);
            dateOfBirth_textBox.TabIndex = 12;
            // 
            // dateOfBirth_label
            // 
            dateOfBirth_label.AutoSize = true;
            dateOfBirth_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dateOfBirth_label.Location = new Point(90, 176);
            dateOfBirth_label.Name = "dateOfBirth_label";
            dateOfBirth_label.Size = new Size(257, 30);
            dateOfBirth_label.TabIndex = 11;
            dateOfBirth_label.Text = "Декларація з доктором";
            // 
            // fullName_textBox
            // 
            fullName_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            fullName_textBox.Location = new Point(362, 125);
            fullName_textBox.Name = "fullName_textBox";
            fullName_textBox.Size = new Size(358, 35);
            fullName_textBox.TabIndex = 10;
            // 
            // fullName_label
            // 
            fullName_label.AutoSize = true;
            fullName_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            fullName_label.Location = new Point(90, 126);
            fullName_label.Name = "fullName_label";
            fullName_label.Size = new Size(93, 30);
            fullName_label.TabIndex = 9;
            fullName_label.Text = "Пацієнт";
            // 
            // Add_newMedicalCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(addressPatient_textBox);
            Controls.Add(addressPatient_label);
            Controls.Add(phoneNumber_textBox);
            Controls.Add(phoneNumber_label);
            Controls.Add(dateOfBirth_textBox);
            Controls.Add(dateOfBirth_label);
            Controls.Add(fullName_textBox);
            Controls.Add(fullName_label);
            Name = "Add_newMedicalCard";
            Size = new Size(878, 524);
            Load += Add_newMedicalCard1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox addressPatient_textBox;
        private Label addressPatient_label;
        private TextBox phoneNumber_textBox;
        private Label phoneNumber_label;
        private TextBox dateOfBirth_textBox;
        private Label dateOfBirth_label;
        private TextBox fullName_textBox;
        private Label fullName_label;
    }
}
