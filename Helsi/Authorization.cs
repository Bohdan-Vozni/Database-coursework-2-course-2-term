using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;



namespace Helsi
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginInDatabase_button_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;            

            string pathToConectionString = Application.StartupPath.ToString();
            pathToConectionString += "/" + "ConectionString.json";


            string ConectionString = "";


            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // додає відступи для читаємості
            };

            if (!File.Exists(pathToConectionString))
            {
                using (FileStream file = new FileStream(pathToConectionString, FileMode.Create))
                {
                    JsonSerializer.Serialize(file, ConectionString, options);
                }
            }
            else
            {
                using (FileStream file = new FileStream(pathToConectionString, FileMode.Open))
                {
                    ConectionString = JsonSerializer.Deserialize<string>(file);
                }
            }
           
            using (SqlConnection connection = new SqlConnection(ConectionString + "User Id =" + login + ";" + "Password =" + password + ";"))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Підключення успішне!");
                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                    connection.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Не вдалося підключитися до бази даних:");              
                }
                
            }

           
               
            
        }


        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
