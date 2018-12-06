using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Park_DACE
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxXmlFile.Text = openFileDialog.FileName;
            }
        }


        private void buttonValidate_Click(object sender, EventArgs e)
        {

            string xml = textBoxXmlFile.Text;

            HandlerXML handler = new HandlerXML(xml);
            handler.LoadConfigurations();

            this.Close();
            //FormDACE.richTextBoxLog.Text += "Reading Configurations from XML... Successfull" + "\n";
            //FormDACE.richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";

        }
    }
}
