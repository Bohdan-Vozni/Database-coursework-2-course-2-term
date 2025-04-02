namespace Helsi
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            helsiToolStripMenuItem = new ToolStripMenuItem();
            newPatient_menuStrip = new ToolStripMenuItem();
            newMedicalCard_menuStrip = new ToolStripMenuItem();
            newEpisode_menuStrip = new ToolStripMenuItem();
            newAction_menuStrip = new ToolStripMenuItem();
            Entrance_menuStrip = new ToolStripMenuItem();
            звітToolStripMenuItem = new ToolStripMenuItem();
            доівідникToolStripMenuItem = new ToolStripMenuItem();
            newPatient_userControl1 = new newPatient_userControl();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { helsiToolStripMenuItem, звітToolStripMenuItem, доівідникToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // helsiToolStripMenuItem
            // 
            helsiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newPatient_menuStrip, newMedicalCard_menuStrip, newEpisode_menuStrip, newAction_menuStrip, Entrance_menuStrip });
            helsiToolStripMenuItem.Name = "helsiToolStripMenuItem";
            helsiToolStripMenuItem.Size = new Size(45, 20);
            helsiToolStripMenuItem.Text = "Helsi";
            // 
            // newPatient_menuStrip
            // 
            newPatient_menuStrip.Name = "newPatient_menuStrip";
            newPatient_menuStrip.Size = new Size(192, 22);
            newPatient_menuStrip.Text = "Новий пацієнт";
            newPatient_menuStrip.Click += newPatient_menuStrip_Click;
            // 
            // newMedicalCard_menuStrip
            // 
            newMedicalCard_menuStrip.Name = "newMedicalCard_menuStrip";
            newMedicalCard_menuStrip.Size = new Size(192, 22);
            newMedicalCard_menuStrip.Text = "Нова медична катрка";
            // 
            // newEpisode_menuStrip
            // 
            newEpisode_menuStrip.Name = "newEpisode_menuStrip";
            newEpisode_menuStrip.Size = new Size(192, 22);
            newEpisode_menuStrip.Text = "Новий епізод";
            // 
            // newAction_menuStrip
            // 
            newAction_menuStrip.Name = "newAction_menuStrip";
            newAction_menuStrip.Size = new Size(192, 22);
            newAction_menuStrip.Text = "Нова дія";
            // 
            // Entrance_menuStrip
            // 
            Entrance_menuStrip.Name = "Entrance_menuStrip";
            Entrance_menuStrip.Size = new Size(192, 22);
            Entrance_menuStrip.Text = "Вихід";
            // 
            // звітToolStripMenuItem
            // 
            звітToolStripMenuItem.Name = "звітToolStripMenuItem";
            звітToolStripMenuItem.Size = new Size(40, 20);
            звітToolStripMenuItem.Text = "Звіт";
            // 
            // доівідникToolStripMenuItem
            // 
            доівідникToolStripMenuItem.Name = "доівідникToolStripMenuItem";
            доівідникToolStripMenuItem.Size = new Size(72, 20);
            доівідникToolStripMenuItem.Text = "Доівідник";
            // 
            // newPatient_userControl1
            // 
            newPatient_userControl1.Location = new Point(0, 27);
            newPatient_userControl1.Name = "newPatient_userControl1";
            newPatient_userControl1.Size = new Size(884, 466);
            newPatient_userControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 489);
            Controls.Add(newPatient_userControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helsiToolStripMenuItem;
        private ToolStripMenuItem newPatient_menuStrip;
        private ToolStripMenuItem newMedicalCard_menuStrip;
        private ToolStripMenuItem newEpisode_menuStrip;
        private ToolStripMenuItem newAction_menuStrip;
        private ToolStripMenuItem Entrance_menuStrip;
        private ToolStripMenuItem звітToolStripMenuItem;
        private ToolStripMenuItem доівідникToolStripMenuItem;
        private newPatient_userControl newPatient_userControl;
        private newPatient_userControl newPatient_userControl1;
    }
}