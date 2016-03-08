using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemInteract
{
    public class ProcessHelper
    {
        private const int DefaultTimeout = 120;
        public static void ReadToEnd(ISystemProcess process, out String output, out String error, int timeout = 120)
        {
            String toutput = "";
            String terror = "";

            DataReceivedEventHandler errorEvent = (a, b) => terror += b.Data;
            DataReceivedEventHandler outEvent = (a, b) => toutput += b.Data;

            process.ErrorDataReceived += errorEvent;
            process.OutputDataReceived += outEvent;

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            if (!process.WaitForExit(timeout * 1000))
            {
                throw new TimeoutException(String.Format("Timeout. Process did not complete executing within {0} seconds", timeout));
            }

            output = toutput;
            error = terror;

            process.ErrorDataReceived -= errorEvent;
            process.OutputDataReceived -= outEvent;
        }

        public static void WaitForExit(ISystemProcess process)
        {
            String temp;

            ReadToEnd(process, out temp, out temp);
        }
    }
}
