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
    public class ServiceBOTSpotSensors : IServiceBOTSpotSensors
    {
        string m_strPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "App_Data\\soap_BOT.xml";

        public void AddParkingSpot(ParkingSpot c_new_parkingSpot)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNode root = doc.SelectSingleNode("/park");
            XmlElement spot = doc.CreateElement("parkingSpot");

            XmlElement id = doc.CreateElement("id");
            id.InnerText = c_new_parkingSpot.StrId;
            spot.AppendChild(id);

            XmlElement type = doc.CreateElement("type");
            type.InnerText = c_new_parkingSpot.StrType;
            spot.AppendChild(type);

            XmlElement name = doc.CreateElement("name");
            name.InnerText = c_new_parkingSpot.StrName;
            spot.AppendChild(name);

            XmlElement location = doc.CreateElement("location");
            location.InnerText = c_new_parkingSpot.StrLocation;
            spot.AppendChild(location);

            XmlElement status = doc.CreateElement("status");

            XmlElement value = doc.CreateElement("value");
            value.InnerText = c_new_parkingSpot.StrValue;
            status.AppendChild(value);

            XmlElement timeStamp = doc.CreateElement("timestamp");
            timeStamp.InnerText = Convert.ToString(c_new_parkingSpot.DateTimeStamp, NumberFormatInfo.InvariantInfo);
            status.AppendChild(timeStamp);


            spot.AppendChild(status);

            XmlElement batteryStatus = doc.CreateElement("batteryStatus");
            batteryStatus.InnerText = Convert.ToString(c_new_parkingSpot.IntBatteryStatus, NumberFormatInfo.InvariantInfo);
            spot.AppendChild(batteryStatus);

            root.AppendChild(spot);
            doc.Save(m_strPath);
        }


        public List<ParkingSpot> GetParkingSpots()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNodeList list = doc.SelectNodes("//parkingSpot");

            List<ParkingSpot> anParkingSpot = new List<ParkingSpot>();

            foreach (XmlNode n in list)
            {
                ParkingSpot cParkingSpot = new ParkingSpot(n["id"].InnerText, n["type"].InnerText, n["name"].InnerText,
                    n["location"].InnerText, n["status"].SelectSingleNode("value").InnerText,
                    Convert.ToDateTime(n["status"].SelectSingleNode("timestamp").InnerText, NumberFormatInfo.InvariantInfo),
                    Convert.ToInt32(n["batteryStatus"].InnerText, NumberFormatInfo.InvariantInfo));
                anParkingSpot.Add(cParkingSpot);
            }

            return anParkingSpot;
        }


        public String GetParkingSpotsXpath()
        {
            CreateParkingSpots(10);

            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);

            XmlNodeList lst = doc.SelectNodes("//parkingSpot");

            String strParkingSpot = string.Empty;

            foreach (XmlNode n in lst)
            {
                strParkingSpot = strParkingSpot
                    + n["id"].InnerText + ";"
                    + n["type"].InnerText + ";"
                    + n["name"].InnerText + ";"
                    + n["location"].InnerText + ";"
                    + n["status"].SelectSingleNode("value").InnerText + ";"
                    + Convert.ToDateTime(n["status"].SelectSingleNode("timestamp").InnerText, NumberFormatInfo.InvariantInfo) + ";"
                    + Convert.ToInt32(n["batteryStatus"].InnerText, NumberFormatInfo.InvariantInfo)
                    + Environment.NewLine;
            }
            Console.WriteLine(strParkingSpot);
            return strParkingSpot;
        }

        private void CreateParkingSpots(int spotsNumber)
        {
            //Remove all parkingSpots
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strPath);
            XmlNodeList list = doc.SelectNodes("/park/parkingSpot");
            XmlNode root = doc.SelectSingleNode("/park");

            foreach (XmlNode n in list)
            {
                root.RemoveChild(n);
            }
            doc.Save(m_strPath);

            //And then, add a parkingSpot
            Random random = new Random();
            string[] values = new string[] { "free", "busy" };
            for (int i = 1; i <= spotsNumber; i++)
            {
                ParkingSpot parkingSpot = new ParkingSpot(
                    "Campus_2_B_Park1",
                    "ParkingSpot",
                    "B-" + i,
                    "", values[random.Next(values.Count())],
                    DateTime.Now,
                    random.Next(1));

                AddParkingSpot(parkingSpot);
            }
        }

    }
}
