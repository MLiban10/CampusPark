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
            this.components = new System.ComponentModel.Container();
            this.buttonPath = new System.Windows.Forms.Button();
            this.richTextBoxConfig = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.buttonDLL = new System.Windows.Forms.Button();
            this.buttonSOAP = new System.Windows.Forms.Button();
            this.buttonReadSOAP = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonBroker = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(254, 258);
            this.buttonPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 24);
            this.buttonPath.TabIndex = 0;
            this.buttonPath.Text = "Config Path";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // richTextBoxConfig
            // 
            this.richTextBoxConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxConfig.Location = new System.Drawing.Point(9, 10);
            this.richTextBoxConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxConfig.Name = "richTextBoxConfig";
            this.richTextBoxConfig.Size = new System.Drawing.Size(241, 245);
            this.richTextBoxConfig.TabIndex = 3;
            this.richTextBoxConfig.Text = "";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxLog.Location = new System.Drawing.Point(9, 284);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(320, 84);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 268);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log Output:";
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(254, 80);
            this.buttonBackground.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(75, 46);
            this.buttonBackground.TabIndex = 8;
            this.buttonBackground.Text = "Run in Background";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // buttonDLL
            // 
            this.buttonDLL.Location = new System.Drawing.Point(254, 10);
            this.buttonDLL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDLL.Name = "buttonDLL";
            this.buttonDLL.Size = new System.Drawing.Size(75, 24);
            this.buttonDLL.TabIndex = 9;
            this.buttonDLL.Text = "DLL";
            this.buttonDLL.UseVisualStyleBackColor = true;
            this.buttonDLL.Click += new System.EventHandler(this.buttonDLL_Click);
            // 
            // buttonSOAP
            // 
            this.buttonSOAP.Location = new System.Drawing.Point(254, 37);
            this.buttonSOAP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSOAP.Name = "buttonSOAP";
            this.buttonSOAP.Size = new System.Drawing.Size(75, 24);
            this.buttonSOAP.TabIndex = 10;
            this.buttonSOAP.Text = "SOAP";
            this.buttonSOAP.UseVisualStyleBackColor = true;
            this.buttonSOAP.Click += new System.EventHandler(this.buttonSOAP_Click);
            // 
            // buttonReadSOAP
            // 
            this.buttonReadSOAP.Location = new System.Drawing.Point(254, 129);
            this.buttonReadSOAP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReadSOAP.Name = "buttonReadSOAP";
            this.buttonReadSOAP.Size = new System.Drawing.Size(75, 24);
            this.buttonReadSOAP.TabIndex = 11;
            this.buttonReadSOAP.Text = "Read SOAP";
            this.buttonReadSOAP.UseVisualStyleBackColor = true;
            this.buttonReadSOAP.Click += new System.EventHandler(this.buttonReadSOAP_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ButtonBroker
            // 
            this.ButtonBroker.Location = new System.Drawing.Point(254, 158);
            this.ButtonBroker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonBroker.Name = "ButtonBroker";
            this.ButtonBroker.Size = new System.Drawing.Size(75, 50);
            this.ButtonBroker.TabIndex = 12;
            this.ButtonBroker.Text = "Connect To Broker";
            this.ButtonBroker.UseVisualStyleBackColor = true;
            this.ButtonBroker.Click += new System.EventHandler(this.ButtonBroker_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(254, 213);
            this.btnPublish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(74, 28);
            this.btnPublish.TabIndex = 13;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // FormDACE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 374);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.ButtonBroker);
            this.Controls.Add(this.buttonReadSOAP);
            this.Controls.Add(this.buttonSOAP);
            this.Controls.Add(this.buttonDLL);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.richTextBoxConfig);
            this.Controls.Add(this.buttonPath);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDACE";
            this.Text = "Park DACE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDACE_FormClosed);
            this.Load += new System.EventHandler(this.FormDACE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Button buttonDLL;
        private System.Windows.Forms.Button buttonSOAP;
        private System.Windows.Forms.Button buttonReadSOAP;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.RichTextBox richTextBoxConfig;
        private System.Windows.Forms.Button ButtonBroker;
        private System.Windows.Forms.Button btnPublish;
        public System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}

