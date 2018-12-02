using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BOT_SpotSensors
{
    [ServiceContract]
    public interface IServiceBOTSpotSensors
    {
        [OperationContract]
        void AddParkingSpot(ParkingSpot parkingSpot);

        [OperationContract]
        bool DeleteParkingSpots(string Id);

        [OperationContract]
        List<ParkingSpot> GetParkingSpots();

    }


    [DataContract]
    public class ParkingSpot
    {
        private string strId;
        private string strType;
        private string strName;
        private string strLocation;     //está dentro do status
        private string strValue;
        private DateTime dateTimeStamp;
        private int intBatteryStatus;

        public ParkingSpot(string id, string type, string name, string location, string value, DateTime timeStamp, int batteryStatus)
        {
            this.strId = id;
            this.strType = type;
            this.strName = name;
            this.strLocation = location;
            this.strValue = value;
            this.dateTimeStamp = timeStamp;
            this.intBatteryStatus = batteryStatus;
        }

        [DataMember]
        public string StrId { get => strId; set => strId = value; }
        [DataMember]
        public string StrType { get => strType; set => strType = value; }
        [DataMember]
        public string StrName { get => strName; set => strName = value; }
        [DataMember]
        public string StrLocation { get => strLocation; set => strLocation = value; }
        [DataMember]
        public string StrValue { get => strValue; set => strValue = value; }
        [DataMember]
        public DateTime DateTimeStamp { get => dateTimeStamp; set => dateTimeStamp = value; }
        [DataMember]
        public int IntBatteryStatus { get => intBatteryStatus; set => intBatteryStatus = value; }
    }
}
