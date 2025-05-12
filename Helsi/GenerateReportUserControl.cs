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
                           
            DataTable dt = new DataTable();

            dt.Columns.Add("NameParametrnInProcedure", typeof(string));
            dt.Columns.Add("Назва параметра для звіту", typeof(string));
            dt.Columns.Add("Дані параметра", typeof(string));


            dt.Rows.Add("@PatientName", "Ім’я пацієнта", "");
            dt.Rows.Add("@BirthDateStart", "Дата народження (від)", "");
            dt.Rows.Add("@BirthDateEnd", "Дата народження (до)", "");
            dt.Rows.Add("@Diagnosis", "Діагноз", "");
            dt.Rows.Add("@DoctorName", "Ім’я лікаря", "");
            dt.Rows.Add("@MedicationName", "Назва медикаменту", "");
            dt.Rows.Add("@Manufacturer", "Виробник медикаменту", "");
            dt.Rows.Add("@MedicationExpirationStart", "Термін придатності медикаменту (від)", "");
            dt.Rows.Add("@MedicationExpirationEnd", "Термін придатності медикаменту (до)", "");
            dt.Rows.Add("@ProcedureName", "Назва процедури", "");
            dt.Rows.Add("@DepartmentName", "Назва відділення", "");
            dt.Rows.Add("@ActionDateStart", "Дата дії (від)", "");
            dt.Rows.Add("@ActionDateEnd", "Дата дії (до)", "");


            allField_dataGridView.DataSource = dt;
            allField_dataGridView.Columns["NameParametrnInProcedure"].Visible = false;

        }

        private DataTable dt = new DataTable();
        private string NameParametrnInProcedure;
        private string nameParametr;
        private string dataParametr;

        private void GenerateReportUserControl_Load(object sender, EventArgs e)
        {
            allField_dataGridView.CellDoubleClick += allField_dataGridView_CellContentClick;
            resultField_dataGridView.CellDoubleClick += resultFieald_dataGridView_CellContentClick;
            loadToFieldForResultGrit();

            deleteAddFieldInResultGrit.Click += deleteAddFieldInResultGrit_Click;
        }

        private void loadToFieldForResultGrit()
        {
            dt = new DataTable();
            dt.Columns.Add("NameParametrnInProcedure", typeof(string));
            dt.Columns.Add("Назва параметра для звіту", typeof(string));
            dt.Columns.Add("Дані параметра", typeof(string));


            resultField_dataGridView.DataSource = dt;
            resultField_dataGridView.Columns["NameParametrnInProcedure"].Visible = false;
        }

        private void addDataToResultGrit()
        {
            // Перевіряємо — щоб одна й та сама комбінація не додавалась двічі
            bool exists = dt.AsEnumerable().Any(row =>
                row.Field<string>("NameParametrnInProcedure") == NameParametrnInProcedure);
               

            if (!exists)
            {
                dt.Rows.Add(NameParametrnInProcedure, nameParametr, dataParametr);
            }
        }

        private void deleteDataToResultGrit()
        {
            var rowToDelete = dt.AsEnumerable().FirstOrDefault(row =>
                row.Field<string>("NameParametrnInProcedure") == NameParametrnInProcedure 
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

                NameParametrnInProcedure = selectedRow.Cells["NameParametrnInProcedure"].FormattedValue.ToString();
                nameParametr = selectedRow.Cells["Назва параметра для звіту"].FormattedValue.ToString();
                dataParametr = selectedRow.Cells["Дані параметра"].FormattedValue.ToString();


                addDataToResultGrit();
            }
        }


        private void resultFieald_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = resultField_dataGridView.Rows[e.RowIndex];

                NameParametrnInProcedure = selectedRow.Cells["NameParametrnInProcedure"].FormattedValue.ToString();
                nameParametr = selectedRow.Cells["Назва параметра для звіту"].FormattedValue.ToString();
                dataParametr = selectedRow.Cells["Дані параметра"].FormattedValue.ToString();


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
            if (nameRepot_textBox.Text == "")
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

            if (genereteRoportFromResultGrit() == false)
            {
                return;
            }

            resultField_dataGridView.DataSource = dataGridView.DataSource;

            var dgvPrinter = new DGVPrinter();
            dgvPrinter.createReport(nameRepot_textBox.Text, resultField_dataGridView);
        }


        private DataTable dtForReport = new DataTable();
        private DataGridView dataGridView = new DataGridView();
        private bool genereteRoportFromResultGrit()
        {
            try
            {
                // Convert the selected fields to JSON
                var reportData = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    reportData.Add(row["NameParametrnInProcedure"].ToString());
                    reportData.Add(row["Дані параметра"].ToString());                    
                 
                }
               
                if (reportData.Count % 2 != 0)
                {
                    MessageBox.Show("У вас наявні пусті записи параметрів");
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetFilteredFullDataReport", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    int i = 0;

                    while (i < reportData.Count)
                    {
                        string paramName = reportData[i].ToString();
                        string paramValue = reportData[i+1].ToString();

                        command.Parameters.AddWithValue(paramName, paramValue);
                        i += 2;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Запит не повернув жодного рядка. Спробуйте інші параметри.");
                        return false;
                    }

                    #region  Перейменування полів в DataGrit для кастомних звітів

                    // Перевірка і перейменування стовпців у DataTable
                    if (dt.Columns.Contains("id_patient"))
                    {
                        dt.Columns["id_patient"].ColumnName = "Індетифікатор пацієнта";
                    }

                    if (dt.Columns.Contains("full_name_patient"))
                    {
                        dt.Columns["full_name_patient"].ColumnName = "Повне ім’я пацієнта";
                    }

                    if (dt.Columns.Contains("date_of_birth"))
                    {
                        dt.Columns["date_of_birth"].ColumnName = "Дата народження";
                    }

                    if (dt.Columns.Contains("patient_phone"))
                    {
                        dt.Columns["patient_phone"].ColumnName = "Телефон пацієнта";
                    }

                    if (dt.Columns.Contains("address_patient"))
                    {
                        dt.Columns["address_patient"].ColumnName = "Адреса пацієнта";
                    }

                    if (dt.Columns.Contains("id_medical_card"))
                    {
                        dt.Columns["id_medical_card"].ColumnName = "Ідентифікатор медичної картки";
                    }

                    if (dt.Columns.Contains("declaration_doctor"))
                    {
                        dt.Columns["declaration_doctor"].ColumnName = "Лікар, що видав декларацію";
                    }

                    if (dt.Columns.Contains("date_created"))
                    {
                        dt.Columns["date_created"].ColumnName = "Дата створення медичної картки";
                    }

                    if (dt.Columns.Contains("status_card"))
                    {
                        dt.Columns["status_card"].ColumnName = "Статус картки";
                    }

                    if (dt.Columns.Contains("id_episode"))
                    {
                        dt.Columns["id_episode"].ColumnName = "Ідентифікатор епізоду";
                    }

                    if (dt.Columns.Contains("diagnosis"))
                    {
                        dt.Columns["diagnosis"].ColumnName = "Діагноз";
                    }

                    if (dt.Columns.Contains("description_diagnosis"))
                    {
                        dt.Columns["description_diagnosis"].ColumnName = "Опис діагнозу";
                    }

                    if (dt.Columns.Contains("description_action"))
                    {
                        dt.Columns["description_action"].ColumnName = "Опис дії";
                    }

                    if (dt.Columns.Contains("action_date"))
                    {
                        dt.Columns["action_date"].ColumnName = "Дата дії";
                    }

                    if (dt.Columns.Contains("id_doctor"))
                    {
                        dt.Columns["id_doctor"].ColumnName = "Ідентифікатор лікаря";
                    }

                    if (dt.Columns.Contains("name_doctor"))
                    {
                        dt.Columns["name_doctor"].ColumnName = "Ім’я лікаря";
                    }

                    if (dt.Columns.Contains("specialization"))
                    {
                        dt.Columns["specialization"].ColumnName = "Спеціалізація лікаря";
                    }

                    if (dt.Columns.Contains("doctor_phone"))
                    {
                        dt.Columns["doctor_phone"].ColumnName = "Телефон лікаря";
                    }

                    if (dt.Columns.Contains("id_department"))
                    {
                        dt.Columns["id_department"].ColumnName = "Ідентифікатор відділення";
                    }

                    if (dt.Columns.Contains("name_department"))
                    {
                        dt.Columns["name_department"].ColumnName = "Назва відділення";
                    }

                    if (dt.Columns.Contains("description_department"))
                    {
                        dt.Columns["description_department"].ColumnName = "Опис відділення";
                    }

                    if (dt.Columns.Contains("id_medication"))
                    {
                        dt.Columns["id_medication"].ColumnName = "Ідентифікатор медикаменту";
                    }

                    if (dt.Columns.Contains("name_medication"))
                    {
                        dt.Columns["name_medication"].ColumnName = "Назва медикаменту";
                    }

                    if (dt.Columns.Contains("manufacturer"))
                    {
                        dt.Columns["manufacturer"].ColumnName = "Виробник медикаменту";
                    }

                    if (dt.Columns.Contains("description_medication"))
                    {
                        dt.Columns["description_medication"].ColumnName = "Опис медикаменту";
                    }

                    if (dt.Columns.Contains("expiration_date"))
                    {
                        dt.Columns["expiration_date"].ColumnName = "Термін придатності медикаменту";
                    }

                    if (dt.Columns.Contains("id_procedure"))
                    {
                        dt.Columns["id_procedure"].ColumnName = "Ідентифікатор процедури";
                    }

                    if (dt.Columns.Contains("name_procedure"))
                    {
                        dt.Columns["name_procedure"].ColumnName = "Назва процедури";
                    }

                    if (dt.Columns.Contains("description_procedure"))
                    {
                        dt.Columns["description_procedure"].ColumnName = "Опис процедури";
                    }


                    #endregion
                    
                    
                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при генерації звіту: {ex.Message}");
            }

            return true;
        }


    }
}
