using Smart_Park.Models;
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

        public string ConfigXmlFilePath { get; set; }
        public string ConfigXsdFilePath { get; set; }
        public string BotXmlFilePath { get; set; }
        public string BotXsdFilePath { get; set; }
        private bool isValid = true;
        private string validationMessage;

        public HandlerXML(string xmlFilePath, string xsdFilePath)
        {
            ConfigXmlFilePath = xmlFilePath;
            ConfigXsdFilePath = xsdFilePath;
        }

        public void HandlerBotXML(string xmlFilePath, string xsdFilePath)
        {
            BotXmlFilePath = xmlFilePath;
            BotXsdFilePath = xsdFilePath;
        }

        public HandlerXML(string xmlFilePath)
        {
            ConfigXmlFilePath = xmlFilePath;
        }

        public void LoadBotXML(string xmlFilePath)
        {
            BotXmlFilePath = xmlFilePath;
        }

        public string ValidationMessage
        {
            get { return validationMessage; }
        }


        public bool ValidateXmlConfigFile()
        {
            isValid = true;
            validationMessage = "Document valid!";
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigXmlFilePath);
            ValidationEventHandler evento = new ValidationEventHandler(myEvent);

            doc.Schemas.Add(null, ConfigXsdFilePath);
            doc.Validate(evento);

            return isValid;
        }

        public bool ValidateXmlBotFile()
        {
            isValid = true;
            validationMessage = "Document valid!";
            XmlDocument doc = new XmlDocument();
            doc.Load(BotXmlFilePath);
            ValidationEventHandler evento = new ValidationEventHandler(myEvent);

            doc.Schemas.Add(null, BotXsdFilePath);
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

        public List<ParkingSpot> GetBotSpots()
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigXmlFilePath);

            XmlNodeList filtro = doc.SelectNodes("/spots/parkingSpot");

            foreach (XmlNode spot in filtro)
            {
                ParkingSpot s = new ParkingSpot();
                s.Id = spot["id"].InnerText;
                s.Type = spot["type"].InnerText;
                s.Name = spot["name"].InnerText;
                s.Location = spot["location"].InnerText;
                s.BateryStatus = int.Parse(spot["batteryStatus"].InnerText);
                s.Value = spot["value"].InnerText;
                s.Timestamp = spot["timestamp"].InnerText;

                spots.Add(s);
            }

            return spots;
        }
    }
}

/*
<spots>
  <parkingSpot>
    <id>Campus_2_B_Park2</id>
    <type>ParkingSpot</type>
    <name>B-1</name>
    <location></location>
    <status>
      <value>free</value>
      <timestamp>???</timestamp>
    </status>
    <batteryStatus>0</batteryStatus>
  </parkingSpot>
</spots>
*/
