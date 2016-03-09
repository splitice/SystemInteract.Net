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
        public static void ReadToEnd(ISystemProcess process, out String output, out String error, int timeout = DefaultTimeout)
        {
            String toutput = "";
            String terror = "";
            DataReceivedEventHandler errorEvent = null, outEvent = null;

            if (process.StartInfo.RedirectStandardError)
            {
                errorEvent = (a, b) => terror += b.Data;
                process.ErrorDataReceived += errorEvent;
                process.BeginErrorReadLine();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                outEvent = (a, b) => toutput += b.Data;
                process.OutputDataReceived += outEvent;
                process.BeginOutputReadLine();
            }

            if (!process.WaitForExit(timeout * 1000))
            {
                throw new TimeoutException(String.Format("Timeout. Process did not complete executing within {0} seconds", timeout));
            }

            output = toutput;
            error = terror;

            if (errorEvent != null)
            {
                process.ErrorDataReceived -= errorEvent;
            }
            if (outEvent != null)
            {
                process.OutputDataReceived -= outEvent;
            }
        }

        public static void WaitForExit(ISystemProcess process)
        {
            String temp;

            ReadToEnd(process, out temp, out temp);
        }
    }
}
