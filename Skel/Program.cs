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
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Net;

namespace netUtils
{
    public class misc
    {
        public static string dhcpOutputText = "";
        public static CancellationTokenSource dhcpCancelToken = new CancellationTokenSource();
        public static bool newTextDHCP = false;
        public struct dhcpOptions
        {
            public string poolStart;
            public string poolEnd;
            public int serverPort;
            public int clientPort;
        }

        public struct dhcpDatagram
        {
            public byte   op;
            public byte   htype;
            public byte   hlen;
            public byte   hops;
            public UInt32 xid;
            public UInt16 secs;
            public UInt16 flags;
            public UInt32 ciaddr;
            public UInt32 yiaddr;
            public UInt32 siaddr;
            public UInt32 giaddr;
            public byte[] chaddr;  // 16 bytes
            public byte[] sname;   // 64 bytes
            public byte[] file;    // 128 bytes
            public byte[] options; // variable length
        }

        public static void dhcpLog(string input)
        {
            dhcpOutputText += $"{input}\r\n";
            newTextDHCP = true;
        }

        public static string printPayload(List<byte> input)
        {
            string output = "";

            if (input.Count == 0)
            {
                return null;
            }

            for (int n = 0; n < input.Count; n++)
            {
                if (n % 1 == 0)
                {
                    output += "    ";
                }

                output += input[n].ToString("X2");

                //if ((n+1) % 4 == 0)
                if ((n+1) % 16 == 0)
                {
                    output += "\r\n";
                }
            }
            verbose.write($"PAYLOAD:\r\n{output}");
            return output;
        }

        public static bool dnsServerRunning = false;
        public static List<byte> icmpPacket = new List<byte>();

        public static UInt32 ip2Int(string input)
        {
            UInt32 output = 0;
            string pattern = @"(\d{0,3})\.(\d{0,3})\.(\d{0,3})\.(\d{0,3})";

            if (Regex.IsMatch(input, pattern))
            {
                Match match = Regex.Match(input, pattern);
                if (match.Groups.Count == 5)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        if (int.Parse(match.Groups[i].Value) < 0 || int.Parse(match.Groups[i].Value) > 255)
                        {
                            verbose.write($"Octet {i} [{int.Parse(match.Groups[i].Value)}] out of range. [0-255]");
                            return 0;
                        } else
                        {
                            output <<= 8;
                            output += UInt32.Parse(match.Groups[i].Value);
                        }
                    }
                    return output;
                }
                else
                {
                    verbose.write("IP address format incorrect.");
                    return 0;
                }
            }
            else
            {
                verbose.write("Invalid IP address.");
                return 0;
            }
        }

        public static bool validateIP(string input)
        {
            string pattern = @"(\d{0,3})\.(\d{0,3})\.(\d{0,3})\.(\d{0,3})";

            if (Regex.IsMatch(input, pattern))
            {
                Match match = Regex.Match(input, pattern);
                if (match.Groups.Count == 5)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        if (int.Parse(match.Groups[i].Value) < 0 || int.Parse(match.Groups[i].Value) > 255)
                        {
                            verbose.write($"Octet {i} [{int.Parse(match.Groups[i].Value)}] out of range. [0-255]");
                            return false;
                        }
                    }
                    return true;
                } else
                {
                    verbose.write("IP address format incorrect.");
                    return false;
                }
            } else
            {
                verbose.write("Invalid IP address.");
                return false;
            }
        }

        public static UInt16 calcCksum(List<byte> data)
        {
            UInt32 output = 0;

            // pad message to an even number of bytes
            if (data.Count % 2 != 0)
            {
                data.Add(0);
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (i % 2 != 0)
                {
                    output += ((UInt32)(data[i - 1]) << 8) + (UInt32)data[i];
                    output = (output & 0xFFFF) + (output >> 16);
                }
            }

            byte[] cksum = { 0, 0 };
            cksum[0] = (byte)(output >> 8);
            cksum[1] = (byte)(output << 8 >> 8);
            verbose.write($"XOR: 0x{cksum[0].ToString("X2")}{cksum[1].ToString("X2")} ^ 0xFFFF");
            cksum[0] = (byte)(cksum[0] ^ 0xFF);
            cksum[1] = (byte)(cksum[1] ^ 0xFF);

            verbose.write($"Checksum: 0x{cksum[0].ToString("X2")}{cksum[1].ToString("X2")}");
            return (UInt16)(((UInt16)cksum[0] << 8) + (UInt16)cksum[1]);
        }
    }
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
