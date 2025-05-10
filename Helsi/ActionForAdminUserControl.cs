using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helsi
{
    public partial class ActionForAdminUserControl : UserControl
    {
        public ActionForAdminUserControl()
        {
            InitializeComponent();
        }

        private void ActionForAdminUserControl_Load(object sender, EventArgs e)
        {
            ShowDataToGrit(searchStrning);
            ShowMedicalCardDropDownList(); // Завантажуємо спочатку медичні карти
            ShowDoctorDropDownList();
            ShowProcedureDropDownList();
            ShowMedicationDropDownList();

            // Додаємо обробник події зміни вибору в комбобоксі медичних карт
            idMedicalCard_comboBox.SelectedIndexChanged += MedicalCardComboBox_SelectedIndexChanged;
            RenameHeaderTextInGrit();
        }

        private void RenameHeaderTextInGrit()
        {
            
            


            action_dataGridView.Columns["full_name"].HeaderText = "Імя пацієнта";
            action_dataGridView.Columns["id_doctor"].Visible = false;
            action_dataGridView.Columns["name_doctor"].HeaderText = "Імя доктора";
            action_dataGridView.Columns["specialization"].HeaderText = "Спеціалізація доктора";
            action_dataGridView.Columns["id_episode"].Visible = false;
            action_dataGridView.Columns["diagnosis"].HeaderText = "Діагноз";
            action_dataGridView.Columns["id_medical_card"].Visible = false;
            action_dataGridView.Columns["description_action"].HeaderText = "Опис дії";
            action_dataGridView.Columns["data_time"].HeaderText = "Дата дії";
            action_dataGridView.Columns["id_procedure"].Visible = false;
            action_dataGridView.Columns["id_medication"].Visible = false;
            action_dataGridView.Columns["name_procedure"].HeaderText = "Процедура що проводилася";
            action_dataGridView.Columns["name_medication"].HeaderText = "Назва ліків";
            action_dataGridView.Columns["name_department"].HeaderText = "Відділення";

        }

        private string searchStrning;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            searchStrning = textBoxSearch.Text.ToLower();
            ShowDataToGrit(searchStrning);
        }


        private List<MedicalCard> allMedicalCard;
        private List<Doctor> allDoctor;
        private List<Episode> allEpisode;
        private List<Procedure> allProcedure;
        private List<Medication> allMedication;

        // Оновлений метод для відображення епізодів для конкретної медичної карти
        private void ShowEpisodesForMedicalCard(string medicalCardId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetEpisodesForMedicalCardProc", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicalCardId", medicalCardId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    allEpisode = new List<Episode>();

                    while (reader.Read())
                    {
                        allEpisode.Add(new Episode
                        {
                            idEpisode = reader.GetString(reader.GetOrdinal("EpisodeId")),
                            diagnosis = reader.GetString(reader.GetOrdinal("Diagnosis")),
                            idMedicalCard = medicalCardId
                        });
                    }
                    idEpisodeCard_comboBox.DataSource = allEpisode;
                    idEpisodeCard_comboBox.DisplayMember = "diagnosis";
                    idEpisodeCard_comboBox.ValueMember = "idEpisode";
                    idEpisodeCard_comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
            }
        }


        // Новий метод для фільтрації епізодів за медичною картою
        private void MedicalCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idMedicalCard_comboBox.SelectedValue != null)
            {
                string selectedMedicalCardId = idMedicalCard_comboBox.SelectedValue.ToString();
                ShowEpisodesForMedicalCard(selectedMedicalCardId);
            }
        }

        private void ShowMedicalCardDropDownList()
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

        private void ShowDoctorDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetIdDoctorWithNameProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    allDoctor = new List<Doctor>();

                    while (reader.Read())
                    {
                        allDoctor.Add(new Doctor
                        {
                            idDoctor = reader.GetString(reader.GetOrdinal("DoctorId")),
                            fullName = reader.GetString(reader.GetOrdinal("DoctorName"))
                        });
                    }
                    idDoctor_comboBox.DataSource = allDoctor;
                    idDoctor_comboBox.DisplayMember = "fullName";
                    idDoctor_comboBox.ValueMember = "idDoctor";
                    idDoctor_comboBox.DropDownStyle = ComboBoxStyle.DropDown;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
            }

        }

        private void ShowProcedureDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetIdProcedureWithNameProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    allProcedure = new List<Procedure>();

                    while (reader.Read())
                    {
                        allProcedure.Add(new Procedure
                        {
                            idProcedure = reader.GetString(reader.GetOrdinal("ProcedureId")),
                            nameProcedure = reader.GetString(reader.GetOrdinal("ProcedureName"))
                        });
                    }
                    idProcedure_comboBox.DataSource = allProcedure;
                    idProcedure_comboBox.DisplayMember = "nameProcedure";
                    idProcedure_comboBox.ValueMember = "idProcedure";
                    idProcedure_comboBox.DropDownStyle = ComboBoxStyle.DropDown;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        private void ShowMedicationDropDownList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
                {
                    SqlCommand command = new SqlCommand("GetIdMedicationWithNameProc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    allMedication = new List<Medication>();

                    while (reader.Read())
                    {
                        allMedication.Add(new Medication
                        {
                            idMedication = reader.GetString(reader.GetOrdinal("MedicationId")),
                            nameMedication = reader.GetString(reader.GetOrdinal("MedicationName"))
                        });
                    }
                    idMedication_comboBox.DataSource = allMedication;
                    idMedication_comboBox.DisplayMember = "nameMedication";
                    idMedication_comboBox.ValueMember = "idMedication";
                    idMedication_comboBox.DropDownStyle = ComboBoxStyle.DropDown;

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
                SqlCommand command = new SqlCommand("GetAllActionProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PatientName", searchStrning);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                action_dataGridView.DataSource = dt;
            }
        }

        public Doctor currentDoctor;
        public Episode currentEpisode;
        public MedicalCard currentMedicalCard;
        public Procedure currentProcedure;
        public Medication currentMedication;
        private void action_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (action_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                action_dataGridView.CurrentRow.Selected = true;

                currentDoctor = allDoctor.FirstOrDefault
                (
                    item => item.idDoctor == action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_doctor"]
                       .FormattedValue
                       .ToString()
                );

                idDoctor_comboBox.Text = currentDoctor.fullName;

                if (allEpisode == null)
                {
                    MessageBox.Show("Натисніть кнопку оновити дані");
                    return;
                }

                currentEpisode = allEpisode.FirstOrDefault
                (
                    item => item.idEpisode == action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_episode"]
                       .FormattedValue
                       .ToString()
                );

                if (currentEpisode != null)
                {
                    idEpisodeCard_comboBox.SelectedValue = currentEpisode.idEpisode;
                }

                currentMedicalCard = allMedicalCard.FirstOrDefault
                (
                    item => item.idMedicaCard == action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_medical_card"]
                       .FormattedValue
                       .ToString()
                );

                idMedicalCard_comboBox.Text = currentMedicalCard.fullName;


                descriptionAction_TextBox.Text = action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["description_action"]
                       .FormattedValue
                       .ToString();


                var dateValue= action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["data_time"]
                       .FormattedValue
                       .ToString();

                if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out DateTime parsedDate))
                {
                    create_dateTimePicker1.Value = parsedDate;
                }
                else
                {
                    // Встановимо сьогоднішню дату або якусь дефолтну
                    create_dateTimePicker1.Value = DateTime.Today;
                }

                currentProcedure = allProcedure.FirstOrDefault
                (
                    item => item.idProcedure == action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_procedure"]
                       .FormattedValue
                       .ToString()
                );

                if (currentProcedure != null)
                {
                    idProcedure_comboBox.Text = currentProcedure.nameProcedure;
                }

                currentMedication = allMedication.FirstOrDefault
                (
                    item => item.idMedication == action_dataGridView
                       .Rows[e.RowIndex]
                       .Cells["id_medication"]
                       .FormattedValue
                       .ToString()
                );

                if (currentMedication != null)
                {
                    idMedication_comboBox.Text = currentMedication.nameMedication;
                }

            }
        }

        private void addAction_Button_Click(object sender, EventArgs e)
        {
            if (idDoctor_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть доктора", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idEpisodeCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть епізод", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть медичну катру", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idProcedure_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть процедуру", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idMedication_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть медикамент", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете додати дію?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedDoctor = (Doctor)idDoctor_comboBox.SelectedItem;
            var selectedEpisode = (Episode)idEpisodeCard_comboBox.SelectedItem;
            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;
            var selectedProcedure = (Procedure)idProcedure_comboBox.SelectedItem;
            var selectedMedication = (Medication)idMedication_comboBox.SelectedItem;


            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("InsertActionProc", connection);
                command.CommandType = CommandType.StoredProcedure;

                var dateTime = DateTime.Now;

                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", selectedDoctor.idDoctor);
                command.Parameters.AddWithValue("@id_episode", selectedEpisode.idEpisode);
                command.Parameters.AddWithValue("@id_medical_card", selectedMedicalCard.idMedicaCard);
                command.Parameters.AddWithValue("@description_action", descriptionAction_TextBox.Text);
                command.Parameters.AddWithValue("@data_time", dateTime);
                command.Parameters.AddWithValue("@id_procedure", selectedProcedure.idProcedure);
                command.Parameters.AddWithValue("@id_medication", selectedMedication.idMedication);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дія успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка додавання дії", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateAction_Button_Click(object sender, EventArgs e)
        {

            if (idDoctor_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть доктора", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idEpisodeCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть епізод", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть медичну катру", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idProcedure_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть процедуру", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idMedication_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть медикамент", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете оновти дію?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedDoctor = (Doctor)idDoctor_comboBox.SelectedItem;
            var selectedEpisode = (Episode)idEpisodeCard_comboBox.SelectedItem;
            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;
            var selectedProcedure = (Procedure)idProcedure_comboBox.SelectedItem;
            var selectedMedication = (Medication)idMedication_comboBox.SelectedItem;

            DateTime actionDate;

            // Перевіряємо, чи дата введена коректно
            if (!DateTime.TryParse(create_dateTimePicker1.Text, out actionDate))
            {
                MessageBox.Show("Будь ласка, введіть коректну дату", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("UpdateActionProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", selectedDoctor.idDoctor);
                command.Parameters.AddWithValue("@id_episode", selectedEpisode.idEpisode);
                command.Parameters.AddWithValue("@id_medical_card", selectedMedicalCard.idMedicaCard);
                command.Parameters.AddWithValue("@new_description_action", descriptionAction_TextBox.Text);
                command.Parameters.AddWithValue("@new_data_time", actionDate);
                command.Parameters.AddWithValue("@new_id_procedure", selectedProcedure.idProcedure);
                command.Parameters.AddWithValue("@new_id_medication", selectedMedication.idMedication);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дія успішно оновлена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка оновленя дії", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void deleteAction_Button_Click(object sender, EventArgs e)
        {


            if (idDoctor_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть доктора", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idEpisodeCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть епізод", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idMedicalCard_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть медичну катру", "Попередження",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити дію?",
                "Підтвердження дії",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            var selectedDoctor = (Doctor)idDoctor_comboBox.SelectedItem;
            var selectedEpisode = (Episode)idEpisodeCard_comboBox.SelectedItem;
            var selectedMedicalCard = (MedicalCard)idMedicalCard_comboBox.SelectedItem;
          

           

            using (SqlConnection connection = new SqlConnection(GetConectionSrtingForConectDataBase.ConectionString))
            {


                SqlCommand command = new SqlCommand("DeleteActionProc", connection);
                command.CommandType = CommandType.StoredProcedure;



                //додати параметри
                command.Parameters.AddWithValue("@id_doctor", selectedDoctor.idDoctor);
                command.Parameters.AddWithValue("@id_episode", selectedEpisode.idEpisode);
                command.Parameters.AddWithValue("@id_medical_card", selectedMedicalCard.idMedicaCard);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дія успішно видалена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        MessageBox.Show(error.Message, "Помилка видаленя дії", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ShowMedicalCardDropDownList(); // Завантажуємо спочатку медичні карти
            ShowDoctorDropDownList();
            ShowProcedureDropDownList();
            ShowMedicationDropDownList();

            // Додаємо обробник події зміни вибору в комбобоксі медичних карт
            idMedicalCard_comboBox.SelectedIndexChanged += MedicalCardComboBox_SelectedIndexChanged;
        }

        private void clearAllField_Button_Click(object sender, EventArgs e)
        {
            ClearAllTextBox.ClearAllTextBoxes(this.Controls);
        }
    }
}
