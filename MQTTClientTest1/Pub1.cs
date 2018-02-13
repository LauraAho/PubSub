using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest1
{
    class Pub1
    {
		static void Main(string[] args)
		{
			System.Console.WriteLine("start");
			// Create Client instance
			MqttClient myClient = new MqttClient("192.168.28.128");


			//Publisher
			string clientId = Guid.NewGuid().ToString();
			myClient.Connect(clientId);
			myClient.ProtocolVersion = MqttProtocolVersion.Version_3_1;
			double temp = 0;
			for (int i = 0; i < 1000; i++)
			{
				// create simulated measurements
				temp = Math.Sin(i / 50.0 + 10000);
				string value = Convert.ToString(temp);
				myClient.Publish("temperature", Encoding.UTF8.GetBytes(value));

				Thread.Sleep(1000);
			}

		}
    }
}
