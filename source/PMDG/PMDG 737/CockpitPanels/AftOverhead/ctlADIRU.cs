using DavyKager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
{
    public partial class ctlADIRU : UserControl, iPanelsPage
    {
        private Timer adiruTimer = new Timer();
        PanelObjects.PanelObject[] iruControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelSection == "ADIRU" && x.Type != PanelObjectType.Annunciator).ToArray();
        PanelObjects.PanelObject[] lights = PMDG737Aircraft.PanelControls.Where(x => x.PanelSection == "ADIRU" && x.Type == PanelObjectType.Annunciator).ToArray();
        public ctlADIRU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }
        private void adiruTimerTick(object Sender, EventArgs e)
        {
            adiruTimer.Stop();
                        //todo: Convert IRS display values into linq.
            leftDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayLeft.Value;
            rightDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayRight.Value;

            foreach (PanelObjects.PanelObject control in iruControls)
            { var toggle = (PanelObjects.SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.IRS_ModeSelector[0])
                {
                    switch (toggle.CurrentState.Key)
                    {
                        case 0:
                            leftModeOffRadioButton.Checked = true;
                            break;
                        case 1:
                            leftModeAlignRadioButton.Checked = true;
                            break;
                        case 2:
                            leftModeNavRadioButton.Checked = true;
                            break;
                        case 3:
                            leftModeAttRadioButton.Checked = true;
                            break;
                    }
                } // Left mode selector.

                if (toggle.Offset == Aircraft.pmdg737.IRS_ModeSelector[1])
                {
                    switch (toggle.CurrentState.Key)
                    {
                        case 0:
                            rightModeOffRadioButton.Checked = true;
                            break;
                        case 1:
                            rightModeAlignRadioButton.Checked = true;
                            break;
                        case 2:
                            rightModeNavRadioButton.Checked = true;
                            break;
                        case 3:
                            rightModeAttRadioButton.Checked = true;
                            break;
                    }
                } // Right mode selector.

                if (toggle.Offset == Aircraft.pmdg737.IRS_DisplaySelector)
                {
                    switch (toggle.CurrentState.Key)
                    {
                        case 1:
                            tkGsRadioButton.Checked = true;
                            leftDisplayTextBox.AccessibleName = "track";
                            rightDisplayTextBox.AccessibleName = "ground speed";
                            break;
                        case 2:
                            pPosRadioButton.Checked = true;
                            leftDisplayTextBox.AccessibleName = "latitude";
                            rightDisplayTextBox.AccessibleName = "longitude";
                            break;
                        case 3:
                            windRadioButton.Checked = true;
                            leftDisplayTextBox.AccessibleName = "wind direction";
                            rightDisplayTextBox.AccessibleName = "wind speed";
                            break;
                        case 4:
                            hdgStatRadioButton.Checked = true;
                            leftDisplayTextBox.AccessibleName = "heading";
                            rightDisplayTextBox.AccessibleName = "status";
                            break;
                    }
                } // Display selector.
            }
foreach(PanelObjects.SingleStateToggle toggle in lights)
            {
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[0]) leftDCFailLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[1]) rightDcFailLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunFAULT[0]) leftIrsFaultLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunFAULT[1]) rightIrsFaultLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunGPS) gpsTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunALIGN[0]) leftIrsLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunALIGN[1]) rightIrsLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunON_DC[0]) leftIrsDcLightTextBox.Text = toggle.CurrentState.Value;
                if (toggle.Offset == Aircraft.pmdg737.IRS_annunON_DC[1]) rightIrsDcLightTextBox.Text = toggle.CurrentState.Value;
            }
                                    adiruTimer.Start();
        }

        private void ctlADIRU_Load(object sender, EventArgs e)
        {
            adiruTimer.Enabled = true;
            adiruTimer.Tick += new EventHandler(adiruTimerTick);
            adiruTimer.Interval = 300;
            adiruTimer.Start();
            Tolk.Load();
                                           }

        private void tkGsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRSDisplayTrackGS();
            }
                    }

        private void pPosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRSDisplayPPOS();
            }
            
        }

        private void windRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRSDisplayWind();
            }
            
        }

        private void hdgStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRSDisplayHdgStat();
            }
            
        }

        private void leftModeOffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRULeftOff();
            }
        }

        private void leftModeAlignRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRULeftAlign();
            }
        }

        private void leftModeNavRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRULeftNav();
            }
        }

        private void leftModeAttRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRULeftAtt();
            }
        }

        private void rightModeOffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRURightOff();
            }
        }

        private void rightModeAlignRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRURightAlign();
            }
        }

        private void rightModeNavRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRURightNav();
            }
        }

        private void rightModeAttRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                PMDG737Aircraft.IRURightAtt();
            }
        }

        private void gpsTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void ctlADIRU_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                adiruTimer.Start();
            }
            else
            {
                adiruTimer.Stop();
            }

        }
    }
}
