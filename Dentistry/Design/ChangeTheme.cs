using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Design
{
    class ChangeTheme
    {
        public static void ButtonColorChange(int num, ref System.Windows.Forms.Button buttonToChange)
        {
            switch (num)
            {
                case 0:
                    buttonToChange.BackColor = System.Drawing.Color.White;
                    break;
                case 1:
                    buttonToChange.BackColor = System.Drawing.Color.Transparent;
                    break;
                default:
                    break;
            }
        }
        public static void LabelColorChange(int num, ref System.Windows.Forms.Label labelToChange)
        {
            switch (num)
            {
                case 0:
                    labelToChange.ForeColor = System.Drawing.Color.White;
                    break;
                case 1:
                    labelToChange.ForeColor = System.Drawing.Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}
