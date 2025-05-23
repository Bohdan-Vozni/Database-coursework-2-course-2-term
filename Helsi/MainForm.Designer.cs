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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            helsiToolStripMenuItem = new ToolStripMenuItem();
            Entrance_menuStrip = new ToolStripMenuItem();
            MainPage_ToolStripMenuItem = new ToolStripMenuItem();
            medicalRecord_ToolStripMenuItem = new ToolStripMenuItem();
            patientForAdmin_ToolStripMenuItem = new ToolStripMenuItem();
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            ActionForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            MedicationForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem = new ToolStripMenuItem();
            allDiagnosisPatients_ToolStripMenuItem = new ToolStripMenuItem();
            loadDoctor_ToolStripMenuItem = new ToolStripMenuItem();
            expirationDateDrugToolStripMenuItem = new ToolStripMenuItem();
            useDrugOnDepartmentFor3Manth_ToolStripMenuItem = new ToolStripMenuItem();
            reportPatientTheHighestVisitLast1Year_ToolStripMenuItem = new ToolStripMenuItem();
            generateReportToolStripMenuItem = new ToolStripMenuItem();
            doctor_ToolStripMenuItem = new ToolStripMenuItem();
            department_ToolStripMenuItem = new ToolStripMenuItem();
            closeUserControllForAddInfo_button = new Button();
            medicalCardForAdminUserControl1 = new medicalCardForAdminUserControl();
            episodeForAdminUserControl1 = new EpisodeForAdminUserControl();
            doctorForAdminUserControl1 = new DoctorForAdminUserControl();
            doctorForAdminUserControl2 = new DoctorForAdminUserControl();
            actionForAdminUserControl1 = new ActionForAdminUserControl();
            departmentForAdminUserControl1 = new DepartmentForAdminUserControl();
            medicationForAdminUserControl1 = new MedicationForAdminUserControl();
            procedureClientForAdminUserControl1 = new ProcedureClientForAdminUserControl();
            reportAllDiagnosisForPatients1 = new ForAllReportUserControl();
            layout_pictureBox = new PictureBox();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layout_pictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { helsiToolStripMenuItem, MainPage_ToolStripMenuItem, medicalRecord_ToolStripMenuItem, звітиToolStripMenuItem, generateReportToolStripMenuItem, doctor_ToolStripMenuItem, department_ToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(945, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
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
            // MainPage_ToolStripMenuItem
            // 
            MainPage_ToolStripMenuItem.Name = "MainPage_ToolStripMenuItem";
            MainPage_ToolStripMenuItem.Size = new Size(65, 20);
            MainPage_ToolStripMenuItem.Text = "Головна";
            MainPage_ToolStripMenuItem.Click += MainPage_ToolStripMenuItem_Click;
            // 
            // medicalRecord_ToolStripMenuItem
            // 
            medicalRecord_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { patientForAdmin_ToolStripMenuItem, medicalCartForAdmin_ToolStripMenuItemolStripMenuItem, EpisodeForAdmin_ToolStripMenuItemolStripMenuItem, ActionForAdmin_ToolStripMenuItemolStripMenuItem, MedicationForAdmin_ToolStripMenuItemolStripMenuItem, ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem });
            medicalRecord_ToolStripMenuItem.Name = "medicalRecord_ToolStripMenuItem";
            medicalRecord_ToolStripMenuItem.Size = new Size(107, 20);
            medicalRecord_ToolStripMenuItem.Text = "Медичні записи";
            // 
            // patientForAdmin_ToolStripMenuItem
            // 
            patientForAdmin_ToolStripMenuItem.Name = "patientForAdmin_ToolStripMenuItem";
            patientForAdmin_ToolStripMenuItem.Size = new Size(157, 22);
            patientForAdmin_ToolStripMenuItem.Text = "Паціент";
            patientForAdmin_ToolStripMenuItem.Click += patientForAdmin_ToolStripMenuItem_Click;
            // 
            // medicalCartForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Name = "medicalCartForAdmin_ToolStripMenuItemolStripMenuItem";
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(157, 22);
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Медична карта";
            medicalCartForAdmin_ToolStripMenuItemolStripMenuItem.Click += medicalCartForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // EpisodeForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Name = "EpisodeForAdmin_ToolStripMenuItemolStripMenuItem";
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(157, 22);
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Eпізод";
            EpisodeForAdmin_ToolStripMenuItemolStripMenuItem.Click += EpisodeForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // ActionForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Name = "ActionForAdmin_ToolStripMenuItemolStripMenuItem";
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(157, 22);
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Дія";
            ActionForAdmin_ToolStripMenuItemolStripMenuItem.Click += ActionForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // MedicationForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            MedicationForAdmin_ToolStripMenuItemolStripMenuItem.Name = "MedicationForAdmin_ToolStripMenuItemolStripMenuItem";
            MedicationForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(157, 22);
            MedicationForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Медикаменти";
            MedicationForAdmin_ToolStripMenuItemolStripMenuItem.Click += MedicationForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem
            // 
            ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem.Name = "ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem";
            ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem.Size = new Size(157, 22);
            ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem.Text = "Процедури";
            ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem.Click += ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem_Click;
            // 
            // звітиToolStripMenuItem
            // 
            звітиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { allDiagnosisPatients_ToolStripMenuItem, loadDoctor_ToolStripMenuItem, expirationDateDrugToolStripMenuItem, useDrugOnDepartmentFor3Manth_ToolStripMenuItem, reportPatientTheHighestVisitLast1Year_ToolStripMenuItem });
            звітиToolStripMenuItem.Name = "звітиToolStripMenuItem";
            звітиToolStripMenuItem.Size = new Size(47, 20);
            звітиToolStripMenuItem.Text = "Звіти";
            // 
            // allDiagnosisPatients_ToolStripMenuItem
            // 
            allDiagnosisPatients_ToolStripMenuItem.Name = "allDiagnosisPatients_ToolStripMenuItem";
            allDiagnosisPatients_ToolStripMenuItem.Size = new Size(417, 22);
            allDiagnosisPatients_ToolStripMenuItem.Text = "Всі діагнози пацієнтів";
            allDiagnosisPatients_ToolStripMenuItem.Click += allDiagnosisPatients_ToolStripMenuItem_Click;
            // 
            // loadDoctor_ToolStripMenuItem
            // 
            loadDoctor_ToolStripMenuItem.Name = "loadDoctor_ToolStripMenuItem";
            loadDoctor_ToolStripMenuItem.Size = new Size(417, 22);
            loadDoctor_ToolStripMenuItem.Text = "Завантаженість лікара";
            loadDoctor_ToolStripMenuItem.Click += loadDoctor_ToolStripMenuItem_Click;
            // 
            // expirationDateDrugToolStripMenuItem
            // 
            expirationDateDrugToolStripMenuItem.Name = "expirationDateDrugToolStripMenuItem";
            expirationDateDrugToolStripMenuItem.Size = new Size(417, 22);
            expirationDateDrugToolStripMenuItem.Text = "Термін придатності ліків";
            expirationDateDrugToolStripMenuItem.Click += expirationDateDrugToolStripMenuItem_Click;
            // 
            // useDrugOnDepartmentFor3Manth_ToolStripMenuItem
            // 
            useDrugOnDepartmentFor3Manth_ToolStripMenuItem.Name = "useDrugOnDepartmentFor3Manth_ToolStripMenuItem";
            useDrugOnDepartmentFor3Manth_ToolStripMenuItem.Size = new Size(417, 22);
            useDrugOnDepartmentFor3Manth_ToolStripMenuItem.Text = "Використання ліків по відділеннях за 3 місяці";
            useDrugOnDepartmentFor3Manth_ToolStripMenuItem.Click += useDrugOnDepartmentFor3Manth_ToolStripMenuItem_Click;
            // 
            // reportPatientTheHighestVisitLast1Year_ToolStripMenuItem
            // 
            reportPatientTheHighestVisitLast1Year_ToolStripMenuItem.Name = "reportPatientTheHighestVisitLast1Year_ToolStripMenuItem";
            reportPatientTheHighestVisitLast1Year_ToolStripMenuItem.Size = new Size(417, 22);
            reportPatientTheHighestVisitLast1Year_ToolStripMenuItem.Text = "Звіт про пацієнтів із найбільшою кількістю відвідувань (за рік)";
            reportPatientTheHighestVisitLast1Year_ToolStripMenuItem.Click += reportPatientTheHighestVisitLast1Year_ToolStripMenuItem_Click;
            // 
            // generateReportToolStripMenuItem
            // 
            generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            generateReportToolStripMenuItem.Size = new Size(107, 20);
            generateReportToolStripMenuItem.Text = "Генератор звітів";
            generateReportToolStripMenuItem.Click += generateReportToolStripMenuItem_Click;
            // 
            // doctor_ToolStripMenuItem
            // 
            doctor_ToolStripMenuItem.Name = "doctor_ToolStripMenuItem";
            doctor_ToolStripMenuItem.Size = new Size(52, 20);
            doctor_ToolStripMenuItem.Text = "Лікарі";
            doctor_ToolStripMenuItem.Click += doctor_ToolStripMenuItem_Click;
            // 
            // department_ToolStripMenuItem
            // 
            department_ToolStripMenuItem.Name = "department_ToolStripMenuItem";
            department_ToolStripMenuItem.Size = new Size(77, 20);
            department_ToolStripMenuItem.Text = "Відділення";
            department_ToolStripMenuItem.Click += department_ToolStripMenuItem_Click;
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
            episodeForAdminUserControl1.Size = new Size(931, 645);
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
            doctorForAdminUserControl2.Size = new Size(940, 614);
            doctorForAdminUserControl2.TabIndex = 7;
            // 
            // actionForAdminUserControl1
            // 
            actionForAdminUserControl1.Location = new Point(0, 27);
            actionForAdminUserControl1.Name = "actionForAdminUserControl1";
            actionForAdminUserControl1.Size = new Size(932, 645);
            actionForAdminUserControl1.TabIndex = 8;
            // 
            // departmentForAdminUserControl1
            // 
            departmentForAdminUserControl1.Location = new Point(0, 29);
            departmentForAdminUserControl1.Name = "departmentForAdminUserControl1";
            departmentForAdminUserControl1.Size = new Size(932, 594);
            departmentForAdminUserControl1.TabIndex = 9;
            // 
            // medicationForAdminUserControl1
            // 
            medicationForAdminUserControl1.Location = new Point(0, 22);
            medicationForAdminUserControl1.Name = "medicationForAdminUserControl1";
            medicationForAdminUserControl1.Size = new Size(932, 594);
            medicationForAdminUserControl1.TabIndex = 10;
            // 
            // procedureClientForAdminUserControl1
            // 
            procedureClientForAdminUserControl1.Location = new Point(12, 29);
            procedureClientForAdminUserControl1.Name = "procedureClientForAdminUserControl1";
            procedureClientForAdminUserControl1.Size = new Size(929, 644);
            procedureClientForAdminUserControl1.TabIndex = 11;
            // 
            // reportAllDiagnosisForPatients1
            // 
            reportAllDiagnosisForPatients1.Location = new Point(0, 29);
            reportAllDiagnosisForPatients1.Name = "reportAllDiagnosisForPatients1";
            reportAllDiagnosisForPatients1.Size = new Size(929, 644);
            reportAllDiagnosisForPatients1.TabIndex = 12;
            // 
            // layout_pictureBox
            // 
            layout_pictureBox.Image = (Image)resources.GetObject("layout_pictureBox.Image");
            layout_pictureBox.Location = new Point(0, 20);
            layout_pictureBox.Name = "layout_pictureBox";
            layout_pictureBox.Size = new Size(945, 665);
            layout_pictureBox.TabIndex = 13;
            layout_pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 680);
            Controls.Add(layout_pictureBox);
            Controls.Add(reportAllDiagnosisForPatients1);
            Controls.Add(procedureClientForAdminUserControl1);
            Controls.Add(medicationForAdminUserControl1);
            Controls.Add(departmentForAdminUserControl1);
            Controls.Add(actionForAdminUserControl1);
            Controls.Add(doctorForAdminUserControl2);
            Controls.Add(doctorForAdminUserControl1);
            Controls.Add(episodeForAdminUserControl1);
            Controls.Add(medicalCardForAdminUserControl1);
            Controls.Add(closeUserControllForAddInfo_button);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Проект на тему \"організоване робоче місце медичної сестри\". Возного Богдана";
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layout_pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem helsiToolStripMenuItem;
        private ToolStripMenuItem Entrance_menuStrip;
        private Button closeUserControllForAddInfo_button;
        private ToolStripMenuItem medicalRecord_ToolStripMenuItem;
        private ToolStripMenuItem patientForAdmin_ToolStripMenuItem;
        private PatientForAdminUserControl patientForAdminUserControl;
        private medicalCardForAdminUserControl medicalCardForAdminUserControl1;
        private ToolStripMenuItem medicalCartForAdmin_ToolStripMenuItemolStripMenuItem;
        private EpisodeForAdminUserControl episodeForAdminUserControl1;
        private ToolStripMenuItem EpisodeForAdmin_ToolStripMenuItemolStripMenuItem;
        private DoctorForAdminUserControl doctorForAdminUserControl1;
        private DoctorForAdminUserControl doctorForAdminUserControl2;
        private ToolStripMenuItem ActionForAdmin_ToolStripMenuItemolStripMenuItem;
        private ActionForAdminUserControl actionForAdminUserControl1;
        private DepartmentForAdminUserControl departmentForAdminUserControl1;
        private MedicationForAdminUserControl medicationForAdminUserControl1;
        private ToolStripMenuItem MedicationForAdmin_ToolStripMenuItemolStripMenuItem;
        private ToolStripMenuItem ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem;
        private ProcedureClientForAdminUserControl procedureClientForAdminUserControl1;
        private ToolStripMenuItem звітиToolStripMenuItem;
        private ToolStripMenuItem allDiagnosisPatients_ToolStripMenuItem;
        private ForAllReportUserControl reportAllDiagnosisForPatients1;
        private ToolStripMenuItem loadDoctor_ToolStripMenuItem;
        private ToolStripMenuItem expirationDateDrugToolStripMenuItem;
        private ToolStripMenuItem generateReportToolStripMenuItem;
        private ToolStripMenuItem useDrugOnDepartmentFor3Manth_ToolStripMenuItem;
        private ToolStripMenuItem reportPatientTheHighestVisitLast1Year_ToolStripMenuItem;
        private PictureBox layout_pictureBox;
        private ToolStripMenuItem MainPage_ToolStripMenuItem;
        private ToolStripMenuItem doctor_ToolStripMenuItem;
        private ToolStripMenuItem department_ToolStripMenuItem;
    }
}