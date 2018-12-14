namespace ParkSS_SS
{
    partial class FormParkSS
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
            this.btn_storeDatabase = new System.Windows.Forms.Button();
            this.buttonChangeIP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(350, 20);
            this.btnSubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(52, 23);
            this.btnSubscribe.TabIndex = 0;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Visible = false;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // richTextBoxSS
            // 
            this.richTextBoxSS.Location = new System.Drawing.Point(17, 47);
            this.richTextBoxSS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxSS.Name = "richTextBoxSS";
            this.richTextBoxSS.Size = new System.Drawing.Size(816, 490);
            this.richTextBoxSS.TabIndex = 1;
            this.richTextBoxSS.Text = "";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(52, 21);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(130, 22);
            this.textBoxIP.TabIndex = 2;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // btn_storeDatabase
            // 
            this.btn_storeDatabase.Location = new System.Drawing.Point(287, 21);
            this.btn_storeDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_storeDatabase.Name = "btn_storeDatabase";
            this.btn_storeDatabase.Size = new System.Drawing.Size(55, 22);
            this.btn_storeDatabase.TabIndex = 3;
            this.btn_storeDatabase.Text = "Store in Database";
            this.btn_storeDatabase.UseVisualStyleBackColor = true;
            this.btn_storeDatabase.Visible = false;
            this.btn_storeDatabase.Click += new System.EventHandler(this.btn_storeDatabase_Click);
            // 
            // buttonChangeIP
            // 
            this.buttonChangeIP.Location = new System.Drawing.Point(189, 21);
            this.buttonChangeIP.Name = "buttonChangeIP";
            this.buttonChangeIP.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeIP.TabIndex = 4;
            this.buttonChangeIP.Text = "Change";
            this.buttonChangeIP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP: ";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(758, 20);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormParkSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 554);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonChangeIP);
            this.Controls.Add(this.btn_storeDatabase);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextBoxSS);
            this.Controls.Add(this.btnSubscribe);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormParkSS";
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
        private System.Windows.Forms.Button btn_storeDatabase;
        private System.Windows.Forms.Button buttonChangeIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear;
    }
}

