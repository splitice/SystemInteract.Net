using System;
using System.Diagnostics;
using Renci.SshNet;

namespace SystemInteract.Remote
{
    class SshFactory : ISystemFactory
    {
        private readonly SshClient _connection;

        public SshFactory(String host, String username, String password)
        {
            _connection = new SshClient(host, username, password);
            _connection.Connect();
        }
        public ISystemProcess StartProcess(String command, String arguments)
        {
            return Remote.SshProcess.Start(new ProcessStartInfo(command, arguments), _connection);
        }
    }
}
