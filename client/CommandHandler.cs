using System.Threading;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;

namespace client
{
    public class CommandHandler
    {
        public Dictionary<string, Action> commands = new Dictionary<string, Action>();

        public void MapAction(string type, Action action)
        {
            this.commands[type] = action;
        }

        public void HandleMessage(string message)
        {
            try
            {
                Message m = JsonSerializer.Deserialize<Message>(message);
                Console.WriteLine("Received action: " + m.action);

                Process.Start(this.commands[m.action].process);

            }
            catch(Exception e) {
                Console.WriteLine("CAUGHT EXCEPTION: " + e.Message);
            }
        }
    }
}
