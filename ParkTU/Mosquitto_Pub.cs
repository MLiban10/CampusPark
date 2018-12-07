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

namespace ParkTU
{
    public partial class Mosquitto_Pub : Form
    {
        MqttClient client = null;
        string[] topics = { "ParkSS" , "ParkDACE", "ParkTU" };

        public Mosquitto_Pub()
        {
            InitializeComponent();
            new Mosquitto_Sub().Show();
        }

        private void btn_connectBroker_Click(object sender, EventArgs e)
        {
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                MessageBox.Show("Unnable to connect to Broker");
            }
            else
            {
                btn_Publish.Enabled = true; //botao do publish
            }
        }

        private void btn_Publish_Click(object sender, EventArgs e)
        {
            string selectedTopic = combBox_topic.SelectedValue.ToString();
            byte[] msg = Encoding.UTF8.GetBytes(txtBox_Message.Text + "\n");

            client.Publish(selectedTopic, msg);
        }
        
        private void Mosquitto_Pub_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }

        private void Mosquitto_Pub_Load(object sender, EventArgs e)
        {
            client = new MqttClient(txtBox_brokerDomain.Text);

            combBox_topic.DataSource = topics;
            combBox_topic.SelectedIndex = 2;
        }
    }
}
