using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

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
            DirName = Path.GetFileName(DirName).ToLower();

            if (DirName.Contains("dx")) return true;
            if (DirName.Contains("directx")) return true;
            if (DirName.Contains("sdk")) return true;
            if (DirName.Contains("microsoft")) return true;
            
            if (DirName.Contains("utilities")) return true;
            if (DirName.Contains("bin")) return true;
            if (DirName.Contains("x86")) return true;

            return false;
        }

        // Try to locate fxc.exe file on the hard disk and return its path or null if not found
        // Takes time!
        public static string TryLocateFxc()
        {
            string fxc_path = locate_fxc_from_registry();
            if (fxc_path == null)
                fxc_path = locate_fxc_on_disk();
            return fxc_path;
        }

        // On error or failure, returns null.
        private static string locate_fxc_on_disk()
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
                        return null;
                }

                // Not found
                return null;
            }
            catch (Exception )
            {
                return null;
            }
        }

        // On error or failure, returns null.
        private static string locate_fxc_from_registry()
        {
            try
            {
                using (RegistryKey dx_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectX"))
                {
                    string[] sub_key_names = dx_key.GetSubKeyNames();
                    foreach (string sub_key_name in sub_key_names)
                    {
                        if (sub_key_name.IndexOf("Microsoft DirectX SDK", StringComparison.InvariantCultureIgnoreCase) != -1)
                        {
                            using (RegistryKey sdk_key = dx_key.OpenSubKey(sub_key_name))
                            {
                                object val = sdk_key.GetValue("InstallPath");
                                if (val != null && val is string)
                                {
                                    string fxc_path = Path.Combine(val as string, @"Utilities\bin\x86\fxc.exe");
                                    if (File.Exists(fxc_path))
                                        return fxc_path;
                                }
                            }
                        }
                    }
                }

                // Not found.
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            string FxcLocation = TryLocateFxc();
            
            if (FxcLocation != null)
            {
                TextBox1.Text = FxcLocation;
                TextBox1.Focus();
            }
            
            Cursor = Cursors.Default;
        }
    }
}