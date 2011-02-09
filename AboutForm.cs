using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FXBC
{
    public partial class AboutForm : Form
    {
        private AboutForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process P = new System.Diagnostics.Process();
            P.StartInfo.FileName = "http://regedit.gamedev.pl/";
            P.StartInfo.UseShellExecute = true;
            P.Start();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process P = new System.Diagnostics.Process();
            P.StartInfo.FileName = "http://www.gamedev.pl/";
            P.StartInfo.UseShellExecute = true;
            P.Start();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process P = new System.Diagnostics.Process();
            P.StartInfo.FileName = "mailto:regedit@regedit.gamedev.pl?subject=FX Batch Compiler";
            P.StartInfo.UseShellExecute = true;
            P.Start();
        }

        // Show modal About dialog
        public static void Go(IWin32Window Owner)
        {
            AboutForm Form = new AboutForm();
            Form.ShowDialog(Owner);
        }
    }
}