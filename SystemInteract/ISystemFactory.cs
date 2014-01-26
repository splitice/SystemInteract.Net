using System;
using System.IO;

namespace SystemInteract
{
    public interface ISystemFactory
    {
        ISystemProcess StartProcess(String command, String arguments);
        Stream Open(string path, FileMode mode, FileAccess access);
    }
}