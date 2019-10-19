﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInteract
{
    public class ProcessHelper
    {
        private const int DefaultTimeout = 120;

        public static async Task StreamReadLineUntilEnd(StreamReader stream, Action<string> output)
        {
            while (!stream.EndOfStream)
            {
                var line = await stream.ReadLineAsync();
                output(line);
            }
        }
        public static void ReadToEnd(ISystemProcess process, Action<String> output, Action<String> error,
            int timeout = DefaultTimeout)
        {
            List<Task> tasks = new List<Task>();
            if (process.StartInfo.RedirectStandardError)
            {
                tasks.Add(Task.Run(()=>StreamReadLineUntilEnd(process.StandardError, error)));
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                tasks.Add(Task.Run(()=> StreamReadLineUntilEnd(process.StandardOutput, output)));
            }

            try
            {
                if (!process.WaitForExit(timeout * 1000))
                {
                    throw new TimeoutException(
                        String.Format("Timeout. Process did not complete executing within {0} seconds", timeout));
                }
            }
            finally
            {
                process.Close();
                Task.WaitAll(tasks.ToArray());
            }
        }


        public static void ReadToEnd(ISystemProcess process, out String output, out String error, int timeout = DefaultTimeout)
        {
            StringBuilder toutput = new StringBuilder();
            StringBuilder terror = new StringBuilder();

            ReadToEnd(process, a=>toutput.AppendLine(a), a=>terror.AppendLine(a), timeout);

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
