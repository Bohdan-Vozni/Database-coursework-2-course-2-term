namespace Helsi
{
    partial class Add_newPatient
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
            fullName_label = new Label();
            fullName_textBox = new TextBox();
            dateOfBirth_textBox = new TextBox();
            dateOfBirth_label = new Label();
            phoneNumber_textBox = new TextBox();
            phoneNumber_label = new Label();
            addressPatient_textBox = new TextBox();
            addressPatient_label = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // fullName_label
            // 
            fullName_label.AutoSize = true;
            fullName_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            fullName_label.Location = new Point(152, 91);
            fullName_label.Name = "fullName_label";
            fullName_label.Size = new Size(54, 30);
            fullName_label.TabIndex = 0;
            fullName_label.Text = "ФІО";
            // 
            // fullName_textBox
            // 
            fullName_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            fullName_textBox.Location = new Point(355, 88);
            fullName_textBox.Name = "fullName_textBox";
            fullName_textBox.Size = new Size(358, 35);
            fullName_textBox.TabIndex = 1;
            // 
            // dateOfBirth_textBox
            // 
            dateOfBirth_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateOfBirth_textBox.Location = new Point(355, 136);
            dateOfBirth_textBox.Name = "dateOfBirth_textBox";
            dateOfBirth_textBox.Size = new Size(358, 35);
            dateOfBirth_textBox.TabIndex = 3;
            // 
            // dateOfBirth_label
            // 
            dateOfBirth_label.AutoSize = true;
            dateOfBirth_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dateOfBirth_label.Location = new Point(152, 141);
            dateOfBirth_label.Name = "dateOfBirth_label";
            dateOfBirth_label.Size = new Size(197, 30);
            dateOfBirth_label.TabIndex = 2;
            dateOfBirth_label.Text = "Дата народження";
            // 
            // phoneNumber_textBox
            // 
            phoneNumber_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phoneNumber_textBox.Location = new Point(355, 191);
            phoneNumber_textBox.Name = "phoneNumber_textBox";
            phoneNumber_textBox.Size = new Size(358, 35);
            phoneNumber_textBox.TabIndex = 5;
            // 
            // phoneNumber_label
            // 
            phoneNumber_label.AutoSize = true;
            phoneNumber_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            phoneNumber_label.Location = new Point(152, 196);
            phoneNumber_label.Name = "phoneNumber_label";
            phoneNumber_label.Size = new Size(186, 30);
            phoneNumber_label.TabIndex = 4;
            phoneNumber_label.Text = "Номер телефону";
            // 
            // addressPatient_textBox
            // 
            addressPatient_textBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            addressPatient_textBox.Location = new Point(355, 243);
            addressPatient_textBox.Name = "addressPatient_textBox";
            addressPatient_textBox.Size = new Size(358, 35);
            addressPatient_textBox.TabIndex = 7;
            // 
            // addressPatient_label
            // 
            addressPatient_label.AutoSize = true;
            addressPatient_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addressPatient_label.Location = new Point(152, 248);
            addressPatient_label.Name = "addressPatient_label";
            addressPatient_label.Size = new Size(170, 30);
            addressPatient_label.TabIndex = 6;
            addressPatient_label.Text = "Адрес пацієнта";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(287, 320);
            button1.Name = "button1";
            button1.Size = new Size(263, 42);
            button1.TabIndex = 8;
            button1.Text = "Додати дані про паціента";
            button1.UseVisualStyleBackColor = true;
            // 
            // Add_newPatient
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
            Name = "Add_newPatient";
            Size = new Size(878, 524);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fullName_label;
        private TextBox fullName_textBox;
        private TextBox dateOfBirth_textBox;
        private Label dateOfBirth_label;
        private TextBox phoneNumber_textBox;
        private Label phoneNumber_label;
        private TextBox addressPatient_textBox;
        private Label addressPatient_label;
        private Button button1;
    }
}
