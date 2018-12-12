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

namespace ParkSS_SS
{
    public partial class Form1 : Form
    {
        MqttClient client = null;
        string[] topics = { "ParkSS", "ParkDACE", "ParkTU" };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                richTextBoxSS.AppendText("Unnable to connect with Broker");
            }
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            byte[] qos = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            client.Subscribe(topics, qos);
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                richTextBoxSS.AppendText($"{e.Topic}: {(Encoding.UTF8.GetString(e.Message)).ToString()}");
                richTextBoxSS.AppendText("--------------------------------------------------------"+
                    Environment.NewLine);
            });
        }

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Unsubscribe(topics);
            }
        }

        private void ParkSS_Load(object sender, EventArgs e)
        {
            client = new MqttClient(textBoxIP.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }

        private void TransformStringInSpots(String spots)
        {
            String[] spot = spots.Split(';');//Cada spot corresponde a uma string;
            
        }
    }
}
