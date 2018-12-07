using Park_DACE.Models;
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
        public string BotXmlFilePath { get; set; }
        public string BotXsdFilePath { get; set; }
        private bool isValid = true;
        private string validationMessage;
        public static List<ParkingSpot> spots = new List<ParkingSpot>();


        public static List<Configuration> configurations = new List<Configuration>();

        public HandlerXML(string xmlFilePath)
        {
            ConfigXmlFilePath = xmlFilePath;
        }

        public void HandlerBotXML(string xmlFilePath, string xsdFilePath)
        {
            BotXmlFilePath = xmlFilePath;
            BotXsdFilePath = xsdFilePath;
        }

        public void LoadBotXML(string xmlFilePath)
        {
            BotXmlFilePath = xmlFilePath;
        }

        public string ValidationMessage
        {
            get { return validationMessage; }
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
            XmlDocument doc = new XmlDocument();
            doc.Load(BotXmlFilePath);

            XmlNodeList filtro = doc.SelectNodes("/spots/parkingSpot");

            foreach (XmlNode spot in filtro)
            {
                ParkingSpot s = new ParkingSpot();
                s.Id = spot["id"].InnerText;
                s.Type = spot["type"].InnerText;
                s.Name = spot["name"].InnerText;
                s.Location = spot["location"].InnerText;
                s.BateryStatus = int.Parse(spot["batteryStatus"].InnerText);
                s.Value = Boolean.Parse(spot["value"].InnerText);
                s.Timestamp = spot["timestamp"].InnerText;

                spots.Add(s);
            }

            return spots;
        }

        public void LoadConfigurations()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigXmlFilePath);

            XmlNodeList filtro = doc.SelectNodes("/parkingLocation/provider");
            configurations.Clear();

            foreach (XmlNode spot in filtro)
            {
                Configuration c = new Configuration();
                c.connectionType = spot["connectionType"].InnerText;
                c.endpoint = spot["endpoint"].InnerText;

                c.id = spot["parkInfo"].SelectSingleNode("id").InnerText;
                c.description = spot["parkInfo"].SelectSingleNode("description").InnerText;
                c.numberOfSpots = int.Parse(spot["parkInfo"].SelectSingleNode("numberOfSpots").InnerText);
                c.operatingHours = spot["parkInfo"].SelectSingleNode("operatingHours").InnerText;
                c.numberOfSpecialSpots = int.Parse(spot["parkInfo"].SelectSingleNode("numberOfSpecialSpots").InnerText);
                c.geoLocationFile = spot["parkInfo"].SelectSingleNode("geoLocationFile").InnerText;

                configurations.Add(c);
            }

        }

        public static String getDLLConfiguration()
        {
            foreach (Configuration configuration in configurations)
            {
                if (configuration.connectionType.Equals("DLL"))
                {
                    return ("Connection Type: " + configuration.connectionType.ToString() + "\n"
                        + "Endpoint: " + configuration.endpoint.ToString() + "\n"
                        + "Id: " + configuration.id.ToString() + "\n"
                        + "Description: " + configuration.description.ToString() + "\n"
                        + "Number Of Spots: " + configuration.numberOfSpots.ToString() + "\n"
                        + "Operating Hours: " + configuration.operatingHours.ToString() + "\n"
                        + "Number Of Special Spots: " + configuration.numberOfSpecialSpots.ToString() + "\n"
                        + "GeoLocation File: " + configuration.geoLocationFile.ToString() + "\n");
                }
            }
            return null;
        }

        public static String getSOAPConfiguration()
        {
            foreach (Configuration configuration in configurations)
            {
                if (configuration.connectionType.Equals("SOAP"))
                {
                    return ("Connection Type: " + configuration.connectionType.ToString() + "\n"
                        + "Endpoint: " + configuration.endpoint.ToString() + "\n"
                        + "Id: " + configuration.id.ToString() + "\n"
                        + "Description: " + configuration.description.ToString() + "\n"
                        + "Number Of Spots: " + configuration.numberOfSpots.ToString() + "\n"
                        + "Operating Hours: " + configuration.operatingHours.ToString() + "\n"
                        + "Number Of Special Spots: " + configuration.numberOfSpecialSpots.ToString() + "\n"
                        + "GeoLocation File: " + configuration.geoLocationFile.ToString() + "\n");
                }
            }
            return null;
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
