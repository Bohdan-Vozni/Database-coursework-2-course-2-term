using Microsoft.Data.SqlClient;
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
    public partial class PatientForAdminUserControl : UserControl
    {
        public PatientForAdminUserControl()
        {
            InitializeComponent();
            ShowDataToGrit();
        }

        private void PatientForAdminUserControl_Load(object sender, EventArgs e)
        {

        }

        private void ShowDataToGrit()
        {
            string query = "select * from Patient";

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPatients", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                patientForAdmin_dataGridView.DataSource = dt;
            }
        }

        private void showAllDataPatientForAdmin_Button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit();
        }

        private void patientForAdmin_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (patientForAdmin_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                patientForAdmin_dataGridView.CurrentRow.Selected  = true;

                fulnameTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView.
                    Rows[e.RowIndex].
                    Cells["full_name"].
                    FormattedValue.ToString();
            }

        }
    }
}
