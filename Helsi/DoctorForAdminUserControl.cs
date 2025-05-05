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
    public partial class DoctorForAdminUserControl : UserControl
    {
        public DoctorForAdminUserControl()
        {
            InitializeComponent();
        }

        private void DoctorForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit();
            ShowDataDropDownList();
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

        private void ShowDataToGrit()
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllDoctorProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                doctor_dataGridView.DataSource = dt;
            }
        }

        private void addDoctor_Button_Click(object sender, EventArgs e)
        {

        }

        private void updateDoctor_Button_Click(object sender, EventArgs e)
        {

        }

        private void deleteDoctor_Button_Click(object sender, EventArgs e)
        {

        }

        private void updateDataInAllForm_button_Click(object sender, EventArgs e)
        {
            ShowDataToGrit();
            ShowDataDropDownList();
        }
    }
}
