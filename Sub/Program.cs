using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Sub
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("start");
			// Create Client instance
			MqttClient myClient = new MqttClient("192.168.28.128");

			//Subscriber
			// Register to message received
			myClient.MqttMsgPublishReceived += client_recievedMessage;


			string clientId = Guid.NewGuid().ToString();
			myClient.Connect(clientId);

			// Subscribe to topic
			myClient.Subscribe(new String[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		}
		static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
		{
			// Handle message received
			var message = System.Text.Encoding.Default.GetString(e.Message);
			System.Console.WriteLine("Message received: " + message);
		}
	}

	
}
