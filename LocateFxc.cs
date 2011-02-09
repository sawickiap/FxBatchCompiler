using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FXBC
{
    // Form to enter the location of FX compiler file.
    // Also supports automatic search for this file.
    public partial class LocateFxcForm : Form
    {
        public LocateFxcForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
                TextBox1.Text = OpenFileDialog1.FileName;
        }

        // Show the form, update given string to new entered path
        public static bool Go(IWin32Window Owner, ref string FxcPath)
        {
            LocateFxcForm Form = new LocateFxcForm();

            Form.TextBox1.Text = FxcPath;

            if (Form.ShowDialog(Owner) == DialogResult.OK)
            {
                FxcPath = Form.TextBox1.Text;
                return true;
            }
            else
                return false;
        }

        // In 100 nanoseconds.
        private const long MAX_LOCATE_TIME = 5 * 10000000; // 5 seconds

        // Return true if given directory is especially interesting when looking for fxc.exe file
        private static bool DirectoryIsInteresting(string DirName)
        {
            int Pos = DirName.LastIndexOf('\\');
            if (Pos > -1 && Pos < DirName.Length-1)
                DirName = DirName.Substring(Pos + 1);
            DirName = DirName.ToLower();

            if (DirName.Contains("dx")) return true;
            if (DirName.Contains("directx")) return true;
            if (DirName.Contains("sdk")) return true;
            if (DirName.Contains("microsoft")) return true;
            
            if (DirName.Contains("utilities")) return true;
            if (DirName.Contains("bin")) return true;
            if (DirName.Contains("x86")) return true;

            return false;
        }

        // Try to locate fxc.exe file on the hard disk and return its path or empty string if not found
        // Takes time!
        public static string TryLocateFxc()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                try
                {
                    long EndTime = DateTime.Now.Ticks + MAX_LOCATE_TIME;

                    // Paths to process
                    System.Collections.Generic.LinkedList<string> PathQueue = new System.Collections.Generic.LinkedList<string>();
                    // Path already processed in form Key=Path, Value="1"
                    System.Collections.Specialized.StringDictionary Processed = new System.Collections.Specialized.StringDictionary();

                    // Add default paths
                    // - Program files
                    PathQueue.AddLast(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                    // - Hard disks
                    foreach (DriveInfo Drive in DriveInfo.GetDrives())
                        if (Drive.DriveType == DriveType.Fixed)
                            PathQueue.AddLast(Drive.RootDirectory.Name);

                    // Processing loop - berform breadth first search (BFS) algorithm
                    while (PathQueue.Count > 0)
                    {
                        // Get directory to process
                        string Dir = PathQueue.First.Value;
                        PathQueue.RemoveFirst();
                        // Already processed
                        if (Processed.ContainsKey(Dir))
                            continue;
                        // Add to processed
                        Processed.Add(Dir, "1");

                        //System.Diagnostics.Debug.WriteLine("Processing: " + Dir);

                        try
                        {
                            // Look for fxc.exe file
                            string[] FxcFiles = Directory.GetFiles(Dir, "fxc.exe");
                            if (FxcFiles.Length > 0)
                                return FxcFiles[0];

                            // Look for subdirectories
                            foreach (string SubDir in Directory.GetDirectories(Dir))
                            {
                                // Interesting directory - add at the beginning of the queue
                                if (DirectoryIsInteresting(SubDir))
                                    PathQueue.AddFirst(SubDir);
                                // Not interesting - add at the end of the queue
                                else
                                    PathQueue.AddLast(SubDir);
                            }
                        }
                        catch (Exception ) { }

                        // Time out
                        if (DateTime.Now.Ticks >= EndTime)
                            return "";
                    }
                    
                    // Not found
                    return "";
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception )
            {
                return "";
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            string FxcLocation = TryLocateFxc();
            if (FxcLocation != null && FxcLocation != string.Empty)
            {
                TextBox1.Text = FxcLocation;
                TextBox1.Focus();
            }
        }
    }
}