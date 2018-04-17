using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.General
{
    class TextCheck
    {
        public void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            e.Handled = true; 
        }
        public void OnlyCyrillic(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 'А' && e.KeyChar < 'я') || e.KeyChar == 'і')return;
            if (e.KeyChar == '\b' || e.KeyChar == (char)8) return;
            if (e.KeyChar == '.' || e.KeyChar == ',') return;
            e.Handled = true;
        }
        public void OnlyLatin(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 'A' && e.KeyChar < 'z')) return;
            if (e.KeyChar == '\b' || e.KeyChar == (char)8) return;
            if (e.KeyChar == '.' || e.KeyChar == ',') return;
            e.Handled = true;
        }
        public void AddressEnter(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 'А'   && e.KeyChar < 'я') || e.KeyChar == 'і') return; 
            if ( e.KeyChar == '\b' || e.KeyChar == (char)8) return;
            if (e.KeyChar == '/'   || e.KeyChar == '\\' || e.KeyChar == '.') return;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            e.Handled = true;
        }
        public void Gender(object sender, KeyPressEventArgs e, string text)
        {
            if ((e.KeyChar == '1' || e.KeyChar == '2') && text.Length < 1) return;
            if (e.KeyChar == (char)8) return;
            e.Handled = true;
        }
    }
}
