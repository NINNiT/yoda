using System;
using System.Diagnostics;

namespace client
{
    public class Action
    {
        public ProcessStartInfo process;

        public Action(
            string application,
            string arguments = "",
            ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal,
            bool useShell = true)
        {
            this.process = new ProcessStartInfo(application, arguments);
            this.process.WindowStyle = windowStyle;
            this.process.UseShellExecute = useShell;
        }
    }

}
