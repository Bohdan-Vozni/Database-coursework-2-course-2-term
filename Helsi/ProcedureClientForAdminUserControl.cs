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
    public partial class ProcedureClientForAdminUserControl : UserControl
    {
        public ProcedureClientForAdminUserControl()
        {
            InitializeComponent();
        }

        private void ProcedureClientForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            RenameHeaderTextInGrit();
        }

        private void RenameHeaderTextInGrit()
        {
            procedureClient_dataGridView.Columns["id_procedure"].Visible = false;
            procedureClient_dataGridView.Columns["name_procedure"].HeaderText = "Назва процедури";
            procedureClient_dataGridView.Columns["description_procedure"].HeaderText = "Опис процедури";
            
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
                SqlCommand command = new SqlCommand("GetProcedureClientProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProcedureName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                procedureClient_dataGridView.DataSource = dt;
            }
        }

        private void procedureClient_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (procedureClient_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                procedureClient_dataGridView.CurrentRow.Selected = true;

                idProcedureClient_TextBox.Text = procedureClient_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_procedure"]
                    .FormattedValue.ToString();


                nameProcedureClient_TextBox.Text = procedureClient_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["name_procedure"]
                    .FormattedValue.ToString();

                descriptionProcedureClient_TextBox.Text = procedureClient_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["description_procedure"]
                    .FormattedValue.ToString();
            }
        }

        private void addProcedureClient_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати процедуру?",
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


                SqlCommand command = new SqlCommand("InsertProcedureClientProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();

                //додати параметри
                command.Parameters.AddWithValue("@id_procedure", idUnic);
                command.Parameters.AddWithValue("@name_procedure", nameProcedureClient_TextBox.Text);
                command.Parameters.AddWithValue("@description_procedure", descriptionProcedureClient_TextBox.Text);



                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Процедуру клієнта успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання процедури клієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateProcedureClient_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновити процедуру?",
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


                SqlCommand command = new SqlCommand("UpdateProcedureClientProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                //додати параметри
                command.Parameters.AddWithValue("@id_procedure", idProcedureClient_TextBox.Text);
                command.Parameters.AddWithValue("@name_procedure", nameProcedureClient_TextBox.Text);
                command.Parameters.AddWithValue("@description_procedure", descriptionProcedureClient_TextBox.Text);



                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Процедуру клієнта успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення процедури клієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteProcedureClient_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити процедуру?",
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


                SqlCommand command = new SqlCommand("DeleteProcedureClientProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                //додати параметри
                command.Parameters.AddWithValue("@id_procedure", idProcedureClient_TextBox.Text);




                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Процедуру клієнта успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видалення процедури клієнта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
