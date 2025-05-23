﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            ShowDataToGrit(searchStrning);

            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            RenameHeaderTextInGrit();

            statusCard_comboBox.Items.Clear();

            statusCard_comboBox.Items.Add("Активна");
            statusCard_comboBox.Items.Add("Архівована");
            statusCard_comboBox.Items.Add("Неактивна");
            statusCard_comboBox.SelectedIndex = 0;
        }

        private void RenameHeaderTextInGrit()
        {
            medicalCardForAdmin_dataGridView.Columns["id_medical_card"].Visible = false;
            medicalCardForAdmin_dataGridView.Columns["id_patient"].Visible = false;
            medicalCardForAdmin_dataGridView.Columns["full_name"].HeaderText = "ПІБ пацієнта";
            medicalCardForAdmin_dataGridView.Columns["declaration_doctor"].HeaderText = "Декларація з доктором";
            medicalCardForAdmin_dataGridView.Columns["date_created"].HeaderText = "Номер телефоку пацієнта";
            medicalCardForAdmin_dataGridView.Columns["status_card"].HeaderText = "Статус картки";
        }

        private string searchStrning;

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            searchStrning = textBoxSearch.Text.ToLower();
            ShowDataToGrit(searchStrning);
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

        private void ShowDataToGrit(string searchStrning)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllMedicalCardProc", connection);
                command.CommandType = CommandType.StoredProcedure;

               command.Parameters.AddWithValue("@PatientName ", searchStrning);

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

                var dateValue = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["date_created"]
                    .FormattedValue.ToString();

                if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out DateTime parsedDate))
                {
                    create_dateTimePicker1.Value = parsedDate;
                }
                else
                {
                    // Встановимо сьогоднішню дату або якусь дефолтну
                    create_dateTimePicker1.Value = DateTime.Today;
                }

                string statusValue = medicalCardForAdmin_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["status_card"]
                    .FormattedValue.ToString();

                // Встановлюємо вибране значення в ComboBox
                if (statusCard_comboBox.Items.Contains(statusValue))
                {
                    statusCard_comboBox.SelectedItem = statusValue;
                }
                else
                {
                    statusCard_comboBox.SelectedIndex = -1; // якщо такого значення нема
                }

            }
        }

        private void addMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати медчну картку?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
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
                command.Parameters.AddWithValue("@date_created", dateCreate);
                command.Parameters.AddWithValue("@status_card", statusCard_comboBox.SelectedItem);

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
            ShowDataToGrit(searchStrning);
        }

        private void updateMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновити медичну картку?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
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
                command.Parameters.AddWithValue("@date_created", create_dateTimePicker1.Value);
                command.Parameters.AddWithValue("@status_card", statusCard_comboBox.SelectedItem);

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
            ShowDataToGrit(searchStrning);
        }

        private void deleteMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {
            if (idPatientComboBox_MedicalCardForAdmin.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (statusCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть статус картки", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити медичну картку?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
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
                   
                        
                    MessageBox.Show(ex.Message, "Помилка видалення медичної картки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //foreach (SqlError error in ex.Errors)
                    //{
                    //    MessageBox.Show(error.Message, "Помилка оновлено даних пацієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                }               
                catch (Exception ex)
                {
                    // Інші неочікувані помилки
                    MessageBox.Show(ex.Message, "Неочікувана помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            ShowDataToGrit(searchStrning);
        }

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataDropDownList();
            ShowDataToGrit(searchStrning);
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
            statusCard_comboBox.SelectedIndex = 0;
        }
    }
}
