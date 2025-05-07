namespace Helsi
{
    partial class ActionForAdminUserControl
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
            action_dataGridView = new DataGridView();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label1 = new Label();
            updateDataInAllForm_button = new Button();
            updateAction_Button = new Button();
            deleteAction_Button = new Button();
            addAction_Button = new Button();
            idMedicalCard_comboBox = new ComboBox();
            idEpisodeCard_comboBox = new ComboBox();
            idDoctor_comboBox = new ComboBox();
            idProcedure_comboBox = new ComboBox();
            label7 = new Label();
            idMedication_comboBox = new ComboBox();
            label8 = new Label();
            descriptionAction_TextBox = new TextBox();
            dateTimeAction_TextBox = new TextBox();
            textBoxSearch = new TextBox();
            clearAllField_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)action_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // action_dataGridView
            // 
            action_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            action_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            action_dataGridView.Location = new Point(384, 228);
            action_dataGridView.Name = "action_dataGridView";
            action_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            action_dataGridView.Size = new Size(542, 413);
            action_dataGridView.TabIndex = 19;
            action_dataGridView.CellContentClick += action_dataGridView_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(19, 302);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 72;
            label6.Text = "Дата час";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(18, 241);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 70;
            label5.Text = "Опис дії";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(19, 178);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 68;
            label3.Text = "Медична картка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(19, 116);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 66;
            label2.Text = "Епізод";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(19, 62);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 65;
            label4.Text = "Доктор";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(328, 28);
            label1.Name = "label1";
            label1.Size = new Size(171, 30);
            label1.TabIndex = 63;
            label1.Text = "Робота з дійою";
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 599);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 62;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateAction_Button
            // 
            updateAction_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateAction_Button.Location = new Point(18, 519);
            updateAction_Button.Name = "updateAction_Button";
            updateAction_Button.Size = new Size(360, 36);
            updateAction_Button.TabIndex = 61;
            updateAction_Button.Text = "Оновити";
            updateAction_Button.UseVisualStyleBackColor = true;
            updateAction_Button.Click += updateAction_Button_Click;
            // 
            // deleteAction_Button
            // 
            deleteAction_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteAction_Button.Location = new Point(18, 561);
            deleteAction_Button.Name = "deleteAction_Button";
            deleteAction_Button.Size = new Size(360, 32);
            deleteAction_Button.TabIndex = 60;
            deleteAction_Button.Text = "Видалити";
            deleteAction_Button.UseVisualStyleBackColor = true;
            deleteAction_Button.Click += deleteAction_Button_Click;
            // 
            // addAction_Button
            // 
            addAction_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addAction_Button.Location = new Point(19, 479);
            addAction_Button.Name = "addAction_Button";
            addAction_Button.Size = new Size(360, 36);
            addAction_Button.TabIndex = 59;
            addAction_Button.Text = "Додати";
            addAction_Button.UseVisualStyleBackColor = true;
            addAction_Button.Click += addAction_Button_Click;
            // 
            // idMedicalCard_comboBox
            // 
            idMedicalCard_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idMedicalCard_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idMedicalCard_comboBox.FormattingEnabled = true;
            idMedicalCard_comboBox.Location = new Point(19, 206);
            idMedicalCard_comboBox.Name = "idMedicalCard_comboBox";
            idMedicalCard_comboBox.Size = new Size(360, 23);
            idMedicalCard_comboBox.TabIndex = 73;
            // 
            // idEpisodeCard_comboBox
            // 
            idEpisodeCard_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idEpisodeCard_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idEpisodeCard_comboBox.FormattingEnabled = true;
            idEpisodeCard_comboBox.Location = new Point(19, 144);
            idEpisodeCard_comboBox.Name = "idEpisodeCard_comboBox";
            idEpisodeCard_comboBox.Size = new Size(360, 23);
            idEpisodeCard_comboBox.TabIndex = 74;
            // 
            // idDoctor_comboBox
            // 
            idDoctor_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idDoctor_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idDoctor_comboBox.FormattingEnabled = true;
            idDoctor_comboBox.Location = new Point(19, 90);
            idDoctor_comboBox.Name = "idDoctor_comboBox";
            idDoctor_comboBox.Size = new Size(360, 23);
            idDoctor_comboBox.TabIndex = 75;
            // 
            // idProcedure_comboBox
            // 
            idProcedure_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idProcedure_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idProcedure_comboBox.FormattingEnabled = true;
            idProcedure_comboBox.Location = new Point(20, 385);
            idProcedure_comboBox.Name = "idProcedure_comboBox";
            idProcedure_comboBox.Size = new Size(360, 23);
            idProcedure_comboBox.TabIndex = 77;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(21, 357);
            label7.Name = "label7";
            label7.Size = new Size(176, 25);
            label7.TabIndex = 76;
            label7.Text = "Назва процедури";
            // 
            // idMedication_comboBox
            // 
            idMedication_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idMedication_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idMedication_comboBox.FormattingEnabled = true;
            idMedication_comboBox.Location = new Point(19, 439);
            idMedication_comboBox.Name = "idMedication_comboBox";
            idMedication_comboBox.Size = new Size(360, 23);
            idMedication_comboBox.TabIndex = 79;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.Location = new Point(20, 411);
            label8.Name = "label8";
            label8.Size = new Size(131, 25);
            label8.TabIndex = 78;
            label8.Text = "Медикамент";
            // 
            // descriptionAction_TextBox
            // 
            descriptionAction_TextBox.Location = new Point(18, 269);
            descriptionAction_TextBox.Name = "descriptionAction_TextBox";
            descriptionAction_TextBox.Size = new Size(360, 23);
            descriptionAction_TextBox.TabIndex = 80;
            // 
            // dateTimeAction_TextBox
            // 
            dateTimeAction_TextBox.Location = new Point(19, 331);
            dateTimeAction_TextBox.Name = "dateTimeAction_TextBox";
            dateTimeAction_TextBox.Size = new Size(360, 23);
            dateTimeAction_TextBox.TabIndex = 81;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(383, 197);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(360, 23);
            textBoxSearch.TabIndex = 83;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // clearAllField_Button
            // 
            clearAllField_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            clearAllField_Button.Location = new Point(764, 190);
            clearAllField_Button.Name = "clearAllField_Button";
            clearAllField_Button.Size = new Size(152, 32);
            clearAllField_Button.TabIndex = 82;
            clearAllField_Button.Text = "Очистити поля";
            clearAllField_Button.UseVisualStyleBackColor = true;
            clearAllField_Button.Click += clearAllField_Button_Click;
            // 
            // ActionForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxSearch);
            Controls.Add(clearAllField_Button);
            Controls.Add(dateTimeAction_TextBox);
            Controls.Add(descriptionAction_TextBox);
            Controls.Add(idMedication_comboBox);
            Controls.Add(label8);
            Controls.Add(idProcedure_comboBox);
            Controls.Add(label7);
            Controls.Add(idDoctor_comboBox);
            Controls.Add(idEpisodeCard_comboBox);
            Controls.Add(idMedicalCard_comboBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateAction_Button);
            Controls.Add(deleteAction_Button);
            Controls.Add(addAction_Button);
            Controls.Add(action_dataGridView);
            Name = "ActionForAdminUserControl";
            Size = new Size(929, 644);
            Load += ActionForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)action_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView action_dataGridView;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label1;
        private Button updateDataInAllForm_button;
        private Button updateAction_Button;
        private Button deleteAction_Button;
        private Button addAction_Button;
        private ComboBox idMedicalCard_comboBox;
        private ComboBox idEpisodeCard_comboBox;
        private ComboBox idDoctor_comboBox;
        private ComboBox idProcedure_comboBox;
        private Label label7;
        private ComboBox idMedication_comboBox;
        private Label label8;
        private TextBox descriptionAction_TextBox;
        private TextBox dateTimeAction_TextBox;
        private TextBox textBoxSearch;
        private Button clearAllField_Button;
    }
}
