using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttWebClient
{
    public partial class Dashboard : System.Web.UI.Page
    {
        MqttClient client = new MqttClient("broker.hivemq.com");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            byte code = client.Connect(Guid.NewGuid().ToString());
            ushort msgId = client.Subscribe(new string[] { "keppa", "/iottest" },
            new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                         MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            Sensor1.Text = "0.00";
            Sensor2.Text = "0.00";
            Session["T1"] = "0.00";
            Session["H1"] = "0.00";
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e != null)
            {
                if (e.Topic.Equals("keppa"))
                {
                    var msg = Encoding.UTF8.GetString(e.Message);

                    if (msg.Contains(","))
                    {
                        string[] msgArray = msg.Split(',');

                        if (msgArray[0].Equals("T1"))
                            Session["T1"] = msgArray[1];

                        if (msgArray[0].Equals("H1"))
                            Session["H1"] = msgArray[1];
                    }
                }
            }
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Sensor1.Text = Session["T1"].ToString();
            Sensor2.Text = Session["H1"].ToString();
        }
    }
}