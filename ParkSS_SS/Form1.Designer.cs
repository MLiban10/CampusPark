namespace ParkSS_SS
{
    partial class Form1
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
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.richTextBoxSS = new System.Windows.Forms.RichTextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(13, 66);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 0;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // richTextBoxSS
            // 
            this.richTextBoxSS.Location = new System.Drawing.Point(13, 195);
            this.richTextBoxSS.Name = "richTextBoxSS";
            this.richTextBoxSS.Size = new System.Drawing.Size(356, 243);
            this.richTextBoxSS.TabIndex = 1;
            this.richTextBoxSS.Text = "";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(95, 68);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(274, 20);
            this.textBoxIP.TabIndex = 2;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 450);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextBoxSS);
            this.Controls.Add(this.btnSubscribe);
            this.Name = "Form1";
            this.Text = "ParkSS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.ParkSS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.RichTextBox richTextBoxSS;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}

