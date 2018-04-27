using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.MedCard
{
    public partial class EditMedCard : Form
    {
        string MedCardId = null;
          SqlConnection testCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True;Connect Timeout=30");
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        General.TextCheck textCheck = new General.TextCheck();

        public EditMedCard()
        {
            InitializeComponent();
            SetTheme();
        }
        private void SetTheme()
        {
            List<Button> buttons = new List<Button> { btnEdit, btnExit, btn1, btn2, btn3, btn4, btn5, btn6};
            List<Label> labels = new List<Label>
            {
                lblAddress, lblBirthday, lblDate,
                lblGender, lblGenderType, lblName,
                lblPhoneNumber, lblNumberCard, lblNum
            };

            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (this.BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;
                            // Колір кнопок
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                Button button = buttons[i];
                                if (i == 0) buttons[i].BackColor = Color.Transparent;
                                else Design.ChangeTheme.ButtonColorChange(ref button, Color.White);

                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.White);
                            }
                        }

                        break;
                    }
                case 1:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            // Колір кнопок
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                Button button = buttons[i];
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Black);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.Black);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.BackColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;

                            // Колір кнопок
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                Button button = buttons[i];
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Black);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label,Color.Black);
                            }
                        }

                        break;
                    }
                default:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            // Колір кнопок
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                Button button = buttons[i];
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Black);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.Black);
                            }
                        }
                        break;
                    }
            }

        }
        private void SaveToWordFile()
        {
            string[] arr = {cmbPacient.Text, txtDateOfBirthday.Text, txtNumber.Text,txtAddress.Text,dtpDateOfCreating.Text,txtGender.Text,
                txtDiagnosis.Text,txtComplaints.Text,txtDoneDiseases.Text,txtCurrentDisease.Text,txtSurvayData.Text,txtBite.Text,
                txtMouthState.Text,txtXReyData.Text,txtColorVita.Text,txtDateOfLessons.Text,txtControlDate.Text,txtSurvayPlan.Text,
                txtTreatmentPlan.Text};

            General.EditMedCardSave general = new General.EditMedCardSave(arr);
            if(general.SaveToWordFile() == true)
            {
                ButtonClear();
            }

        }
        public void ButtonClear()
        {
            //The new functionality that have to clear all textboxes
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void UpdateBase()
        {
            try
            {
                if (cmbPacient.Text.Length == 0)
                    throw new Exception("Не вибрана Мед карта, перевірте ще раз!");
                else
                {
                    testCon.Open();

                    string query = $"select MedCard_Id from MedCard where [Name] = N'{cmbPacient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        MedCardId = reader["MedCard_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Помилка!");
                    }
                    testCon.Close();

                    string qweryn =
                        " UPDATE MedCard " +
                        $" set Adress = N'{txtAddress.Text}', " +
                    $" Name = N'{cmbPacient.Text}', " + $"State = N'{txtGender.Text}', " + $"Birthday = N'{txtDateOfBirthday.Text}', " +
                    $"Number = N'{txtNumber.Text}', " + $"DateMC = N'{dtpDateOfCreating.Value.Date.ToString("dd/MM/yyyy")}', " + $"Diagnos = N'{txtDiagnosis.Text}', " +
                    $"Scarg = N'{txtComplaints.Text}', " + $"PereneseniTaSuputniZahvor =  N'{txtDoneDiseases.Text}', " +
                    $"RozvutokTeperishnogoZahvor = N'{txtCurrentDisease.Text}', " + $"DaniObjektDoslidjennya = N'{txtSurvayData.Text}', " +
                    $"Prikus =  N'{txtBite.Text}', " + $"StanGigiyenuRota = N'{txtMouthState.Text}', " + $"xRayData = N'{txtXReyData.Text}', " +
                    $"ColorVita = N'{txtColorVita.Text}', " + $"DateOfLessons =  N'{txtDateOfLessons.Text}', " + $"ControlDate = N'{txtControlDate.Text}',  " +
                    $"SurvayData = N'{txtSurvayData.Text}', " + $"SurvayPlan = N'{txtSurvayPlan.Text}', " + $"TreatmentPlan =  N'{txtTreatmentPlan.Text}' " +
                    $" where MedCard_Id = '{MedCardId}' ";

                    testCon.Open();
                    SqlCommand upbtn = new SqlCommand(qweryn, testCon);
                    upbtn.ExecuteNonQuery();
                    testCon.Close();
                    MessageBox.Show("Мед карту Редаговано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateBase();
            SaveToWordFile();
        }
        private void cmbPacient_SelectedValueChanged(object sender, EventArgs e)
        {
            string query1 = $"SELECT * From MedCard where Name = N'{cmbPacient.Text}'";

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                lblNumberCard.Text = sqlReader["MedCard_Id"].ToString();
                txtDateOfBirthday.Text = sqlReader["Birthday"].ToString();
                txtNumber.Text = sqlReader["Number"].ToString();
                txtAddress.Text = sqlReader["Adress"].ToString();
                dtpDateOfCreating.Text = sqlReader["DateMC"].ToString();
                txtGender.Text = sqlReader["State"].ToString();
                txtDiagnosis.Text = sqlReader["Diagnos"].ToString();
                txtComplaints.Text = sqlReader["Scarg"].ToString();
                txtDoneDiseases.Text = sqlReader["PereneseniTaSuputniZahvor"].ToString();
                txtCurrentDisease.Text = sqlReader["RozvutokTeperishnogoZahvor"].ToString();
                txtSurvayData.Text = sqlReader["DaniObjektDoslidjennya"].ToString();
                txtBite.Text = sqlReader["Prikus"].ToString();
                txtMouthState.Text = sqlReader["StanGigiyenuRota"].ToString();
                txtXReyData.Text = sqlReader["xRayData"].ToString();
                txtDateOfLessons.Text = sqlReader["DateOfLessons"].ToString();
                txtControlDate.Text = sqlReader["ControlDate"].ToString();
                txtSurvayPlan.Text = sqlReader["SurvayPlan"].ToString();
                txtTreatmentPlan.Text = sqlReader["TreatmentPlan"].ToString();
                txtColorVita.Text = sqlReader["ColorVita"].ToString();
            }
            sqlReader.Close();
            testCon.Close();
           
        }
        private void cmbPacient_KeyPress(object sender, KeyPressEventArgs e)
        {
            textCheck.OnlyCyrillic(sender, e);
        }
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            textCheck.AddressEnter(sender, e);
        }
        private void cmbPacient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && cmbPacient != null)
            {
                e.Handled = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtGender_KeyPress(object sender, KeyPressEventArgs e)
        {           
            textCheck.Gender(sender, e, txtGender.Text);
        }
        private void EditMedCard_Load(object sender, EventArgs e)
        {
            cmbPacient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPacient.AutoCompleteSource = AutoCompleteSource.ListItems;
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Name FROM [MedCard]", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbPacient.Items.Add(Convert.ToString(sqlReader["Name"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
            testCon.Close();
        }
    }
}
