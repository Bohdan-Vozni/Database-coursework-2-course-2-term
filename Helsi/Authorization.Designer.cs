namespace Helsi
{
    partial class Authorization
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            authorizationBackgroundColor_panel = new Panel();
            authorization_label = new Label();
            loginInDatabase_button = new Button();
            login_label = new Label();
            close_button = new Button();
            password_label = new Label();
            login_textBox = new TextBox();
            password_textBox = new TextBox();
            pictureBox1 = new PictureBox();
            mainBackgroundColor_panel = new Panel();
            authorizationBackgroundColor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainBackgroundColor_panel.SuspendLayout();
            SuspendLayout();
            // 
            // authorizationBackgroundColor_panel
            // 
            authorizationBackgroundColor_panel.BackColor = SystemColors.Highlight;
            authorizationBackgroundColor_panel.Controls.Add(authorization_label);
            authorizationBackgroundColor_panel.Location = new Point(0, 0);
            authorizationBackgroundColor_panel.Name = "authorizationBackgroundColor_panel";
            authorizationBackgroundColor_panel.Size = new Size(331, 76);
            authorizationBackgroundColor_panel.TabIndex = 4;
            // 
            // authorization_label
            // 
            authorization_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            authorization_label.Location = new Point(77, 25);
            authorization_label.Name = "authorization_label";
            authorization_label.Size = new Size(136, 30);
            authorization_label.TabIndex = 1;
            authorization_label.Text = "Authorization";
            // 
            // loginInDatabase_button
            // 
            loginInDatabase_button.BackColor = SystemColors.AppWorkspace;
            loginInDatabase_button.Cursor = Cursors.Hand;
            loginInDatabase_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            loginInDatabase_button.FlatStyle = FlatStyle.Flat;
            loginInDatabase_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            loginInDatabase_button.Location = new Point(93, 237);
            loginInDatabase_button.Name = "loginInDatabase_button";
            loginInDatabase_button.Size = new Size(120, 40);
            loginInDatabase_button.TabIndex = 0;
            loginInDatabase_button.Text = "Login";
            loginInDatabase_button.UseVisualStyleBackColor = false;
            loginInDatabase_button.Click += loginInDatabase_button_Click;
            // 
            // login_label
            // 
            login_label.AutoSize = true;
            login_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            login_label.Location = new Point(3, 131);
            login_label.Name = "login_label";
            login_label.Size = new Size(78, 32);
            login_label.TabIndex = 2;
            login_label.Text = "Login";
            // 
            // close_button
            // 
            close_button.AutoSize = true;
            close_button.BackColor = SystemColors.AppWorkspace;
            close_button.Cursor = Cursors.Hand;
            close_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            close_button.FlatStyle = FlatStyle.Flat;
            close_button.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            close_button.Location = new Point(283, 0);
            close_button.Name = "close_button";
            close_button.Size = new Size(47, 49);
            close_button.TabIndex = 3;
            close_button.Text = "X";
            close_button.UseVisualStyleBackColor = false;
            close_button.Click += close_button_Click;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            password_label.Location = new Point(3, 178);
            password_label.Name = "password_label";
            password_label.Size = new Size(122, 32);
            password_label.TabIndex = 5;
            password_label.Text = "Password";
            // 
            // login_textBox
            // 
            login_textBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_textBox.Location = new Point(125, 128);
            login_textBox.Name = "login_textBox";
            login_textBox.Size = new Size(205, 39);
            login_textBox.TabIndex = 6;
            // 
            // password_textBox
            // 
            password_textBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            password_textBox.Location = new Point(125, 175);
            password_textBox.Name = "password_textBox";
            password_textBox.Size = new Size(205, 39);
            password_textBox.TabIndex = 7;
            password_textBox.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(66, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // mainBackgroundColor_panel
            // 
            mainBackgroundColor_panel.BackColor = SystemColors.ActiveCaption;
            mainBackgroundColor_panel.Controls.Add(pictureBox1);
            mainBackgroundColor_panel.Controls.Add(password_textBox);
            mainBackgroundColor_panel.Controls.Add(login_textBox);
            mainBackgroundColor_panel.Controls.Add(password_label);
            mainBackgroundColor_panel.Controls.Add(close_button);
            mainBackgroundColor_panel.Controls.Add(login_label);
            mainBackgroundColor_panel.Controls.Add(loginInDatabase_button);
            mainBackgroundColor_panel.Controls.Add(authorizationBackgroundColor_panel);
            mainBackgroundColor_panel.Location = new Point(-1, 0);
            mainBackgroundColor_panel.Name = "mainBackgroundColor_panel";
            mainBackgroundColor_panel.Size = new Size(334, 302);
            mainBackgroundColor_panel.TabIndex = 1;
            // 
            // Authorization
            // 
            ClientSize = new Size(332, 302);
            Controls.Add(mainBackgroundColor_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Authorization";
            StartPosition = FormStartPosition.CenterScreen;
            authorizationBackgroundColor_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainBackgroundColor_panel.ResumeLayout(false);
            mainBackgroundColor_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem логінToolStripMenuItem;
        private ToolStripMenuItem увійтиToolStripMenuItem;
        private ToolStripMenuItem вийтиToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel authorizationBackgroundColor_panel;
        private Label authorization_label;
        private Button loginInDatabase_button;
        private Label login_label;
        private Button close_button;
        private Label password_label;
        private TextBox login_textBox;
        private TextBox password_textBox;
        private PictureBox pictureBox1;
        private Panel mainBackgroundColor_panel;
    }
}
