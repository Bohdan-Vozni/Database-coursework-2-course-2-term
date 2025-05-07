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
using DGVPrinterHelper;
using System.Text.Json;

namespace Helsi
{
    public partial class GenerateReportUserControl : UserControl
    {
        public GenerateReportUserControl()
        {
            InitializeComponent();
            ShowDataToGrit();
        }

        private void ShowDataToGrit()
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllTableColumnsProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                allField_dataGridView.DataSource = dt;
            }
        }

        private DataTable dt = new DataTable();
        private string nameTabel;
        private string nameField;
        private bool nameIsNulble;
        private void GenerateReportUserControl_Load(object sender, EventArgs e)
        {
            allField_dataGridView.CellDoubleClick += allField_dataGridView_CellContentClick;
            resultField_dataGridView.CellDoubleClick += resultFieald_dataGridView_CellContentClick;
            loadToFieldForResultGrit();
        }

        private void loadToFieldForResultGrit()
        {
            dt = new DataTable();
            dt.Columns.Add("Назва таблиці", typeof(string));
            dt.Columns.Add("Назва поля", typeof(string));
            dt.Columns.Add("Чи обовязково повинні бути дані", typeof(bool)); // або typeof(bool)

            resultField_dataGridView.DataSource = dt;
        }

        private void addDataToResultGrit()
        {
            // Перевіряємо — щоб одна й та сама комбінація не додавалась двічі
            bool exists = dt.AsEnumerable().Any(row =>
                row.Field<string>("Назва таблиці") == nameTabel &&
                row.Field<string>("Назва поля") == nameField);

            if (!exists)
            {
                dt.Rows.Add(nameTabel, nameField, nameIsNulble);
            }
        }

        private void deleteDataToResultGrit()
        {
            var rowToDelete = dt.AsEnumerable().FirstOrDefault(row =>
                row.Field<string>("Назва таблиці") == nameTabel &&
                row.Field<string>("Назва поля") == nameField
            );

            if (rowToDelete != null)
                if (rowToDelete != null)
                {
                    dt.Rows.Remove(rowToDelete);
                }
        }


        private void allField_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = allField_dataGridView.Rows[e.RowIndex];

                nameTabel = selectedRow.Cells["Назва таблиці"].FormattedValue.ToString();
                nameField = selectedRow.Cells["Назва поля"].FormattedValue.ToString();
                nameIsNulble = (bool)selectedRow.Cells["Чи обовязково повинні бути дані"].FormattedValue;

                addDataToResultGrit();
            }
        }


        private void resultFieald_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = resultField_dataGridView.Rows[e.RowIndex];

                nameTabel = selectedRow.Cells["Назва таблиці"].FormattedValue.ToString();
                nameField = selectedRow.Cells["Назва поля"].FormattedValue.ToString();
                nameIsNulble = (bool)selectedRow.Cells["Чи обовязково повинні бути дані"].FormattedValue;

                deleteDataToResultGrit();
            }
        }

        private void deleteAddFieldInResultGrit_Click(object sender, EventArgs e)
        {
            loadToFieldForResultGrit();
            var rowsToDelete = dt.AsEnumerable().ToList();

            foreach (var row in rowsToDelete)
            {
                dt.Rows.Remove(row);
            }
        }

        private void generetaReport_button_Click(object sender, EventArgs e)
        {
            if(nameRepot_textBox.Text == "")
            {
                MessageBox.Show("Введіть назву звіту");
                return;
            }

            var rowsCount = dt.AsEnumerable().ToList().Count;
            if (rowsCount == 0)
            {
                MessageBox.Show("Додайте поля для генерування звіту");
                return;
            }

            genereteRoportFromResultGrit();

            resultField_dataGridView.DataSource = dataGridView.DataSource;

            var dgvPrinter = new DGVPrinter();
            dgvPrinter.createReport(nameRepot_textBox.Text, resultField_dataGridView);
        }


        private DataTable dtForReport = new DataTable();
        private DataGridView dataGridView = new DataGridView();
        private void genereteRoportFromResultGrit()
        {
            try
            {
                // Convert the selected fields to JSON
                var reportData = new List<object>();
                foreach (DataRow row in dt.Rows)
                {
                    reportData.Add(new
                    {
                        TableName = row["Назва таблиці"].ToString(),
                        ColumnName = row["Назва поля"].ToString(),
                        IsNullable = (bool)row["Чи обовязково повинні бути дані"]
                    });
                }

                string jsonData = JsonSerializer.Serialize(reportData);

                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetInfoForGenerateReport", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReportData", jsonData);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dtForReport = new DataTable();
                    adapter.Fill(dtForReport);

                    // Bind the result to the DataGridView
                    dataGridView.DataSource = dtForReport;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при генерації звіту: {ex.Message}");
            }


        }


    }
}
