using System;
using System.Threading;
using WebSocketSharp;

namespace client
{
    class Client
    {
        private string clientId;
        private CommandHandler commandHandler;

        public Client(string id, CommandHandler commandHandler)
        {
            this.clientId = id;
            this.commandHandler = commandHandler;
        }

        public void Start(string serverAdress)
        {
            using (WebSocket socket = new WebSocket("ws://" + serverAdress + "/"))

            {
                socket.OnOpen += (sender, e) =>
                {
                    Console.WriteLine("Connection established");

                };

                socket.OnMessage += (sender, e) =>
                {
                    commandHandler.HandleMessage(e.Data);
                };

                socket.OnError += (sender, e) =>
                {
                    Console.WriteLine(e.Message);
                };

                socket.Connect();
                socket.Send("Client " + this.clientId + "Connected");

                while (true)
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
