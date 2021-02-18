using System;
using System.Diagnostics;
using System.IO;
using Renci.SshNet;
using Serilog;
using Serilog.Core;

namespace SystemInteract.Remote
{
    public class SshFactory : ISystemFactory
    {
        public static ILogger Log { get; set; } = Logger.None;
        private readonly SshClient _connection;
        private readonly SftpClient _sftp;

        public SshFactory(String host, String username, String password)
        {
            _connection = new SshClient(host, username, password);
            _connection.Connect();
            _sftp = new SftpClient(_connection.ConnectionInfo);
            _sftp.Connect();
        }
        public ISystemProcess StartProcess(String command, String arguments)
        {
            return Remote.SshProcess.Start(new ProcessStartInfo(command, arguments), _connection);
        }

        public Stream Open(string path, FileMode mode, FileAccess access)
        {
            return new Remote.SshFileStream(_sftp.Open(path, mode, access));
        }
    }
}
