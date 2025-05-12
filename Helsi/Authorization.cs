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


        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string pathToConectionString;

        private void loginInDatabase_button_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;

            pathToConectionString = Application.StartupPath.ToString();
            pathToConectionString += "/" + "ConectionString.json";

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ведіть всі дані в поля");
                return;
            }


            if (!File.Exists(pathToConectionString))
            {
                MessageBox.Show("Будьласка згенеруйте файл для підключення до бази даних і впишіть строку підключення");
                return;
            }
                      


            using (FileStream file = new FileStream(pathToConectionString, FileMode.Open))
            {
                GetConectionSrtingForConectDataBase.ConectionString = JsonSerializer.Deserialize<string>(file);
                if (GetConectionSrtingForConectDataBase.ConectionString == null)
                {
                    MessageBox.Show($"Будьласка впишіть строку підключення в файл з який знаходиться по такому шляху {pathToConectionString}");
                    return;
                }
                GetConectionSrtingForConectDataBase.ConectionString += "User Id =" + login + ";" + "Password =" + password + ";";
            }
            

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Підключення успішне!");

                    var mainForm = new MainForm(login);

                    mainForm.Show();
                    this.Hide();
                    connection.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Не вдалося підключитися до бази даних:");
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
