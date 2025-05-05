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

            patientForAdminUserControl = new PatientForAdminUserControl();
            this.Controls.Add(patientForAdminUserControl);
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
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            hideAllPages();

            closeUserControllForAddInfo_button.Visible = false;
            closeUserControllForAddInfo_button.BringToFront();
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
            Application.Exit(); // припинити отладку
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
    }
}
