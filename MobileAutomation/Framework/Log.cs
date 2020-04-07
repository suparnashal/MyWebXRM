using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileAutomation.Framework
{
    public static class Log
    {        
        private static readonly string logFileName = $"Logfile_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.log";

        private static StreamWriter _writer;

        /// <summary>
        /// Create a log file in preset directory        
        /// </summary>
        public static void CreateLogFile()
        {
            string file = Path.Combine(@"C:\ss_carxrm\CodeMaster\Logs\",logFileName);
            _writer = File.AppendText(file);
            _writer.WriteLine($"Test run started : {DateTime.Now}");
            _writer.Flush();
        }
    }
}
