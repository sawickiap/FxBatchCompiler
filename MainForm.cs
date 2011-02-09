using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace FXBC
{
    // Represents main application form
    // Also implements most of application functionality, including compilation.
    public partial class MainForm : Form
    {
        // State of the application
        enum State
        {
            // Editing script
            ScriptTab,
            // Editing task list
            BuildTab,
            // Compilation in progress
            Compilation
        }

        // Arguments passed to application's command line
        private string[] m_CmdLineArgs;
        // Font used in textareas
        private Font m_Font;
        // Current document
        private Document m_Document;
        // Data for compilation
        // Valid only when m_State == State.Compilation.
        CompilationData m_CompilationData;
        // Number of tasks skipped because of being up-to-date
        // Saved when build command is called and Compilation state starts.
        // Used when compilation is finished.
        int m_UpToDateTaskCount;

        // The state of entire GUI
        State m_State;
        // Whether to show row and col during script editing
        bool m_UseRowColTimer;
        // Maximum number of working threads during compilation
        // Loaded from configuration.
        int m_NumCompilationThreads;

        public MainForm(string[] CmdLineArgs)
        {
            InitializeComponent();

            Panel1.Dock = DockStyle.Fill;
            Panel2.Dock = DockStyle.Fill;

            m_CmdLineArgs = CmdLineArgs;
            m_Font = ScriptTextbox.Font;

            Globals.prepare_application_data_dir();
            LoadConfig();

            // New, empty document
            m_Document = new Document(ScriptTextbox, ListView1);
            ApplyDocumentNameToGui();

            m_CompilationData = null;
            m_State = State.ScriptTab;
            SetState(State.ScriptTab);
        }

        // Load configuration from Configuration module into application
        private void LoadConfig()
        {
            Configuration.Load();

            // Load font
            LoadFont();
            if (m_Font != null)
                ApplyFontToGui(m_Font);

            // Load row-col timer parameters
            m_UseRowColTimer = true;
            string RowColTimerIntervalS = Configuration.GetString("row_col_timer_interval");
            if (RowColTimerIntervalS != "")
            {
                int RowColTimerInterval;
                if (int.TryParse(RowColTimerIntervalS, out RowColTimerInterval))
                {
                    if (RowColTimerInterval > 0)
                    {
                        TextboxRowColTimer.Interval = RowColTimerInterval;
                        m_UseRowColTimer = true;
                    }
                    else
                        m_UseRowColTimer = false;
                }
            }

            // Load compilation threads number
            m_NumCompilationThreads = 3;
            if (Configuration.KeyExists("num_compilation_threads"))
            {
                int i;
                if (int.TryParse(Configuration.GetString("num_compilation_threads"), out i))
                    m_NumCompilationThreads = i;
            }
        }

        // Applies document name from m_Document to the GUI
        // Document can have no name.
        private void ApplyDocumentNameToGui()
        {
            if (m_Document.HasFileName())
                this.Text = m_Document.GetDocumentName() + " - " + Globals.APP_TITLE;
            else
                this.Text = Globals.APP_TITLE;
        }

        // Change application GUI state
        private void SetState(State NewState)
        {
            if (NewState == State.BuildTab || NewState == State.Compilation)
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }

            BuildMenuItem.Visible = (NewState != State.ScriptTab);

            Button1.Enabled = (NewState != State.Compilation);
            Button2.Enabled = (NewState != State.Compilation);

            BuildSelectedButton.Enabled = (NewState == State.BuildTab);
            RebuildSelectedButton.Enabled = (NewState == State.BuildTab);
            BuildCheckedButton.Enabled = (NewState == State.BuildTab);
            RebuildCheckedButton.Enabled = (NewState == State.BuildTab);
            BuildAllButton.Enabled = (NewState == State.BuildTab);
            RebuildAllButton.Enabled = (NewState == State.BuildTab);
            AbortButton.Enabled = (NewState == State.Compilation);

            BuildSelectedMenuItem.Enabled = (NewState == State.BuildTab);
            RebuildSelectedMenuItem.Enabled = (NewState == State.BuildTab);
            BuildCheckedMenuItem.Enabled = (NewState == State.BuildTab);
            RebuildCheckedMenuItem.Enabled = (NewState == State.BuildTab);
            BuildAllMenuItem.Enabled = (NewState == State.BuildTab);
            RebuildAllMenuItem.Enabled = (NewState == State.BuildTab);
            AbortMenuItem.Enabled = (NewState == State.Compilation);

            NewMenuItem.Enabled = (NewState != State.Compilation);
            OpenMenuItem.Enabled = (NewState != State.Compilation);
            SaveMenuItem.Enabled = (NewState != State.Compilation);
            SaveAsMenuItem.Enabled = (NewState != State.Compilation);

            if (m_UseRowColTimer && (NewState == State.ScriptTab))
                TextboxRowColTimer.Enabled = true;
            else
            {
                TextboxRowColTimer.Enabled = false;
                MainStatusStrip.Items[0].Text = "";
            }

            CompilationTimer.Enabled = (NewState == State.Compilation);

            if (NewState == State.BuildTab && m_State == State.ScriptTab)
                OutputTextBox.Clear();

            MainStatusStrip.Items[1].Text = "";
            MainStatusStrip.Items[2].Visible = false;

            m_State = NewState;
        }

        // Load font from configuration to m_Font
        // If font is not stored in configuration, leave the m_Font field unchanged.
        private void LoadFont()
        {
            string FontData = Configuration.GetString("Font");
            try
            {
                if (FontData.Length > 0)
                {
                    string[] Data = FontData.Split(new char[] { '|' });
                    m_Font = new Font(
                        Data[0], // FamilyName
                        float.Parse(Data[1]), // EmSize
                        (FontStyle)uint.Parse(Data[2]), // Style
                        (GraphicsUnit)uint.Parse(Data[3]), // Unit
                        byte.Parse(Data[4]), // GdiCharSet,
                        bool.Parse(Data[5])); // GdiVerticalFont
                }
            }
            catch (Exception)
            {
            }
        }

        // Save font from m_Font to configuration (without Configuration.Save)
        private void SaveFont()
        {
            if (m_Font == null)
                Configuration.SetString("font", "");
            else
            {
                Configuration.SetString("font", string.Format(
                    "{0}|{1}|{2}|{3}|{4}|{5}", new object[] {
                        m_Font.FontFamily.Name,
                        m_Font.SizeInPoints,
                        (uint)m_Font.Style,
                        (uint)m_Font.Unit,
                        m_Font.GdiCharSet,
                        m_Font.GdiVerticalFont
                    }));
            }
        }

        // Script Tab
        private void Button1_Click(object sender, EventArgs e)
        {
            if (m_State == State.BuildTab)
                SetState(State.ScriptTab);
        }

        // Build Tab
        private void Button2_Click(object sender, EventArgs e)
        {
            if (m_State == State.ScriptTab)
            {
                try
                {
                    // Process script, generate task list
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        m_Document.GenerateTasks();
                        SetState(State.BuildTab);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception Err)
                {
                    Globals.ShowError(this, Err);
                }
            }
        }

        // Help > About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm(Icon);
            f.ShowDialog(this);
        }

        // Settings > Locate Fxc
        private void LocateFxcMenuItem_Click(object sender, EventArgs e)
        {
            string FxcPath = Configuration.GetString("fxc_location");
            if (LocateFxcForm.Go(this, ref FxcPath))
            {
                Configuration.SetString("fxc_location", FxcPath);
                Configuration.Save();
            }
        }

        // Called once just after application startup
        private void StartupTimer_Tick(object sender, EventArgs e)
        {
            StartupTimer.Enabled = false;

            // First run
            if (Configuration.GetString("first_run") == "1")
            {
                // Locate fxc compiler
                string FxcFile = LocateFxcForm.TryLocateFxc();
                if (FxcFile != null && FxcFile.Length > 0)
                    Configuration.SetString("fxc_location", FxcFile);

                Configuration.SetString("first_run", "0");
                Configuration.Save();

                // Load sample script
                string sample_path = Path.Combine(Globals.calc_application_data_dir(), "Sample.fxbc");
                OpenDocument(sample_path);
            }

            // Command line argument
            if (m_CmdLineArgs.Length == 1)
            {
                // Load given document
                OpenDocument(m_CmdLineArgs[0]);
            }
        }

        // Ensure the fxc.exe file is located and it really exists.
        // Show dialog box if needed.
        // If succeeded, return false and return the file name with path via the parameter.
        // If failed, return false.
        private bool EnsureFxcPath(out string FxcPath)
        {
            FxcPath = Configuration.GetString("fxc_location");

            if (FxcPath == null || FxcPath.Length == 0 || !File.Exists(FxcPath))
            {
                if (LocateFxcForm.Go(this, ref FxcPath))
                {
                    Configuration.SetString("fxc_location", FxcPath);
                    Configuration.Save();
                }
                return !(FxcPath == null || FxcPath.Length == 0 || !File.Exists(FxcPath));
            }
            else
                return true;
        }

        // Help > Fxc Parameters
        private void FxcParametersMenuItem_Click(object sender, EventArgs e)
        {
            string FxcPath;
            if (EnsureFxcPath(out FxcPath))
            {
                string Output;
                Cursor.Current = Cursors.WaitCursor;
                Fxc.Run(out Output, FxcPath, null, null);
                Cursor.Current = Cursors.Default;

                ShowTextForm.Go(this, "Fxc Parameters", Output, m_Font);
            }
        }

        // Settings > Font
        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            if (m_Font != null)
                FontDialog1.Font = m_Font;

            if (FontDialog1.ShowDialog(this) == DialogResult.OK)
                ApplyFontChange(FontDialog1.Font);
        }

        // Apply button in font dialog
        private void FontDialog1_Apply(object sender, EventArgs e)
        {
            ApplyFontChange(FontDialog1.Font);
        }

        // Apply given font to GUI controls
        private void ApplyFontToGui(Font F)
        {
            ScriptTextbox.Font = F;
            OutputTextBox.Font = F;
            //ListView1.Font = F;
        }

        // The font was changed using font dialog
        private void ApplyFontChange(Font F)
        {
            // Store in field
            m_Font = F;

            // Apply in GUI
            ApplyFontToGui(F);

            // Serialize to configuration
            SaveFont();
            Configuration.Save();
        }

        // File > Exit
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save current document.
        // Ask for file name using Save As dialog if needed.
        // Return true if can continue.
        bool SaveDocument()
        {
            if (m_Document == null) return true;

            if (!m_Document.HasFileName())
            {
                if (SaveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    m_Document.SetFileName(SaveFileDialog1.FileName);
                    ApplyDocumentNameToGui();
                }
                else
                    return false;
            }

            try
            {
                m_Document.SaveToFile();
            }
            catch (Exception Err)
            {
                Globals.ShowError(this, Err);
                return false;
            }

            return true;
        }

        // If document was not saved, ask for saving.
        // Return true if can continue.
        bool AskForDocumentSave()
        {
            if (m_Document == null)
                return true;
            if (!m_Document.GetModified())
                return true;

            DialogResult Result;
            if (m_Document.HasFileName())
                Result = MessageBox.Show(
                    this,
                    "Do you want to save the changes to \"" + m_Document.GetDocumentName() + "\" ?",
                    Globals.APP_TITLE,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);
            else
                Result = MessageBox.Show(
                    this,
                    "Do you want to save the changes to the current document ?",
                    Globals.APP_TITLE,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);

            if (Result == DialogResult.Cancel)
                return false;
            else if (Result == DialogResult.No)
                return true;
            else
                return SaveDocument();
        }

        // File > New
        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            if (AskForDocumentSave())
            {
                m_Document = new Document(ScriptTextbox, ListView1);
                ApplyDocumentNameToGui();
                SetState(State.ScriptTab);
            }
        }

        // File > Open
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (AskForDocumentSave())
            {
                if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
                    OpenDocument(OpenFileDialog1.FileName);
            }
        }

        // Open document with given file name
        // On error, show error message and create new, empty document.
        private void OpenDocument(string FileName)
        {
            try
            {
                m_Document = new Document(ScriptTextbox, ListView1, FileName);
                ApplyDocumentNameToGui();
                SetState(State.ScriptTab);
            }
            catch (Exception Err)
            {
                m_Document = new Document(ScriptTextbox, ListView1); // Clear document
                ApplyDocumentNameToGui();
                SetState(State.ScriptTab);
                Globals.ShowError(this, Err);
            }
        }

        // File > Save
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        // File > Save As
        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                m_Document.SetFileName(SaveFileDialog1.FileName);
                ApplyDocumentNameToGui();

                try
                {
                    m_Document.SaveToFile();
                }
                catch (Exception Err)
                {
                    Globals.ShowError(this, Err);
                }
            }
        }

        // Ask for save on exit
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AskForDocumentSave();
        }

        // Script editing operation
        private void ScriptTextbox_TextChanged(object sender, EventArgs e)
        {
            m_Document.OnScriptTextChanged();
        }

        // Resize status bar components
        private void MainStatusStrip_Layout(object sender, LayoutEventArgs e)
        {
            int W = MainStatusStrip.ClientSize.Width - MainStatusStrip.Items[1].Width;
            MainStatusStrip.Items[0].Width = W / 2;
            MainStatusStrip.Items[2].Width = W / 2 - 32;
        }

        private void UpdateScriptTextBoxCursorPos()
        {
            if (ScriptTextbox.SelectionLength > 0)
                MainStatusStrip.Items[0].Text = "";
            else
            {
                int ColIndex;
                int RowIndex;
                int RowStartIndex;

                RowIndex = Globals.SendMessage(ScriptTextbox.Handle, Globals.EM_LINEFROMCHAR, -1, 0) + 1;
                RowStartIndex = Globals.SendMessage(ScriptTextbox.Handle, Globals.EM_LINEINDEX, -1, 0);
                ColIndex = ScriptTextbox.SelectionStart - RowStartIndex + 1;

                MainStatusStrip.Items[0].Text = string.Format("Row {0}      Col {1}", RowIndex, ColIndex);
            }
        }

        // Update row and col number on status bar periodically
        // There is no better way to do that as there is no event such as CaretPostChange in textbox component!
        private void TextboxRowColTimer_Tick(object sender, EventArgs e)
        {
            UpdateScriptTextBoxCursorPos();
        }

        // Task list context menu is opening - enable or disable its commands
        private void TaskMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool OneTaskSelected = (ListView1.SelectedItems.Count == 1);
            bool SelectedAnyTasks = (ListView1.SelectedItems.Count > 0);

            Task t = null;
            if (OneTaskSelected)
                t = (Task)ListView1.SelectedItems[0].Tag;

            TaskBuildMenuItem.Enabled = SelectedAnyTasks;
            TaskRebuildMenuItem.Enabled = SelectedAnyTasks;
            TaskEditMenuItem.Enabled = OneTaskSelected;
            TaskOpenSrcFileMenuItem.Enabled = OneTaskSelected && t.SrcFile != "";
            TaskOpenDestFileMenuItem.Enabled = OneTaskSelected && t.DestFile != "";
            TaskViewSrcFileMenuItem.Enabled = OneTaskSelected && t.SrcFile != "";
            TaskViewDestFileMenuItem.Enabled = OneTaskSelected && t.DestFile != "" && t.IsDestFileText;
        }

        // Task list context menu > Edit
        private void TaskEditMenuItem_Click(object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0) return;

            Task t = (Task)ListView1.SelectedItems[0].Tag;

            SetState(State.ScriptTab);
            SetScriptCaretPos(t.Row);
            ScriptTextbox.Focus();
        }

        // Set caret pos in script textbox to the beginning of given row
        private void SetScriptCaretPos(int Row)
        {
            int Pos = 0;
            while (Pos < ScriptTextbox.Text.Length && Row > 1)
            {
                if (ScriptTextbox.Text[Pos] == '\n')
                    Row--;
                Pos++;
            }

            ScriptTextbox.SelectionStart = Pos;
            ScriptTextbox.SelectionLength = 0;
        }

        // Task list context menu > Open Source File
        private void TaskOpenSrcFileMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_Document.HasFileName()) return;
            if (ListView1.SelectedItems.Count != 1) return;
            Task t = (Task)ListView1.SelectedItems[0].Tag;
            if (t.SrcFile == "") return;

            if (!File.Exists(Path.Combine(m_Document.GetFileDirectory(), t.SrcFile)))
            {
                Globals.ShowError(this, "Source file doesn't exist.\r\n" + t.SrcFile);
                return;
            }

            try
            {
                System.Diagnostics.Process P = new System.Diagnostics.Process();
                P.StartInfo.WorkingDirectory = m_Document.GetFileDirectory();
                P.StartInfo.UseShellExecute = true;
                P.StartInfo.FileName = t.SrcFile;
                P.Start();
            }
            catch (Exception Err)
            {
                Globals.ShowError(this, Err);
            }
        }

        // Task list context menu > Open Destination File
        private void TaskOpenDestFileMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_Document.HasFileName()) return;
            if (ListView1.SelectedItems.Count != 1) return;
            Task t = (Task)ListView1.SelectedItems[0].Tag;
            if (t.DestFile == "") return;

            if (!File.Exists(Path.Combine(m_Document.GetFileDirectory(), t.DestFile)))
            {
                Globals.ShowError(this, "Destination file doesn't exist.\r\n" + t.DestFile);
                return;
            }

            try
            {
                System.Diagnostics.Process P = new System.Diagnostics.Process();
                P.StartInfo.WorkingDirectory = m_Document.GetFileDirectory();
                P.StartInfo.UseShellExecute = true;
                P.StartInfo.FileName = t.DestFile;
                P.Start();
            }
            catch (Exception Err)
            {
                Globals.ShowError(this, Err);
            }
        }

        // Task list context menu > View Source File
        private void TaskViewSrcFileMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_Document.HasFileName()) return;
            if (ListView1.SelectedItems.Count != 1) return;
            Task t = (Task)ListView1.SelectedItems[0].Tag;
            if (t.SrcFile == "") return;

            string SrcFullPath = Path.Combine(m_Document.GetFileDirectory(), t.SrcFile);
            if (!File.Exists(SrcFullPath))
            {
                Globals.ShowError(this, "Source file doesn't exist.\r\n" + t.SrcFile);
                return;
            }

            try
            {
                using (StreamReader f = new StreamReader(SrcFullPath, Encoding.ASCII))
                {
                    string Contents = f.ReadToEnd();
                    ShowTextForm.Go(this, "Source file: " + t.SrcFile, Contents, m_Font);
                }
            }
            catch (Exception Err)
            {
                Globals.ShowError(this, Err);
            }
        }

        // Task list context menu > View Destination File
        private void TaskViewDestFileMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_Document.HasFileName()) return;
            if (ListView1.SelectedItems.Count != 1) return;
            Task t = (Task)ListView1.SelectedItems[0].Tag;
            if (t.SrcFile == "") return;
            if (t.IsDestFileText == false) return;

            string DestFullPath = Path.Combine(m_Document.GetFileDirectory(), t.DestFile);
            if (!File.Exists(DestFullPath))
            {
                Globals.ShowError(this, "Destination file doesn't exist.\r\n" + t.DestFile);
                return;
            }

            try
            {
                using (StreamReader f = new StreamReader(DestFullPath, Encoding.ASCII))
                {
                    string Contents = f.ReadToEnd();
                    ShowTextForm.Go(this, "Destination file: " + t.SrcFile, Contents, m_Font);
                }
            }
            catch (Exception Err)
            {
                Globals.ShowError(this, Err);
            }
        }

        private void BuildSelectedButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Selected, false);
        }

        private void RebuildSelectedButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Selected, true);
        }

        private void BuildCheckedButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Checked, false);
        }

        private void RebuildCheckedButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Checked, true);
        }

        private void BuildAllButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.All, false);
        }

        private void RebuildAllButton_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.All, true);
        }

        // Ensures document to have file name assigned by asking for save if it hasn't one
        private bool EnsureDocumentHasFileName()
        {
            if (m_Document.HasFileName())
                return true;
            else
                return SaveDocument();
        }

        // Return true if given task should be built (is not up-to-date)
        private bool TaskShouldBeBuilt(Task t)
        {
            try
            {
                if (!m_Document.HasFileName()) return true;

                string DocumentDir = m_Document.GetFileDirectory();

                string SrcPath = Path.Combine(DocumentDir, t.SrcFile);
                string DestPath = Path.Combine(DocumentDir, t.DestFile);

                if (!File.Exists(SrcPath)) return true;
                if (!File.Exists(DestPath)) return true;

                if (File.GetLastWriteTime(SrcPath) != t.SrcFileTime) return true;
                if (File.GetLastWriteTime(DestPath) != t.DestFileTime) return true;

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        // Build command type
        private enum WhatToBuild
        {
            Selected,
            Checked,
            All
        }

        // Begin build process
        private void Build(WhatToBuild What, bool Rebuild)
        {
            if (m_State != State.BuildTab) return;
            string FxcPath;
            if (!EnsureFxcPath(out FxcPath)) return;
            if (!EnsureDocumentHasFileName()) return;

            m_CompilationData = new CompilationData(FxcPath, m_Document.GetFileDirectory());
            m_UpToDateTaskCount = 0;

            ListView1.BeginUpdate();
            foreach (ListViewItem Item in ListView1.Items)
            {
                if (What == WhatToBuild.All ||
                    (What == WhatToBuild.Selected && Item.Selected) ||
                    (What == WhatToBuild.Checked && Item.Checked))
                {
                    Task t = (Task)Item.Tag;
                    if (Rebuild || TaskShouldBeBuilt(t))
                    {
                        Item.SubItems[2].Text = "Compiling...";
                        m_CompilationData.AddItem(new CompilationDataItem(t.Parameters, Item.Index));
                    }
                    else if (!Rebuild)
                    {
                        Item.SubItems[2].Text = "Up-To-Date";
                        m_UpToDateTaskCount++;
                    }
                }
                else
                    Item.SubItems[2].Text = "";
            }
            ListView1.EndUpdate();

            if (m_CompilationData.GetItemCount() > 0)
            {
                int NumThreads = Math.Min(m_NumCompilationThreads, m_CompilationData.GetItemCount());
                m_CompilationData.SetThreadCount(NumThreads);

                for (int i = 0; i < NumThreads; i++)
                {
                    Thread th = new Thread(new ParameterizedThreadStart(CompilationThreadProc));
                    th.Start(m_CompilationData);
                }

                SetState(State.Compilation);
                MainStatusStrip.Items[0].Text = "Compilation in progres...";

                MainStatusStrip.Items[1].Text = string.Format("0/{0}", m_CompilationData.GetItemCount());
                ((ToolStripProgressBar)MainStatusStrip.Items[2]).Maximum = m_CompilationData.GetItemCount();
                ((ToolStripProgressBar)MainStatusStrip.Items[2]).Value = 0;
                MainStatusStrip.Items[2].Visible = true;

                // Yield to start threads
                Thread.Sleep(0);
            }
            else
                MainStatusStrip.Items[0].Text = "Nothing to build.";
        }

        // Task list selection change
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 1)
                OutputTextBox.Text = ((Task)ListView1.SelectedItems[0].Tag).Output;
            else
                OutputTextBox.Clear();
        }

        // Timer tick during compilation process
        private void CompilationTimer_Tick(object sender, EventArgs e)
        {
            if (m_CompilationData == null) return; // !!!

            // Show progress
            int ItemCount = m_CompilationData.GetItemCount();
            int DoneCount = m_CompilationData.GetProgress();

            MainStatusStrip.Items[1].Text = string.Format("{0}/{1}", DoneCount, ItemCount);
            ((ToolStripProgressBar)MainStatusStrip.Items[2]).Value = DoneCount;

            bool UpdateBegun = false;
            
            // New finished tasks
            int[] FinishedIndices = m_CompilationData.LoadFinishedIndices();
            if (FinishedIndices.Length > 0)
            {
                UpdateBegun = true;
                ListView1.BeginUpdate();
            }
            foreach (int FinishedIndex in FinishedIndices)
            {
                string Output, s1, s2; bool Succeeded; int NumErrors, NumWarnings, ListViewItemIndex;
                m_CompilationData.GetTaskOutput(FinishedIndex, out ListViewItemIndex, out Output, out Succeeded, out NumErrors, out NumWarnings);

                if (Succeeded)
                    s1 = "Succeeded";
                else
                    s1 = "Failed";

                if (NumErrors > 0 && NumWarnings > 0)
                    s2 = string.Format(" ({0} errors, {1} warnings)", NumErrors, NumWarnings);
                else if (NumErrors > 0)
                    s2 = string.Format(" ({0} errors)", NumErrors);
                else if (NumWarnings > 0)
                    s2 = string.Format(" ({0} warnings)", NumWarnings);
                else
                    s2 = "";

                ListView1.Items[ListViewItemIndex].SubItems[2].Text = s1;
                ListView1.Items[ListViewItemIndex].SubItems[3].Text = s1 + s2;
                Task t = (Task)(ListView1.Items[ListViewItemIndex].Tag);
                t.Output = Output;

                // Update output textbox if this item is selected
                if (ListView1.Items[ListViewItemIndex].Selected && ListView1.SelectedItems.Count == 1)
                    OutputTextBox.Text = Output;
            }

            // Work done
            if (m_CompilationData.IsAllDone())
            {
                SetState(State.BuildTab);

                int[] UnfinishedTaskIndices = m_CompilationData.GetUnfinishedIndices();
                if (UnfinishedTaskIndices.Length > 0 && !UpdateBegun)
                {
                    UpdateBegun = true;
                    ListView1.BeginUpdate();
                }
                foreach (int UnfinishedIndex in UnfinishedTaskIndices)
                    ListView1.Items[m_CompilationData.GetTaskListViewIndex(UnfinishedIndex)].SubItems[2].Text = "Aborted";

                if (m_CompilationData.IsAborting())
                    MainStatusStrip.Items[0].Text = "Compilation aborted.";
                else
                {
                    int Succeeded, Failed;
                    m_CompilationData.GetStats(out Succeeded, out Failed);
                    MainStatusStrip.Items[0].Text = string.Format("Build: {0} succeeded, {1} failed, {2} up-to-date", Succeeded, Failed, m_UpToDateTaskCount);
                }

                if (!m_CompilationData.IsAborting())
                    UpdateTaskFileTime();

                m_CompilationData = null;
            }

            if (UpdateBegun)
                ListView1.EndUpdate();
        }

        // Update task data according to new last write time information from source and destination files
        // Call this method after compilation process is finished.
        private void UpdateTaskFileTime()
        {
            if (!m_Document.HasFileName()) return;

            string DocumentDir = m_Document.GetFileDirectory();

            foreach (ListViewItem Item in ListView1.Items)
            {
                try
                {
                    Task t = (Task)Item.Tag;

                    string SrcPath = Path.Combine(DocumentDir, t.SrcFile);
                    string DestPath = Path.Combine(DocumentDir, t.DestFile);

                    if (File.Exists(SrcPath))
                        t.SrcFileTime = File.GetLastWriteTime(SrcPath);
                    else
                        t.SrcFileTime = DateTime.MinValue;

                    if (File.Exists(DestPath))
                        t.DestFileTime = File.GetLastWriteTime(DestPath);
                    else
                        t.DestFileTime = DateTime.MinValue;
                }
                catch (Exception)
                {
                }
            }
        }

        // Thread procedure of working thread for compilation.
        // There is working threads pool and each one takes net tasks on loop and executes them.
        private void CompilationThreadProc(Object Obj)
        {
            System.Diagnostics.Debug.WriteLine("Thread started.");

            CompilationData Data = (CompilationData)Obj;

            string FxcPath, DocumentDirectory;
            Data.GetMainData(out FxcPath, out DocumentDirectory);

            while (!Data.IsAborting())
            {
                string Parameters;
                int TaskIndex = Data.StartNextTask(out Parameters);
                System.Diagnostics.Debug.WriteLine(string.Format("Thread obtained task index {0}", TaskIndex));
                if (TaskIndex == -1) break;

                // Go!
                string Output;
                //Thread.Sleep(new Random().Next(100));
                if (Fxc.Run(out Output, FxcPath, Parameters, DocumentDirectory))
                {
                    // Analyze output
                    Regex ErrorsReg = new Regex(@"\(\d+\)\:\serror\s");
                    Regex WarningsReg = new Regex(@"\(\d+\)\:\swarning\s");
                    Regex FailedReg = new Regex(@"^compilation failed");

                    MatchCollection ErrorsMatches = ErrorsReg.Matches(Output);
                    MatchCollection WarningsMatches = WarningsReg.Matches(Output);
                    Match FailedMatch = FailedReg.Match(Output);

                    bool Failed = (FailedMatch.Success || ErrorsMatches.Count > 0);

                    Data.TaskFinished(TaskIndex, Output, !Failed, ErrorsMatches.Count, WarningsMatches.Count);
                }
                // Executing compiler failed
                else
                    Data.TaskFinished(TaskIndex, Output, false, 0, 0);
                
                System.Diagnostics.Debug.WriteLine(string.Format("Thread finished task index {0}", TaskIndex));
            }

            Data.OnThreadExit();
            System.Diagnostics.Debug.WriteLine("Thread finished.");
        }

        private void TaskBuildMenuItem_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Selected, false);
        }

        private void TaskRebuildMenuItem_Click(object sender, EventArgs e)
        {
            Build(WhatToBuild.Selected, true);
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            if (m_State != State.Compilation) return;

            m_CompilationData.Abort();
        }

        // Help > Documentation
        private void DocumentationMenuItem_Click(object sender, EventArgs e)
        {
            Globals.shell_execute(this, Path.Combine(Application.StartupPath, "FXBC Documentation.pdf"));
        }
    }

    // Description of single task in compilation data - both input and output fields
    class CompilationDataItem
    {
        public enum StateType
        {
            // Task is wainting for a working thread to start it
            Waiting,
            // Task is being processed right now by a working thread
            Started,
            // Task is already finished but still not shown in GUI
            Finished,
            // Task is finished and shown in GUI
            Showed,
        }

        // Task state
        // State can change only from previous to next one.
        public StateType State;

        // ==== INPUT ====
        // Command line parameters for compiler
        public string Parameters;
        // Index of task on the GUI task list
        public int ListViewItemIndex;
        
        // ==== OUTPUT ====
        // Output text - compilation result
        public string Output;
        // Whether compilation succeeded
        public bool Succeeded;
        // Error count
        public int NumErrors;
        // Warning count
        public int NumWarnings;

        public CompilationDataItem(string Parameters, int ListViewItemIndex)
        {
            this.Parameters = Parameters;
            this.ListViewItemIndex = ListViewItemIndex;
            State = StateType.Waiting;
        }
    }

    // Represents database of tasks to compile.
    // Used by both main GUI thread and compilation working threads.
    // This class is thread safe except construction stage.
    class CompilationData
    {
        // Compiler file name with full path
        private string m_FxcPath;
        // Script document directory - for compiler as working directory
        private string m_DocumentDirectory;
        // Tasks
        private List<CompilationDataItem> m_Items;
        // Current working thread count
        // Set during construction, threads decrease it, when drops to 0, all is done.
        private int m_ThreadCount;
        // Tasks 0..m_StartedCount are at least started
        private int m_StartedCount;
        // Number of tasks done
        private int m_FinishedOrShowedCount;
        // List of items in state Finished
        private List<int> m_FinishedItemIndices;
        // Whether Abort command has been called
        private bool m_Aborting;
        // Dummy object to use as critical section
        private Object m_Lock;

        // ======== FOR MAIN THREAD (CONSTRUCTION) ========

        public CompilationData(string FxcPath, string DocumentDirectory)
        {
            m_FxcPath = FxcPath;
            m_DocumentDirectory = DocumentDirectory;
            m_Items = new List<CompilationDataItem>();
            m_ThreadCount = 0;
            m_StartedCount = 0;
            m_FinishedOrShowedCount = 0;
            m_FinishedItemIndices = new List<int>();
            m_Aborting = false;
            m_Lock = new object();
        }

        public void AddItem(CompilationDataItem NewItem)
        {
            m_Items.Add(NewItem);
        }

        public void SetThreadCount(int ThreadCount)
        {
            m_ThreadCount = ThreadCount;
        }

        // ======== GENERAL ========

        public int GetItemCount()
        {
            lock (m_Lock) { return m_Items.Count; }
        }

        // ======== FOR MAIN THREAD ========

        public bool IsAllDone()
        {
            lock (m_Lock) { return (m_ThreadCount == 0); }
        }

        public void GetStats(out int Succeeded, out int Failed)
        {
            lock (m_Lock)
            {
                Succeeded = 0;
                Failed = 0;
                foreach (CompilationDataItem Item in m_Items)
                {
                    if (Item.Succeeded)
                        Succeeded++;
                    else
                        Failed++;
                }
            }
        }

        public void Abort()
        {
            lock (m_Lock) { m_Aborting = true; }
        }

        // Return and delete from list current indices of finished but yet not showed tasks.
        public int[] LoadFinishedIndices()
        {
            lock (m_Lock)
            {
                int[] R = m_FinishedItemIndices.ToArray();
                foreach (int Index in R)
                    m_Items[Index].State = CompilationDataItem.StateType.Showed;
                m_FinishedItemIndices.Clear();
                return R;
            }
        }

        public int[] GetUnfinishedIndices()
        {
            lock (m_Lock)
            {
                List<int> l = new List<int>();
                int i = 0;
                foreach (CompilationDataItem Item in m_Items)
                {
                    if (Item.State == CompilationDataItem.StateType.Waiting ||
                        Item.State == CompilationDataItem.StateType.Started)
                    {
                        l.Add(i);
                    }
                    i++;
                }
                return l.ToArray();
            }
        }

        public void GetTaskOutput(int Index, out int ListViewItemIndex, out string Output, out bool Succeeded, out int NumErrors, out int NumWarnings)
        {
            lock (m_Lock)
            {
                ListViewItemIndex = m_Items[Index].ListViewItemIndex;
                Output = m_Items[Index].Output;
                Succeeded = m_Items[Index].Succeeded;
                NumErrors = m_Items[Index].NumErrors;
                NumWarnings = m_Items[Index].NumWarnings;
            }
        }

        public int GetTaskListViewIndex(int Index)
        {
            lock (m_Lock) { return m_Items[Index].ListViewItemIndex; }
        }

        public int GetProgress()
        {
            lock (m_Lock) { return m_FinishedOrShowedCount; }
        }

        // ======== FOR WORKING THREADS ========

        public bool IsAborting()
        {
            lock (m_Lock) { return m_Aborting; }
        }

        public void OnThreadExit()
        {
            lock (m_Lock) { m_ThreadCount--; }
        }

        // Return index of next waiting task to start and start it.
        // If there are no waiting tasks left, return -1.
        public int StartNextTask(out string Parameters)
        {
            Parameters = "";

            lock (m_Lock)
            {
                if (m_StartedCount >= m_Items.Count)
                    return -1;

                int Index = m_StartedCount;
                m_Items[Index].State = CompilationDataItem.StateType.Started;
                Parameters = m_Items[Index].Parameters;
                m_StartedCount++;
                return Index;
            }
        }

        public void GetMainData(out string FxcPath, out string DocumentDirectory)
        {
            lock (m_Lock)
            {
                FxcPath = m_FxcPath;
                DocumentDirectory = m_DocumentDirectory;
            }
        }

        public void TaskFinished(int Index, string Output, bool Succeeded, int NumErrors, int NumWarnings)
        {
            lock (m_Lock)
            {
                m_Items[Index].State = CompilationDataItem.StateType.Finished;
                m_Items[Index].Output = Output;
                m_Items[Index].Succeeded = Succeeded;
                m_Items[Index].NumErrors = NumErrors;
                m_Items[Index].NumWarnings = NumWarnings;

                m_FinishedItemIndices.Add(Index);
                m_FinishedOrShowedCount++;
            }
        }
    }
}