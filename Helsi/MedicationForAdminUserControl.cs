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
    public partial class MedicationForAdminUserControl : UserControl
    {
        public MedicationForAdminUserControl()
        {
            InitializeComponent();
        }

        private void MedicationForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
           RenameHeaderTextInGrit();
        }

        private void RenameHeaderTextInGrit()
        {
            medication_dataGridView.Columns["id_medication"].Visible = false;
            medication_dataGridView.Columns["name_medication"].HeaderText = "Назва медикаменту";
            medication_dataGridView.Columns["manufacturer"].HeaderText = "Виробник";
            medication_dataGridView.Columns["description_medication"].HeaderText = "Опис медикаменту";
            medication_dataGridView.Columns["expiration_date"].HeaderText = "Дата придатності";
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
                SqlCommand command = new SqlCommand("GetMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MedicationName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                medication_dataGridView.DataSource = dt;
            }
        }

        private void medication_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (medication_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                medication_dataGridView.CurrentRow.Selected = true;

                idMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_medication"]
                    .FormattedValue.ToString();


                nameMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["name_medication"]
                    .FormattedValue.ToString();

                manufacturerMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["manufacturer"]
                    .FormattedValue.ToString();

                descriptionMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["description_medication"]
                    .FormattedValue.ToString();

                var dateValue = medication_dataGridView.Rows[e.RowIndex].Cells["expiration_date"].Value;

                if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out DateTime parsedDate))
                {
                    expiration_dateTimePicker.Value = parsedDate;
                }
                else
                {
                    // Встановимо сьогоднішню дату або якусь дефолтну
                    expiration_dateTimePicker.Value = DateTime.Today;
                }

               

            }
        }

        private void addMedication_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати медикаменти?",
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


                SqlCommand command = new SqlCommand("InsertMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();

                //додати параметри
                command.Parameters.AddWithValue("@id_medication", idUnic);
                command.Parameters.AddWithValue("@name_medication", nameMedication_TextBox.Text);
                command.Parameters.AddWithValue("@manufacturer", manufacturerMedication_TextBox.Text);
                command.Parameters.AddWithValue("@description_medication", descriptionMedication_TextBox.Text);
                command.Parameters.AddWithValue("@expiration_date", expiration_dateTimePicker.Value);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медикамент успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання медикаменту", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateMedication_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновти медикамети?",
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


                SqlCommand command = new SqlCommand("UpdateMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_medication", idMedication_TextBox.Text);
                command.Parameters.AddWithValue("@name_medication", nameMedication_TextBox.Text);
                command.Parameters.AddWithValue("@manufacturer", manufacturerMedication_TextBox.Text);
                command.Parameters.AddWithValue("@description_medication", descriptionMedication_TextBox.Text);
                command.Parameters.AddWithValue("@expiration_date", expiration_dateTimePicker.Value);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медикамент успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення медикаменту", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteMedication_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити медикаменти?",
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


                SqlCommand command = new SqlCommand("DeleteMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_medication", idMedication_TextBox.Text);



                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Медикамент успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видаленя медикаменту", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
        }
    }
}
