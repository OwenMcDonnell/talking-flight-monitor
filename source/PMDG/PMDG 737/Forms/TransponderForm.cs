using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.Forms
{
    public partial class TransponderForm : Form
    {

        System.Timers.Timer transponderTimer = new System.Timers.Timer();
        int oldTransponder = 0;

        public TransponderForm()
        {
            InitializeComponent();
        }

        private void TransponderTimerTick(Object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            if (App.instrumentPanel.Transponder != oldTransponder)
            {
                transponderCodeTextBox.Text = App.instrumentPanel.Transponder.ToString();
                oldTransponder = App.instrumentPanel.Transponder;
            }

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.XPDR_XpndrSelector_2)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        sourceButton.Text = $"&Source {toggle.CurrentState.Value}";
                        sourceButton.AccessibleName = $"Transponder source {toggle.CurrentState.Value}";
                    }
                } // source

                if (toggle.Offset == Aircraft.pmdg737.XPDR_AltSourceSel_2)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        altSourceButton.Text = $"&Alt {toggle.CurrentState.Value}";
                        altSourceButton.AccessibleName = $"Alternate source {toggle.CurrentState.Value}";
                    }
                } // Alt source

                if (toggle.Offset == Aircraft.pmdg737.XPDR_ModeSel)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        modeButton.Text = $"&Mode {toggle.CurrentState.Value}";
                        modeButton.AccessibleName = $"Transponder mode {toggle.CurrentState.Value}";
                    }
                } // mode

                if (toggle.Offset == Aircraft.pmdg737.XPDR_annunFAIL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        transponderFailTextBox.Text = toggle.CurrentState.Value;
                    }
                } // fail
            } // loop.
        }

        private void TransponderForm_Load(object sender, EventArgs e)
        {
            transponderTimer.Elapsed += new System.Timers.ElapsedEventHandler(TransponderTimerTick);
            transponderTimer.Start();

            transponderCodeTextBox.Text = App.instrumentPanel.Transponder.ToString();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.XPDR_XpndrSelector_2)
                {
                    sourceButton.Text = $"&Source {toggle.CurrentState.Value}";
                    sourceButton.AccessibleName = $"Transponder source {toggle.CurrentState.Value}";
                } // source

                if (toggle.Offset == Aircraft.pmdg737.XPDR_AltSourceSel_2)
                {
                    altSourceButton.Text = $"&Alt {toggle.CurrentState.Value}";
                    altSourceButton.AccessibleName = $"Alternate source {toggle.CurrentState.Value}";
                } // Alt source

                if (toggle.Offset == Aircraft.pmdg737.XPDR_ModeSel)
                {
                    modeButton.Text = $"&Mode {toggle.CurrentState.Value}";
                    modeButton.AccessibleName = $"Transponder mode {toggle.CurrentState.Value}";
                } // mode

                if (toggle.Offset == Aircraft.pmdg737.XPDR_annunFAIL)
                {
                    transponderFailTextBox.Text = toggle.CurrentState.Value;
                } // fail
            } // loop.
        }

        private void transponderCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG737Aircraft.SetTransponder(transponderCodeTextBox.Text);
            }

        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TransponderSource();
        }

        private void altSourceButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TransponderAlternateSource();
        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TransponderMode();
        }

        private void identButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TransponderIdent();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TransponderTest();
        }
    }
}
