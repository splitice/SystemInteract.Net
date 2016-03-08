using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemInteract
{
    public class ProcessHelper
    {
        public static void ReadToEnd(ISystemProcess process, out String output, out String error)
        {
            String toutput = "";
            String terror = "";

            DataReceivedEventHandler errorEvent = (a, b) => terror += b.Data;
            DataReceivedEventHandler outEvent = (a, b) => toutput += b.Data;

            process.ErrorDataReceived += errorEvent;
            process.OutputDataReceived += outEvent;

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.WaitForExit();

            output = toutput;
            error = terror;
        }

        public static void WaitForExit(ISystemProcess process)
        {
            String temp;

            ReadToEnd(process, out temp, out temp);
        }
    }
}
