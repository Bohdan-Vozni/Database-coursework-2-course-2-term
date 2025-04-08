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
            Entrance_menuStrip = new ToolStripMenuItem();
            patient_StripMenu = new ToolStripMenuItem();
            medicalCard_StripMenu = new ToolStripMenuItem();
            епізодToolStripMenuItem = new ToolStripMenuItem();
            діяToolStripMenuItem = new ToolStripMenuItem();
            докторToolStripMenuItem = new ToolStripMenuItem();
            доівідникToolStripMenuItem = new ToolStripMenuItem();
            звітToolStripMenuItem = new ToolStripMenuItem();
            newMedicalCard_userControl = new Add_newMedicalCard();
            newPatient_userControl = new Add_newPatient();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helsiToolStripMenuItem, patient_StripMenu, medicalCard_StripMenu, епізодToolStripMenuItem, діяToolStripMenuItem, докторToolStripMenuItem, доівідникToolStripMenuItem, звітToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // helsiToolStripMenuItem
            // 
            helsiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Entrance_menuStrip });
            helsiToolStripMenuItem.Name = "helsiToolStripMenuItem";
            helsiToolStripMenuItem.Size = new Size(45, 20);
            helsiToolStripMenuItem.Text = "Helsi";
            // 
            // Entrance_menuStrip
            // 
            Entrance_menuStrip.Name = "Entrance_menuStrip";
            Entrance_menuStrip.Size = new Size(103, 22);
            Entrance_menuStrip.Text = "Вихід";
            Entrance_menuStrip.Click += Entrance_menuStrip_Click;
            // 
            // patient_StripMenu
            // 
            patient_StripMenu.Name = "patient_StripMenu";
            patient_StripMenu.Size = new Size(62, 20);
            patient_StripMenu.Text = "Паціент";
            patient_StripMenu.Click += patient_StripMenu_Click;
            // 
            // medicalCard_StripMenu
            // 
            medicalCard_StripMenu.Name = "medicalCard_StripMenu";
            medicalCard_StripMenu.Size = new Size(102, 20);
            medicalCard_StripMenu.Text = "Медична карта";
            medicalCard_StripMenu.Click += medicalCard_StripMenu_Click;
            // 
            // епізодToolStripMenuItem
            // 
            епізодToolStripMenuItem.Name = "епізодToolStripMenuItem";
            епізодToolStripMenuItem.Size = new Size(53, 20);
            епізодToolStripMenuItem.Text = "Епізод";
            // 
            // діяToolStripMenuItem
            // 
            діяToolStripMenuItem.Name = "діяToolStripMenuItem";
            діяToolStripMenuItem.Size = new Size(36, 20);
            діяToolStripMenuItem.Text = "Дія";
            // 
            // докторToolStripMenuItem
            // 
            докторToolStripMenuItem.Name = "докторToolStripMenuItem";
            докторToolStripMenuItem.Size = new Size(59, 20);
            докторToolStripMenuItem.Text = "Доктор";
            // 
            // доівідникToolStripMenuItem
            // 
            доівідникToolStripMenuItem.Name = "доівідникToolStripMenuItem";
            доівідникToolStripMenuItem.Size = new Size(69, 20);
            доівідникToolStripMenuItem.Text = "Довідник";
            // 
            // звітToolStripMenuItem
            // 
            звітToolStripMenuItem.Name = "звітToolStripMenuItem";
            звітToolStripMenuItem.Size = new Size(40, 20);
            звітToolStripMenuItem.Text = "Звіт";
            // 
            // newMedicalCard_userControl
            // 
            newMedicalCard_userControl.Location = new Point(0, 27);
            newMedicalCard_userControl.Margin = new Padding(3, 4, 3, 4);
            newMedicalCard_userControl.Name = "newMedicalCard_userControl";
            newMedicalCard_userControl.Size = new Size(884, 462);
            newMedicalCard_userControl.TabIndex = 1;
            // 
            // newPatient_userControl
            // 
            newPatient_userControl.Location = new Point(0, 27);
            newPatient_userControl.Margin = new Padding(3, 4, 3, 4);
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
        private ToolStripMenuItem Entrance_menuStrip;
        private ToolStripMenuItem звітToolStripMenuItem;
        private ToolStripMenuItem доівідникToolStripMenuItem;
        private Add_newMedicalCard newMedicalCard_userControl;
        private Add_newPatient newPatient_userControl;
        private ToolStripMenuItem patient_StripMenu;
        private ToolStripMenuItem medicalCard_StripMenu;
        private ToolStripMenuItem епізодToolStripMenuItem;
        private ToolStripMenuItem діяToolStripMenuItem;
        private ToolStripMenuItem докторToolStripMenuItem;
    }
}