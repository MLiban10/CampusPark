namespace ParkDashboard
{
    partial class FormParkDashboard
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
            this.btnAllSpots = new System.Windows.Forms.Button();
            this.richTextBoxSpots = new System.Windows.Forms.RichTextBox();
            this.btnReplaceSensors = new System.Windows.Forms.Button();
            this.comboBoxSpots = new System.Windows.Forms.ComboBox();
            this.btnSpotInfo = new System.Windows.Forms.Button();
            this.comboBoxParks = new System.Windows.Forms.ComboBox();
            this.btnParkPercentage = new System.Windows.Forms.Button();
            this.btnParkSpots = new System.Windows.Forms.Button();
            this.btnParkSensors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllSpots
            // 
            this.btnAllSpots.Location = new System.Drawing.Point(208, 12);
            this.btnAllSpots.Name = "btnAllSpots";
            this.btnAllSpots.Size = new System.Drawing.Size(75, 23);
            this.btnAllSpots.TabIndex = 0;
            this.btnAllSpots.Text = "GetAllSpots";
            this.btnAllSpots.UseVisualStyleBackColor = true;
            this.btnAllSpots.Click += new System.EventHandler(this.btnAllSpots_Click);
            // 
            // richTextBoxSpots
            // 
            this.richTextBoxSpots.Location = new System.Drawing.Point(13, 12);
            this.richTextBoxSpots.Name = "richTextBoxSpots";
            this.richTextBoxSpots.Size = new System.Drawing.Size(189, 342);
            this.richTextBoxSpots.TabIndex = 1;
            this.richTextBoxSpots.Text = "";
            // 
            // btnReplaceSensors
            // 
            this.btnReplaceSensors.Enabled = false;
            this.btnReplaceSensors.Location = new System.Drawing.Point(208, 42);
            this.btnReplaceSensors.Name = "btnReplaceSensors";
            this.btnReplaceSensors.Size = new System.Drawing.Size(75, 49);
            this.btnReplaceSensors.TabIndex = 2;
            this.btnReplaceSensors.Text = "Check Critical Sensors";
            this.btnReplaceSensors.UseVisualStyleBackColor = true;
            this.btnReplaceSensors.Click += new System.EventHandler(this.btnReplaceSensors_Click);
            // 
            // comboBoxSpots
            // 
            this.comboBoxSpots.FormattingEnabled = true;
            this.comboBoxSpots.Location = new System.Drawing.Point(304, 12);
            this.comboBoxSpots.Name = "comboBoxSpots";
            this.comboBoxSpots.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSpots.TabIndex = 3;
            // 
            // btnSpotInfo
            // 
            this.btnSpotInfo.Enabled = false;
            this.btnSpotInfo.Location = new System.Drawing.Point(304, 42);
            this.btnSpotInfo.Name = "btnSpotInfo";
            this.btnSpotInfo.Size = new System.Drawing.Size(121, 23);
            this.btnSpotInfo.TabIndex = 4;
            this.btnSpotInfo.Text = "Spot Info";
            this.btnSpotInfo.UseVisualStyleBackColor = true;
            this.btnSpotInfo.Click += new System.EventHandler(this.btnSpotInfo_Click);
            // 
            // comboBoxParks
            // 
            this.comboBoxParks.FormattingEnabled = true;
            this.comboBoxParks.Location = new System.Drawing.Point(467, 14);
            this.comboBoxParks.Name = "comboBoxParks";
            this.comboBoxParks.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParks.TabIndex = 5;
            // 
            // btnParkPercentage
            // 
            this.btnParkPercentage.Enabled = false;
            this.btnParkPercentage.Location = new System.Drawing.Point(467, 42);
            this.btnParkPercentage.Name = "btnParkPercentage";
            this.btnParkPercentage.Size = new System.Drawing.Size(121, 36);
            this.btnParkPercentage.TabIndex = 6;
            this.btnParkPercentage.Text = "Get Ocupation Percentage for Park";
            this.btnParkPercentage.UseVisualStyleBackColor = true;
            this.btnParkPercentage.Click += new System.EventHandler(this.btnParkPercentage_Click);
            // 
            // btnParkSpots
            // 
            this.btnParkSpots.Enabled = false;
            this.btnParkSpots.Location = new System.Drawing.Point(467, 84);
            this.btnParkSpots.Name = "btnParkSpots";
            this.btnParkSpots.Size = new System.Drawing.Size(121, 23);
            this.btnParkSpots.TabIndex = 7;
            this.btnParkSpots.Text = "Get Spots For Park";
            this.btnParkSpots.UseVisualStyleBackColor = true;
            this.btnParkSpots.Click += new System.EventHandler(this.btnParkSpots_Click);
            // 
            // btnParkSensors
            // 
            this.btnParkSensors.Enabled = false;
            this.btnParkSensors.Location = new System.Drawing.Point(467, 114);
            this.btnParkSensors.Name = "btnParkSensors";
            this.btnParkSensors.Size = new System.Drawing.Size(121, 41);
            this.btnParkSensors.TabIndex = 8;
            this.btnParkSensors.Text = "Check Critical Sensors For Park";
            this.btnParkSensors.UseVisualStyleBackColor = true;
            this.btnParkSensors.Click += new System.EventHandler(this.btnParkSensors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnParkSensors);
            this.Controls.Add(this.btnParkSpots);
            this.Controls.Add(this.btnParkPercentage);
            this.Controls.Add(this.comboBoxParks);
            this.Controls.Add(this.btnSpotInfo);
            this.Controls.Add(this.comboBoxSpots);
            this.Controls.Add(this.btnReplaceSensors);
            this.Controls.Add(this.richTextBoxSpots);
            this.Controls.Add(this.btnAllSpots);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Park Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllSpots;
        private System.Windows.Forms.RichTextBox richTextBoxSpots;
        private System.Windows.Forms.Button btnReplaceSensors;
        private System.Windows.Forms.ComboBox comboBoxSpots;
        private System.Windows.Forms.Button btnSpotInfo;
        private System.Windows.Forms.ComboBox comboBoxParks;
        private System.Windows.Forms.Button btnParkPercentage;
        private System.Windows.Forms.Button btnParkSpots;
        private System.Windows.Forms.Button btnParkSensors;
    }
}

