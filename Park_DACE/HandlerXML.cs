using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Park_DACE
{
    class HandlerXML
    {
        public HandlerXML(string xmlFilePath, string xsdFilePath)
        {
            XmlFilePath = xmlFilePath;
            XsdFilePath = xsdFilePath;
        }

        public HandlerXML(string xmlFilePath)
        {
            XmlFilePath = xmlFilePath;
        }

        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }
        private string validationMessage;

        public string ValidationMessage
        {
            get { return validationMessage; }
        }

        private bool isValid = true;

        public bool ValidateXmlFile()
        {
            isValid = true;
            validationMessage = "Document valid!";
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);
            ValidationEventHandler evento = new ValidationEventHandler(myEvent);

            doc.Schemas.Add(null, XsdFilePath);
            doc.Validate(evento);

            return isValid;
        }

        private void myEvent(object sender, ValidationEventArgs e)
        {
            isValid = false;

            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    validationMessage = "[ERRO] : " + e.Message;
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = "[WARNING] : " + e.Message;
                    break;
                default:
                    validationMessage = "Unknow error! Document not VALID!";
                    break;
            }
        }

        /* --- Para Referencia ---
        public List<String> GetTitles()
        {
            List<String> titulos = new List<String>();
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            XmlNodeList filtro = doc.SelectNodes("/bookstore/book/title");

            foreach (XmlNode item in filtro)
            {
                titulos.Add(item.InnerText);
            }

            return titulos;
        }

        public bool UpdateBookAuthor(String titulo, String novoAutor)
        {
            bool updated = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            XmlNode autor = doc.SelectSingleNode("/bookstore/book[titles='" + titulo + "']/author");

            if (autor != null)
            {
                autor.InnerText = novoAutor;
                doc.Save(XmlFilePath);
                updated = true;
                return updated;

            }

            return false;
        }
        */
    }
}
