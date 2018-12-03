namespace Park_DACE
{
    partial class FormDACE
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
            this.buttonPath = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.buttonDLL = new System.Windows.Forms.Button();
            this.buttonSOAP = new System.Windows.Forms.Button();
            this.buttonReadSOAP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(197, 332);
            this.buttonPath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 24);
            this.buttonPath.TabIndex = 0;
            this.buttonPath.Text = "Config Path";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(185, 318);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(9, 361);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(268, 84);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 342);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log Output:";
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(197, 79);
            this.buttonBackground.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(75, 46);
            this.buttonBackground.TabIndex = 8;
            this.buttonBackground.Text = "Run in Background";
            this.buttonBackground.UseVisualStyleBackColor = true;
            // 
            // buttonDLL
            // 
            this.buttonDLL.Location = new System.Drawing.Point(197, 10);
            this.buttonDLL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDLL.Name = "buttonDLL";
            this.buttonDLL.Size = new System.Drawing.Size(75, 24);
            this.buttonDLL.TabIndex = 9;
            this.buttonDLL.Text = "DLL";
            this.buttonDLL.UseVisualStyleBackColor = true;
            this.buttonDLL.Click += new System.EventHandler(this.buttonDLL_Click);
            // 
            // buttonSOAP
            // 
            this.buttonSOAP.Location = new System.Drawing.Point(197, 38);
            this.buttonSOAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSOAP.Name = "buttonSOAP";
            this.buttonSOAP.Size = new System.Drawing.Size(75, 24);
            this.buttonSOAP.TabIndex = 10;
            this.buttonSOAP.Text = "SOAP";
            this.buttonSOAP.UseVisualStyleBackColor = true;
            // 
            // buttonReadSOAP
            // 
            this.buttonReadSOAP.Location = new System.Drawing.Point(197, 129);
            this.buttonReadSOAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadSOAP.Name = "buttonReadSOAP";
            this.buttonReadSOAP.Size = new System.Drawing.Size(75, 24);
            this.buttonReadSOAP.TabIndex = 11;
            this.buttonReadSOAP.Text = "Read SOAP";
            this.buttonReadSOAP.UseVisualStyleBackColor = true;
            // 
            // FormDACE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 452);
            this.Controls.Add(this.buttonReadSOAP);
            this.Controls.Add(this.buttonSOAP);
            this.Controls.Add(this.buttonDLL);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonPath);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDACE";
            this.Text = "Park DACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Button buttonDLL;
        private System.Windows.Forms.Button buttonSOAP;
        private System.Windows.Forms.Button buttonReadSOAP;
    }
}

