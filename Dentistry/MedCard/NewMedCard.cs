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

            General.NewMedCard general = new General.NewMedCard(arr);
            general.SaveToWordFile();
            

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveToWordFile();
            using (var name = new DentistryContext())
            {
                var stud = new Entity.MedCard() { NamePatient = txtName.Text };
                name.MedCards.Add(stud);
                name.SaveChanges();
            }
            
            MessageBox.Show("Виконано!");
        }
    }
}
