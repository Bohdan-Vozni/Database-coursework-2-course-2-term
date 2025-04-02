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
            newDoctor_menuStrip = new ToolStripMenuItem();
            Entrance_menuStrip = new ToolStripMenuItem();
            звітToolStripMenuItem = new ToolStripMenuItem();
            доівідникToolStripMenuItem = new ToolStripMenuItem();
            newMedicalCard_userControl = new Add_newMedicalCard();
            newPatient_userControl = new Add_newPatient();
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
            helsiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newPatient_menuStrip, newMedicalCard_menuStrip, newEpisode_menuStrip, newAction_menuStrip, newDoctor_menuStrip, Entrance_menuStrip });
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
            newMedicalCard_menuStrip.Click += newMedicalCard_menuStrip_Click_1;
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
            // newDoctor_menuStrip
            // 
            newDoctor_menuStrip.Name = "newDoctor_menuStrip";
            newDoctor_menuStrip.Size = new Size(192, 22);
            newDoctor_menuStrip.Text = "Новий доктор";
            // 
            // Entrance_menuStrip
            // 
            Entrance_menuStrip.Name = "Entrance_menuStrip";
            Entrance_menuStrip.Size = new Size(192, 22);
            Entrance_menuStrip.Text = "Вихід";
            Entrance_menuStrip.Click += Entrance_menuStrip_Click;
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
            // newMedicalCard_userControl
            // 
            newMedicalCard_userControl.Location = new Point(0, 27);
            newMedicalCard_userControl.Name = "newMedicalCard_userControl";
            newMedicalCard_userControl.Size = new Size(884, 462);
            newMedicalCard_userControl.TabIndex = 1;
            // 
            // newPatient_userControl
            // 
            newPatient_userControl.Location = new Point(0, 27);
            newPatient_userControl.Name = "newPatient_userControl";
            newPatient_userControl.Size = new Size(884, 462);
            newPatient_userControl.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 489);
            Controls.Add(newPatient_userControl);
            Controls.Add(newMedicalCard_userControl);
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


        private ToolStripMenuItem newDoctor_menuStrip;
        private Add_newMedicalCard newMedicalCard_userControl;
        private Add_newPatient newPatient_userControl;
    }
}