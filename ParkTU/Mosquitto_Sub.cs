using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ParkTU
{
    public partial class Mosquitto_Sub : Form
    {
        MqttClient client = null;
        string[] topics = { "ParkSS", "ParkDACE", "ParkTU" };

        public Mosquitto_Sub()
        {
            InitializeComponent();
        }

        private void Mosquitto_Sub_Load(object sender, EventArgs e)
        {
            client = new MqttClient(txtBox_domain.Text);
        }

        private void btn_subscribe_Click(object sender, EventArgs e)
        {
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                rchTxtBox_Message.AppendText("Unnable to connect with Broker");
            }
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            byte[] qos = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            client.Subscribe(topics, qos);
        }

        private void btn_Unsubscribe_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                client.Unsubscribe(topics);
            }
        }

        private void Mosquitto_Sub_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                rchTxtBox_Message.AppendText($"{e.Topic}: {(Encoding.UTF8.GetString(e.Message)).ToString()}");
            });
        }

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {

        }
    }
}
