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

            login_textBox.Text = "Admindatabase";
            password_textBox.Text = "1234";
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


            


            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // додає відступи для читаємості
            };

            if (!File.Exists(pathToConectionString))
            {
                using (FileStream file = new FileStream(pathToConectionString, FileMode.Create))
                {
                    JsonSerializer.Serialize(file, GetConectionSrtingForConectDataBase.ConectionString, options);
                }
            }
            else
            {
                using (FileStream file = new FileStream(pathToConectionString, FileMode.Open))
                {
                    GetConectionSrtingForConectDataBase.ConectionString = JsonSerializer.Deserialize<string>(file) + "User Id =" + login + ";" + "Password =" + password + ";";
                }
            }

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString ))
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

        private void Authorization_Load(object sender, EventArgs e)
        {

        }
    }
}
