using Microsoft.Data.SqlClient;
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

namespace Helsi
{
    public partial class DoctorForAdminUserControl : UserControl
    {
        public DoctorForAdminUserControl()
        {
            InitializeComponent();
        }

        private void DoctorForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            ShowDataDropDownList();
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
        }

        private string searchStrning;

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            searchStrning = textBoxSearch.Text.ToLower();
            ShowDataToGrit(searchStrning);
        }

        private List<Department> allDepartment;

        private void ShowDataDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetIdDepartmentWithNameProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    allDepartment = new List<Department>();


                    while (reader.Read())
                    {
                        allDepartment.Add(new Department
                        {
                            idDepartment = reader.GetString(reader.GetOrdinal("idDepartment")),
                            nameDepartment = reader.GetString(reader.GetOrdinal("nameDepartment"))
                        });
                    }
                    idDepartmentDoctor_ComboBox.DataSource = allDepartment;
                    idDepartmentDoctor_ComboBox.DisplayMember = "nameDepartment";
                    idDepartmentDoctor_ComboBox.ValueMember = "idDepartment";
                    idDepartmentDoctor_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;

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
                SqlCommand command = new SqlCommand("GetAllDoctorProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                doctor_dataGridView.DataSource = dt;
            }
        }

        public Department currentDepartment;
        private void doctor_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (doctor_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                doctor_dataGridView.CurrentRow.Selected = true;

                idDodctor_TextBox.Text = doctor_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_doctor"]
                    .FormattedValue.ToString();



                currentDepartment = allDepartment
                   .FirstOrDefault
                       (id => id.idDepartment == doctor_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_department"]
                       .FormattedValue
                       .ToString()
                       );

                idDepartmentDoctor_ComboBox.Text = currentDepartment.nameDepartment;


                fullNameDoctor_TextBox.Text = doctor_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["ПІБ Доктора"]
                    .FormattedValue.ToString();

                specializationDoctor_TextBox.Text = doctor_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Спеціалізація доктора"]
                    .FormattedValue.ToString();

                phoneNumberDoctor_TextBox.Text = doctor_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Номер телефону"]
                    .FormattedValue.ToString();

            }
        }

        private void addDoctor_Button_Click(object sender, EventArgs e)
        {
            if (idDepartmentDoctor_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть відділення", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedDepartment = (Department)idDepartmentDoctor_ComboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertDoctorProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();

                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", idUnic);
                command.Parameters.AddWithValue("@id_department", selectedDepartment.idDepartment);
                command.Parameters.AddWithValue("@name_doctor", fullNameDoctor_TextBox.Text);
                command.Parameters.AddWithValue("@specialization", specializationDoctor_TextBox.Text);
                command.Parameters.AddWithValue("@phone_number", phoneNumberDoctor_TextBox.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Доктор успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання доктора", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateDoctor_Button_Click(object sender, EventArgs e)
        {
            if (idDepartmentDoctor_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть відділення", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedDepartment = (Department)idDepartmentDoctor_ComboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateDoctorProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", idDodctor_TextBox.Text);
                command.Parameters.AddWithValue("@id_department", selectedDepartment.idDepartment);
                command.Parameters.AddWithValue("@name_doctor", fullNameDoctor_TextBox.Text);
                command.Parameters.AddWithValue("@specialization", specializationDoctor_TextBox.Text);
                command.Parameters.AddWithValue("@phone_number", phoneNumberDoctor_TextBox.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Доктор успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex) when (ex.Number == 50000) // Перевірка на нашу кастомну помилку
                {
                    // Це наша спеціальна помилка з RAISERROR
                    MessageBox.Show(ex.Message, "Помилка оновлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення доктора", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteDoctor_Button_Click(object sender, EventArgs e)
        {

            if (idDepartmentDoctor_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть відділення", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedDepartment = (Department)idDepartmentDoctor_ComboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeleteDoctorProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", idDodctor_TextBox.Text);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Доктор успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видалення доктора", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            ShowDataDropDownList();
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
        }
    }
}
