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
        [TestCase]
        public void Test1()
        {
            LocalFactory lf = new LocalFactory();
            var process = lf.StartProcess("netstat", "/a /n");
            String output, error;
            ProcessHelper.ReadToEnd(process, out output, out error);
        }
    }
}
