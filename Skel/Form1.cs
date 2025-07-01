using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg.Sig;
using static netUtils.misc;


namespace netUtils
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                verbose.check();
                this.BringToFront();

            }
            catch (Exception ex)
            {
                verbose.write($"SOURCE: {ex.Source}");
                verbose.write($"STACK TRACE: {ex.StackTrace}");
                verbose.write($"EXCEPTION: {ex.Message}");
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                maximizeButton.Text = "⧉";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximizeButton.Text = "◻";
            }


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            verbose.close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void tabPage2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void startServerDHCPbutton_Click(object sender, EventArgs e)
        {
            startServerDHCPbutton.Enabled = false;
            stopServerDHCPbutton.Enabled = true;
            poolStartDHCPtextbox.ReadOnly = true;
            poolStopDHCPtextbox.ReadOnly = true;
            serverPortDHCPtextbox.ReadOnly = true;
            clientPortDHCPtextbox.ReadOnly = true;
            misc.dhcpLog("Staring DHCP Server...");
            
            if (!misc.validateIP(poolStartDHCPtextbox.Text))
            {
                misc.dhcpLog($"Invalid pool start IP address [{poolStartDHCPtextbox.Text}]");
                stopServerDHCPbutton_Click(sender, e);
                return;
            }
            if (!misc.validateIP(poolStopDHCPtextbox.Text))
            {
                misc.dhcpLog($"Invalid pool stop IP address [{poolStopDHCPtextbox.Text}]");
                stopServerDHCPbutton_Click(sender , e);
                return;
            }

            // validate pools
            UInt32 ip1 = misc.ip2Int(poolStartDHCPtextbox.Text);
            UInt32 ip2 = misc.ip2Int(poolStopDHCPtextbox.Text);

            if (ip1 > ip2)
            {
                misc.dhcpLog($"Begining of DHCP pool is larger than end of pool [{poolStartDHCPtextbox.Text} - {poolStopDHCPtextbox.Text}]");
                stopServerDHCPbutton_Click(sender, e);
                return;
            }

            // validate ports
            try
            {
                UInt16 dhcpServerPort = UInt16.Parse(serverPortDHCPtextbox.Text);
            } catch (OverflowException ex)
            {
                misc.dhcpLog($"Invalid server port number [{serverPortDHCPtextbox.Text}]\r\nMust be valid 16-bit unsigned integer, i.e. 0 - 65535");
                stopServerDHCPbutton_Click(sender, e);
                return;
            }
            try
            {
                UInt16 dhcpClientPort = UInt16.Parse(clientPortDHCPtextbox.Text);
            }
            catch (OverflowException ex)
            {
                misc.dhcpLog($"Invalid client port number [{clientPortDHCPtextbox.Text}]\r\nMust be valid 16-bit unsigned integer, i.e. 0 - 65535");
                stopServerDHCPbutton_Click(sender, e);
                return;
            }

            misc.dhcpOptions dhcpParameters = new misc.dhcpOptions();
            dhcpParameters.poolStart = poolStartDHCPtextbox.Text;
            dhcpParameters.poolEnd = poolStopDHCPtextbox.Text;
            dhcpParameters.serverPort = int.Parse(serverPortDHCPtextbox.Text);
            dhcpParameters.clientPort = int.Parse(clientPortDHCPtextbox.Text);

            //await Task.Run(() =>
            //{
                await dhcpServer(dhcpParameters, misc.dhcpCancelToken.Token);
            //});
            
            this.Refresh();
        }

        private async Task dhcpServer(misc.dhcpOptions parameters, CancellationToken cancelToken)
        {
            int listenPort = parameters.serverPort;

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                await Task.Run(() =>
                {
                    int connCount = 0;
                    while (!cancelToken.IsCancellationRequested || true)
                    {
                        /*
                        if (cancelToken.IsCancellationRequested)
                        {
                            misc.dhcpLog("Closing socket");
                            listener.Close();
                            listener.Dispose();
                            break;
                        }
                        */

                        misc.dhcpLog($"Waiting for broadcast...");
                        byte[] bytes = listener.Receive(ref groupEP);
                        connCount++;
                        misc.dhcpLog($"CONN[{connCount}] Received broadcast from {groupEP} [{bytes.Length} bytes]\r\n{misc.printPayload(bytes.ToList<byte>())}");
                        misc.dhcpDatagram datagram = new misc.dhcpDatagram();
                        datagram.chaddr = new byte[16];
                        datagram.sname = new byte[64];
                        datagram.file = new byte[128];
                        datagram.options = Array.Empty<byte>();

                        if (bytes.Length > 235)
                        {
                            datagram.op = bytes[0];
                            datagram.htype = bytes[1];
                            datagram.hlen = bytes[2];
                            datagram.hops = bytes[3];
                            for (int i = 0; i < 4; i++)
                            {
                                datagram.xid <<= 8;
                                datagram.xid += bytes[4 + i];
                            }
                            datagram.secs = bytes[8];
                            datagram.secs <<= 8;
                            datagram.secs += bytes[9];
                            datagram.flags = bytes[10];
                            datagram.flags <<= 8;
                            datagram.flags += bytes[11];
                            for (int i = 0; i < 4; i++)
                            {
                                datagram.ciaddr <<= 8;
                                datagram.ciaddr += bytes[12 + i];
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                datagram.yiaddr <<= 8;
                                datagram.yiaddr += bytes[16 + i];
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                datagram.siaddr <<= 8;
                                datagram.siaddr += bytes[20 + i];
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                datagram.giaddr <<= 8;
                                datagram.giaddr += bytes[24 + i];
                            }
                            for (int i = 0; i < 16; i++)
                            {
                                datagram.chaddr[i] = bytes[28 + i];
                            }
                            for (int i = 0; i < 64; i++)
                            {
                                datagram.sname[i] = bytes[44 + i];
                            }
                            for (int i = 0; i < 128; i++)
                            {
                                datagram.file[i] = bytes[108 + i];
                            }
                            
                            //datagram.options = new ArraySegment<byte>(bytes, 236, bytes.Length).ToArray<byte>();
                            /*
                            for (int i = 236; i < bytes.Length; i++)
                            {
                                datagram.options[236 - i] = bytes[i];
                            }
                            */
                            misc.dhcpLog($"CONN[{connCount}] OP CODE: {datagram.op}  ;  [ 1 = BOOTREQUEST, 2 = BOOTREPLY ]");
                            misc.dhcpLog($"CONN[{connCount}] HW ADDR TYPE: {datagram.htype}  ;  [ 1 = 10mb ethernet, see 'Assigned Numbers' RFC ]");
                            misc.dhcpLog($"CONN[{connCount}] HW ADDR LEN:  {datagram.hlen}   ;  [ 6 for 10mb ethernet ]");
                            misc.dhcpLog($"CONN[{connCount}] HOPS: {datagram.hops}");
                            misc.dhcpLog($"CONN[{connCount}] XID: {datagram.xid}");
                            misc.dhcpLog($"CONN[{connCount}] SECONDS: {datagram.secs}");
                            misc.dhcpLog($"CONN[{connCount}] FLAGS: {datagram.flags}"); // breakout individual flags here
                            misc.dhcpLog($"CONN[{connCount}] CLIENT IP: {(byte)(datagram.ciaddr >> 24)}.{(byte)(datagram.ciaddr >> 16)}.{(byte)(datagram.ciaddr >> 8)}.{(byte)(datagram.ciaddr)}");
                            misc.dhcpLog($"CONN[{connCount}] YOUR IP: {(byte)(datagram.yiaddr >> 24)}.{(byte)(datagram.yiaddr >> 16)}.{(byte)(datagram.yiaddr >> 8)}.{(byte)(datagram.yiaddr)}");
                            misc.dhcpLog($"CONN[{connCount}] SERVER IP: {(byte)(datagram.siaddr >> 24)}.{(byte)(datagram.siaddr >> 16)}.{(byte)(datagram.siaddr) >> 8}.{(byte)(datagram.siaddr)}");
                            misc.dhcpLog($"CONN[{connCount}] RELAY IP: {(byte)(datagram.giaddr >> 24)}.{(byte)(datagram.giaddr >> 16)}.{(byte)(datagram.giaddr >> 8)}.{(byte)(datagram.giaddr)}");
                            string hwAddr = "";
                            for (int i = 0; i < datagram.chaddr.Length; i++)
                            {
                                if (i % 2 == 0 && i != 0)
                                {
                                    hwAddr += ":";
                                }
                                hwAddr += datagram.chaddr[i].ToString("X2");
                            }
                            misc.dhcpLog($"CONN[{connCount}] HW ADDR: {hwAddr}");
                            misc.dhcpLog($"CONN[{connCount}] SERVER NAME: {System.Text.Encoding.Default.GetString(datagram.sname)}");
                            // break out individual options

                            // do stuff
                            bytes = Array.Empty<byte>();
                            continue;
                        }

                    }
                });
            }
            catch (SocketException e)
            {
                misc.dhcpLog($"Socket Exception: {e}");
            }
            finally
            {
                misc.dhcpLog($"Closing socket");
                listener.Close();
                //listener.Dispose();
            }
        }

        private void stopServerDHCPbutton_Click(object sender, EventArgs e)
        {
            stopServerDHCPbutton.Enabled = false;
            startServerDHCPbutton.Enabled = true;
            poolStartDHCPtextbox.ReadOnly = false;
            poolStopDHCPtextbox.ReadOnly = false;
            serverPortDHCPtextbox.ReadOnly = false;
            clientPortDHCPtextbox.ReadOnly = false;
            misc.dhcpLog("Stopping DHCP server...");
            misc.dhcpCancelToken.Cancel();
        }

        private void serverPortDHCPtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void poolStartDHCPtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        int dhcpOutputCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (misc.newTextDHCP)
            {
                DHCPoutput.Text = misc.dhcpOutputText;
                misc.newTextDHCP = false;
            }
            /*
            if (dhcpOutputCount != misc.dhcpOutputText.Length)
            {
                DHCPoutput.Clear();
                //DHCPoutput.Text = "";
                DHCPoutput.AppendText(misc.dhcpOutputText);
                dhcpOutputCount = misc.dhcpOutputText.Length;

                verbose.write($"Updating DHCP output text");
                this.Refresh();
            }
            */
        }
    }
}
