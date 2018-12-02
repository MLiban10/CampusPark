using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace BOT_SpotSensors
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceBOTSpotSensors : IBOTSpotSensors
    {
        string m_strPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "App_Data\\xml_example_for_the_soap_BOT.xml";

        void AddParkingSpot(ParkingSpot c_new_parkingSpot)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNode root = doc.SelectSingleNode("/parkingSpot");

            XmlElement elem = doc.CreateElement("parkingSpot");
            XmlElement id = doc.CreateElement("id");
            XmlElement type = doc.CreateElement("type");
            XmlElement name = doc.CreateElement("name");
            XmlElement location = doc.CreateElement("location");
            XmlElement value = doc.CreateElement("value");
            XmlElement timeStamp = doc.CreateElement("timeStamp");
            XmlElement batteryStatus = doc.CreateElement("batteryStatus");

            id.InnerText = c_new_parkingSpot.strId;
            type.InnerText = c_new_parkingSpot.strType;
            name.InnerText = c_new_parkingSpot.strName;
            location.InnerText = c_new_parkingSpot.strLocation;
            value.InnerText = c_new_parkingSpot.strValue;
            timeStamp.InnerText = Convert.ToString(c_new_parkingSpot.dateTimeStamp, NumberFormatInfo.InvariantInfo);
            batteryStatus.InnerText = Convert.ToString(c_new_parkingSpot.intBatteryStatus, NumberFormatInfo.InvariantInfo);

            elem.AppendChild(id);
            elem.AppendChild(type);
            elem.AppendChild(name);
            elem.AppendChild(location);
            elem.AppendChild(value);
            elem.AppendChild(timeStamp);
            elem.AppendChild(batteryStatus);

            root.AppendChild(elem);
            doc.Save(m_strPath);
        }

        bool DeleteParkingSpots(string Id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNode n = doc.SelectSingleNode("/parkingSpot/id='" + id + "']");
            if (n == null)
            {
                return false;
            }

            XmlNode root = doc.SelectSingleNode("/parkingSpot");
            root.RemoveChild(n);

            return true;
        }

        List<ParkingSpot> GetParkingSpots()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNodeList list = doc.SelectNodes("/parkingSpot");

            List<ParkingSpot> anParkingSpot = new List<ParkingSpot>();

            foreach (XmlNode n in list)
            {
                ParkingSpot cParkingSpot = new ParkingSpot(n["id"].InnerText, n["type"].InnerText, n["name"].InnerText,
                    n["location"].InnerText, n["value"].InnerText,
                    Convert.ToDateTime(n["timeStamp"].InnerText, NumberFormatInfo.InvariantInfo),
                    Convert.ToInt32(n["batteryStatus"].InnerText, NumberFormatInfo.InvariantInfo));
                anParkingSpot.Add(cParkingSpot);
            }

            return anParkingSpot;
        }

    }
}
