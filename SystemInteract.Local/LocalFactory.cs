using System;
using System.Diagnostics;
using System.IO;

namespace SystemInteract.Local
{
    class LocalFactory : ISystemFactory
    {
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
