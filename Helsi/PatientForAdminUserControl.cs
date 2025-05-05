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
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPatientsProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                patientForAdmin_dataGridView.DataSource = dt;
            }
        }

        private void findPatientForAdmin_Button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit();
        }

        private void patientForAdmin_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (patientForAdmin_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                patientForAdmin_dataGridView.CurrentRow.Selected = true;

                idTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_patient"]
                    .FormattedValue.ToString();

                fulnameTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView.
                    Rows[e.RowIndex].
                    Cells["full_name"].
                    FormattedValue.ToString();

                dateBithTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["date_of_birth"]
                    .FormattedValue.ToString();

                phoneNumberTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["phone_number"]
                    .FormattedValue.ToString();

                addressTextBox_PatientForAdmin.Text = patientForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["address_patient"]
                    .FormattedValue.ToString();

            }

        }

        private void addPatientForAdmin_button_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertPatientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();
                //додати параметри
                command.Parameters.AddWithValue("@id_patient", idUnic);
                command.Parameters.AddWithValue("@full_name", fulnameTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@date_of_bith", dateBithTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@phone_number", phoneNumberTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@address_patient", addressTextBox_PatientForAdmin.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пацієнта успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання пацієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Інші неочікувані помилки
                    MessageBox.Show(ex.Message, "Неочікувана помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            ShowDataToGrit();
        }

        private void deletePatientForAdmin_button_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeletePatientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = idTextBox_PatientForAdmin.Text;
                //додати параметри
                command.Parameters.AddWithValue("@id_patient", idUnic);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пацієнта успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видаленя пацієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Інші неочікувані помилки
                    MessageBox.Show(ex.Message, "Неочікувана помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowDataToGrit();

            }
        }

        private void updatePatientForAdmin_button_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdatePatientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = idTextBox_PatientForAdmin.Text;
                //додати параметри
                command.Parameters.AddWithValue("@id_patient", idUnic);
                command.Parameters.AddWithValue("@full_name", fulnameTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@date_of_bith", dateBithTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@phone_number", phoneNumberTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@address_patient", addressTextBox_PatientForAdmin.Text);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пацієнта успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлено даних пацієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Інші неочікувані помилки
                    MessageBox.Show(ex.Message, "Неочікувана помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowDataToGrit();

            }
        }

        
    }
}
