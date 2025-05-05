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
            patient_ToolStripMenuItem = new ToolStripMenuItem();
            medicalCard_ToolStripMenuItem = new ToolStripMenuItem();
            епізодToolStripMenuItem1 = new ToolStripMenuItem();
            діяToolStripMenuItem1 = new ToolStripMenuItem();
            відділенняToolStripMenuItem = new ToolStripMenuItem();
            докторToolStripMenuItem = new ToolStripMenuItem();
            адмінToolStripMenuItem = new ToolStripMenuItem();
            patientForAdmin_ToolStripMenuItem = new ToolStripMenuItem();
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            DoctorForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            closeUserControllForAddInfo_button = new Button();
            medicalCardForAdminUserControl1 = new medicalCardForAdminUserControl();
            episodeForAdminUserControl1 = new EpisodeForAdminUserControl();
            doctorForAdminUserControl1 = new DoctorForAdminUserControl();
            doctorForAdminUserControl2 = new DoctorForAdminUserControl();
            actionForAdminUserControl1 = new ActionForAdminUserControl();
            ActionForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helsiToolStripMenuItem, patient_StripMenu, відділенняToolStripMenuItem, адмінToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1043, 24);
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
            patient_StripMenu.DropDownItems.AddRange(new ToolStripItem[] { patient_ToolStripMenuItem, medicalCard_ToolStripMenuItem, епізодToolStripMenuItem1, діяToolStripMenuItem1 });
            patient_StripMenu.Name = "patient_StripMenu";
            patient_StripMenu.Size = new Size(92, 20);
            patient_StripMenu.Text = "Про пацієнта";
            // 
            // patient_ToolStripMenuItem
            // 
            patient_ToolStripMenuItem.Name = "patient_ToolStripMenuItem";
            patient_ToolStripMenuItem.Size = new Size(157, 22);
            patient_ToolStripMenuItem.Text = "Пацієнт";
            patient_ToolStripMenuItem.Click += patient_ToolStripMenuItem_Click;
            // 
            // medicalCard_ToolStripMenuItem
            // 
            medicalCard_ToolStripMenuItem.Name = "medicalCard_ToolStripMenuItem";
            medicalCard_ToolStripMenuItem.Size = new Size(157, 22);
            medicalCard_ToolStripMenuItem.Text = "Медична катра";
            medicalCard_ToolStripMenuItem.Click += medicalCard_ToolStripMenuItem_Click;
            // 
            // епізодToolStripMenuItem1
            // 
            епізодToolStripMenuItem1.Name = "епізодToolStripMenuItem1";
            епізодToolStripMenuItem1.Size = new Size(157, 22);
            епізодToolStripMenuItem1.Text = "Епізод";
            // 
            // діяToolStripMenuItem1
            // 
            діяToolStripMenuItem1.Name = "діяToolStripMenuItem1";
            діяToolStripMenuItem1.Size = new Size(157, 22);
            діяToolStripMenuItem1.Text = "Дія";
            // 
            // відділенняToolStripMenuItem
            // 
            відділенняToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { докторToolStripMenuItem });
            відділенняToolStripMenuItem.Name = "відділенняToolStripMenuItem";
            відділенняToolStripMenuItem.Size = new Size(77, 20);
            відділенняToolStripMenuItem.Text = "Відділення";
            // 
            // докторToolStripMenuItem
            // 
            докторToolStripMenuItem.Name = "докторToolStripMenuItem";
            докторToolStripMenuItem.Size = new Size(114, 22);
            докторToolStripMenuItem.Text = "Доктор";
            // 
            // адмінToolStripMenuItem
            // 
            адмінToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { patientForAdmin_ToolStripMenuItem, medicalCartForAdmin_ToolStripMenuItemolStripMenuItem, EpisodeForAdmin_ToolStripMenuItemolStripMenuItem, DoctorForAdmin_ToolStripMenuItemolStripMenuItem, ActionForAdmin_ToolStripMenuItemolStripMenuItem });
            адмінToolStripMenuItem.Name = "адмінToolStripMenuItem";
            адмінToolStripMenuItem.Size = new Size(52, 20);
            адмінToolStripMenuItem.Text = "Адмін";
            // 
            // patientForAdmin_ToolStripMenuItem
            // 
            patientForAdmin_ToolStripMenuItem.Name = "patientForAdmin_ToolStripMenuItem";
            patientForAdmin_ToolStripMenuItem.Size = new Size(180, 22);
            patientForAdmin_ToolStripMenuItem.Text = "Паціент";
            patientForAdmin_ToolStripMenuItem.Click += patientForAdmin_ToolStripMenuItem_Click;
            // 
            // medicalCartForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Name = "medicalCartForAdmin_ToolStripMenuItemolStripMenuItem";
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(180, 22);
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Медична карта";
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Click += medicalCartForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // EpisodeForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Name = "EpisodeForAdmin_ToolStripMenuItemolStripMenuItem";
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(180, 22);
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Eпізод";
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Click += EpisodeForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // DoctorForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            DoctorForAdmin_ToolStripMenuItemolStripMenuItem.Name = "DoctorForAdmin_ToolStripMenuItemolStripMenuItem";
            DoctorForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(180, 22);
            DoctorForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Доктор";
            DoctorForAdmin_ToolStripMenuItemolStripMenuItem.Click += DoctorForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // closeUserControllForAddInfo_button
            // 
            closeUserControllForAddInfo_button.Location = new Point(809, 27);
            closeUserControllForAddInfo_button.Name = "closeUserControllForAddInfo_button";
            closeUserControllForAddInfo_button.Size = new Size(75, 40);
            closeUserControllForAddInfo_button.TabIndex = 3;
            closeUserControllForAddInfo_button.Text = "X";
            closeUserControllForAddInfo_button.UseVisualStyleBackColor = true;
            closeUserControllForAddInfo_button.Click += closeUserControllForAddInfo_button_Click;
            // 
            // medicalCardForAdminUserControl1
            // 
            medicalCardForAdminUserControl1.Location = new Point(0, 27);
            medicalCardForAdminUserControl1.Name = "medicalCardForAdminUserControl1";
            medicalCardForAdminUserControl1.Size = new Size(972, 589);
            medicalCardForAdminUserControl1.TabIndex = 4;
            // 
            // episodeForAdminUserControl1
            // 
            episodeForAdminUserControl1.Location = new Point(1, 27);
            episodeForAdminUserControl1.Name = "episodeForAdminUserControl1";
            episodeForAdminUserControl1.Size = new Size(1043, 678);
            episodeForAdminUserControl1.TabIndex = 5;
            // 
            // doctorForAdminUserControl1
            // 
            doctorForAdminUserControl1.Location = new Point(864, 785);
            doctorForAdminUserControl1.Name = "doctorForAdminUserControl1";
            doctorForAdminUserControl1.Size = new Size(8, 8);
            doctorForAdminUserControl1.TabIndex = 6;
            // 
            // doctorForAdminUserControl2
            // 
            doctorForAdminUserControl2.Location = new Point(1, 27);
            doctorForAdminUserControl2.Name = "doctorForAdminUserControl2";
            doctorForAdminUserControl2.Size = new Size(1030, 614);
            doctorForAdminUserControl2.TabIndex = 7;
            // 
            // actionForAdminUserControl1
            // 
            actionForAdminUserControl1.Location = new Point(0, 27);
            actionForAdminUserControl1.Name = "actionForAdminUserControl1";
            actionForAdminUserControl1.Size = new Size(1044, 688);
            actionForAdminUserControl1.TabIndex = 8;
            // 
            // ActionForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Name = "ActionForAdmin_ToolStripMenuItemolStripMenuItem";
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(180, 22);
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Дія";
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Click += ActionForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 799);
            Controls.Add(actionForAdminUserControl1);
            Controls.Add(doctorForAdminUserControl2);
            Controls.Add(doctorForAdminUserControl1);
            Controls.Add(episodeForAdminUserControl1);
            Controls.Add(medicalCardForAdminUserControl1);
            Controls.Add(closeUserControllForAddInfo_button);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Проект на тему \"організоване робоче місце медичної сестри\". Возного Богдана";
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
        private ToolStripMenuItem patient_StripMenu;
        private ToolStripMenuItem patient_ToolStripMenuItem;
        private ToolStripMenuItem medicalCard_ToolStripMenuItem;
        private ToolStripMenuItem епізодToolStripMenuItem1;
        private ToolStripMenuItem діяToolStripMenuItem1;
        private Button closeUserControllForAddInfo_button;
        private ToolStripMenuItem відділенняToolStripMenuItem;
        private ToolStripMenuItem докторToolStripMenuItem;
        private ToolStripMenuItem адмінToolStripMenuItem;
        private ToolStripMenuItem patientForAdmin_ToolStripMenuItem;
        private PatientForAdminUserControl patientForAdminUserControl;
        private medicalCardForAdminUserControl medicalCardForAdminUserControl1;
        private ToolStripMenuItem medicalCartForAdmin_ToolStripMenuItemolStripMenuItem;
        private EpisodeForAdminUserControl episodeForAdminUserControl1;
        private ToolStripMenuItem EpisodeForAdmin_ToolStripMenuItemolStripMenuItem;
        private DoctorForAdminUserControl doctorForAdminUserControl1;
        private DoctorForAdminUserControl doctorForAdminUserControl2;
        private ToolStripMenuItem DoctorForAdmin_ToolStripMenuItemolStripMenuItem;
        private ToolStripMenuItem ActionForAdmin_ToolStripMenuItemolStripMenuItem;
        private ActionForAdminUserControl actionForAdminUserControl1;
    }
}