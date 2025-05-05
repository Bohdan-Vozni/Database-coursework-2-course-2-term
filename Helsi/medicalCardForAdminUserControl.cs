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
        private void medicalCardForAdminUserControl_Load(object sender, EventArgs e)
        {

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

        private List<Patient> allPatient;
        public medicalCardForAdminUserControl()
        {
            InitializeComponent();
            ShowDataDropDownList();
            ShowDataToGrit();
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
            //idPatientComboBox_MedicalCardForAdmin.ValueMember = "id"; // Якщо потрібно

            // Показуємо випадаючий список
            idPatientComboBox_MedicalCardForAdmin.DroppedDown = true;

            // Зберігаємо позицію курсора
            idPatientComboBox_MedicalCardForAdmin.SelectionStart = searchText.Length;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  // обробник кнопки ентер
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

        private void addMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {

        }

        private void updateMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {

        }

        private void deleteMedicalCardForAdmin_button_Click(object sender, EventArgs e)
        {

        }
    }
}
