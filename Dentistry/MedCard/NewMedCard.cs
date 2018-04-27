using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dentistry.MedCard
{
    public partial class NewMedCard : Form
    {
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

        public NewMedCard()
        {
            InitializeComponent();
            SetTheme();
        }
        
        private void SetTheme()
        {
            List<Button> buttons = new List<Button> { btnAdd, btnExit,btn1, btn2, btn3, btn4, btn5, btn6, };
            List<Label> labels = new List<Label>
            {
                lblAddress, lblBirthday, lblDate,
                lblGender, lblGenderType, lblName,
                lblPhoneNumber
            };

            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (this.BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;
                            // Колір кнопок
                            for(int i = 0; i < buttons.Count;i++)
                            {
                                Button button = buttons[i];
                                if (i == 0) buttons[i].BackColor = Color.Transparent;
                                else Design.ChangeTheme.ButtonColorChange(0, ref button);

                            }
                            // Колір лейбла
                            for(int i = 0; i < labels.Count;i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(0, ref label);
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
                                Design.ChangeTheme.ButtonColorChange(1, ref button);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(1, ref label);
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
                                Design.ChangeTheme.ButtonColorChange(1, ref button);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(1, ref label);
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
                                Design.ChangeTheme.ButtonColorChange(1, ref button);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(1, ref label);
                            }
                        }
                        break;
                    }
            }

        }

        public void SaveToWordFile()
        {
            string[] arr = {txtName.Text, txtDateOfBirthday.Text, txtNumber.Text,txtAddress.Text,dtpDateOfCreating.Text,txtGender.Text,
                txtDiagnosis.Text,txtComplaints.Text,txtDoneDiseases.Text,txtCurrentDisease.Text,txtSurvayData.Text,txtBite.Text,
                txtMouthState.Text,txtXReyData.Text,txtColorVita.Text,txtDateOfLessons.Text,txtControlDate.Text,txtSurvayPlan.Text,
                txtTreatmentPlan.Text};

            General.NewMedCardSave general = new General.NewMedCardSave(arr);
            general.SaveToWordFile();
            

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0 || txtNumber.Text.Length == 0 || txtAddress.Text.Length == 0 || txtDateOfBirthday.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO MedCard ( Name, State, Birthday, Number, Adress, DateMC, Diagnos, Scarg, PereneseniTaSuputniZahvor, " +
                        $"RozvutokTeperishnogoZahvor, DaniObjektDoslidjennya, Prikus, StanGigiyenuRota, xRayData, ColorVita, DateOfLessons, ControlDate, " +
                        $"SurvayPlan, TreatmentPlan) " +
                        $"values ( N'{txtName.Text}',  N'{txtGender.Text}', N'{txtDateOfBirthday.Text}', " +
                        $" N'{txtNumber.Text}', N'{txtAddress.Text}',  N'{dtpDateOfCreating.Value.Date.ToString("dd/MM/yyyy")}', N'{txtDiagnosis.Text}', N'{txtComplaints.Text}', N'{txtDoneDiseases.Text}', N'{txtCurrentDisease.Text}', " +
                        $" N'{txtSurvayData.Text}', N'{txtBite.Text}', N'{txtMouthState.Text}', N'{txtXReyData.Text}', N'{txtDateOfLessons.Text}', N'{txtControlDate.Text}', " +
                        $" N'{txtSurvayData.Text}', N'{txtSurvayPlan.Text}', N'{txtTreatmentPlan.Text}')";
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Додано нового паціента.");


                    testCon.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }

            SaveToWordFile();
            MessageBox.Show("Виконано!");
        }       

        private void txtGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            textCheck.Gender(sender, e, txtGender.Text);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            textCheck.AddressEnter(sender, e);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            textCheck.OnlyCyrillic(sender, e);
        }
    }
}
