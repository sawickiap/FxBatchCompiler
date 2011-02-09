using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FXBC
{
    // For showing just unformatted text in big multiline read-only textarea.
    public partial class ShowTextForm : Form
    {
        public ShowTextForm()
        {
            InitializeComponent();
        }

        // Show the form
        public static void Go(IWin32Window Owner, string Title, string Text, Font F)
        {
            ShowTextForm Form = new ShowTextForm();
            if (F != null)
                Form.TextBox1.Font = F;
            Form.Text = Title;
            Form.TextBox1.Text = Text;

            Form.ShowDialog(Owner);
        }
    }
}