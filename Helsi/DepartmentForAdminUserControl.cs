﻿using Microsoft.Data.SqlClient;
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
            ShowDataToGrit(searchStrning);
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            RenameHeaderTextInGrit();
        }

        private void RenameHeaderTextInGrit()
        {

            department_dataGridView.Columns["id_department"].Visible = false;
            department_dataGridView.Columns["name_department"].HeaderText = "Назва відділення";
            department_dataGridView.Columns["description_department"].HeaderText = "Опис відділення";


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
                SqlCommand command = new SqlCommand("GetAllDepartmentProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DepartmentName", searchStrning);

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
                    .Cells["name_department"]
                    .FormattedValue.ToString();

                descriptionDepartment_TextBox.Text = department_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["description_department"]
                    .FormattedValue.ToString();


            }
        }

        private void addDepartment_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати відділення?",
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
            ShowDataToGrit(searchStrning);
        }

        private void updateDepartment_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновити відділення?",
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
            ShowDataToGrit(searchStrning);
        }

        private void deleteDepartment_Button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити відділення?",
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
