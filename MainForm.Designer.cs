namespace FXBC
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebuildSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BuildCheckedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebuildCheckedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BuildAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebuildAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.AbortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocateFxcMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FxcParametersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ScriptTextbox = new System.Windows.Forms.TextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.TaskMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TaskEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TaskBuildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskRebuildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TaskOpenSrcFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskOpenDestFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.TaskViewSrcFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskViewDestFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AbortButton = new System.Windows.Forms.Button();
            this.RebuildAllButton = new System.Windows.Forms.Button();
            this.BuildAllButton = new System.Windows.Forms.Button();
            this.RebuildCheckedButton = new System.Windows.Forms.Button();
            this.BuildCheckedButton = new System.Windows.Forms.Button();
            this.RebuildSelectedButton = new System.Windows.Forms.Button();
            this.BuildSelectedButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.StartupTimer = new System.Windows.Forms.Timer(this.components);
            this.FontDialog1 = new System.Windows.Forms.FontDialog();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TextboxRowColTimer = new System.Windows.Forms.Timer(this.components);
            this.CompilationTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TaskMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.BuildMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.toolStripSeparator3,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuItem.Size = new System.Drawing.Size(163, 22);
            this.NewMenuItem.Text = "&New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(163, 22);
            this.OpenMenuItem.Text = "&Open...";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SaveMenuItem.Text = "&Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SaveAsMenuItem.Text = "Save &As...";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // BuildMenuItem
            // 
            this.BuildMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuildSelectedMenuItem,
            this.RebuildSelectedMenuItem,
            this.toolStripSeparator4,
            this.BuildCheckedMenuItem,
            this.RebuildCheckedMenuItem,
            this.toolStripSeparator5,
            this.BuildAllMenuItem,
            this.RebuildAllMenuItem,
            this.toolStripSeparator6,
            this.AbortMenuItem});
            this.BuildMenuItem.Name = "BuildMenuItem";
            this.BuildMenuItem.Size = new System.Drawing.Size(41, 20);
            this.BuildMenuItem.Text = "&Build";
            this.BuildMenuItem.Visible = false;
            // 
            // BuildSelectedMenuItem
            // 
            this.BuildSelectedMenuItem.Name = "BuildSelectedMenuItem";
            this.BuildSelectedMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.BuildSelectedMenuItem.Size = new System.Drawing.Size(213, 22);
            this.BuildSelectedMenuItem.Text = "&Build Selected";
            this.BuildSelectedMenuItem.Click += new System.EventHandler(this.BuildSelectedButton_Click);
            // 
            // RebuildSelectedMenuItem
            // 
            this.RebuildSelectedMenuItem.Name = "RebuildSelectedMenuItem";
            this.RebuildSelectedMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F7)));
            this.RebuildSelectedMenuItem.Size = new System.Drawing.Size(213, 22);
            this.RebuildSelectedMenuItem.Text = "&Rebuild Selected";
            this.RebuildSelectedMenuItem.Click += new System.EventHandler(this.RebuildSelectedButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // BuildCheckedMenuItem
            // 
            this.BuildCheckedMenuItem.Name = "BuildCheckedMenuItem";
            this.BuildCheckedMenuItem.Size = new System.Drawing.Size(213, 22);
            this.BuildCheckedMenuItem.Text = "Build &Checked";
            this.BuildCheckedMenuItem.Click += new System.EventHandler(this.BuildCheckedButton_Click);
            // 
            // RebuildCheckedMenuItem
            // 
            this.RebuildCheckedMenuItem.Name = "RebuildCheckedMenuItem";
            this.RebuildCheckedMenuItem.Size = new System.Drawing.Size(213, 22);
            this.RebuildCheckedMenuItem.Text = "Rebuild C&hecked";
            this.RebuildCheckedMenuItem.Click += new System.EventHandler(this.RebuildCheckedButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // BuildAllMenuItem
            // 
            this.BuildAllMenuItem.Name = "BuildAllMenuItem";
            this.BuildAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
            this.BuildAllMenuItem.Size = new System.Drawing.Size(213, 22);
            this.BuildAllMenuItem.Text = "Build &All";
            this.BuildAllMenuItem.Click += new System.EventHandler(this.BuildAllButton_Click);
            // 
            // RebuildAllMenuItem
            // 
            this.RebuildAllMenuItem.Name = "RebuildAllMenuItem";
            this.RebuildAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.F7)));
            this.RebuildAllMenuItem.Size = new System.Drawing.Size(213, 22);
            this.RebuildAllMenuItem.Text = "Rebuild A&ll";
            this.RebuildAllMenuItem.Click += new System.EventHandler(this.RebuildAllButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(210, 6);
            // 
            // AbortMenuItem
            // 
            this.AbortMenuItem.Name = "AbortMenuItem";
            this.AbortMenuItem.ShortcutKeyDisplayString = "Ctrl+Break";
            this.AbortMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Pause)));
            this.AbortMenuItem.Size = new System.Drawing.Size(213, 22);
            this.AbortMenuItem.Text = "A&bort";
            this.AbortMenuItem.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocateFxcMenuItem,
            this.FontMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // LocateFxcMenuItem
            // 
            this.LocateFxcMenuItem.Name = "LocateFxcMenuItem";
            this.LocateFxcMenuItem.Size = new System.Drawing.Size(147, 22);
            this.LocateFxcMenuItem.Text = "&Locate fxc...";
            this.LocateFxcMenuItem.Click += new System.EventHandler(this.LocateFxcMenuItem_Click);
            // 
            // FontMenuItem
            // 
            this.FontMenuItem.Name = "FontMenuItem";
            this.FontMenuItem.Size = new System.Drawing.Size(147, 22);
            this.FontMenuItem.Text = "&Font...";
            this.FontMenuItem.Click += new System.EventHandler(this.FontMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DocumentationMenuItem,
            this.FxcParametersMenuItem,
            this.toolStripSeparator7,
            this.AboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // DocumentationMenuItem
            // 
            this.DocumentationMenuItem.Name = "DocumentationMenuItem";
            this.DocumentationMenuItem.Size = new System.Drawing.Size(172, 22);
            this.DocumentationMenuItem.Text = "&Documentation";
            this.DocumentationMenuItem.Click += new System.EventHandler(this.DocumentationMenuItem_Click);
            // 
            // FxcParametersMenuItem
            // 
            this.FxcParametersMenuItem.Name = "FxcParametersMenuItem";
            this.FxcParametersMenuItem.Size = new System.Drawing.Size(172, 22);
            this.FxcParametersMenuItem.Text = "&Fxc Parameters...";
            this.FxcParametersMenuItem.Click += new System.EventHandler(this.FxcParametersMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(169, 6);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(172, 22);
            this.AboutMenuItem.Text = "&About...";
            this.AboutMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Value = 50;
            this.toolStripProgressBar1.Visible = false;
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 593);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(794, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Layout += new System.Windows.Forms.LayoutEventHandler(this.MainStatusStrip_Layout);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Info;
            this.TopPanel.Controls.Add(this.Button2);
            this.TopPanel.Controls.Add(this.Button1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 24);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(794, 43);
            this.TopPanel.TabIndex = 1;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(97, 8);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(83, 27);
            this.Button2.TabIndex = 1;
            this.Button2.TabStop = false;
            this.Button2.Text = "Build";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(8, 8);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(83, 27);
            this.Button1.TabIndex = 0;
            this.Button1.TabStop = false;
            this.Button1.Text = "Script";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ScriptTextbox);
            this.Panel1.Location = new System.Drawing.Point(12, 73);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(770, 140);
            this.Panel1.TabIndex = 3;
            // 
            // ScriptTextbox
            // 
            this.ScriptTextbox.AcceptsReturn = true;
            this.ScriptTextbox.AcceptsTab = true;
            this.ScriptTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptTextbox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScriptTextbox.Location = new System.Drawing.Point(0, 0);
            this.ScriptTextbox.Multiline = true;
            this.ScriptTextbox.Name = "ScriptTextbox";
            this.ScriptTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ScriptTextbox.Size = new System.Drawing.Size(770, 140);
            this.ScriptTextbox.TabIndex = 0;
            this.ScriptTextbox.WordWrap = false;
            this.ScriptTextbox.TextChanged += new System.EventHandler(this.ScriptTextbox_TextChanged);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.splitContainer1);
            this.Panel2.Location = new System.Drawing.Point(12, 228);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(770, 344);
            this.Panel2.TabIndex = 4;
            this.Panel2.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListView1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(770, 344);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // ListView1
            // 
            this.ListView1.CheckBoxes = true;
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ListView1.ContextMenuStrip = this.TaskMenuStrip;
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView1.HideSelection = false;
            this.ListView1.LabelWrap = false;
            this.ListView1.Location = new System.Drawing.Point(0, 0);
            this.ListView1.Name = "ListView1";
            this.ListView1.ShowGroups = false;
            this.ListView1.Size = new System.Drawing.Size(648, 200);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Row";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Parameters";
            this.columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Build Status";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 200;
            // 
            // TaskMenuStrip
            // 
            this.TaskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskEditMenuItem,
            this.toolStripMenuItem1,
            this.TaskBuildMenuItem,
            this.TaskRebuildMenuItem,
            this.toolStripMenuItem2,
            this.TaskOpenSrcFileMenuItem,
            this.TaskOpenDestFileMenuItem,
            this.toolStripMenuItem3,
            this.TaskViewSrcFileMenuItem,
            this.TaskViewDestFileMenuItem});
            this.TaskMenuStrip.Name = "TaskMenuStrip";
            this.TaskMenuStrip.Size = new System.Drawing.Size(188, 176);
            this.TaskMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TaskMenuStrip_Opening);
            // 
            // TaskEditMenuItem
            // 
            this.TaskEditMenuItem.Name = "TaskEditMenuItem";
            this.TaskEditMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskEditMenuItem.Text = "&Edit";
            this.TaskEditMenuItem.Click += new System.EventHandler(this.TaskEditMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 6);
            // 
            // TaskBuildMenuItem
            // 
            this.TaskBuildMenuItem.Name = "TaskBuildMenuItem";
            this.TaskBuildMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskBuildMenuItem.Text = "&Build";
            this.TaskBuildMenuItem.Click += new System.EventHandler(this.TaskBuildMenuItem_Click);
            // 
            // TaskRebuildMenuItem
            // 
            this.TaskRebuildMenuItem.Name = "TaskRebuildMenuItem";
            this.TaskRebuildMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskRebuildMenuItem.Text = "&Rebuild";
            this.TaskRebuildMenuItem.Click += new System.EventHandler(this.TaskRebuildMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // TaskOpenSrcFileMenuItem
            // 
            this.TaskOpenSrcFileMenuItem.Name = "TaskOpenSrcFileMenuItem";
            this.TaskOpenSrcFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskOpenSrcFileMenuItem.Text = "Open &Source File";
            this.TaskOpenSrcFileMenuItem.Click += new System.EventHandler(this.TaskOpenSrcFileMenuItem_Click);
            // 
            // TaskOpenDestFileMenuItem
            // 
            this.TaskOpenDestFileMenuItem.Name = "TaskOpenDestFileMenuItem";
            this.TaskOpenDestFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskOpenDestFileMenuItem.Text = "Open &Destination File";
            this.TaskOpenDestFileMenuItem.Click += new System.EventHandler(this.TaskOpenDestFileMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // TaskViewSrcFileMenuItem
            // 
            this.TaskViewSrcFileMenuItem.Name = "TaskViewSrcFileMenuItem";
            this.TaskViewSrcFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskViewSrcFileMenuItem.Text = "&View Source File";
            this.TaskViewSrcFileMenuItem.Click += new System.EventHandler(this.TaskViewSrcFileMenuItem_Click);
            // 
            // TaskViewDestFileMenuItem
            // 
            this.TaskViewDestFileMenuItem.Name = "TaskViewDestFileMenuItem";
            this.TaskViewDestFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.TaskViewDestFileMenuItem.Text = "View Destination &File";
            this.TaskViewDestFileMenuItem.Click += new System.EventHandler(this.TaskViewDestFileMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.AbortButton);
            this.panel3.Controls.Add(this.RebuildAllButton);
            this.panel3.Controls.Add(this.BuildAllButton);
            this.panel3.Controls.Add(this.RebuildCheckedButton);
            this.panel3.Controls.Add(this.BuildCheckedButton);
            this.panel3.Controls.Add(this.RebuildSelectedButton);
            this.panel3.Controls.Add(this.BuildSelectedButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(648, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(122, 200);
            this.panel3.TabIndex = 1;
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(8, 182);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(105, 23);
            this.AbortButton.TabIndex = 6;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // RebuildAllButton
            // 
            this.RebuildAllButton.Location = new System.Drawing.Point(8, 153);
            this.RebuildAllButton.Name = "RebuildAllButton";
            this.RebuildAllButton.Size = new System.Drawing.Size(105, 23);
            this.RebuildAllButton.TabIndex = 5;
            this.RebuildAllButton.Text = "Rebuild All";
            this.RebuildAllButton.UseVisualStyleBackColor = true;
            this.RebuildAllButton.Click += new System.EventHandler(this.RebuildAllButton_Click);
            // 
            // BuildAllButton
            // 
            this.BuildAllButton.Location = new System.Drawing.Point(8, 124);
            this.BuildAllButton.Name = "BuildAllButton";
            this.BuildAllButton.Size = new System.Drawing.Size(105, 23);
            this.BuildAllButton.TabIndex = 4;
            this.BuildAllButton.Text = "Build All";
            this.BuildAllButton.UseVisualStyleBackColor = true;
            this.BuildAllButton.Click += new System.EventHandler(this.BuildAllButton_Click);
            // 
            // RebuildCheckedButton
            // 
            this.RebuildCheckedButton.Location = new System.Drawing.Point(8, 95);
            this.RebuildCheckedButton.Name = "RebuildCheckedButton";
            this.RebuildCheckedButton.Size = new System.Drawing.Size(105, 23);
            this.RebuildCheckedButton.TabIndex = 3;
            this.RebuildCheckedButton.Text = "Rebuild Checked";
            this.RebuildCheckedButton.UseVisualStyleBackColor = true;
            this.RebuildCheckedButton.Click += new System.EventHandler(this.RebuildCheckedButton_Click);
            // 
            // BuildCheckedButton
            // 
            this.BuildCheckedButton.Location = new System.Drawing.Point(8, 66);
            this.BuildCheckedButton.Name = "BuildCheckedButton";
            this.BuildCheckedButton.Size = new System.Drawing.Size(105, 23);
            this.BuildCheckedButton.TabIndex = 2;
            this.BuildCheckedButton.Text = "Build Checked";
            this.BuildCheckedButton.UseVisualStyleBackColor = true;
            this.BuildCheckedButton.Click += new System.EventHandler(this.BuildCheckedButton_Click);
            // 
            // RebuildSelectedButton
            // 
            this.RebuildSelectedButton.Location = new System.Drawing.Point(8, 37);
            this.RebuildSelectedButton.Name = "RebuildSelectedButton";
            this.RebuildSelectedButton.Size = new System.Drawing.Size(105, 23);
            this.RebuildSelectedButton.TabIndex = 1;
            this.RebuildSelectedButton.Text = "Rebuild Selected";
            this.RebuildSelectedButton.UseVisualStyleBackColor = true;
            this.RebuildSelectedButton.Click += new System.EventHandler(this.RebuildSelectedButton_Click);
            // 
            // BuildSelectedButton
            // 
            this.BuildSelectedButton.Location = new System.Drawing.Point(8, 8);
            this.BuildSelectedButton.Name = "BuildSelectedButton";
            this.BuildSelectedButton.Size = new System.Drawing.Size(105, 23);
            this.BuildSelectedButton.TabIndex = 0;
            this.BuildSelectedButton.Text = "Build Selected";
            this.BuildSelectedButton.UseVisualStyleBackColor = true;
            this.BuildSelectedButton.Click += new System.EventHandler(this.BuildSelectedButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(770, 138);
            this.OutputTextBox.TabIndex = 0;
            this.OutputTextBox.WordWrap = false;
            // 
            // StartupTimer
            // 
            this.StartupTimer.Enabled = true;
            this.StartupTimer.Tick += new System.EventHandler(this.StartupTimer_Tick);
            // 
            // FontDialog1
            // 
            this.FontDialog1.FontMustExist = true;
            this.FontDialog1.ShowApply = true;
            this.FontDialog1.ShowEffects = false;
            this.FontDialog1.Apply += new System.EventHandler(this.FontDialog1_Apply);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.DefaultExt = "fxbc";
            this.OpenFileDialog1.Filter = "FX Batch Compiler Script (*.fxbc)|*.fxbc|All files (*.*)|*.*";
            this.OpenFileDialog1.Title = "Open Script";
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.DefaultExt = "fxbc";
            this.SaveFileDialog1.Filter = "FX Batch Compiler Script (*.fxbc)|*.fxbc|All files (*.*)|*.*";
            this.SaveFileDialog1.Title = "Save Script As";
            // 
            // TextboxRowColTimer
            // 
            this.TextboxRowColTimer.Interval = 50;
            this.TextboxRowColTimer.Tick += new System.EventHandler(this.TextboxRowColTimer_Tick);
            // 
            // CompilationTimer
            // 
            this.CompilationTimer.Interval = 200;
            this.CompilationTimer.Tick += new System.EventHandler(this.CompilationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 615);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.TaskMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BuildMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BuildSelectedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RebuildSelectedMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem BuildCheckedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RebuildCheckedMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem BuildAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RebuildAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem AbortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocateFxcMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FxcParametersMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.TextBox ScriptTextbox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button RebuildCheckedButton;
        private System.Windows.Forms.Button BuildCheckedButton;
        private System.Windows.Forms.Button RebuildSelectedButton;
        private System.Windows.Forms.Button BuildSelectedButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button RebuildAllButton;
        private System.Windows.Forms.Button BuildAllButton;
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Timer StartupTimer;
        private System.Windows.Forms.FontDialog FontDialog1;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private System.Windows.Forms.Timer TextboxRowColTimer;
        private System.Windows.Forms.ContextMenuStrip TaskMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TaskEditMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TaskBuildMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskRebuildMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TaskOpenSrcFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskOpenDestFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem TaskViewSrcFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskViewDestFileMenuItem;
        private System.Windows.Forms.Timer CompilationTimer;
    }
}

