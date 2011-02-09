namespace FXBC
{
    partial class AboutForm
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
            this.Button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.homepage_link_label_ = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.email_link_label_ = new System.Windows.Forms.LinkLabel();
            this.icon_picture_box_ = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon_picture_box_)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button1.Location = new System.Drawing.Point(223, 86);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "OK";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "FX Batch Compiler";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(50, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version 1.1    February 2011";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // homepage_link_label_
            // 
            this.homepage_link_label_.AutoSize = true;
            this.homepage_link_label_.Location = new System.Drawing.Point(20, 81);
            this.homepage_link_label_.Name = "homepage_link_label_";
            this.homepage_link_label_.Size = new System.Drawing.Size(126, 13);
            this.homepage_link_label_.TabIndex = 5;
            this.homepage_link_label_.TabStop = true;
            this.homepage_link_label_.Text = "http://www.asawicki.info";
            this.homepage_link_label_.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.homepage_link_label__LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Adam Sawicki";
            // 
            // email_link_label_
            // 
            this.email_link_label_.AutoSize = true;
            this.email_link_label_.Location = new System.Drawing.Point(20, 94);
            this.email_link_label_.Name = "email_link_label_";
            this.email_link_label_.Size = new System.Drawing.Size(135, 13);
            this.email_link_label_.TabIndex = 6;
            this.email_link_label_.TabStop = true;
            this.email_link_label_.Text = "mailto:adam@asawicki.info";
            this.email_link_label_.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.email_link_label__LinkClicked);
            // 
            // icon_picture_box_
            // 
            this.icon_picture_box_.Location = new System.Drawing.Point(12, 12);
            this.icon_picture_box_.Name = "icon_picture_box_";
            this.icon_picture_box_.Size = new System.Drawing.Size(32, 32);
            this.icon_picture_box_.TabIndex = 7;
            this.icon_picture_box_.TabStop = false;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button1;
            this.ClientSize = new System.Drawing.Size(311, 122);
            this.Controls.Add(this.icon_picture_box_);
            this.Controls.Add(this.email_link_label_);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homepage_link_label_);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About FX Batch Compiler";
            ((System.ComponentModel.ISupportInitialize)(this.icon_picture_box_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel homepage_link_label_;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel email_link_label_;
        private System.Windows.Forms.PictureBox icon_picture_box_;
    }
}