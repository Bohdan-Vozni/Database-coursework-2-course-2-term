namespace Helsi
{
    partial class GenerateReportUserControl
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
            generetaReport_button = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            resultField_dataGridView = new DataGridView();
            allField_dataGridView = new DataGridView();
            deleteAddFieldInResultGrit = new Button();
            label4 = new Label();
            nameRepot_textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)resultField_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)allField_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // generetaReport_button
            // 
            generetaReport_button.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            generetaReport_button.Location = new Point(99, 511);
            generetaReport_button.Name = "generetaReport_button";
            generetaReport_button.Size = new Size(305, 60);
            generetaReport_button.TabIndex = 11;
            generetaReport_button.Text = "Генерувати";
            generetaReport_button.UseVisualStyleBackColor = true;
            generetaReport_button.Click += generetaReport_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(561, 141);
            label3.Name = "label3";
            label3.Size = new Size(158, 30);
            label3.TabIndex = 10;
            label3.Text = "Дані для звіту";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(130, 141);
            label2.Name = "label2";
            label2.Size = new Size(197, 30);
            label2.TabIndex = 9;
            label2.Text = "Всі можливі поля";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(359, -2);
            label1.Name = "label1";
            label1.Size = new Size(217, 30);
            label1.TabIndex = 8;
            label1.Text = "Конфігуратор звітів";
            // 
            // resultField_dataGridView
            // 
            resultField_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultField_dataGridView.Location = new Point(471, 189);
            resultField_dataGridView.Name = "resultField_dataGridView";
            resultField_dataGridView.Size = new Size(433, 303);
            resultField_dataGridView.TabIndex = 7;
            // 
            // allField_dataGridView
            // 
            allField_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allField_dataGridView.Location = new Point(24, 189);
            allField_dataGridView.Name = "allField_dataGridView";
            allField_dataGridView.Size = new Size(430, 303);
            allField_dataGridView.TabIndex = 6;
            // 
            // deleteAddFieldInResultGrit
            // 
            deleteAddFieldInResultGrit.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteAddFieldInResultGrit.Location = new Point(493, 511);
            deleteAddFieldInResultGrit.Name = "deleteAddFieldInResultGrit";
            deleteAddFieldInResultGrit.Size = new Size(305, 60);
            deleteAddFieldInResultGrit.TabIndex = 12;
            deleteAddFieldInResultGrit.Text = "Видалити всі дані звіту";
            deleteAddFieldInResultGrit.UseVisualStyleBackColor = true;
            deleteAddFieldInResultGrit.Click += deleteAddFieldInResultGrit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(24, 77);
            label4.Name = "label4";
            label4.Size = new Size(208, 30);
            label4.TabIndex = 13;
            label4.Text = "Введіть назву звіту";
            // 
            // nameRepot_textBox
            // 
            nameRepot_textBox.Location = new Point(238, 84);
            nameRepot_textBox.Name = "nameRepot_textBox";
            nameRepot_textBox.Size = new Size(333, 23);
            nameRepot_textBox.TabIndex = 14;
            // 
            // GenerateReportUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nameRepot_textBox);
            Controls.Add(label4);
            Controls.Add(deleteAddFieldInResultGrit);
            Controls.Add(generetaReport_button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(resultField_dataGridView);
            Controls.Add(allField_dataGridView);
            Name = "GenerateReportUserControl";
            Size = new Size(929, 587);
            Load += GenerateReportUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)resultField_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)allField_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generetaReport_button;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView resultField_dataGridView;
        private DataGridView allField_dataGridView;
        private Button deleteAddFieldInResultGrit;
        private Label label4;
        private TextBox nameRepot_textBox;
    }
}
