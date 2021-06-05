using System;
using System.Threading;
using WebSocketSharp;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebSocket socket = new WebSocket("ws://192.168.0.23:8888"))

            {
                socket.OnOpen += (sender, e) =>
                {
                    Console.WriteLine("Connection established");

                };

                socket.OnMessage += (sender, e) =>
                {
                    Console.WriteLine(e.Data);
                };

                socket.OnError += (sender, e) =>
                {
                    Console.WriteLine(e.Message);
                };

                socket.Connect();

                while (true)
                {
                    socket.Send("yup");
                    Thread.Sleep(1000);
                }


            }
            Console.WriteLine("Hello World!");
        }
    }
}
