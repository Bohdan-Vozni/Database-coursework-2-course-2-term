using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Helsi
{
    public partial class MainForm : Form
    {
        private string UserName;
        private GenerateReportUserControl generateReportUserControl1;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            patientForAdminUserControl = new PatientForAdminUserControl();
            this.Controls.Add(patientForAdminUserControl);

            generateReportUserControl1 = new GenerateReportUserControl();
            this.Controls.Add(generateReportUserControl1);
        }
        public MainForm(string UserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            patientForAdminUserControl = new PatientForAdminUserControl();
            this.Controls.Add(patientForAdminUserControl);

            generateReportUserControl1 = new GenerateReportUserControl();
            this.Controls.Add(generateReportUserControl1);

            this.UserName = UserName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hideAllPages();
            closeUserControllForAddInfo_button.Visible = false;
            closeUserControllForAddInfo_button.BringToFront();

            CheckUserPermissionsAtLogin();
            medicalRecord_ToolStripMenuItem.Visible = false;

            if (permissions.User == "sa" || permissions.Role == "MainDoctor")
            {
                medicalRecord_ToolStripMenuItem.Visible = true;
                doctor_ToolStripMenuItem.Visible = true;
                department_ToolStripMenuItem.Visible = true;
            }
            else if (permissions.Role == "Doctor")
            {
                medicalRecord_ToolStripMenuItem.Visible = true;
                doctor_ToolStripMenuItem.Visible = false;
                department_ToolStripMenuItem.Visible = false;
            }
            else if(permissions.Role == "Nurse")
            {
                medicalRecord_ToolStripMenuItem.Visible = false;
                doctor_ToolStripMenuItem.Visible = false;
                department_ToolStripMenuItem.Visible = false;
            }


            layout_pictureBox.Visible = true;
        }

        private UserPermissions permissions;

        public void CheckUserPermissionsAtLogin()
        {
            permissions = new UserPermissions();

            try
            {
                using (var connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("CheckLoginPermissions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", UserName);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                permissions.User = (string)reader["Username"];
                                permissions.Role = (string)reader["Roleuser"];

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show($"Помилка перевірки прав: {ex.Message}");
            }
        }


        private void hideAllPages()
        {
            foreach (Control control in this.Controls)
            {
                if (control is UserControl userControl)
                {
                    userControl.Hide();
                }
            }
            layout_pictureBox.Visible = false;
        }

        private void Entrance_menuStrip_Click(object sender, EventArgs e)
        {
            var Authorization = new Authorization();
            Authorization.Show();
            Hide();
        }

        private void closeUserControllForAddInfo_button_Click(object sender, EventArgs e)
        {
            closeUserControllForAddInfo_button.Visible = false;
            hideAllPages();
            layout_pictureBox.Visible = true;
            // Application.Exit(); // припинити отладку
        }

        private void patient_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        private void medicalCard_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();

        }

        private void patientForAdmin_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            hideAllPages();

            patientForAdminUserControl.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();


        }

        private void medicalCartForAdmin_ToolStripMenuItemolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            medicalCardForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();

        }

        private void EpisodeForAdmin_ToolStripMenuItemolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            episodeForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

       

        private void ActionForAdmin_ToolStripMenuItemolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            actionForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        

        private void MedicationForAdmin_ToolStripMenuItemolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            medicationForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        private void ProcedureClientForAdmin_ToolStripMenuItemolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            procedureClientForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }


        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            generateReportUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        private void viewReportForAll(string _procedureName, string _nameReport)
        {
            hideAllPages();

            // Створюємо новий екземпляр і присвоюємо його до reportAllDiagnosisForPatients1
            reportAllDiagnosisForPatients1 = new ForAllReportUserControl(procedureName: _procedureName, nameReport: _nameReport);

            // Налаштування відображення
            reportAllDiagnosisForPatients1.Dock = DockStyle.Fill;
            this.Controls.Add(reportAllDiagnosisForPatients1);
            reportAllDiagnosisForPatients1.Visible = true;
            reportAllDiagnosisForPatients1.BringToFront();


            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }


        private void allDiagnosisPatients_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewReportForAll(_procedureName: "GetPatientDiagnosisInfo", _nameReport: "Звіт всі діагнози пацієнта");

        }

        private void loadDoctor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewReportForAll(_procedureName: "GetDoctorActivityStats", _nameReport: " Звіт про завантаженість лікарів");
        }

        private void expirationDateDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewReportForAll(_procedureName: "GetExpiringMedications", _nameReport: "Звіт про термін придатності ліків");

        }

        private void useDrugOnDepartmentFor3Manth_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewReportForAll(_procedureName: "GetMedicationUsageByDepartment", _nameReport: " Звіт про використання ліків по відділеннях (за останні 3 місяці)");

        }

        private void reportPatientTheHighestVisitLast1Year_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewReportForAll(_procedureName: "GetTopPatients", _nameReport: "Звіт про пацієнтів із найбільшою кількістю відвідувань (за рік)");

        }

        private void MainPage_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();
            layout_pictureBox.Visible = true;
            closeUserControllForAddInfo_button.Visible = false;
        }

        private void doctor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            doctorForAdminUserControl2.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        private void department_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPages();

            departmentForAdminUserControl1.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }
    }
}
