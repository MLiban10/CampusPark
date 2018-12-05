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
            richTextBoxConfig = new System.Windows.Forms.RichTextBox();
            richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.buttonDLL = new System.Windows.Forms.Button();
            this.buttonSOAP = new System.Windows.Forms.Button();
            this.buttonReadSOAP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(338, 317);
            this.buttonPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(100, 30);
            this.buttonPath.TabIndex = 0;
            this.buttonPath.Text = "Config Path";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // richTextBoxConfig
            // 
            richTextBoxConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            richTextBoxConfig.Location = new System.Drawing.Point(12, 12);
            richTextBoxConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            richTextBoxConfig.Name = "richTextBoxConfig";
            richTextBoxConfig.Size = new System.Drawing.Size(320, 301);
            richTextBoxConfig.TabIndex = 3;
            richTextBoxConfig.Text = "";
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            richTextBoxLog.Location = new System.Drawing.Point(12, 349);
            richTextBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.Size = new System.Drawing.Size(426, 102);
            richTextBoxLog.TabIndex = 6;
            richTextBoxLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log Output:";
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(338, 98);
            this.buttonBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(100, 57);
            this.buttonBackground.TabIndex = 8;
            this.buttonBackground.Text = "Run in Background";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // buttonDLL
            // 
            this.buttonDLL.Location = new System.Drawing.Point(338, 12);
            this.buttonDLL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDLL.Name = "buttonDLL";
            this.buttonDLL.Size = new System.Drawing.Size(100, 30);
            this.buttonDLL.TabIndex = 9;
            this.buttonDLL.Text = "DLL";
            this.buttonDLL.UseVisualStyleBackColor = true;
            this.buttonDLL.Click += new System.EventHandler(this.buttonDLL_Click);
            // 
            // buttonSOAP
            // 
            this.buttonSOAP.Location = new System.Drawing.Point(338, 46);
            this.buttonSOAP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSOAP.Name = "buttonSOAP";
            this.buttonSOAP.Size = new System.Drawing.Size(100, 30);
            this.buttonSOAP.TabIndex = 10;
            this.buttonSOAP.Text = "SOAP";
            this.buttonSOAP.UseVisualStyleBackColor = true;
            this.buttonSOAP.Click += new System.EventHandler(this.buttonSOAP_Click);
            // 
            // buttonReadSOAP
            // 
            this.buttonReadSOAP.Location = new System.Drawing.Point(338, 159);
            this.buttonReadSOAP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReadSOAP.Name = "buttonReadSOAP";
            this.buttonReadSOAP.Size = new System.Drawing.Size(100, 30);
            this.buttonReadSOAP.TabIndex = 11;
            this.buttonReadSOAP.Text = "Read SOAP";
            this.buttonReadSOAP.UseVisualStyleBackColor = true;
            // 
            // FormDACE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 460);
            this.Controls.Add(this.buttonReadSOAP);
            this.Controls.Add(this.buttonSOAP);
            this.Controls.Add(this.buttonDLL);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(richTextBoxLog);
            this.Controls.Add(richTextBoxConfig);
            this.Controls.Add(this.buttonPath);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDACE";
            this.Text = "Park DACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPath;
        public static System.Windows.Forms.RichTextBox richTextBoxConfig;
        public static System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Button buttonDLL;
        private System.Windows.Forms.Button buttonSOAP;
        private System.Windows.Forms.Button buttonReadSOAP;
    }
}

