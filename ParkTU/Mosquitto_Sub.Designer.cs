namespace ParkTU
{
    partial class Mosquitto_Sub
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
            this.lbl_domain = new System.Windows.Forms.Label();
            this.txtBox_domain = new System.Windows.Forms.TextBox();
            this.btn_subscribe = new System.Windows.Forms.Button();
            this.btn_Unsubscribe = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.rchTxtBox_Message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbl_domain
            // 
            this.lbl_domain.AutoSize = true;
            this.lbl_domain.Location = new System.Drawing.Point(12, 17);
            this.lbl_domain.Name = "lbl_domain";
            this.lbl_domain.Size = new System.Drawing.Size(78, 13);
            this.lbl_domain.TabIndex = 0;
            this.lbl_domain.Text = "Broker domain:";
            // 
            // txtBox_domain
            // 
            this.txtBox_domain.Location = new System.Drawing.Point(96, 14);
            this.txtBox_domain.Name = "txtBox_domain";
            this.txtBox_domain.Size = new System.Drawing.Size(196, 20);
            this.txtBox_domain.TabIndex = 1;
            this.txtBox_domain.Text = "127.0.0.1";
            // 
            // btn_subscribe
            // 
            this.btn_subscribe.Location = new System.Drawing.Point(15, 54);
            this.btn_subscribe.Name = "btn_subscribe";
            this.btn_subscribe.Size = new System.Drawing.Size(149, 23);
            this.btn_subscribe.TabIndex = 2;
            this.btn_subscribe.Text = "Connect and subscribe";
            this.btn_subscribe.UseVisualStyleBackColor = true;
            this.btn_subscribe.Click += new System.EventHandler(this.btn_subscribe_Click);
            // 
            // btn_Unsubscribe
            // 
            this.btn_Unsubscribe.Location = new System.Drawing.Point(170, 54);
            this.btn_Unsubscribe.Name = "btn_Unsubscribe";
            this.btn_Unsubscribe.Size = new System.Drawing.Size(122, 23);
            this.btn_Unsubscribe.TabIndex = 3;
            this.btn_Unsubscribe.Text = "Unsubscribe all topics";
            this.btn_Unsubscribe.UseVisualStyleBackColor = true;
            this.btn_Unsubscribe.Click += new System.EventHandler(this.btn_Unsubscribe_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(12, 99);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(53, 13);
            this.lbl_Message.TabIndex = 4;
            this.lbl_Message.Text = "Message:";
            // 
            // rchTxtBox_Message
            // 
            this.rchTxtBox_Message.Location = new System.Drawing.Point(71, 99);
            this.rchTxtBox_Message.Name = "rchTxtBox_Message";
            this.rchTxtBox_Message.Size = new System.Drawing.Size(221, 182);
            this.rchTxtBox_Message.TabIndex = 5;
            this.rchTxtBox_Message.Text = "";
            // 
            // Mosquitto_Sub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 328);
            this.Controls.Add(this.rchTxtBox_Message);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btn_Unsubscribe);
            this.Controls.Add(this.btn_subscribe);
            this.Controls.Add(this.txtBox_domain);
            this.Controls.Add(this.lbl_domain);
            this.Name = "Mosquitto_Sub";
            this.Text = "Subscriber";
            this.Load += new System.EventHandler(this.Mosquitto_Sub_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_domain;
        private System.Windows.Forms.TextBox txtBox_domain;
        private System.Windows.Forms.Button btn_subscribe;
        private System.Windows.Forms.Button btn_Unsubscribe;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.RichTextBox rchTxtBox_Message;
    }
}