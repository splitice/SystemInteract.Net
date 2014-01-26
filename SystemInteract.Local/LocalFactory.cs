using System;
using System.Diagnostics;

namespace SystemInteract.Local
{
    class LocalFactory
    {
        public ISystemProcess StartProcess(String command, String arguments)
        {
            return Local.LocalProcess.Start(new ProcessStartInfo(command, arguments));
        }
    }
}
