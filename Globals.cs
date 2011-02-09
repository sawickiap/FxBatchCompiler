using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FXBC
{
    static class Globals
    {
        // Full application name
        public const string APP_TITLE = "FX Batch Compiler";

        public static string calc_application_data_dir()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APP_TITLE);
        }

        public static void prepare_application_data_dir()
        {
            string dir = calc_application_data_dir();

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);

                unpack_resource_file(dir, Properties.Resources.Config_dat, "Config.dat");
                unpack_resource_file(dir, Properties.Resources.Sample_fxbc, "Sample.fxbc");
                unpack_resource_file(dir, Properties.Resources.SampleEffect_fx, "SampleEffect.fx");
                unpack_resource_file(dir, Properties.Resources.SampleVS_vs, "SampleVS.vs");
                unpack_resource_file(dir, Properties.Resources.SamplePS_ps, "SamplePS.ps");
            }
        }

        private static void unpack_resource_file(string dir, byte[] bytes, string file_name)
        {
            string path = Path.Combine(dir, file_name);
            File.WriteAllBytes(path, bytes);
        }

        // Convert file size in bytes to string
        public static string SizeToStr(long Size)
        {
            if (Size < 1024)
                return Size.ToString() + " B";
            double s = Size / 1024.0;
            if (s < 1024.0)
                return s.ToString("F2") + " KB";
            s /= 1024.0;
            if (s < 1024.0)
                return s.ToString("F2") + " MB";
            s /= 1024.0;
            return s.ToString("F2") + " GB";
        }

        // Copy directory with its content recursively
        public static void CopyDirectory(string SrcPath, string DestPath)
        {
            System.IO.Directory.CreateDirectory(DestPath);

            string[] Dirs = System.IO.Directory.GetDirectories(SrcPath);
            foreach (string Dir in Dirs)
            {
                string DirName = System.IO.Path.GetFileName(Dir);
                System.IO.Directory.CreateDirectory(DestPath + '\\' + DirName);
                CopyDirectory(SrcPath + '\\' + DirName, DestPath + '\\' + DirName);
            }

            string[] Files = System.IO.Directory.GetFiles(SrcPath);
            foreach (string File in Files)
            {
                string FileName = System.IO.Path.GetFileName(File);
                System.IO.File.Copy(SrcPath + '\\' + FileName, DestPath + '\\' + FileName);
            }
        }

        // Remove trailing '\' from given path if there is one
        public static string ExcludeTrailingPathDelimiter(string Path)
        {
            if (Path == null || Path.Length == 0)
                return Path;

            if (Path[Path.Length - 1] == '\\')
                return Path.Substring(0, Path.Length - 1);
            else
                return Path;
        }
        
        // Show message box with error
        public static void ShowError(IWin32Window Owner, Exception Error)
        {
            MessageBox.Show(Owner, Error.Message, APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowError(IWin32Window Owner, string ErrMsg)
        {
            MessageBox.Show(Owner, ErrMsg, APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static int LastId = 1;

        // Return next unique universal identifier number: 1, 2, 3, ...
        public static int NewId()
        {
            return LastId++;
        }

        // Foo... :)
        [System.Runtime.InteropServices.DllImport("User32.Dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);                      
        public const int EM_LINEINDEX = 0xBB;
        public const int EM_LINEFROMCHAR = 0xC9;

        public static void shell_execute(IWin32Window error_parent, string path)
        {
            try
            {
                System.Diagnostics.Process P = new System.Diagnostics.Process();
                P.StartInfo.UseShellExecute = true;
                P.StartInfo.FileName = path;
                P.Start();
            }
            catch (Exception ex)
            {
                ShowError(error_parent, ex);
            }
        }
    }
}
