using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helsi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            newMedicalCard_userControl.Visible = false;
            newPatient_userControl.Visible = false;
            closeUserControllForAddInfo_button.Visible = false;
            patientForAdminUserControl.Visible = false;

            closeUserControllForAddInfo_button.BringToFront();
        }








        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Entrance_menuStrip_Click(object sender, EventArgs e)
        {
            var Authorization = new Authorization();
            Authorization.Show();
            Hide();
        }





        private void closeUserControllForAddInfo_button_Click(object sender, EventArgs e)
        {
            newMedicalCard_userControl.Visible = false;
            newPatient_userControl.Visible = false;
            closeUserControllForAddInfo_button.Visible = false;
            patientForAdminUserControl.Visible = false;

        }

        private void patient_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newMedicalCard_userControl.Visible = false;
            patientForAdminUserControl.Visible = false;

            newPatient_userControl.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();
        }

        private void medicalCard_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            newPatient_userControl.Visible = false;
            patientForAdminUserControl.Visible = false;
            newMedicalCard_userControl.Visible = true;

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();

        }

        private void patientForAdmin_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPatient_userControl.Visible = false;
            newMedicalCard_userControl.Visible = false;

            patientForAdminUserControl.Visible = true;
            

            closeUserControllForAddInfo_button.Visible = true;
            closeUserControllForAddInfo_button.BringToFront();


        }

        private void newMedicalCard_userControl_Load(object sender, EventArgs e)
        {

        }
    }
}
