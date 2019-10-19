using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemInteract.Local;
using NUnit.Framework;

namespace SystemInteract.Tests
{
    [TestFixture]
    public class Class1
    {
        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        [TestCase]
        public void Test1()
        {
            if (IsLinux) return;
            LocalFactory lf = new LocalFactory();
            var process = lf.StartProcess("netstat", "/a /n");
            String output, error;
            ProcessHelper.ReadToEnd(process, out output, out error);
        }

        [TestCase]
        public void TestLong()
        {
            if (!IsLinux) return;
            LocalFactory lf = new LocalFactory();
            var process = lf.StartProcess(@"awk", "'{for(i=1;i<1000;i++)print \"test\"}' /proc/loadavg");
            String output, error;
            ProcessHelper.ReadToEnd(process, out output, out error);
        }

        
    }
}
