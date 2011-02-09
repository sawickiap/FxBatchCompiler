namespace FXBC
{
    partial class LocateFxcForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.OkButton1 = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "To use this tool, you need to enter full path of the fxc.exe file - the Microsoft" +
                " (R) D3DX9 Shader Compiler shipped with DirectX SDK.";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 42);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(289, 20);
            this.TextBox1.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(307, 39);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // OkButton1
            // 
            this.OkButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton1.Location = new System.Drawing.Point(226, 77);
            this.OkButton1.Name = "OkButton1";
            this.OkButton1.Size = new System.Drawing.Size(75, 23);
            this.OkButton1.TabIndex = 4;
            this.OkButton1.Text = "OK";
            this.OkButton1.UseVisualStyleBackColor = true;
            // 
            // CancelButton1
            // 
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Location = new System.Drawing.Point(307, 77);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(75, 23);
            this.CancelButton1.TabIndex = 5;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(12, 77);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(120, 23);
            this.FindButton.TabIndex = 3;
            this.FindButton.Text = "Find automatically";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.AddExtension = false;
            this.OpenFileDialog1.DefaultExt = "exe";
            this.OpenFileDialog1.FileName = "fxc.exe";
            this.OpenFileDialog1.Filter = "fxc.exe|fxc.exe|All files (*.*)|*.*";
            this.OpenFileDialog1.Title = "Locate fxc.exe";
            // 
            // LocateFxcForm
            // 
            this.AcceptButton = this.OkButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton1;
            this.ClientSize = new System.Drawing.Size(394, 112);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.OkButton1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocateFxcForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locate fxc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button OkButton1;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
    }
}