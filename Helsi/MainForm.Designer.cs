﻿namespace Helsi
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
            newMedicalCard_userControl = new Add_newMedicalCard();
            newPatient_userControl = new Add_newPatient();
            closeUserControllForAddInfo_button = new Button();
            відділенняToolStripMenuItem = new ToolStripMenuItem();
            докторToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helsiToolStripMenuItem, patient_StripMenu, відділенняToolStripMenuItem });
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
            Entrance_menuStrip.Size = new Size(180, 22);
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
            докторToolStripMenuItem.Size = new Size(180, 22);
            докторToolStripMenuItem.Text = "Доктор";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 489);
            Controls.Add(closeUserControllForAddInfo_button);
            Controls.Add(newMedicalCard_userControl);
            Controls.Add(menuStrip1);
            Controls.Add(newPatient_userControl);
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
        private Add_newMedicalCard newMedicalCard_userControl;
        private Add_newPatient newPatient_userControl;
        private ToolStripMenuItem patient_StripMenu;
        private ToolStripMenuItem patient_ToolStripMenuItem;
        private ToolStripMenuItem medicalCard_ToolStripMenuItem;
        private ToolStripMenuItem епізодToolStripMenuItem1;
        private ToolStripMenuItem діяToolStripMenuItem1;
        private Button closeUserControllForAddInfo_button;
        private ToolStripMenuItem відділенняToolStripMenuItem;
        private ToolStripMenuItem докторToolStripMenuItem;
    }
}