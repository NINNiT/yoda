using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.MapAction("flick-north", new Action(application: "firefox"));

            Client client = new Client(id: "client1", commandHandler: commandHandler);
            client.Start("192.168.0.23:3000");
        }
    }

}
