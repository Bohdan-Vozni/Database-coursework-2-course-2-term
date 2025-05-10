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
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;

        }
        private void PatientForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            RenameHeaderTextInGrit();
        }

        private void RenameHeaderTextInGrit()
        {
            patientForAdmin_dataGridView.Columns["id_patient"].HeaderText = "Ідетифікатор пацієнта";
            patientForAdmin_dataGridView.Columns["id_patient"].Visible = false;
            patientForAdmin_dataGridView.Columns["full_name"].HeaderText = "ПІБ пацієнта";
            patientForAdmin_dataGridView.Columns["date_of_birth"].HeaderText = "Дата народження пацієнта";
            patientForAdmin_dataGridView.Columns["phone_number"].HeaderText = "Номер телефоку пацієнта";
            patientForAdmin_dataGridView.Columns["address_patient"].HeaderText = "Адреса пацієнта";
        }

        private string searchStrning;

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            searchStrning = textBoxSearch.Text.ToLower();
            ShowDataToGrit(searchStrning);
        }


        private void ShowDataToGrit(string searchStrning)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPatientsProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SearchName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                patientForAdmin_dataGridView.DataSource = dt;
            }
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

                var dateValue = patientForAdmin_dataGridView.Rows[e.RowIndex].Cells["date_of_birth"].Value;

                if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out DateTime parsedDate))
                {
                    bith_dateTimePicker1.Value = parsedDate;
                }
                else
                {
                    // Встановимо сьогоднішню дату або якусь дефолтну
                    bith_dateTimePicker1.Value = DateTime.Today;
                }


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
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати пацієнта?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertPatientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();
                //додати параметри
                command.Parameters.AddWithValue("@id_patient", idUnic);
                command.Parameters.AddWithValue("@full_name", fulnameTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@date_of_bith", bith_dateTimePicker1.Value);
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
            ShowDataToGrit(searchStrning);
        }


        private void updatePatientForAdmin_button_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновити пацієнта?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdatePatientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = idTextBox_PatientForAdmin.Text;
                //додати параметри
                command.Parameters.AddWithValue("@id_patient", idUnic);
                command.Parameters.AddWithValue("@full_name", fulnameTextBox_PatientForAdmin.Text);
                command.Parameters.AddWithValue("@date_of_bith", bith_dateTimePicker1.Value);
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

                ShowDataToGrit(searchStrning);

            }
        }


        private void deletePatientForAdmin_button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити пацієнта?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

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
                        MessageBox.Show(error.Message, "Помилка видалення даних пацієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Інші неочікувані помилки
                    MessageBox.Show(ex.Message, "Неочікувана помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowDataToGrit(searchStrning);

            }
        }

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
        }
    }
}
