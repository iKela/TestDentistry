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
    public partial class EditMedCard : Form
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveToWordFile();
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
    }
}
