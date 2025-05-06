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
            ShowDataToGrit();
        }

        private void ShowDataToGrit()
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;

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
                    .Cells["Назва медикаменту"]
                    .FormattedValue.ToString();

                manufacturerMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Виробник"]
                    .FormattedValue.ToString();

                descriptionMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Опис медикаменту"]
                    .FormattedValue.ToString();

                expirationDateMedication_TextBox.Text = medication_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Дата придатності"]
                    .FormattedValue.ToString();


            }
        }

        private void addMedication_Button_Click(object sender, EventArgs e)
        {
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
                command.Parameters.AddWithValue("@expiration_date", expirationDateMedication_TextBox.Text);


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
            ShowDataToGrit();
        }

        private void updateMedication_Button_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateMedicationProc", connection);
                command.CommandType = CommandType.StoredProcedure;


               

                //додати параметри
                command.Parameters.AddWithValue("@id_medication", idMedication_TextBox.Text);
                command.Parameters.AddWithValue("@name_medication", nameMedication_TextBox.Text);
                command.Parameters.AddWithValue("@manufacturer", manufacturerMedication_TextBox.Text);
                command.Parameters.AddWithValue("@description_medication", descriptionMedication_TextBox.Text);
                command.Parameters.AddWithValue("@expiration_date", expirationDateMedication_TextBox.Text);


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
            ShowDataToGrit();
        }

        private void deleteMedication_Button_Click(object sender, EventArgs e)
        {

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
            ShowDataToGrit();
        }

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit();
        }

        
    }
}
