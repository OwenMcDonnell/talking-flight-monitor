using DavyKager;
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
                private string oldLineSelectMode;
        private string oldCDUScreen;
        private string oldScreenTitle;

        public CduDialog()
        {
            InitializeComponent();
            RefreshCDU();

            // Load the line select keys...
            if(tfm.Properties.Settings.Default.PMDGCDUKeyLayout == "1")
            {
                RemoveAlternateLskSet();
                LoadDefaultLskSet();
            }
            else
            {
                RemoveDefaultLskSet();
                LoadAlternateLskSet();
            }
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
                    await Task.Delay(TimeSpan.FromMilliseconds(10000), cancellationToken);

                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        // Check to see if the CDU display changes, if so, show the new display.
                                                                            RefreshCDU();
                        
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
            oldScreenTitle = this.Title;
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

        private void AnnounceScreenTitle()
        {
            if(oldScreenTitle != this.Title)
            {
                Tolk.Speak(this.Title);
            }
        }

        //Key command executed events.
        #region "Keyboard commands"

        private void FocusCDUDisplay(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(cduDisplay);
        }

        private void FocusScratchpadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(ScratchpadTextBox);
        }

        private void FocusLineSelectMode(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(lineSelectModeTextBox);
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

                private void ActivateDesPage(object sender, ExecutedRoutedEventArgs e)
        {
            desButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
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
            if(tfm.Properties.Settings.Default.PMDGCDUKeyLayout == "1")
            {
                tfm.Properties.Settings.Default.PMDGCDUKeyLayout = "2";
                tfm.Properties.Settings.Default.Save();
                RemoveDefaultLskSet();
                LoadAlternateLskSet();
                lineSelectModeTextBox.Text = "A";
                Tolk.Output("Alternate  line select keys active.");
            }
            else
            {
                tfm.Properties.Settings.Default.PMDGCDUKeyLayout = "1";
                tfm.Properties.Settings.Default.Save();
                RemoveAlternateLskSet();
                LoadDefaultLskSet();
                lineSelectModeTextBox.Text = "D";
                Tolk.Output("Default line select keys active.");
            }
        }

        private void ActivateLsk1Left(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L1, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk2Left(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L2, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk3Left(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L3, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk4Left(object sender, ExecutedRoutedEventArgs executed)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L4, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk5Left(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L5, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk6Left(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L6, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk1Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R1, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void ActivateLsk2Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R2, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk3Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R3, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk4Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R4, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk5Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R5, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        
        private void ActivateLsk6Right(object sender, ExecutedRoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R6, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }
        #endregion

        // Control events.
        #region "Control events"
        private void initRefButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_INIT_REF, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

                                        private void rteButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_RTE, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void clbButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CLB, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void crzButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CRZ, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void desButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_DES, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

                private void legsButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_LEGS, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void depArButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_DEP_ARR, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void holdButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_HOLD, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void progButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_PROG, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void n1LimitButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_N1_LIMIT, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void fixButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_FIX, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_PREV_PAGE, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_NEXT_PAGE, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_MENU, Aircraft.ClkL);
            RefreshCDU();
            AnnounceScreenTitle();
        }

        private void execButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_EXEC, Aircraft.ClkL);
            RefreshCDU();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_CLR, Aircraft.ClkL);
            ScratchpadTextBox.Clear();
            Tolk.Output("Scratchpad cleared.");
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

        private async void ScratchpadTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var requestedCDU = 1;
                ScratchpadTextBox.Clear();
                await              PMDG737Aircraft.EnterCDUTextAsync(requestedCDU, ScratchpadTextBox.Text);
                if(requestedCDU == 1)
                {
                    var inst = new IOSubsystem(false);
                    inst.Output(isGauge: false, output: "CDU ready.", useSAPI: true);
                }
                            }
        }

                private void Window_Closing(object sender, CancelEventArgs e)
        {
            StopAutoRefreshCDUAsync();
        }

        #endregion

        // Methods to change line select key sets.
        #region "Change line select methods"
        private void LoadDefaultLskSet()
        {
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk1Left, ActivateLsk1Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk2Left, ActivateLsk2Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk3Left, ActivateLsk3Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk4Left, ActivateLsk4Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk5Left, ActivateLsk5Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk6Left, ActivateLsk6Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk1Right, ActivateLsk1Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk2Right, ActivateLsk2Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk3Right, ActivateLsk3Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk4Right, ActivateLsk4Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk5Right, ActivateLsk5Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.lsk6Right, ActivateLsk6Right));
        }
        
        private void LoadAlternateLskSet()
        {
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk1Left, ActivateLsk1Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk2Left, ActivateLsk2Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk3Left, ActivateLsk3Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk4Left, ActivateLsk4Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk5Left, ActivateLsk5Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk6Left, ActivateLsk6Left));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk1Right, ActivateLsk1Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk2Right, ActivateLsk2Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk3Right, ActivateLsk3Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk4Right, ActivateLsk4Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk5Right, ActivateLsk5Right));
            CommandBindings.Add(new CommandBinding(CDUKeyCommands.altLsk6Right, ActivateLsk6Right));
        }

        private void RemoveDefaultLskSet()
        {
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk1Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk2Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk3Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk4Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk5Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk6Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk1Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk2Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk3Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk4Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk5Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.lsk6Right);
        }

        private void RemoveAlternateLskSet()
        {
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk1Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk2Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk3Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk4Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk5Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk6Left);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk1Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk2Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk3Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk4Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk5Right);
            RemoveCommandBinding(CommandBindings, CDUKeyCommands.altLsk6Right);
        }

        private void RemoveCommandBinding(CommandBindingCollection commandBindings, ICommand command)
        {
            var commandBinding = commandBindings.OfType<CommandBinding>().FirstOrDefault(cb => cb.Command == command);
            if (commandBinding != null)
            {
                commandBindings.Remove(commandBinding);
            }
        }

        #endregion

        private void ScratchpadTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ScratchpadTextBox.SelectAll();
        }

        private void ActivateKeyCommandHelp(object sender, ExecutedRoutedEventArgs e)
        {
            WindowBindingsHelp w = new WindowBindingsHelp(CommandBindings);
            w.Show();
        }
    }
}
