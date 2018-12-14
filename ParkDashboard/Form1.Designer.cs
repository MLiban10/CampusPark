namespace ParkDashboard
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
            this.btnAllSpots = new System.Windows.Forms.Button();
            this.richTextBoxSpots = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnAllSpots
            // 
            this.btnAllSpots.Location = new System.Drawing.Point(13, 13);
            this.btnAllSpots.Name = "btnAllSpots";
            this.btnAllSpots.Size = new System.Drawing.Size(75, 23);
            this.btnAllSpots.TabIndex = 0;
            this.btnAllSpots.Text = "GetAllSpots";
            this.btnAllSpots.UseVisualStyleBackColor = true;
            this.btnAllSpots.Click += new System.EventHandler(this.btnAllSpots_Click);
            // 
            // richTextBoxSpots
            // 
            this.richTextBoxSpots.Location = new System.Drawing.Point(13, 42);
            this.richTextBoxSpots.Name = "richTextBoxSpots";
            this.richTextBoxSpots.Size = new System.Drawing.Size(189, 312);
            this.richTextBoxSpots.TabIndex = 1;
            this.richTextBoxSpots.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.richTextBoxSpots);
            this.Controls.Add(this.btnAllSpots);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Park Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllSpots;
        private System.Windows.Forms.RichTextBox richTextBoxSpots;
    }
}

