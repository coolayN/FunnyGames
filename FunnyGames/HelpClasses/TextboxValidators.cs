using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyGames.HelpClasses
{
    public static class TextboxValidators
    {
        public static void IntFilter(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) &&  number != 08)
            {
                e.Handled = true;
                //MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
