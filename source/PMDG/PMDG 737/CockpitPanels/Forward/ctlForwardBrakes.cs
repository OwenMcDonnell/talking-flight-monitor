using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    public partial class ctlForwardBrakes : UserControl
    {
        public ctlForwardBrakes()
        {
            InitializeComponent();
        }

        private void autoBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt && e.KeyCode == Keys.D1) ||
    (e.Alt && e.KeyCode == Keys.D2) ||
    (e.Alt && e.KeyCode == Keys.D3)) return;
            if (e.KeyCode == Keys.O)
            {
                PMDG737Aircraft.AutoBrake(1);
            }
            if (e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.AutoBrake(0);
            }
            if (e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.AutoBrake(2);
            }
            if (e.KeyCode == Keys.D1)
            {
                PMDG737Aircraft.AutoBrake(3);
            }
            if (e.KeyCode == Keys.D2)
            {
                PMDG737Aircraft.AutoBrake(4);
            }
            if (e.KeyCode == Keys.D3)
            {
                PMDG737Aircraft.AutoBrake(5);
            }

        }

        private void autoBrakeTextBox_Enter(object sender, EventArgs e)
        {
            autoBrakeTextBox.Select(autoBrakeTextBox.Text.Length, 0);
        }
    }
}
