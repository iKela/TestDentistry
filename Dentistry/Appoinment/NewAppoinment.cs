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
using Word = Microsoft.Office.Interop.Word;

namespace Dentistry.Appoinment
{
    public partial class NewAppoinment : Form
    {
        int Arrears;
        string MedCardId = null;
        string DoctorId = null;
        string query;
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
        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }
        public NewAppoinment()
        {
            InitializeComponent();
            SetTheme();
        }
        private void NewAppoinment_Load(object sender, EventArgs e)
        {
            cmbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Name from MedCard", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbPatient.Items.Add(Convert.ToString(sqlReader["Name"]));
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

            testCon.Open();
            sqlReader = null;
            command = null;
            command = new SqlCommand("SELECT Name from Doctor", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbDoctor.Items.Add(Convert.ToString(sqlReader["Name"]));
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
                                else Design.ChangeTheme.ButtonColorChange(ref button, Color.White);

                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.White);
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
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Transparent);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.Black);
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
                                Design.ChangeTheme.ButtonColorChange(ref button, Color.Transparent);
                            }
                            // Колір лейбла
                            for (int i = 0; i < labels.Count; i++)
                            {
                                Label label = labels[i];
                                Design.ChangeTheme.LabelColorChange(ref label, Color.Black);
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
            saveToBD();
        }
        private void saveToBD()
        {
            try
            {
                if (cmbPatient.Text.Length == 0 || txtDescription.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {
                    if (string.IsNullOrEmpty(cmbPatient.Text)) throw new Exception("Виберіть  Паціента!");
                    testCon.Open();
                    query = $"select MedCard_Id from MedCard where [Name] = N'{cmbPatient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        MedCardId = reader["MedCard_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибраний паціент, перевірте ще раз!");
                    }
                    reader.Close();
                    testCon.Close();

                    if (string.IsNullOrEmpty(cmbDoctor.Text)) throw new Exception("Виберіть Лікаря!");
                    testCon.Open();
                    query = $"select Doctor_Id from Doctor where [Name] = N'{cmbDoctor.Text}'";
                    cmd1 = new SqlCommand(query, testCon);
                    reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        DoctorId = reader["Doctor_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибраний паціент, перевірте ще раз!");
                    }
                    reader.Close();
                    testCon.Close();
                    // ----------------------------------------------------------------------------------------------------------------------------------------------------------
                    testCon.Open();
                    cmd1 = testCon.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = $"INSERT INTO Reception (IdMedCard, Date, IdDoctor, Info, Money, Arrears, tlt1, tlt2, tlt3, tlt4, tlt5, tlt6, tlt7, tlt8, " +
                        $"trt1, trt2, trt3, trt4, trt5, trt6, trt7, trt8, " +
                        $"brt1, brt2, brt3, brt4, brt5, brt6, brt7, brt8, " +
                        $"blt1, blt2, blt3, blt4, blt5, blt6, blt7, blt8)" +
                        $"values ('{MedCardId}', '{dtpDate.Value.Date.ToString("yyyy/MM/dd")}', N'{DoctorId}', N'{txtDescription.Text}', N'{txtMoney.Text}', '{Arrears}', " +

                        $" N'{TopLeftTextBox1.Text}',  N'{TopLeftTextBox2.Text}',  N'{TopLeftTextBox3.Text}',  N'{TopLeftTextBox4.Text}',  N'{TopLeftTextBox5.Text}',  N'{TopLeftTextBox6.Text}',  N'{TopLeftTextBox7.Text}',  N'{TopLeftTextBox8.Text}'," +
                        $" N'{TopRightTextBox1.Text}', N'{TopRightTextBox2.Text}', N'{TopRightTextBox3.Text}', N'{TopRightTextBox4.Text}', N'{TopRightTextBox5.Text}', N'{TopRightTextBox6.Text}', N'{TopRightTextBox7.Text}', N'{TopRightTextBox8.Text}'," +
                        $" N'{BotRightTextBox8.Text}', N'{BotRightTextBox7.Text}', N'{BotRightTextBox6.Text}', N'{BotRightTextBox5.Text}', N'{BotRightTextBox4.Text}', N'{BotRightTextBox3.Text}', N'{BotRightTextBox2.Text}', N'{BotRightTextBox1.Text}'," +
                        $" N'{BotLeftTextBox8.Text}',  N'{BotLeftTextBox7.Text}',  N'{BotLeftTextBox6.Text}',  N'{BotLeftTextBox5.Text}',  N'{BotLeftTextBox4.Text}',  N'{BotLeftTextBox3.Text}',  N'{BotLeftTextBox2.Text}',  N'{BotLeftTextBox1.Text}')";

                    cmd1.ExecuteNonQuery();

                    ButtonClear();
                    MessageBox.Show("Додано новий прийом.");
                    testCon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
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
