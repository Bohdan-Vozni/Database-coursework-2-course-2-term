namespace Helsi
{
    partial class ProcedureClientForAdminUserControl
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
            label5 = new Label();
            procedureClient_dataGridView = new DataGridView();
            updateDataInAllForm_button = new Button();
            updateProcedureClient_Button = new Button();
            deleteProcedureClient_Button = new Button();
            addProcedureClient_Button = new Button();
            nameProcedureClient_TextBox = new TextBox();
            idProcedureClient_TextBox = new TextBox();
            descriptionProcedureClient_TextBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            textBoxSearch = new TextBox();
            clearAllField_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)procedureClient_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(293, 31);
            label5.Name = "label5";
            label5.Size = new Size(278, 30);
            label5.TabIndex = 53;
            label5.Text = "Управління процедурами";
            // 
            // procedureClient_dataGridView
            // 
            procedureClient_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            procedureClient_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            procedureClient_dataGridView.Location = new Point(384, 228);
            procedureClient_dataGridView.Name = "procedureClient_dataGridView";
            procedureClient_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            procedureClient_dataGridView.Size = new Size(542, 413);
            procedureClient_dataGridView.TabIndex = 54;
            procedureClient_dataGridView.CellContentClick += procedureClient_dataGridView_CellContentClick;
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 569);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 66;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateProcedureClient_Button
            // 
            updateProcedureClient_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateProcedureClient_Button.Location = new Point(18, 489);
            updateProcedureClient_Button.Name = "updateProcedureClient_Button";
            updateProcedureClient_Button.Size = new Size(360, 36);
            updateProcedureClient_Button.TabIndex = 65;
            updateProcedureClient_Button.Text = "Оновити";
            updateProcedureClient_Button.UseVisualStyleBackColor = true;
            updateProcedureClient_Button.Click += updateProcedureClient_Button_Click;
            // 
            // deleteProcedureClient_Button
            // 
            deleteProcedureClient_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteProcedureClient_Button.Location = new Point(18, 531);
            deleteProcedureClient_Button.Name = "deleteProcedureClient_Button";
            deleteProcedureClient_Button.Size = new Size(360, 32);
            deleteProcedureClient_Button.TabIndex = 64;
            deleteProcedureClient_Button.Text = "Видалити";
            deleteProcedureClient_Button.UseVisualStyleBackColor = true;
            deleteProcedureClient_Button.Click += deleteProcedureClient_Button_Click;
            // 
            // addProcedureClient_Button
            // 
            addProcedureClient_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addProcedureClient_Button.Location = new Point(18, 449);
            addProcedureClient_Button.Name = "addProcedureClient_Button";
            addProcedureClient_Button.Size = new Size(360, 36);
            addProcedureClient_Button.TabIndex = 63;
            addProcedureClient_Button.Text = "Додати";
            addProcedureClient_Button.UseVisualStyleBackColor = true;
            addProcedureClient_Button.Click += addProcedureClient_Button_Click;
            // 
            // nameProcedureClient_TextBox
            // 
            nameProcedureClient_TextBox.Location = new Point(18, 271);
            nameProcedureClient_TextBox.Name = "nameProcedureClient_TextBox";
            nameProcedureClient_TextBox.Size = new Size(360, 23);
            nameProcedureClient_TextBox.TabIndex = 67;
            // 
            // idProcedureClient_TextBox
            // 
            idProcedureClient_TextBox.Location = new Point(18, 157);
            idProcedureClient_TextBox.Name = "idProcedureClient_TextBox";
            idProcedureClient_TextBox.Size = new Size(360, 23);
            idProcedureClient_TextBox.TabIndex = 68;
            idProcedureClient_TextBox.Visible = false;
            // 
            // descriptionProcedureClient_TextBox
            // 
            descriptionProcedureClient_TextBox.Location = new Point(18, 339);
            descriptionProcedureClient_TextBox.Multiline = true;
            descriptionProcedureClient_TextBox.Name = "descriptionProcedureClient_TextBox";
            descriptionProcedureClient_TextBox.Size = new Size(360, 90);
            descriptionProcedureClient_TextBox.TabIndex = 69;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(18, 129);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 70;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(18, 243);
            label3.Name = "label3";
            label3.Size = new Size(176, 25);
            label3.TabIndex = 71;
            label3.Text = "Назва процедури";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 311);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 72;
            label1.Text = "Опис процедури";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(384, 199);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(360, 23);
            textBoxSearch.TabIndex = 74;
            // 
            // clearAllField_Button
            // 
            clearAllField_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            clearAllField_Button.Location = new Point(765, 192);
            clearAllField_Button.Name = "clearAllField_Button";
            clearAllField_Button.Size = new Size(152, 32);
            clearAllField_Button.TabIndex = 73;
            clearAllField_Button.Text = "Очистити поля";
            clearAllField_Button.UseVisualStyleBackColor = true;
            clearAllField_Button.Click += clearAllField_Button_Click;
            // 
            // ProcedureClientForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxSearch);
            Controls.Add(clearAllField_Button);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(descriptionProcedureClient_TextBox);
            Controls.Add(idProcedureClient_TextBox);
            Controls.Add(nameProcedureClient_TextBox);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateProcedureClient_Button);
            Controls.Add(deleteProcedureClient_Button);
            Controls.Add(addProcedureClient_Button);
            Controls.Add(procedureClient_dataGridView);
            Controls.Add(label5);
            Name = "ProcedureClientForAdminUserControl";
            Size = new Size(929, 644);
            Load += ProcedureClientForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)procedureClient_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private DataGridView procedureClient_dataGridView;
        private Button updateDataInAllForm_button;
        private Button updateProcedureClient_Button;
        private Button deleteProcedureClient_Button;
        private Button addProcedureClient_Button;
        private TextBox nameProcedureClient_TextBox;
        private TextBox idProcedureClient_TextBox;
        private TextBox descriptionProcedureClient_TextBox;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox textBoxSearch;
        private Button clearAllField_Button;
    }
}
