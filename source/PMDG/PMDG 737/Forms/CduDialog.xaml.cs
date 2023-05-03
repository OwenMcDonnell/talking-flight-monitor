using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tfm.PMDG.PMDG_737.Forms
{
        public partial class CduDialog : Window
    {

        private System.Timers.Timer cduTimer = new System.Timers.Timer();

        public CduDialog()
        {
            InitializeComponent();

            RefreshCDU();
            cduDisplay.Focus();
        }

        private void RefreshCDU()
        {

            cduDisplay.Clear();

            Thread.Sleep(500);
            string displayText = PMDG737Aircraft.RefreshCDU(0);

            // Set the title of the window if the CDU is powered.
            if (PMDG737Aircraft.cdu0.Powered)
            {
                this.Title = PMDG737Aircraft.cdu0.Rows[0].ToString().Trim();
                cduDisplay.Text = displayText;
            }
            else
            {
                this.Title = "CDU not powered";
                cduDisplay.Text = "The CDU is powered off.";
            }
                                }

        //Key command executed events.
        #region "Keyboard commands"

        private void FocusCDUDisplay(object sender, ExecutedRoutedEventArgs e)
        {
            cduDisplay.Focus();
        }

        private void FocusScratchpadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ScratchpadTextBox.Focus();
        }

        private void FocusLineSelectMode(object sender, ExecutedRoutedEventArgs e)
        {
            lineSelectModeTextBox.Focus();
        }

        private void ActivateInitRefPage(object sender, ExecutedRoutedEventArgs e)
        {
            initRefButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateRtePage(object sender, ExecutedRoutedEventArgs e)
        {
            rteButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

private void ActivateClbPage(object sender, ExecutedRoutedEventArgs e)
        {
            clbButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

private void ActivateCrzPage(object sender, ExecutedRoutedEventArgs e)
        {
            crzButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateLegsPage(object sender, ExecutedRoutedEventArgs e)
        {
            legsButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateDepArPage(object sender, ExecutedRoutedEventArgs e)
        {
            depArButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateHoldPage(object sender, ExecutedRoutedEventArgs e)
        {
            holdButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateProgPage(object sender, ExecutedRoutedEventArgs e)
        {
            progButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateN1Page(object sender, ExecutedRoutedEventArgs e)
        {
            n1LimitButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateFixPage(object sender, ExecutedRoutedEventArgs e)
        {
            fixButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

private void ActivatePreviousPage(object sender, ExecutedRoutedEventArgs e)
        {
            prevButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateNextPage(object sender, ExecutedRoutedEventArgs e)
        {
            nextButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateMenuPage(object sender, ExecutedRoutedEventArgs e)
        {
            menuButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ExecuteCDUAction(object sender, ExecutedRoutedEventArgs e)
        {
            execButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ClearScratchpad(object sender, ExecutedRoutedEventArgs e)
        {
            clearButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void RefreshCDUAction(object sender, ExecutedRoutedEventArgs e)
        {
            refreshButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void DeleteAction(object sender, ExecutedRoutedEventArgs e)
        {
            deleteButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ChangeLineSelectKeys(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion
        
        // Button click events.
        #region "button click events"
        private void initRefButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_INIT_REF, Aircraft.ClkL);
            RefreshCDU();
        }

                                        private void rteButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_RTE, Aircraft.ClkL);
            RefreshCDU();

        }

        private void clbButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CLB, Aircraft.ClkL);
            RefreshCDU();
        }

        private void crzButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CRZ, Aircraft.ClkL);
            RefreshCDU();
        }

        private void legsButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_LEGS, Aircraft.ClkL);
            RefreshCDU();
        }

        private void depArButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_DEP_ARR, Aircraft.ClkL);
            RefreshCDU();
        }

        private void holdButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_HOLD, Aircraft.ClkL);
            RefreshCDU();
        }

        private void progButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_PROG, Aircraft.ClkL);
            RefreshCDU();
        }

        private void n1LimitButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_N1_LIMIT, Aircraft.ClkL);
            RefreshCDU();
        }

        private void fixButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_FIX, Aircraft.ClkL);
            RefreshCDU();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_PREV_PAGE, Aircraft.ClkL);
            RefreshCDU();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_NEXT_PAGE, Aircraft.ClkL);
            RefreshCDU();
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_MENU, Aircraft.ClkL);
            RefreshCDU();
        }

        private void execButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_EXEC, Aircraft.ClkL);
            RefreshCDU();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CLR, Aircraft.ClkL);
            RefreshCDU();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshCDU();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_DEL, Aircraft.ClkL);
            RefreshCDU();
        }
        #endregion
    }
}
