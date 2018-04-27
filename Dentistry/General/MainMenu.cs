using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.General
{
    public partial class MainMenu : Form
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
        Main main;
        MedCard.NewMedCard newMedCard;
        MedCard.EditMedCard editMedCard;
        Appoinment.NewAppoinment newAppoinment;
        Source.AboutSoft aboutSoft;
        Source.Calculator calculator;
        General.ProgramSettings settings;
        Source.UserInfo userInfo;
        General.Account account;
        Source.HelpContacts helpContacts;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            SetTheme();
            btnUsername.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnUsernameLogo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnInfo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void SetTheme()
        {
            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;
                        }
                        break;
                    }
                case 1:
                    {
                        if (BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;
                        }
                        break;
                    }
                case 2:
                    {
                        if (BackColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;
                        }
                        break;
                    }
                default:
                    {
                        if (BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;
                        }
                        break;
                    }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            if (main == null || main.IsDisposed)
            {
                main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                main.Focus();
            }
        }

        private void btnNewAppoinment_Click(object sender, EventArgs e)
        {
            if (newAppoinment == null || newAppoinment.IsDisposed)
            {
                newAppoinment = new Appoinment.NewAppoinment();
                newAppoinment.Show();
            }
            else
            {
                newAppoinment.Focus();
            }
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            if (helpContacts == null || helpContacts.IsDisposed)
            {
                helpContacts = new Source.HelpContacts();
                helpContacts.Show();
            }
            else
            {
                helpContacts.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userInfo == null || userInfo.IsDisposed)
            {
                userInfo = new Source.UserInfo();
                userInfo.Show();
            }
            else
            {
                userInfo.Focus();
            }
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            if (newMedCard == null || newMedCard.IsDisposed)
            {
                newMedCard = new MedCard.NewMedCard();
                newMedCard.Show();
            }
            else
            {
                newMedCard.Focus();
            }
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (editMedCard == null || editMedCard.IsDisposed)
            {
                editMedCard = new MedCard.EditMedCard();
                editMedCard.Show();
            }
            else
            {
                editMedCard.Focus();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (settings == null || settings.IsDisposed)
            {
                settings = new General.ProgramSettings();
                settings.Show();
            }
            else
            {
                settings.Focus();
            }
        }

        private void showAccount()
        {
            if (account == null || account.IsDisposed)
            {
                account = new General.Account();
                account.Show();
            }
            else
            {
                account.Focus();
            }
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            showAccount();
        }

        private void btnUsernameLogo_Click(object sender, EventArgs e)
        {
            showAccount();
        }

        #region MouseHover & Leave

        private void btnRegistry_MouseHover(object sender, EventArgs e)
        {
            btnRegistry.Size = new Size(115, 115);
            btnRegistry.Location = new Point(170, 79);
        }

        private void btnRegistry_MouseLeave(object sender, EventArgs e)
        {
            btnRegistry.Size = new Size(110, 110);
            btnRegistry.Location = new Point(173, 82);
        }

        private void btnNewAppoinment_MouseHover(object sender, EventArgs e)
        {
            btnNewAppoinment.Size = new Size(115, 115);
            btnNewAppoinment.Location = new Point(314, 79);
        }

        private void btnNewAppoinment_MouseLeave(object sender, EventArgs e)
        {
            btnNewAppoinment.Size = new Size(110, 110);
            btnNewAppoinment.Location = new Point(317, 82);
        }

        private void btnReporting_MouseHover(object sender, EventArgs e)
        {
            btnReporting.Size = new Size(115, 115);
            btnReporting.Location = new Point(458, 79);
        }

        private void btnReporting_MouseLeave(object sender, EventArgs e)
        {
            btnReporting.Size = new Size(110, 110);
            btnReporting.Location = new Point(461, 82);
        }
        #endregion

        private void btnNewPatient_MouseHover(object sender, EventArgs e)
        {
            btnNewPatient.Size = new Size(115, 115);
            btnNewPatient.Location = new Point(170, 217);
        }

        private void btnNewPatient_MouseLeave(object sender, EventArgs e)
        {
            btnNewPatient.Size = new Size(110, 110);
            btnNewPatient.Location = new Point(173, 220);
        }

        private void btnEditPatient_MouseHover(object sender, EventArgs e)
        {
            btnEditPatient.Size = new Size(115, 115);
            btnEditPatient.Location = new Point(314, 217);
        }

        private void btnEditPatient_MouseLeave(object sender, EventArgs e)
        {
            btnEditPatient.Size = new Size(110, 110);
            btnEditPatient.Location = new Point(317, 220);
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            btnSettings.Size = new Size(115, 115);
            btnSettings.Location = new Point(458, 217);
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.Size = new Size(110, 110);
            btnSettings.Location = new Point(461, 220);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.Size = new Size(36, 36);
            btnExit.Location = new Point(355, 1);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Size = new Size(35, 35);
            btnExit.Location = new Point(358, 3);
        }

        private void btnInfo_MouseHover(object sender, EventArgs e)
        {
            btnInfo.Size = new Size(27, 27);
            btnInfo.Location = new Point(717, 4);
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            btnInfo.Size = new Size(25, 25);
            btnInfo.Location = new Point(719, 6);
        }

        private void btnUsername_MouseHover(object sender, EventArgs e)
        {
            btnUsername.Font = new Font("Times New Roman", 13, FontStyle.Underline);
        }

        private void btnUsername_MouseLeave(object sender, EventArgs e)
        {
            btnUsername.Font = new Font("Times New Roman", 12, FontStyle.Underline);
        }
    }
}
