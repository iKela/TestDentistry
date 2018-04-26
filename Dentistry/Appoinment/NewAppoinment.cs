using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Dentistry.Appoinment
{
    public partial class NewAppoinment : Form
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
            Source.Calculator newForm = new Source.Calculator(this);
            newForm.Show();
        }
        public void ButtonClear()
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
        #region TextBox'и зубів
        #region Mouse Hover & Leave на TextBox'и зубів
        //-----------TextBoxMouseHover------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseHover(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        this.TopLeftTextBox8.Size = new Size(150, 150);
                        this.TopLeftTextBox8.BringToFront();
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox7.Size = new Size(150, 150);
                        this.TopLeftTextBox7.BringToFront();
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox6.Size = new Size(150, 150);
                        this.TopLeftTextBox6.BringToFront();
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox5.Size = new Size(150, 150);
                        this.TopLeftTextBox5.BringToFront();
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox4.Size = new Size(150, 150);
                        this.TopLeftTextBox4.BringToFront();
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox3.Size = new Size(150, 150);
                        this.TopLeftTextBox3.BringToFront();
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox2.Size = new Size(150, 150);
                        this.TopLeftTextBox2.BringToFront();
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox1.Size = new Size(150, 150);
                        this.TopLeftTextBox1.BringToFront();
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox1.Size = new Size(150, 150);
                        this.TopRightTextBox1.BringToFront();
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox2.Size = new Size(150, 150);
                        this.TopRightTextBox2.BringToFront();
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox3.Size = new Size(150, 150);
                        this.TopRightTextBox3.BringToFront();
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox4.Size = new Size(150, 150);
                        this.TopRightTextBox4.BringToFront();
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox5.Size = new Size(150, 150);
                        this.TopRightTextBox5.BringToFront();
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox6.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox6.Size = new Size(150, 150);
                        this.TopRightTextBox6.BringToFront();
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox7.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox7.Size = new Size(150, 150);
                        this.TopRightTextBox7.BringToFront();
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox8.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox8.Size = new Size(150, 150);
                        this.TopRightTextBox8.BringToFront();
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox8.Size = new Size(150, 150);
                        this.BotLeftTextBox8.BringToFront();
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox7.Size = new Size(150, 150);
                        this.BotLeftTextBox7.BringToFront();
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox6.Size = new Size(150, 150);
                        this.BotLeftTextBox6.BringToFront();
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox5.Size = new Size(150, 150);
                        this.BotLeftTextBox5.BringToFront();
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox4.Size = new Size(150, 150);
                        this.BotLeftTextBox4.BringToFront();
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox3.Size = new Size(150, 150);
                        this.BotLeftTextBox3.BringToFront();
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox2.Size = new Size(150, 150);
                        this.BotLeftTextBox2.BringToFront();
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox1.Size = new Size(150, 150);
                        this.BotLeftTextBox1.BringToFront();
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox1.Size = new Size(150, 150);
                        this.BotRightTextBox1.BringToFront();
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox2.Size = new Size(150, 150);
                        this.BotRightTextBox2.BringToFront();
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox3.Size = new Size(150, 150);
                        this.BotRightTextBox3.BringToFront();
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox4.Size = new Size(150, 150);
                        this.BotRightTextBox4.BringToFront();
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox5.Size = new Size(150, 150);
                        this.BotRightTextBox5.BringToFront();
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox6.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox6.Size = new Size(150, 150);
                        this.BotRightTextBox6.BringToFront();
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox7.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox7.Size = new Size(150, 150);
                        this.BotRightTextBox7.BringToFront();
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox8.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox8.Size = new Size(150, 150);
                        this.BotRightTextBox8.BringToFront();
                        break;
                    }
            }
        }
        //-----------TextBoxMouseLeave------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseLeave(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        this.TopLeftTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox6.Location = new Point(446, TopRightTextBox5.Location.Y);
                        this.TopRightTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox7.Location = new Point(489, TopRightTextBox5.Location.Y);
                        this.TopRightTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox8.Location = new Point(527, TopRightTextBox5.Location.Y);
                        this.TopRightTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox6.Location = new Point(446, BotRightTextBox5.Location.Y);
                        this.BotRightTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox7.Location = new Point(489, BotRightTextBox5.Location.Y);
                        this.BotRightTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox8.Location = new Point(527, BotRightTextBox5.Location.Y);
                        this.BotRightTextBox8.Size = new Size(21, 21);
                        break;
                    }
            }

        }
        #endregion
        public void TopLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(1);
        }

        public void TopLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(1);
        }
        public void TopLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(2);
        }

        private void TopLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(2);
        }
        private void TopLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(3);
        }

        private void TopLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(3);
        }
        private void TopLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(4);
        }

        private void TopLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(4);
        }
        private void TopLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(5);
        }

        private void TopLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(5);
        }
        private void TopLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(6);
        }

        private void TopLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(6);
        }
        private void TopLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(7);
        }

        private void TopLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(7);
        }
        private void TopLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(8);
        }

        private void TopLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(8);
        }

        private void TopRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(9);
        }

        private void TopRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(9);
        }
        private void TopRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(10);
        }

        private void TopRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(10);
        }
        private void TopRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(11);
        }

        private void TopRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(11);
        }
        private void TopRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(12);
        }

        private void TopRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(12);
        }
        private void TopRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(13);
        }

        private void TopRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(13);
        }
        private void TopRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(14);
        }

        private void TopRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(14);
        }
        private void TopRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(15);
        }

        private void TopRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(15);
        }
        private void TopRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(16);
        }

        private void TopRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(16);
        }

        private void BotLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(17);
        }

        private void BotLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(17);
        }
        private void BotLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(18);
        }

        private void BotLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(18);
        }
        private void BotLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(19);
        }

        private void BotLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(19);
        }
        private void BotLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(20);
        }

        private void BotLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(20);
        }
        private void BotLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(21);
        }

        private void BotLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(21);
        }
        private void BotLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(22);
        }

        private void BotLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(22);
        }
        private void BotLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(23);
        }

        private void BotLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(23);
        }
        private void BotLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(24);
        }

        private void BotLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(24);
        }
        private void BotRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(25);
        }

        private void BotRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(25);
        }
        private void BotRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(26);
        }

        private void BotRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(26);
        }
        private void BotRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(27);
        }

        private void BotRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(27);
        }
        private void BotRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(28);
        }

        private void BotRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(28);
        }
        private void BotRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(29);
        }

        private void BotRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(29);
        }
        private void BotRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(30);
        }

        private void BotRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(30);
        }
        private void BotRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(31);
        }

        private void BotRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(31);
        }
        private void BotRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(32);
        }
        private void BotRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(32);
        }

        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveToWordFile();
            //Doesn't has a datebase currently
            //saveToBD();
        }
        #region Заповнення Word файла  
        private void SaveToWordFile()
        {

            string[] arr = {cmbPatient.Text, cmbDoctor.Text, dtpDate.Text,txtDescription.Text,txtMoney.Text};
            
            General.NewAppoinmentSave general = new General.NewAppoinmentSave(arr);
            if (general.SaveToWordFile() == true)
            {
                ButtonClear();
            }
        }
        #endregion
    }
}
