using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.Source
{
    public partial class UserInfo : Form
    {
        UserInfoAddClass text = new UserInfoAddClass();
        double number = 0;
        int leftArrow;
        int rightArrow;
        int setVisible;
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {           
           TextLoading();         
        }
        private void TextLoading()
        {
            rtxtAboutSoft.Text = text.AboutSoft;
            rtxtInterface.Text = text.AboutInterface;
            rtxtSettings.Text = text.AboutSettings;
        }
        private void selectBoxByButton()
        {
            switch (number)
            {
                case 1:
                    {
                        setVisible = 1;
                        setVisibility();
                        break;
                    }
                case 2:
                    {
                        setVisible = 2;
                        setVisibility();
                        break;
                    }
                case 3:
                    {
                        setVisible = 3;
                        setVisibility();
                        break;
                    }
            }
        }
        private void setVisibility()
        {
            switch (setVisible)
            {
                case 1:
                    {
                        gBoxAboutSoft.Visible = true;
                        gBoxInterface.Visible = false;
                        gBoxSettings.Visible = false;
                        break;
                    }
                case 2:
                    {
                        gBoxAboutSoft.Visible = false;
                        gBoxInterface.Visible = true;
                        gBoxSettings.Visible = false;
                        break;
                    }
                case 3:
                    {
                        gBoxAboutSoft.Visible = false;
                        gBoxInterface.Visible = false;
                        gBoxSettings.Visible = true;
                        break;
                    }
            }
        }
        #region Кнопки
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    {
                        leftArrow = 1;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        leftArrow = 2;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        leftArrow = 3;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    {
                        leftArrow = 2;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 1:
                    {
                        leftArrow = 1;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        leftArrow = 3;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
            }
        }
        private void toolStripSplitButton4_ButtonClick(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    {
                        leftArrow = 3;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
                case 1:
                    {
                        leftArrow = 1;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        leftArrow = 2;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }
        #endregion
        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            switch (leftArrow)
            {
                case 1:
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            switch (rightArrow)
            {
                case 1:
                    {
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
