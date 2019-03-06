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

        public static void ReadToEnd(ISystemProcess process, Action<String> output, Action<String> error,
            int timeout = DefaultTimeout)
        {
            DataReceivedEventHandler errorEvent = null, outEvent = null;

            if (process.StartInfo.RedirectStandardError)
            {
                errorEvent = (a, b) => error(b.Data);
                process.ErrorDataReceived += errorEvent;
                process.BeginErrorReadLine();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                outEvent = (a, b) => output(b.Data);
                process.OutputDataReceived += outEvent;
                process.BeginOutputReadLine();
            }

            if (!process.WaitForExit(timeout * 1000))
            {
                throw new TimeoutException(String.Format("Timeout. Process did not complete executing within {0} seconds", timeout));
            }

            if (errorEvent != null)
            {
                process.ErrorDataReceived -= errorEvent;
            }
            if (outEvent != null)
            {
                process.OutputDataReceived -= outEvent;
            }
        }


        public static void ReadToEnd(ISystemProcess process, out String output, out String error, int timeout = DefaultTimeout)
        {
            StringBuilder toutput = new StringBuilder();
            StringBuilder terror = new StringBuilder();

            ReadToEnd(process, a=>toutput.AppendLine(a), a=>terror.AppendLine(a));

            output = toutput.ToString();
            error = terror.ToString();
        }

        public static void WaitForExit(ISystemProcess process)
        {
            String temp;

            ReadToEnd(process, out temp, out temp);
        }
    }
}
