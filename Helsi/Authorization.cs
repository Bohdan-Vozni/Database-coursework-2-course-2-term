using System.Diagnostics;

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

            if (login == "asd" && password == "asd" || password == "")
            {
                var mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
        }


        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
