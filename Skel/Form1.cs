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

            await Task.Run(() =>
            {
                dhcpServer(dhcpParameters, misc.dhcpCancelToken.Token);
            });
            
            this.Refresh();
        }

        private async Task dhcpServer(misc.dhcpOptions parameters, CancellationToken cancelToken)
        {
            int listenPort = parameters.serverPort;

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        misc.dhcpLog("Closing socket");
                        listener.Close();
                        listener.Dispose();
                        break;
                    }

                    misc.dhcpLog($"Waiting for broadcast...");
                    byte[] bytes = listener.Receive(ref groupEP);
                    misc.dhcpLog($"Received broadcast from {groupEP}");
                }
            }
            catch (SocketException e)
            {
                misc.dhcpLog($"Socket Exception: {e}");
            }
            finally
            {
                misc.dhcpLog($"Closing socket");
                listener.Close();
                listener.Dispose();
            }
        }

        private void stopServerDHCPbutton_Click(object sender, EventArgs e)
        {
            stopServerDHCPbutton.Enabled = false;
            startServerDHCPbutton.Enabled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (String.Compare(DHCPoutput.Text, misc.dhcpOutputText, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) != 0)
            {
                DHCPoutput.Text = misc.dhcpOutputText;
            }
        }

        private void DHCPoutput_TextChanged(object sender, EventArgs e)
        {
            DHCPoutput.SelectionStart = DHCPoutput.Text.Length;
            DHCPoutput.ScrollToCaret();
        }
    }
}
