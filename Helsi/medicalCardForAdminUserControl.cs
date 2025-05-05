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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Helsi
{


    public partial class medicalCardForAdminUserControl : UserControl
    {
        private List<Patient> allPatient;
        private void medicalCardForAdminUserControl_Load(object sender, EventArgs e)
        {          

            ShowDataDropDownList();
            ShowDataToGrit();
        }


        public medicalCardForAdminUserControl()
        {
            InitializeComponent();
        }

        private void ShowDataDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetAllPatientsProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    allPatient = new List<Patient>();


                    while (reader.Read())
                    {
                        allPatient.Add(new Patient
                        {
                            idPatient = reader.GetString(reader.GetOrdinal("id_patient")),
                            fullName = reader.GetString(reader.GetOrdinal("full_name"))
                        });
                    }
                    idPatientComboBox_MedicalCardForAdmin.DataSource = allPatient;
                    idPatientComboBox_MedicalCardForAdmin.DisplayMember = "fullName";
                    idPatientComboBox_MedicalCardForAdmin.ValueMember = "idPatient";
                    idPatientComboBox_MedicalCardForAdmin.DropDownStyle = ComboBoxStyle.DropDown;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
            }

        }


        private void idPatientComboBox_MedicalCardForAdmin_TextUpdate(object sender, EventArgs e)
        {
            string searchText = idPatientComboBox_MedicalCardForAdmin.Text.ToLower();

            // Фільтруємо список, ігноруючи null-значення
            var filtered = allPatient
                .Where(p => p.fullName != null && p.fullName.ToLower().Contains(searchText))
                .ToList();

            // Оновлюємо DataSource
            idPatientComboBox_MedicalCardForAdmin.DataSource = null; // Спочатку очищуємо
            idPatientComboBox_MedicalCardForAdmin.DataSource = filtered;

            // Вказуємо, яке поле відображати
            idPatientComboBox_MedicalCardForAdmin.DisplayMember = "fullName";
            idPatientComboBox_MedicalCardForAdmin.ValueMember = "id";

            // Показуємо випадаючий список
            idPatientComboBox_MedicalCardForAdmin.DroppedDown = true;

            // Зберігаємо позицію курсора
            idPatientComboBox_MedicalCardForAdmin.SelectionStart = searchText.Length;
        }

        private void idPatientComboBox_MedicalCardForAdmin_SelectedIndexChanged(object sender, EventArgs e)  // обробник кнопки ентер
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem != null)
            {
                int id = (int)idPatientComboBox_MedicalCardForAdmin.SelectedValue;
                idPatientComboBox_MedicalCardForAdmin.Text = $"ID: {id}";
            }
        }

        private void ShowDataToGrit()
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllMedicalCardProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                medicalCardForAdmin_dataGridView.DataSource = dt;
            }
        }

        private void medicalCardForAdmin_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (medicalCardForAdmin_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                medicalCardForAdmin_dataGridView.CurrentRow.Selected = true;

                idMedicalCardTextBox_MedicalCardForAdmin.Text = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_medical_card"]
                    .FormattedValue.ToString();


                var currentPatien = allPatient
                    .FirstOrDefault
                        (id => id.idPatient == medicalCardForAdmin_dataGridView
                        .Rows[e.RowIndex]
                        .Cells["id_patient"]
                        .FormattedValue
                        .ToString()
                        );
                idPatientComboBox_MedicalCardForAdmin.Text = currentPatien.fullName;


                declarationDoctorTextBox_MedicalCardForAdmin.Text = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["declaration_doctor"]
                    .FormattedValue.ToString();

                dateCreatedTextBox_MedicalCardForAdmin.Text = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["date_created"]
                    .FormattedValue.ToString();

                statusCardTextBox_MedicalCardForAdmin.Text = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["status_card"]
                    .FormattedValue.ToString();

            }
        }

        private void addMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if(idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedPatient = (Patient)idPatientComboBox_MedicalCardForAdmin.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertMedicalCardProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();
                var dateCreate = DateTime.Now;
                //додати параметри
                command.Parameters.AddWithValue("@id_medical_card", idUnic);
                command.Parameters.AddWithValue("@id_patient", selectedPatient.idPatient);
                command.Parameters.AddWithValue("@declaration_doctor", declarationDoctorTextBox_MedicalCardForAdmin.Text);
                command.Parameters.AddWithValue("@date_created", dateCreate.ToString());
                command.Parameters.AddWithValue("@status_card", statusCardTextBox_MedicalCardForAdmin.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медичну картку успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання медичної картки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedPatient = (Patient)idPatientComboBox_MedicalCardForAdmin.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateMedicalCardProc", connection);
                command.CommandType = CommandType.StoredProcedure;


               
                //додати параметри
                command.Parameters.AddWithValue("@id_medical_card", idMedicalCardTextBox_MedicalCardForAdmin.Text);
                command.Parameters.AddWithValue("@id_patient", selectedPatient.idPatient);
                command.Parameters.AddWithValue("@declaration_doctor", declarationDoctorTextBox_MedicalCardForAdmin.Text);
                command.Parameters.AddWithValue("@date_created", dateCreatedTextBox_MedicalCardForAdmin.Text);
                command.Parameters.AddWithValue("@status_card", statusCardTextBox_MedicalCardForAdmin.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медичну картку успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення медичної картки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedPatient = (Patient)idPatientComboBox_MedicalCardForAdmin.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeleteMedicalCardProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                //додати параметри
                command.Parameters.AddWithValue("@id_medical_card", idMedicalCardTextBox_MedicalCardForAdmin.Text);
                

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медичну картку успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видалення медичної картки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataDropDownList();
            ShowDataToGrit();
        }
    }
}
