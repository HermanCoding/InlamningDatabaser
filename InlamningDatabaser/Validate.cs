using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InlamningDatabaser
{
    class Validate
    {
        TextBox[] txtBoxes;
        public Validate(TextBox[] txtBoxes)
        {
            this.txtBoxes = txtBoxes;
            foreach (TextBox textbox in txtBoxes)
            {
                textbox.Text = textbox.Text.Trim();
                if (textbox.Text == "")
                {
                    textbox.BorderBrush = Brushes.Red;
                    valid = false;
                }
                else
                {
                    textbox.ClearValue(TextBox.BorderBrushProperty);
                }
            }
            if (!valid)
            {
                MessageBox.Show("Information i rödmarkerade rutor får inte vara tom.");
                return;
            }

        }
        public bool valid = true;
    }
}
