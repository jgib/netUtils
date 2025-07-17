using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace netUtils
{
    public class dhcp
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int bufSize = 65535;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public void Server(string address, int port)
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        public void Client(string address, int port)
        {
            _socket.Connect(IPAddress.Parse(address), port);
            Receive();
        }
        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndSend(ar);
                verbose.Append($"SEND: {bytes}, {text}\r\n{misc.PrintPacket(data, bytes)}");
            }, state);
        }
        private void Receive()
        {
            _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                string logTxt = "";
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                verbose.Append($"RECV: {epFrom.ToString()}: {bytes}\r\n{misc.PrintPacket(so.buffer, bytes)}");
                dhcpPacket packet = dhcpParse(so.buffer, bytes);

                logTxt += "OP:     ";
                if (packet.op == 1)
                {
                    logTxt += "BOOTREQUEST";
                }
                if (packet.op == 2)
                {
                    logTxt += "BOOTREPLY";
                }
                logTxt += "\r\n";

                logTxt += "HTYPE:  ";
                if (packet.htype == 1)
                {
                    logTxt += "Ethernet (10Mb)\r\n";
                }
                else if (packet.htype == 2)
                {
                    logTxt += "Experimental Ethernet (3Mb)\r\n";
                }
                else if (packet.htype == 3)
                {
                    logTxt += "Amateur Radio AX.25\r\n";
                }
                else if (packet.htype == 4)
                {
                    logTxt += "Proteon ProNET Token Ring\r\n";
                }
                else if (packet.htype == 5)
                {
                    logTxt += "Chaos\r\n";
                }
                else if (packet.htype == 6)
                {
                    logTxt += "IEEE 802 Networks\r\n";
                }
                else if (packet.htype == 7)
                {
                    logTxt += "ARCNET\r\n";
                }
                else if (packet.htype == 8)
                {
                    logTxt += "Hyperchannel\r\n";
                }
                else if (packet.htype == 9)
                {
                    logTxt += "Lanstar\r\n";
                }
                else if (packet.htype == 10)
                {
                    logTxt += "Autonet Short Address\r\n";
                }
                else if (packet.htype == 11)
                {
                    logTxt += "LocalTalk\r\n";
                }
                else if (packet.htype == 12)
                {
                    logTxt += "LocalNet (IBM PCNet or SYTEK LocalNET)\r\n";
                }
                else if (packet.htype == 13)
                {
                    logTxt += "Ultra link\r\n";
                }
                else if (packet.htype == 14)
                {
                    logTxt += "SMDS\r\n";
                }
                else if (packet.htype == 15)
                {
                    logTxt += "Frame Replay\r\n";
                }
                else if (packet.htype == 16)
                {
                    logTxt += "Asynchronous Transmission Mode (ATM)\r\n";
                }
                else if (packet.htype == 17)
                {
                    logTxt += "HDLC\r\n";
                }
                else if (packet.htype == 18)
                {
                    logTxt += "Fibre Channel\r\n";
                }
                else if (packet.htype == 19)
                {
                    logTxt += "Asynchronous Transmission Mode (ATM)\r\n";
                }
                else if (packet.htype == 20)
                {
                    logTxt += "Serial Line\r\n";
                }
                else if (packet.htype == 21)
                {
                    logTxt += "Asynchronous Transmission Mode (ATM)\r\n";
                }
                else
                {
                    logTxt += $"[{packet.htype}]  See ARP section in \"Assigned Numbers\" RFC\r\n";
                }

                logTxt += "HLEN:   ";
                logTxt += $"{packet.hlen}\r\n";

                logTxt += "HOPS:   ";
                logTxt += $"{packet.hops}\r\n";

                logTxt += "XID:    ";
                logTxt += $"{packet.xid}\r\n";

                logTxt += "SECS:   ";
                logTxt += $"{packet.secs} seconds\r\n";

                logTxt += "FLAGS:  ";
                if ((packet.flags >> 15) == 1)
                {
                    logTxt += "BROADCAST";
                }
                if ((packet.flags >> 15) == 0)
                {
                    logTxt += "NOT BROADCAST";
                }
                logTxt += "\r\n";

                logTxt += "CIADDR: ";
                logTxt += $"{(byte)(packet.ciaddr >> 24)}.{(byte)(packet.ciaddr >> 16)}.{(byte)(packet.ciaddr >> 8)}.{(byte)(packet.ciaddr)}\r\n";

                logTxt += "YIADDR: ";
                logTxt += $"{(byte)(packet.yiaddr >> 24)}.{(byte)(packet.yiaddr >> 16)}.{(byte)(packet.yiaddr >> 8)}.{(byte)(packet.yiaddr)}\r\n";

                logTxt += "SIADDR: ";
                logTxt += $"{(byte)(packet.siaddr >> 24)}.{(byte)(packet.siaddr >> 16)}.{(byte)(packet.siaddr >> 8)}.{(byte)(packet.siaddr)}\r\n";

                logTxt += "GIADDR: ";
                logTxt += $"{(byte)(packet.giaddr >> 24)}.{(byte)(packet.giaddr >> 16)}.{(byte)(packet.giaddr >> 8)}.{(byte)(packet.giaddr)}\r\n";

                logTxt += "CHADDR: ";
                for (int i = 0; i < 16; i++)
                {
                    if (i%2 == 0 && i != 0)
                    {
                        logTxt += " ";
                    }
                    logTxt += $"{packet.chaddr[i].ToString("X2")}";
                }
                logTxt += "\r\n";
                
                logTxt += "SNAME:  ";
                for (int i = 0; i < 64; i++)
                {
                    if (packet.sname[i] == 0)
                    {
                        break;
                    } else
                    {
                        logTxt += $"{packet.sname[i].ToString()}";
                    }
                }
                logTxt += "\r\n";

                logTxt += "FILE:   ";
                for (int i = 0; i < 128; i++)
                {
                    if (packet.file[i] == 0)
                    {
                        break;
                    } else
                    {
                        logTxt += $"{packet.file[i].ToString()}";
                    }
                }
                logTxt += "\r\n";

                logTxt += "OPTIONS:\r\n";
                for (int i = 0; i < packet.options.Length; i++)
                {
                    byte curr = packet.options[i];

                    if (curr == 0)
                    {
                        logTxt += "  PAD\r\n";
                        continue;
                    }
                    if (curr == 255)
                    {
                        logTxt += "  END\r\n";
                        continue;
                    }
                    if (curr == 1 && i+5 < packet.options.Length)
                    {
                        logTxt += $"  SNMASK: {packet.options[i + 2]}.{packet.options[i + 3]}.{packet.options[i + 4]}.{packet.options[i + 5]}\r\n";
                        i += 5;
                        continue;
                    }
                    if (curr == 2 && i+5 < packet.options.Length)
                    {
                        logTxt += $"  OFFSET: {((int)packet.options[i + 2] << 24) + ((int)packet.options[i + 2] << 16) + ((int)packet.options[i + 2] << 8) + ((int)packet.options[i + 2])} seconds [{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0,DateTimeKind.Utc).AddSeconds(((int)packet.options[i + 2] << 24) + ((int)packet.options[i + 2] << 16) + ((int)packet.options[i + 2] << 8) + ((int)packet.options[i + 2]))}]\r\n";
                        i += 5;
                        continue;
                    }
                    if (curr == 3 && i+1 < packet.options.Length && i + 1 + packet.options[i+1] < packet.options.Length)
                    {
                        for (int j = i + 2; j < packet.options[i+1]; j++)
                        {
                            if (j+3 < packet.options[i+1])
                            {
                                logTxt += $"  ROUTER: {(byte)(packet.options[j])}.{(byte)(packet.options[j+1])}.{(byte)(packet.options[j+2])}.{(byte)(packet.options[j+3])}\r\n";
                                j += 4;
                            }
                        }
                        i += (packet.options[i + 1] + 1);
                        continue;
                    }
                }

                verbose.Append($"\r\n{logTxt}");

            }, state);
        }
        public dhcpPacket dhcpParse(byte[] data, int length)
        {
            dhcpPacket output = new dhcpPacket();

            if (data.Length < 236)
            {
                return output;
            }

            output.chaddr = new byte[16];
            output.sname = new byte[64];
            output.file = new byte[128];
            output.options = new byte[length - 236];

            output.op = data[0];
            output.htype = data[1];
            output.hlen = data[2];
            output.hops = data[3];

            for (int i = 0; i < 4; i++)
            {
                output.xid <<= 8;
                output.xid += data[4 + i];
            }

            for (int i = 0; i < 2; i++)
            {
                output.secs <<= 8;
                output.secs += data[8 + i];
            }

            for (int i = 0; i < 2; i++)
            {
                output.flags <<= 8;
                output.flags += data[10 + i];
            }

            for (int i = 0; i < 4; i++)
            {
                output.ciaddr <<= 8;
                output.ciaddr += data[12 + i];
            }

            for (int i = 0; i < 4; i++)
            {
                output.yiaddr <<= 8;
                output.yiaddr += data[16 + i];
            }

            for (int i = 0; i < 4; i++)
            {
                output.siaddr <<= 8;
                output.siaddr += data[20 + i];
            }

            for (int i = 0; i < 4; i++)
            {
                output.giaddr <<= 8;
                output.giaddr += data[24 + i];
            }

            for (int i = 0; i < 16; i++)
            {
                output.chaddr[i] = data[28 + i];
            }

            for (int i = 0; i < 64; i++)
            {
                output.sname[i] = data[44 + i];
            }

            for (int i = 0; i < 128; i++)
            {
                output.file[i] = data[108 + i];
            }

            for (int i = 236; i < length; i++)
            {
                output.options[i - 236] = data[i];
            }

            return output;
        }
        public struct dhcpPacket
        {
            public byte op;
            public byte htype;
            public byte hlen;
            public byte hops;
            public uint xid;
            public ushort secs;
            public ushort flags;
            public uint ciaddr;
            public uint yiaddr;
            public uint siaddr;
            public uint giaddr;
            public byte[] chaddr;  //  16 bytes
            public byte[] sname;   //  64 bytes
            public byte[] file;    // 128 bytes
            public byte[] options; // variable bytes
        }
        public struct dhcpServer
        {
            public string poolStart;
            public string poolEnd;
            public string snm;
            public string broadcast;
            public string serverId;
            public uint lease;
            public uint renew;
            public uint rebind;
            public ushort clientPort;
            public ushort serverPort;
            public List<string> dnsServers;
            public List<string> routers;
        }
    }
    public static class misc
    {
        public static string PrintPacket(byte[] input, int bufSize)
        {
            string output = "";

            if (bufSize > input.Length)
            {
                throw new ArgumentException($"Buffer size [{bufSize}] is larger than length of input data [{input.Length}]");
            }

            for (int i = 0; i < bufSize; i++)
            {
                if (i % 2 == 0 && i != 0)
                {
                    output += "  ";
                }
                if (i % 8 == 0 && i != 0)
                {
                    output += "      ";
                }
                if (i % 32 == 0 && i != 0)
                {
                    output += "\r\n";
                }

                output += $"{input[i].ToString("X2")}";
            }

            return output;
        }
        public static bool IsIP (string ipAddr)
        {
            try
            {
                IP2int(ipAddr);
                return true;
            } catch
            { 
                return false;
            }
        }
        public static uint IP2int (string ipAddr)
        {
            uint ip = 0;
            string pattern = @"^(\d{0,3})\.(\d{0,3})\.(\d{0,3})\.(\d{0,3})$";

            if (Regex.IsMatch(ipAddr, pattern))
            {
                Match match = Regex.Match(ipAddr, pattern);
                if (match.Groups.Count == 5)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        int octet;
                        try
                        {
                            octet = int.Parse(match.Groups[i].Value);
                        } catch
                        {
                            throw;
                        }

                        if (octet < 0 || octet > 255)
                        {
                            throw new Exception($"Octet number {i} out of range: [{octet}]");
                        } else
                        {
                            ip <<= 8;
                            ip += (uint)octet;
                        }
                    }
                } else
                {
                    throw new Exception($"IP address does not match 5 caputre groups: [{match.Groups.Count}]");
                }
            } else
            {
                throw new Exception($"IP address does not match regular expression {pattern}");
            }

                return ip;
        }
    }
    public static class verbose
    {
        private static bool _initialized = false;
        private static int sizeX = 1000;
        private static int sizeY = 500;
        private static byte[] iconBytes = Convert.FromBase64String("AAABAAEAgIAAAAEAIAAoCAEAFgAAACgAAACAAAAAAAEAAAEAIAAAAAAAAAgBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFAAAADAAAABMAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABkAAAAZAAAAGQAAABUAAAAQAAAACgAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAUAAAAIAAAACMAAAAjAAAAJQAAACoAAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAvAAAALwAAAC8AAAAuAAAAKwAAACYAAAAjAAAAIQAAABYAAAAJAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAHgAAACMAAAArAAAANgAAADwAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAEEAAABBAAAAQQAAAD4AAAA0AAAAKgAAACMAAAAaAAAABwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEwAAACMAAAAkAAAANAAAAEEAAABBAAAARQAAAEoAAABQAAAAVQAAAFkAAABaAAAAWgAAAFoAAABaAAAAWgAAAFoAAABaAAAAWgAAAFoAAABaAAAAWgAAAFoAAABaAAAAWgAAAFoAAABaAAAAWgAA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AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADgAAACEAAAA1AAAASAAAAFMAAABFAAAANQAAACYAAAAXAAAABwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////4AAAAAAAAAH//////////wAAAAAAAAAAf/////////4AAAAAAAAAAB/////////8AAAAAAAAAAAH////////+AAAAAAAAAAAAf////////AAAAAAAAAAAAD////////gAAAAAAAAAAAAP///////wAAAAAAAAAAAAB///////4AAAAAAAAAAAAAP//////8AAAAAAAAAAAAAA///////AAAAAAAAAAAAAAH//////gAAAAAAAAAAAAAA//////4AAAAAAAAAAAAAAH/////8AAAAAAAAAAAAAAA//////AAAAAAAAAAAAAAAH/////wAAAAAAAAAAAAAAAf////8AAAAAAAAAAAAAAAD/////AAAAAAAAAAAAAAAAf////wAAAAAAAAAAAAAAAD////8AAAAAAAAAAAAAAAAf////AAAAAAAAAAAAAAAAH////wAAAAAAAAAAAAAAAA////8AAAAAAAAAAAAAAAAH////AAAAAAAAAAAAAAAAA////wAAAAAAAAAAAAAAAAH///8AAAAAAAAAAAAAAAAA////AAAAAAAAAAAAAAAAAH///wAAAAAAAAAAAAAAAAB///8AAAAAAAAAAAAAAAAAP///AAAAAAAAAAAAAAAAAB///wAAAAAAAAAAAAAAAAAP//8AAAAAAAAAAAAAAAAAD///AAAAAAAAAAAAAAAAAAf//wAAAAAAAAAAAAAAAAAD//8AAAAAAAAAAAAAAAAAA///AAAAAAAAAAAAAAAAAAH//wAAAAAAAAAAAAAAAAAB//8AAAAAAAAAAAAAAAAAAP//AAAAAAAAAAAAAAAAAAB//wAAAAAAAAAAAAAAAAAAf/8AAAAAAAAAAAAAAAAAAH//AAAAAAAAAAAAAAAAAAA//wAAAAAAAAAAAAAAAAAAP/8AAAAAAAAAAAAAAAAAAD//AAAAAAAAAAAAAAAAAAA//wAAAAAAAAAAAAAAAAAAP/8AAAAAAAAAAAAAAAAAAD//AAAAAAAAAAAAAAAAAAA//wAAAAAAAAAAAAAAAAAAP/8AAAAAAAAAAAAAAAAAAD//AAAAAAAAAAAAAAAAAAA//wAAAAAAAAAAAAAAAAAAP/8AAAAAAAAAAAAAAAAAAD//AAAAAAAAAAAAAAAAAAA//wAAAAAAAAAAAAAAAAAAP/8AAAAAAAAAAAAAAAAAAD//AAAAAAAAAAAAAAAAAAA//gAAAAAAAAAAAAAAAAAAP/gAAAAAAAAAAAAAAAAAAD/4AAAAAAAAAAAAAAAAAAA/8AAAAAAAAAAAAAAAAAAAP+AAAAAAAAAAAAAAAAAAAD/AAAAAAAAAAAAAAAAAAAA/gAAAAAAAAAAAAAAAAAAAP4AAAAAAAAAAAAAAAAAAAD8AAAAAAAAAAAAAAAAAAAA/AAAAAAAAAAAAAAAAAAAAPgAAAAAAAAAAAAAAAAAAADwAAAAAAAAAAAAAAAAAAAA8AAAAAAAAAAAAAAAAAAAAOAAAAAAAAAAAAAAAAAAAADgAAAAAAAAAAAAAAAAAAAA4AAAAAAAAAAAAAAAAAAAAOAAAAAAAAAAAAAAAAAAAADAAAAAAAAAAAAAAAAAAAAAwAAAAAAAAAAAAAAAAAAAAMAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAADAAAAAAAAAAAAAAAAAAAAAwAAAAAAAAAAAAAAAAAAAAMAAAAAAAAAAAAAAAAAAAADAAAAAAAAAAAAAAAAAAAAA4AAAAAAAAAAAAAAAAAAAAOAAAAAAAAAAAAAAAAAAAADgAAAAAAAAAAAAAAAAAAAA8AAAAAAAAAAAAAAAAAAAAPAAAAAAAAAAAAAAAAAAAAD4AAAAAAAAAAAAAAAAAAAA+AAAAAAAAAAAAAAAAAAAAPwAAAAAAAAAAAAAAAAAAAD8AAAAAAAAAAAAAAAAAAAA/gAAAAAAAAAAAAAAAAAAAf8AAAAAAAAAAAAAAAAAAAP/gAAAAAAAAAAAAAAAAAAD/4AAAAAAAAAAAAAAAAAAB//AAAAAAAAAAAAAAAAAAA//4AAAAAAAAAAAAAAAAAAf//AAAAAAAAAAAAAAAAAAP//4AAAAAAAAAAAAAAAAAH///gAAAAAAAAAAAAAAAAD///8AAAAAAAAAAAAAAAAB////gAAAAAAAAAAAAAAAB////+AAAAAAAAAAAAAAAH/////4AAAAAAH//////////////gAAAAAH///////////////AAAAAP////////////////AAAA//////////////////8AP////////////8=");
        private static MemoryStream iconMs = new MemoryStream(iconBytes);
        private static bool showIcon = true;
        private static Font formFont = new System.Drawing.Font("Lucida Console", 8.25f, FontStyle.Regular);
        private static FormBorderStyle formBoardStyle = FormBorderStyle.None;
        private static FormStartPosition formStartPosition = FormStartPosition.CenterScreen;
        private static bool showInTaskbar = true;
        private static string formTitle = "Debug Output";
        private static Font textFont = formFont;
        private static Color textForeColor = Color.LightGreen;
        private static Color textBackColor = Color.Black;
        private static Form verboseForm = new Form();
        private static TextBox textBox = new TextBox();

        private static DateTime lastClick;
        private static double doubleClickThreshold = 150;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);
        public static void TextColor(Color foreColor, Color backColor)
        {
            if (!_initialized)
            {
                textForeColor = foreColor;
                textBackColor = backColor;
            }
        }
        public static void ShowInTaskbar(bool show)
        {
            if (!_initialized)
            {
                showInTaskbar = show;
            }
        }
        public static void ShowIcon(bool show)
        {
            if (!_initialized)
            {
                showIcon = show;
            }
        }
        public static void Title(string title)
        {
            if (!_initialized)
            {
                formTitle = title;
            }
        }
        public static void Icon(MemoryStream iconData)
        {
            if (!_initialized)
            {
                iconMs = iconData;
            }
        }
        public static void FormFont(Font font)
        {
            if (!_initialized)
            {
                formFont = font;
            }
        }
        public static void TextFont(Font font)
        {
            if (!_initialized)
            {
                textFont = font;
            }
        }
        public static void Size(int width, int height)
        {
            if (!_initialized)
            {
                if (width < 86)
                {
                    throw new ArgumentException($"invalid width [{width}]");
                }
                if (height < 63)
                {
                    throw new ArgumentException($"invalid height [{height}]");
                }

                sizeX = width;
                sizeY = height;
                return;
            }
        }
        public static void Write(string input, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string callername = "", [CallerFilePath] string filePath = "")
        {
            if (_initialized)
            {
                /*
                if (input.Length > textBox.MaxLength)
                {
                    throw new ArgumentException($"input length [{input.Length}] exceeds maximum length for textbox control [{textBox.MaxLength}]");
                }
                */

                if (textBox.InvokeRequired)
                {
                    textBox.Invoke(new MethodInvoker(delegate { textBox.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} | {filePath}:{lineNumber} | {callername} | {input}\r\n"; }));
                } else
                {
                    textBox.Text = $"{DateTime.Now.ToString("HH:mm:ss.fff")} | {filePath}:{lineNumber} | {callername} | {input}\r\n";
                }
            }
        }
        public static void Append(string input, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string callername = "", [CallerFilePath] string filePath = "")
        {
            if (_initialized)
            {
                /*
                if (input.Length > textBox.MaxLength)
                {
                    throw new ArgumentException($"input length [{input.Length}] exceeds maximum length for textbox control [{textBox.MaxLength}]");
                }
                if (input.Length + textBox.Text.Length > textBox.MaxLength)
                {
                    throw new ArgumentException($"input length [{input.Length}] in addition to current textbox control length [{textBox.Text.Length}] exceeds maximum length for textbox control [{textBox.MaxLength}]");
                }
                */

                if (textBox.InvokeRequired)
                {
                    textBox.Invoke(new MethodInvoker(delegate { textBox.AppendText($"{DateTime.Now.ToString("HH:mm:ss.fff")} | {filePath}:{lineNumber} | {callername} | {input}\r\n"); }));
                } else
                {
                    textBox.AppendText($"{DateTime.Now.ToString("HH:mm:ss.fff")} | {filePath}:{lineNumber} | {callername} | {input}\r\n");
                }
            }
        }
        public static void Clear()
        {
            if (_initialized)
            {
                textBox.Text = "";
            }
        }
        public static void CreateForm()
        {
            if (!_initialized)
            {
                _initialized = true;
                verboseForm.Text = formTitle;
                verboseForm.Width = sizeX;
                verboseForm.Height = sizeY;
                verboseForm.Icon = new System.Drawing.Icon(iconMs);
                verboseForm.Font = formFont;
                verboseForm.FormBorderStyle = formBoardStyle;
                verboseForm.ShowIcon = showIcon;
                verboseForm.ShowInTaskbar = showInTaskbar;
                verboseForm.StartPosition = formStartPosition;
                verboseForm.Load += new EventHandler(VerboseForm_Load);
                verboseForm.MouseDown += new MouseEventHandler(VerboseForm_MouseDown);

                Label titleLabel = new Label();
                titleLabel.Text = formTitle;
                titleLabel.Location = new Point(0, 0);
                titleLabel.MouseDown += new MouseEventHandler(TitleLabel_MouseDown);

                Button minimizeButton = new Button();
                minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                minimizeButton.Width = 23;
                minimizeButton.Height = 23;
                minimizeButton.Location = new Point(verboseForm.Width - (minimizeButton.Width * 3) - 17, 1);
                minimizeButton.Text = "−";
                minimizeButton.FlatStyle = FlatStyle.Flat;
                minimizeButton.FlatAppearance.BorderSize = 0;
                minimizeButton.Click += new EventHandler(Minimize_Click);

                Button maximizeButton = new Button();
                maximizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                maximizeButton.Width = minimizeButton.Width;
                maximizeButton.Height = minimizeButton.Height;
                maximizeButton.Location = new Point(verboseForm.Width - (minimizeButton.Width * 2) - 17, 1);
                maximizeButton.Text = "◻";
                maximizeButton.FlatStyle = minimizeButton.FlatStyle;
                maximizeButton.FlatAppearance.BorderSize = minimizeButton.FlatAppearance.BorderSize;
                maximizeButton.Click += new EventHandler(Maximize_Click);

                Button closeButton = new Button();
                closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                closeButton.Width = minimizeButton.Width;
                closeButton.Height = minimizeButton.Height;
                closeButton.Location = new Point(verboseForm.Width - (minimizeButton.Width * 1) - 17, 1);
                closeButton.Text = "✕";
                closeButton.FlatStyle = minimizeButton.FlatStyle;
                closeButton.FlatAppearance.BorderSize = minimizeButton.FlatAppearance.BorderSize;
                closeButton.Click += new EventHandler(Close_Click);

                textBox.ReadOnly = true;
                textBox.BackColor = textBackColor;
                textBox.ForeColor = textForeColor;
                textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
                textBox.BorderStyle = BorderStyle.None;
                textBox.Font = textFont;
                textBox.Cursor = Cursors.Arrow;
                textBox.Multiline = true;
                textBox.WordWrap = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Location = new Point(0, 24);
                textBox.Width = verboseForm.Width - 20;
                textBox.Height = verboseForm.Height - 63;
                textBox.SendToBack();
                textBox.GotFocus += new EventHandler(TextBox_GotFocus);
                //textBox.MouseDown += new MouseEventHandler(TextBox_MouseDown);

                verboseForm.Controls.Add(textBox);
                verboseForm.Controls.Add(minimizeButton);
                verboseForm.Controls.Add(maximizeButton);
                verboseForm.Controls.Add(closeButton);
                verboseForm.Controls.Add(titleLabel);

                verboseForm.Show();
                //TextBox_GotFocus(textBox, new EventArgs());
                //verboseForm.SendToBack();
            }
        }
        private static void VerboseForm_Load(object sender, EventArgs e)
        {

        }
        private static void VerboseForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((DateTime.Now - lastClick).TotalMilliseconds < doubleClickThreshold)
            {
                Form verboseForm = sender as Form;
                if (verboseForm.WindowState == FormWindowState.Maximized)
                {
                    verboseForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    verboseForm.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                Form verboseForm = sender as Form;
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(verboseForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            }

            lastClick = DateTime.Now;
        }
        private static void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            Label titleLabel = sender as Label;
            Form verboseForm = titleLabel.Parent as Form;
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(verboseForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private static void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Form verboseForm = textBox.Parent as Form;
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(verboseForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private static void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            HideCaret(textBox.Handle);
        }
        private static void Minimize_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Form verboseForm = button.Parent as Form;
            verboseForm.WindowState = FormWindowState.Minimized;
        }

        private static void Maximize_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Form verboseForm = button.Parent as Form;

            if (verboseForm.WindowState != FormWindowState.Maximized)
            {
                button.Text = "⧉";
                verboseForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                button.Text = "◻";
                verboseForm.WindowState = FormWindowState.Normal;
            }

            verboseForm.Invalidate(true);
        }
        private static void Close_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Form verboseForm = button.Parent as Form;
            verboseForm.Close();
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
            Application.Run(new mainForm());
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
}
