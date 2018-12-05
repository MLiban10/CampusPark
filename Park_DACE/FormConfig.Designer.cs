namespace Park_DACE
{
    partial class FormConfig
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
            this.textBoxXmlFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.buttonXml = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxXmlFile
            // 
            this.textBoxXmlFile.Location = new System.Drawing.Point(62, 25);
            this.textBoxXmlFile.Name = "textBoxXmlFile";
            this.textBoxXmlFile.Size = new System.Drawing.Size(547, 22);
            this.textBoxXmlFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "XML: ";
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(549, 57);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(148, 35);
            this.buttonValidate.TabIndex = 4;
            this.buttonValidate.Text = "Load";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // buttonXml
            // 
            this.buttonXml.Location = new System.Drawing.Point(616, 22);
            this.buttonXml.Name = "buttonXml";
            this.buttonXml.Size = new System.Drawing.Size(81, 29);
            this.buttonXml.TabIndex = 5;
            this.buttonXml.Text = "Open";
            this.buttonXml.UseVisualStyleBackColor = true;
            this.buttonXml.Click += new System.EventHandler(this.buttonXml_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 100);
            this.Controls.Add(this.buttonXml);
            this.Controls.Add(this.buttonValidate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxXmlFile);
            this.Name = "FormConfig";
            this.Text = "Configuration Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxXmlFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Button buttonXml;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}