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
            this.comboBoxHours = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMinutes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFreeSpotsForPark = new System.Windows.Forms.Button();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSpotParkStatus = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDLLConfig = new System.Windows.Forms.Button();
            this.btnSoapConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllSpots
            // 
            this.btnAllSpots.Location = new System.Drawing.Point(208, 67);
            this.btnAllSpots.Name = "btnAllSpots";
            this.btnAllSpots.Size = new System.Drawing.Size(75, 23);
            this.btnAllSpots.TabIndex = 0;
            this.btnAllSpots.Text = "GetAllSpots";
            this.btnAllSpots.UseVisualStyleBackColor = true;
            this.btnAllSpots.Visible = false;
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
            this.btnReplaceSensors.Location = new System.Drawing.Point(208, 12);
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
            this.comboBoxParks.Location = new System.Drawing.Point(449, 14);
            this.comboBoxParks.Name = "comboBoxParks";
            this.comboBoxParks.Size = new System.Drawing.Size(139, 21);
            this.comboBoxParks.TabIndex = 5;
            // 
            // btnParkPercentage
            // 
            this.btnParkPercentage.Enabled = false;
            this.btnParkPercentage.Location = new System.Drawing.Point(449, 42);
            this.btnParkPercentage.Name = "btnParkPercentage";
            this.btnParkPercentage.Size = new System.Drawing.Size(139, 36);
            this.btnParkPercentage.TabIndex = 6;
            this.btnParkPercentage.Text = "Get Ocupation Percentage for Park";
            this.btnParkPercentage.UseVisualStyleBackColor = true;
            this.btnParkPercentage.Click += new System.EventHandler(this.btnParkPercentage_Click);
            // 
            // btnParkSpots
            // 
            this.btnParkSpots.Enabled = false;
            this.btnParkSpots.Location = new System.Drawing.Point(449, 84);
            this.btnParkSpots.Name = "btnParkSpots";
            this.btnParkSpots.Size = new System.Drawing.Size(139, 23);
            this.btnParkSpots.TabIndex = 7;
            this.btnParkSpots.Text = "Get Spots For Park";
            this.btnParkSpots.UseVisualStyleBackColor = true;
            this.btnParkSpots.Click += new System.EventHandler(this.btnParkSpots_Click);
            // 
            // btnParkSensors
            // 
            this.btnParkSensors.Enabled = false;
            this.btnParkSensors.Location = new System.Drawing.Point(449, 114);
            this.btnParkSensors.Name = "btnParkSensors";
            this.btnParkSensors.Size = new System.Drawing.Size(139, 41);
            this.btnParkSensors.TabIndex = 8;
            this.btnParkSensors.Text = "Check Critical Sensors For Park";
            this.btnParkSensors.UseVisualStyleBackColor = true;
            this.btnParkSensors.Click += new System.EventHandler(this.btnParkSensors_Click);
            // 
            // comboBoxHours
            // 
            this.comboBoxHours.Enabled = false;
            this.comboBoxHours.FormattingEnabled = true;
            this.comboBoxHours.Location = new System.Drawing.Point(452, 232);
            this.comboBoxHours.Name = "comboBoxHours";
            this.comboBoxHours.Size = new System.Drawing.Size(56, 21);
            this.comboBoxHours.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hours";
            // 
            // comboBoxMinutes
            // 
            this.comboBoxMinutes.Enabled = false;
            this.comboBoxMinutes.FormattingEnabled = true;
            this.comboBoxMinutes.Location = new System.Drawing.Point(536, 232);
            this.comboBoxMinutes.Name = "comboBoxMinutes";
            this.comboBoxMinutes.Size = new System.Drawing.Size(55, 21);
            this.comboBoxMinutes.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Minutes";
            // 
            // btnFreeSpotsForPark
            // 
            this.btnFreeSpotsForPark.Enabled = false;
            this.btnFreeSpotsForPark.Location = new System.Drawing.Point(452, 259);
            this.btnFreeSpotsForPark.Name = "btnFreeSpotsForPark";
            this.btnFreeSpotsForPark.Size = new System.Drawing.Size(139, 36);
            this.btnFreeSpotsForPark.TabIndex = 13;
            this.btnFreeSpotsForPark.Text = "Get Free Spots For Park";
            this.btnFreeSpotsForPark.UseVisualStyleBackColor = true;
            this.btnFreeSpotsForPark.Click += new System.EventHandler(this.btnFreeSpotsForPark_Click);
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(449, 184);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(37, 21);
            this.comboBoxDay.TabIndex = 14;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(493, 184);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(37, 21);
            this.comboBoxMonth.TabIndex = 15;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(536, 184);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(48, 21);
            this.comboBoxYear.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Year";
            // 
            // btnSpotParkStatus
            // 
            this.btnSpotParkStatus.Location = new System.Drawing.Point(452, 302);
            this.btnSpotParkStatus.Name = "btnSpotParkStatus";
            this.btnSpotParkStatus.Size = new System.Drawing.Size(139, 34);
            this.btnSpotParkStatus.TabIndex = 20;
            this.btnSpotParkStatus.Text = "Get Status For Spot In a Park";
            this.btnSpotParkStatus.UseVisualStyleBackColor = true;
            this.btnSpotParkStatus.Click += new System.EventHandler(this.btnSpotParkStatus_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(208, 134);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(217, 202);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "";
            // 
            // btnDLLConfig
            // 
            this.btnDLLConfig.Location = new System.Drawing.Point(209, 105);
            this.btnDLLConfig.Name = "btnDLLConfig";
            this.btnDLLConfig.Size = new System.Drawing.Size(75, 23);
            this.btnDLLConfig.TabIndex = 22;
            this.btnDLLConfig.Text = "DLL Config";
            this.btnDLLConfig.UseVisualStyleBackColor = true;
            this.btnDLLConfig.Click += new System.EventHandler(this.btnDLLConfig_Click);
            // 
            // btnSoapConfig
            // 
            this.btnSoapConfig.Location = new System.Drawing.Point(304, 105);
            this.btnSoapConfig.Name = "btnSoapConfig";
            this.btnSoapConfig.Size = new System.Drawing.Size(88, 23);
            this.btnSoapConfig.TabIndex = 23;
            this.btnSoapConfig.Text = "SOAP Config";
            this.btnSoapConfig.UseVisualStyleBackColor = true;
            this.btnSoapConfig.Click += new System.EventHandler(this.btnSoapConfig_Click);
            // 
            // FormParkDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 366);
            this.Controls.Add(this.btnSoapConfig);
            this.Controls.Add(this.btnDLLConfig);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSpotParkStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.btnFreeSpotsForPark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMinutes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHours);
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
            this.Name = "FormParkDashboard";
            this.Text = "Park Dashboard";
            this.Load += new System.EventHandler(this.FormParkDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox comboBoxHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMinutes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFreeSpotsForPark;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSpotParkStatus;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDLLConfig;
        private System.Windows.Forms.Button btnSoapConfig;
    }
}

