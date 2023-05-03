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

        private CancellationTokenSource cduTimerCancellationTokenSource;
        private System.Timers.Timer cduTimer = new System.Timers.Timer();
        private string oldLineSelectMode;
        private string oldCDUScreen;

        public CduDialog()
        {
            InitializeComponent();
            RefreshCDU();
            // Update the line select indicator.
           lineSelectModeTextBox.Text = Properties.Settings.Default.PMDGCDUKeyLayout == "1" ? "D" : "A";

            cduDisplay.Focus();
            StartAutoRefreshCDUAsync();
                                                                                }

        // Task methods.
        #region "tasks"
        private async Task AutoRefreshCDUAsync()
        {
            cduTimerCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cduTimerCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(30000), cancellationToken);

                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        // Check to see if the CDU display changes, if so, show the new display.
                        if (cduDisplay.Text != oldCDUScreen)
                        {
                            RefreshCDU();
                        }

                        // Update the line select mode. a= alternate; d = default.
                        if (oldLineSelectMode != lineSelectModeTextBox.Text)
                        {
                            lineSelectModeTextBox.Text = Properties.Settings.Default.PMDGCDUKeyLayout == "1" ? "D" : "A";
                        }

                        oldLineSelectMode = lineSelectModeTextBox.Text;
                        oldCDUScreen = cduDisplay.Text;
                    }));
                }
                catch (TaskCanceledException)
                {
                    // Task was cancelled, handle the cancellation if necessary.
                    break;
                }
            }
        }

        public async void StartAutoRefreshCDUAsync()
        {
            await AutoRefreshCDUAsync();
        }

                public void StopAutoRefreshCDUAsync()
        {
            cduTimerCancellationTokenSource.Cancel();
        }

        #endregion

        private void RefreshCDU()
        {
            int currentCaretPosition = cduDisplay.CaretIndex;
            cduDisplay.Clear();

            Thread.Sleep(500);
            string displayText = PMDG737Aircraft.RefreshCDU(0);

            // Set the title of the window if the CDU is powered.
            if (PMDG737Aircraft.cdu0.Powered)
            {
                this.Title = PMDG737Aircraft.cdu0.Rows[0].ToString().Trim();
                cduDisplay.Text = displayText;
                cduDisplay.CaretIndex = Math.Min(currentCaretPosition, displayText.Length);
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
        
        // Control events.
        #region "Control events"
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            StopAutoRefreshCDUAsync();
        }

        #endregion

    }
}
