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
    public partial class DepartmentForAdminUserControl : UserControl
    {
        public DepartmentForAdminUserControl()
        {
            InitializeComponent();
        }


        private void DepartmentForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit();
        }

        private void ShowDataToGrit()
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllDepartmentProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                department_dataGridView.DataSource = dt;
            }
        }

        private void department_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (department_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                department_dataGridView.CurrentRow.Selected = true;

                idDepartment_TextBox.Text = department_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_department"]
                    .FormattedValue.ToString();


                nameDepartment_TextBox.Text = department_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Назва відділення"]
                    .FormattedValue.ToString();

                descriptionDepartment_TextBox.Text = department_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Опис відділення"]
                    .FormattedValue.ToString();


            }
        }

        private void addDepartment_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertDepartmentProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();

                //додати параметри
                command.Parameters.AddWithValue("@id_department", idUnic);
                command.Parameters.AddWithValue("@name_department", nameDepartment_TextBox.Text);
                command.Parameters.AddWithValue("@description_department", descriptionDepartment_TextBox.Text);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Відділення успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання відділення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateDepartment_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateDepartmentProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                

                //додати параметри
                command.Parameters.AddWithValue("@id_department", idDepartment_TextBox.Text);
                command.Parameters.AddWithValue("@name_department", nameDepartment_TextBox.Text);
                command.Parameters.AddWithValue("@description_department", descriptionDepartment_TextBox.Text);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Відділення успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення відділення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteDepartment_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeleteDepartmentProc", connection);
                command.CommandType = CommandType.StoredProcedure;


               

                //додати параметри
                command.Parameters.AddWithValue("@id_department", idDepartment_TextBox.Text);
                


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Відділення успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видалення відділення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
