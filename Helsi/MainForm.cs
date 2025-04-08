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

        private void patient_StripMenu_Click(object sender, EventArgs e)
        {
            newMedicalCard_userControl.Visible = false;
            newPatient_userControl.Visible = true;
        }

        private void medicalCard_StripMenu_Click(object sender, EventArgs e)
        {
            newPatient_userControl.Visible = false;
            newMedicalCard_userControl.Visible = true;
        }
    }
}
