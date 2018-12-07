namespace ParkTU
{
    partial class Mosquitto_Pub
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
            this.label_brokerDomain = new System.Windows.Forms.Label();
            this.txtBox_brokerDomain = new System.Windows.Forms.TextBox();
            this.btn_connectBroker = new System.Windows.Forms.Button();
            this.lbl_topic = new System.Windows.Forms.Label();
            this.combBox_topic = new System.Windows.Forms.ComboBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.txtBox_Message = new System.Windows.Forms.TextBox();
            this.btn_Publish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_brokerDomain
            // 
            this.label_brokerDomain.AutoSize = true;
            this.label_brokerDomain.Location = new System.Drawing.Point(12, 9);
            this.label_brokerDomain.Name = "label_brokerDomain";
            this.label_brokerDomain.Size = new System.Drawing.Size(78, 13);
            this.label_brokerDomain.TabIndex = 0;
            this.label_brokerDomain.Text = "Broker domain:";
            // 
            // txtBox_brokerDomain
            // 
            this.txtBox_brokerDomain.Location = new System.Drawing.Point(96, 7);
            this.txtBox_brokerDomain.Name = "txtBox_brokerDomain";
            this.txtBox_brokerDomain.Size = new System.Drawing.Size(166, 20);
            this.txtBox_brokerDomain.TabIndex = 1;
            this.txtBox_brokerDomain.Text = "127.0.0.1";
            // 
            // btn_connectBroker
            // 
            this.btn_connectBroker.Location = new System.Drawing.Point(289, 7);
            this.btn_connectBroker.Name = "btn_connectBroker";
            this.btn_connectBroker.Size = new System.Drawing.Size(105, 23);
            this.btn_connectBroker.TabIndex = 2;
            this.btn_connectBroker.Text = "Connect to broker";
            this.btn_connectBroker.UseVisualStyleBackColor = true;
            this.btn_connectBroker.Click += new System.EventHandler(this.btn_connectBroker_Click);
            // 
            // lbl_topic
            // 
            this.lbl_topic.AutoSize = true;
            this.lbl_topic.Location = new System.Drawing.Point(53, 54);
            this.lbl_topic.Name = "lbl_topic";
            this.lbl_topic.Size = new System.Drawing.Size(37, 13);
            this.lbl_topic.TabIndex = 3;
            this.lbl_topic.Text = "Topic:";
            // 
            // combBox_topic
            // 
            this.combBox_topic.FormattingEnabled = true;
            this.combBox_topic.Location = new System.Drawing.Point(96, 51);
            this.combBox_topic.Name = "combBox_topic";
            this.combBox_topic.Size = new System.Drawing.Size(298, 21);
            this.combBox_topic.TabIndex = 4;
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(37, 105);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(53, 13);
            this.lbl_message.TabIndex = 5;
            this.lbl_message.Text = "Message:";
            // 
            // txtBox_Message
            // 
            this.txtBox_Message.Location = new System.Drawing.Point(96, 102);
            this.txtBox_Message.Multiline = true;
            this.txtBox_Message.Name = "txtBox_Message";
            this.txtBox_Message.Size = new System.Drawing.Size(298, 100);
            this.txtBox_Message.TabIndex = 6;
            // 
            // btn_Publish
            // 
            this.btn_Publish.Location = new System.Drawing.Point(96, 208);
            this.btn_Publish.Name = "btn_Publish";
            this.btn_Publish.Size = new System.Drawing.Size(298, 23);
            this.btn_Publish.TabIndex = 7;
            this.btn_Publish.Text = "Publish";
            this.btn_Publish.UseVisualStyleBackColor = true;
            this.btn_Publish.Click += new System.EventHandler(this.btn_Publish_Click);
            // 
            // Mosquitto_Pub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 249);
            this.Controls.Add(this.btn_Publish);
            this.Controls.Add(this.txtBox_Message);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.combBox_topic);
            this.Controls.Add(this.lbl_topic);
            this.Controls.Add(this.btn_connectBroker);
            this.Controls.Add(this.txtBox_brokerDomain);
            this.Controls.Add(this.label_brokerDomain);
            this.Name = "Mosquitto_Pub";
            this.Text = "Publisher";
            this.Load += new System.EventHandler(this.Mosquitto_Pub_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_brokerDomain;
        private System.Windows.Forms.TextBox txtBox_brokerDomain;
        private System.Windows.Forms.Button btn_connectBroker;
        private System.Windows.Forms.Label lbl_topic;
        private System.Windows.Forms.ComboBox combBox_topic;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.TextBox txtBox_Message;
        private System.Windows.Forms.Button btn_Publish;
    }
}

