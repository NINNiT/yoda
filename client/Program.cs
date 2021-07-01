namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHandler commandHandler = new CommandHandler();

            commandHandler.MapAction("tap-south", new Action(
                application: "firefox"));

            commandHandler.MapAction("tap-west", new Action(
                application: "nightmode"));

            commandHandler.MapAction("flick-west", new Action(
                application: "i3-msg",
                arguments: "workspace next"));

            commandHandler.MapAction("flick-east", new Action(
                application: "i3-msg",
                arguments: "workspace prev"));

            commandHandler.MapAction("flick-south", new Action(
                application: "i3-msg",
                arguments: "kill"));

            Client client = new Client(id: "client1", commandHandler: commandHandler);
            client.Start("192.168.0.23:3000");
        }
    }

}
