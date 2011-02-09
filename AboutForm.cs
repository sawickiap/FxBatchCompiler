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
        public AboutForm(Icon icon)
        {
            InitializeComponent();
            icon_picture_box_.Image = icon.ToBitmap();
        }

        private void homepage_link_label__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Globals.shell_execute(this, "http://www.asawicki.info/");
        }

        private void email_link_label__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Globals.shell_execute(this, "mailto:adam@asawicki.info?subject=FX Batch Compiler 1.1");
        }
    }
}