using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.Appoinment
{
    public partial class NewAppoinment : Form
    {
        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }
        public NewAppoinment()
        {
            InitializeComponent();
            SetTheme();
        }
        private void SetTheme()
        {
            List<Button> buttons = new List<Button> { btnAdd, btnExit, btn1, btn2, btn3, btn4, btn5, btn6 };
            List<Label> labels = new List<Label>
            {
                lbl1, lbl2, lbl3,
                lbl4, lbl5, lbl6
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
                                else Design.ChangeTheme.ButtonColorChange(0, ref button);

                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(0, ref label);
                            }
                            chbArrears.ForeColor = Color.White;
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
                            chbArrears.ForeColor = Color.Black;
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
                            chbArrears.ForeColor = Color.Black;
                        }

                        break;
                    }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            // Doesn't have Calculator Form
            //Calculator newForm = new Calculator(this);
            //newForm.Show();
        }
        public void Buttonclear()
        {
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
    }
}
