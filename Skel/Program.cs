using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace netUtils
{
    public class verbose
    {
        public static System.Threading.Thread thread;
        public static bool enabled = false;
        public static string text = "";
        public static int sleepInterval = 100;

        public static void write(string input, bool bold = false, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string callername = "", [CallerFilePath] string filePath = "")
        {
            text += $"{filePath}:{lineNumber} | {callername} | {input}\r\n";
        }
        public static void createWindow()
        {
            using (verboseForm vF = new verboseForm())
            {
                vF.ShowDialog();
            }
        }

        public static void check()
        {
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (String.Equals(arg, "-v", StringComparison.OrdinalIgnoreCase) || String.Equals(arg, "--verbose", StringComparison.OrdinalIgnoreCase))
                {
                    enabled = true;
                    thread = new System.Threading.Thread(createWindow);
                    thread.Start();
                    break;
                }
            }
        }
        public static void close()
        {
            if (enabled)
            {
                    thread.Abort();
            }
        }
    }
       
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
