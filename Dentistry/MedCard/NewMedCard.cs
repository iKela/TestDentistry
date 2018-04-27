using Dentistry.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.MedCard
{
    public partial class NewMedCard : Form
    {
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
                                else Design.ChangeTheme.ButtonColorChange(ref button, Color.White);

                            }
                            // Колір лейбла
                            for(int i = 0; i < labels.Count;i++)
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
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Transparent);
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
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Transparent);
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
                default:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            // Колір кнопок
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                Button button = buttons[i];
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Transparent);
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
           using (var name = new ModelFirs())
           {
               var variables = new MedCards { NamePatient = txtName.Text, Gender = txtGender.Text,
                  DateOfBirth = txtDateOfBirthday.Text, NumberPhone = txtNumber.Text, Adress=txtAddress.Text,
                  dateOfCreatingMC = dtpDateOfCreating.Text, Diagnosis= txtDiagnosis.Text,
                  Complaint =txtComplaints.Text,DoneDiseases= txtDoneDiseases.Text, CurrentDiseas= txtCurrentDisease.Text,
                  SurvayData= txtSurvayData.Text, Bite= txtBite.Text, MouthState= txtMouthState.Text,
                  XReyDate= txtXReyData.Text,ColorVita= txtColorVita.Text, DateOfLessons= txtDateOfLessons.Text,
                  ControlDate= txtControlDate.Text, SurvayPlan= txtSurvayPlan.Text,  TreatmentPlan= txtTreatmentPlan.Text
               };
               name.MedCards.Add(variables);
               name.SaveChanges();
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
