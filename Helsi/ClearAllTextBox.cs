using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsi
{
    public static class ClearAllTextBox
    {
        public static void ClearAllTextBoxes(Control.ControlCollection controls)
        {
            foreach(Control control in controls)
            {
                if(control is TextBox textBox)
                {
                    textBox.Clear();
                }else if (control.HasChildren)
                {
                    ClearAllTextBoxes(control.Controls); // рекурсія для вкладених контейнерів
                }
            }
        }

    }
}
