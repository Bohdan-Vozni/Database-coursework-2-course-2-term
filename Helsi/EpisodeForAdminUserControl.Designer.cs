namespace Helsi
{
    partial class EpisodeForAdminUserControl
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
            episode_dataGridView = new DataGridView();
            updateDataInAllForm_button = new Button();
            updateEpisode_Button = new Button();
            deleteEpisode_Button = new Button();
            addEpisode_Button = new Button();
            description_TextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            diagnosis_TextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            idEpisode_TextBox = new TextBox();
            idMedicalCard_comboBox = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)episode_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // episode_dataGridView
            // 
            episode_dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            episode_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            episode_dataGridView.Location = new Point(384, 171);
            episode_dataGridView.Name = "episode_dataGridView";
            episode_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            episode_dataGridView.Size = new Size(542, 413);
            episode_dataGridView.TabIndex = 17;
            episode_dataGridView.CellContentClick += episode_dataGridView_CellContentClick;
            // 
            // updateDataInAllForm_button
            // 
            updateDataInAllForm_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateDataInAllForm_button.Location = new Point(18, 459);
            updateDataInAllForm_button.Name = "updateDataInAllForm_button";
            updateDataInAllForm_button.Size = new Size(360, 32);
            updateDataInAllForm_button.TabIndex = 39;
            updateDataInAllForm_button.Text = "Оновити дані";
            updateDataInAllForm_button.UseVisualStyleBackColor = true;
            updateDataInAllForm_button.Click += updateDataInAllForm_button_Click;
            // 
            // updateEpisode_Button
            // 
            updateEpisode_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            updateEpisode_Button.Location = new Point(18, 379);
            updateEpisode_Button.Name = "updateEpisode_Button";
            updateEpisode_Button.Size = new Size(360, 36);
            updateEpisode_Button.TabIndex = 38;
            updateEpisode_Button.Text = "Оновити";
            updateEpisode_Button.UseVisualStyleBackColor = true;
            updateEpisode_Button.Click += updateEpisode_Button_Click;
            // 
            // deleteEpisode_Button
            // 
            deleteEpisode_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteEpisode_Button.Location = new Point(18, 421);
            deleteEpisode_Button.Name = "deleteEpisode_Button";
            deleteEpisode_Button.Size = new Size(360, 32);
            deleteEpisode_Button.TabIndex = 37;
            deleteEpisode_Button.Text = "Видалити";
            deleteEpisode_Button.UseVisualStyleBackColor = true;
            deleteEpisode_Button.Click += deleteEpisode_Button_Click;
            // 
            // addEpisode_Button
            // 
            addEpisode_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addEpisode_Button.Location = new Point(18, 339);
            addEpisode_Button.Name = "addEpisode_Button";
            addEpisode_Button.Size = new Size(360, 36);
            addEpisode_Button.TabIndex = 36;
            addEpisode_Button.Text = "Додати";
            addEpisode_Button.UseVisualStyleBackColor = true;
            addEpisode_Button.Click += addEpisode_Button_Click;
            // 
            // description_TextBox
            // 
            description_TextBox.Location = new Point(18, 291);
            description_TextBox.Name = "description_TextBox";
            description_TextBox.Size = new Size(360, 23);
            description_TextBox.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(18, 263);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 41;
            label2.Text = "Опис діагноза";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 197);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 43;
            label1.Text = "Діагноз";
            // 
            // diagnosis_TextBox
            // 
            diagnosis_TextBox.Location = new Point(18, 225);
            diagnosis_TextBox.Name = "diagnosis_TextBox";
            diagnosis_TextBox.Size = new Size(360, 23);
            diagnosis_TextBox.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(18, 143);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 45;
            label3.Text = "Медична картка";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(18, 73);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 47;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // idEpisode_TextBox
            // 
            idEpisode_TextBox.Location = new Point(18, 101);
            idEpisode_TextBox.Name = "idEpisode_TextBox";
            idEpisode_TextBox.Size = new Size(360, 23);
            idEpisode_TextBox.TabIndex = 46;
            idEpisode_TextBox.Visible = false;
            // 
            // idMedicalCard_comboBox
            // 
            idMedicalCard_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            idMedicalCard_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            idMedicalCard_comboBox.FormattingEnabled = true;
            idMedicalCard_comboBox.Location = new Point(18, 171);
            idMedicalCard_comboBox.Name = "idMedicalCard_comboBox";
            idMedicalCard_comboBox.Size = new Size(360, 23);
            idMedicalCard_comboBox.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(339, 35);
            label5.Name = "label5";
            label5.Size = new Size(202, 30);
            label5.TabIndex = 49;
            label5.Text = "Робота з епізодом";
            // 
            // EpisodeForAdminUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(idMedicalCard_comboBox);
            Controls.Add(label4);
            Controls.Add(idEpisode_TextBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(diagnosis_TextBox);
            Controls.Add(label2);
            Controls.Add(description_TextBox);
            Controls.Add(updateDataInAllForm_button);
            Controls.Add(updateEpisode_Button);
            Controls.Add(deleteEpisode_Button);
            Controls.Add(addEpisode_Button);
            Controls.Add(episode_dataGridView);
            Name = "EpisodeForAdminUserControl";
            Size = new Size(929, 587);
            Load += EpisodeForAdminUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)episode_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView episode_dataGridView;
        private Button updateDataInAllForm_button;
        private Button updateEpisode_Button;
        private Button deleteEpisode_Button;
        private Button addEpisode_Button;
        private TextBox description_TextBox;
        private Label label2;
        private Label label1;
        private TextBox diagnosis_TextBox;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox idEpisode_TextBox;
        private ComboBox idMedicalCard_comboBox;
        private Label label5;
    }
}
