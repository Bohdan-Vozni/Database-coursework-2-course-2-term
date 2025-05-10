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
    public partial class EpisodeForAdminUserControl : UserControl
    {
        private List<MedicalCard> allMedicalCard;
        public EpisodeForAdminUserControl()
        {
            InitializeComponent();
        }

        private void EpisodeForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            ShowDataDropDownList();
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
        }

        private string searchStrning;

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            searchStrning = textBoxSearch.Text.ToLower();
            ShowDataToGrit(searchStrning);
        }

        private void ShowDataDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetMedicalCardsWithPatientNamesProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    allMedicalCard = new List<MedicalCard>();


                    while (reader.Read())
                    {
                        allMedicalCard.Add(new MedicalCard
                        {
                            idMedicaCard = reader.GetString(reader.GetOrdinal("id_medical_card")),
                            fullName = reader.GetString(reader.GetOrdinal("full_name"))
                        });
                    }
                    idMedicalCard_comboBox.DataSource = allMedicalCard;
                    idMedicalCard_comboBox.DisplayMember = "fullName";
                    idMedicalCard_comboBox.ValueMember = "idMedicaCard";
                    idMedicalCard_comboBox.DropDownStyle = ComboBoxStyle.DropDown;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
            }

        }

        private void ShowDataToGrit(string searchStrning)
        {
            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEpisodeProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PatientName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                episode_dataGridView.DataSource = dt;
            }
        }

        public MedicalCard currentMedicalCard;
        private void episode_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (episode_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                episode_dataGridView.CurrentRow.Selected = true;

                idEpisode_TextBox.Text = episode_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["id_episode"]
                    .FormattedValue.ToString();


                currentMedicalCard = allMedicalCard
                   .FirstOrDefault
                       (id => id.idMedicaCard == episode_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_medical_card"]
                       .FormattedValue
                       .ToString()
                       );
                diagnosis_TextBox.Text = currentMedicalCard.fullName;


                diagnosis_TextBox.Text = episode_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Діагноз"]
                    .FormattedValue.ToString();

                description_TextBox.Text = episode_dataGridView
                    .Rows[e.RowIndex]
                    .Cells["Опис діагноза"]
                    .FormattedValue.ToString();


            }
        }

        private void addEpisode_Button_Click(object sender, EventArgs e)
        {
            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати епізод?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertEpisodeProc", connection);
                command.CommandType = CommandType.StoredProcedure;


                var idUnic = Guid.NewGuid().ToString();

                //додати параметри
                command.Parameters.AddWithValue("@id_episode", idUnic);
                command.Parameters.AddWithValue("@id_medical_card", selectedMedicalCard.idMedicaCard);
                command.Parameters.AddWithValue("@diagnosis", diagnosis_TextBox.Text);
                command.Parameters.AddWithValue("@description_diagnosis", description_TextBox.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Епізод успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання епізоду", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void updateEpisode_Button_Click(object sender, EventArgs e)
        {
            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновити епізод?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateEpisodeProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_episode", idEpisode_TextBox.Text);
                command.Parameters.AddWithValue("@id_medical_card", selectedMedicalCard.idMedicaCard);
                command.Parameters.AddWithValue("@diagnosis", diagnosis_TextBox.Text);
                command.Parameters.AddWithValue("@description_diagnosis", description_TextBox.Text);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Епізод успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновлення епізоду", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteEpisode_Button_Click(object sender, EventArgs e)
        {
            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть пацієнта", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити епізод?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeleteEpisodeProc", connection);
                command.CommandType = CommandType.StoredProcedure;




                //додати параметри
                command.Parameters.AddWithValue("@id_episode", idEpisode_TextBox.Text);
                command.Parameters.AddWithValue("@id_medical_card", currentMedicalCard.idMedicaCard);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Епізод успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видалення епізоду", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ShowDataDropDownList();
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
        }
    }
}
