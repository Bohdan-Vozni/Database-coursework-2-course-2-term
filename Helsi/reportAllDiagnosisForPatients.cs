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
using Microsoft.AspNetCore.Http;

namespace Helsi
{

    public partial class reportAllDiagnosisForPatients : UserControl
    {
        private string nameReport;
        public reportAllDiagnosisForPatients()
        {
            InitializeComponent();
           // ShowDataToGrit();     
                
        }
        public reportAllDiagnosisForPatients(string procedureName, string nameReport)
        {
            InitializeComponent();
            ShowDataToGrit(procedureName);
            this.nameReport = nameReport;
        }
       

        private void ShowDataToGrit(string procedureName)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                report_dataGridView.DataSource = dt;
            }
        }

        private void printReport_Click(object sender, EventArgs e)
        {
            var dgvPrinter = new DGVPrinter();
            dgvPrinter.createReport(nameReport, report_dataGridView);
        }
    }
}
