using System;
using System.Diagnostics;
using System.IO;
using Serilog;
using Serilog.Core;

namespace SystemInteract.Local
{
    public class LocalFactory : ISystemFactory
    {
        public static ILogger Log { get; set; } = Logger.None;

        public ISystemProcess StartProcess(String command, String arguments)
        {
            return Local.LocalProcess.Start(new ProcessStartInfo(command, arguments));
        }

        public Stream Open(string path, FileMode mode, FileAccess access)
        {
            return File.Open(path, mode);
        }
    }
}
