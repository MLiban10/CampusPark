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

        private void buttonXsd_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Schema files (*.xsd)|*.xsd";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxXsdFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            string xml = textBoxXmlFile.Text;
            string xsd = textBoxXsdFile.Text;

            HandlerXML handler = new HandlerXML(xml, xsd);
            bool valid = handler.ValidateXmlFile();

            MessageBox.Show(valid + Environment.NewLine + handler.ValidationMessage);
        }
    }
}
