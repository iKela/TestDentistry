using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Design
{
    class ChangeTheme
    {
        public static void ButtonColorChange(ref System.Windows.Forms.Button buttonToChange, System.Drawing.Color color)
        {
            buttonToChange.BackColor = color;
        }
        public static void LabelColorChange(ref System.Windows.Forms.Label labelToChange, System.Drawing.Color color)
        {
            labelToChange.ForeColor = color;
        }
        public static void PanelToChange(ref PanelZ.PanelZ panelToChange, System.Drawing.Color endColor, System.Drawing.Color startColor)
        {
            panelToChange.EndColor = endColor;
            panelToChange.StartColor = startColor;
        }
        public static void GroupBoxToChange(ref System.Windows.Forms.GroupBox groupBox, System.Drawing.Color color)
        {
            groupBox.ForeColor = color;
        }
    }
}
