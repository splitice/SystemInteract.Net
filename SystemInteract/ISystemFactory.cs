using System;

namespace SystemInteract
{
    public interface ISystemFactory
    {
        ISystemProcess StartProcess(String command, String arguments);
    }
}