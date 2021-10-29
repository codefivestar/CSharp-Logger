using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_How_to_open_and_append_to_a_log_file
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger("DBA Rules !");
        }


        public static void Logger(string logMessage)
        {
            string log_path, log_file;
            log_path = Path.Combine(Environment.CurrentDirectory, "logs");

            DirectoryInfo di = new DirectoryInfo(log_path);

            if (!di.Exists)
            {
                di.Create();
            }

            log_file = Path.Combine(log_path, "logger_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");

            using (StreamWriter w = File.AppendText(log_file))
            {
                Log(logMessage, w);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($" { DateTime.Now.ToLongTimeString() } { DateTime.Now.ToLongDateString() }");
            w.WriteLine("  :");
            w.WriteLine($"  : { logMessage }");
            w.WriteLine("-------------------------------");
        }

    }
}
