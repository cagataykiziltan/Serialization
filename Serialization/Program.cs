using System;

namespace Serialization
{
    class Program
    {

        static void Main(string[] args)
        {
            Message message = new Message
            {
                Sender = "Mustafa Cagatay KIZILTAN",
                Receiver = "Sample Receiver",
                MessageBody = "Sample  Message"
            };


            string serializedJsonMessage = Serializer.ToJson(message);
            Message deserializedJsonMessage = Serializer.FromJson<Message>(serializedJsonMessage);

            string serializedXmlMessage = Serializer.ToXml(message);
            Message deserializedXmlMessage = Serializer.FromXml<Message>(serializedXmlMessage);

            byte[] serializedBinaryMessage = Serializer.ToBinary(message);
            Message deserializedBinaryMessage = Serializer.FromBinary<Message>(serializedBinaryMessage);


            Console.ReadKey();

        }

    }
    
    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string MessageBody { get; set; }
    }
}
