using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using debug = netUtils.verbose;

namespace netUtils
{
    public partial class mainForm : Form
    {
        static mainForm instance;
        public static mainForm Instance { get { return instance; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            instance = this;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            instance = null;
        }

        public DateTime lastClick;
        public double doubleClickThreshold = 150;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);
        public mainForm()
        {
            InitializeComponent();
        }
        public void logDHCP(string message)
        {
            message += "\r\n";
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    this.outputDHCPtextbox.AppendText(message);
                }));
                return;
            }
            this.outputDHCPtextbox.AppendText(message);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (arg == "-v" || arg == "--verbose")
                {
                    debug.CreateForm();
                }
            }

            toolTip1.SetToolTip(poolStartLabel,  "   First address in DHCP pool");
            toolTip1.SetToolTip(poolEndLabel,    "   Last address in DHCP pool");
            toolTip1.SetToolTip(snmLabel,        "   The subnet mask option specifies the client's subnet mask as per RFC\r\n   950 ");
            toolTip1.SetToolTip(broadcastLabel,  "   This option specifies the broadcast address in use on the client's\r\n   subnet.");
            toolTip1.SetToolTip(serverIdLabel,   "   The identifier is the IP address of the selected server.");
            toolTip1.SetToolTip(leaseTimeLabel,  "   The time is in units of seconds, and is specified as a 32-bit\r\n   unsigned integer.");
            toolTip1.SetToolTip(renewTimeLabel,  "   The value is in units of seconds, and is specified as a 32-bit\r\n   unsigned integer.");
            toolTip1.SetToolTip(rebindTimeLabel, "   The value is in units of seconds, and is specified as a 32-bit\r\n   unsigned integer.");

            for (int i = 0; i < 7; i++)
            {
                debug.Append($"TEST [{i}]");
            }

            debug.Append(misc.IsIP("0.0.0.2").ToString());
        }

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((DateTime.Now - lastClick).TotalMilliseconds < doubleClickThreshold)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            }

            lastClick = DateTime.Now;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                maximizeButton.Text = "⧉";
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                maximizeButton.Text = "◻";
                this.WindowState = FormWindowState.Normal;
            }

            this.Invalidate(true);
        }

        private void tabDHCP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void startDHCPbutton_Click(object sender, EventArgs e)
        {
            dhcp.dhcpServer server = new dhcp.dhcpServer();
            server.dnsServers = new List<string>();
            server.routers = new List<string>();

            if (startDHCPbutton.Text == "Start")
            {
                startDHCPbutton.Text = "Stop";
                string outTxt = $"DHCP Server Starting...";
                logDHCP(outTxt);
                debug.Append(outTxt);
                
                if (!misc.IsIP(poolStartTextbox.Text))
                {
                    string errTxt = $"Pool start address is not a valid IP [{poolStartTextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                if (!misc.IsIP(poolEndTextbox.Text))
                {
                    string errTxt = $"Pool end address is not a valid IP [{poolEndTextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                if (misc.IP2int(poolStartTextbox.Text) > misc.IP2int(poolEndTextbox.Text))
                {
                    string errTxt = $"Pool start address is larger than pool end address [{poolStartTextbox.Text} > {poolEndTextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                server.poolStart = poolStartTextbox.Text;
                server.poolEnd = poolEndTextbox.Text;
                outTxt = $"POOL START:  {server.poolStart}";
                logDHCP(outTxt);
                debug.Append(outTxt);
                outTxt = $"POOL END:    {server.poolEnd}";
                logDHCP(outTxt);
                debug.Append(outTxt);

                if (snmDHCPtextbox.Text.Trim() != String.Empty && !misc.IsIP(snmDHCPtextbox.Text))
                {
                    string errTxt = $"Subnet mask address is not a valid IP [{snmDHCPtextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                server.snm = snmDHCPtextbox.Text;
                outTxt = $"SUBNET MASK: {server.snm}";
                logDHCP(outTxt);
                debug.Append(outTxt);

                if (broadcastDHCPtextbox.Text.Trim() != String.Empty && !misc.IsIP(broadcastDHCPtextbox.Text))
                {
                    string errTxt = $"Broadcast address is not a valid IP [{broadcastDHCPtextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                server.broadcast = broadcastDHCPtextbox.Text;
                outTxt = $"BROADCAST:   {server.broadcast}";
                logDHCP(outTxt);
                debug.Append(outTxt);

                if (serverIdDHCPtextbox.Text.Trim() != String.Empty && !misc.IsIP(serverIdDHCPtextbox.Text))
                {
                    string errTxt = $"Server ID address is not a valid IP [{serverIdDHCPtextbox.Text}]";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                server.serverId = serverIdDHCPtextbox.Text;
                outTxt = $"SERVER ID:   {server.serverId}";
                logDHCP(outTxt);
                debug.Append(outTxt);

                try
                {
                    server.lease = uint.Parse(leaseTimeDHCPtextbox.Text.Trim());
                    outTxt = $"LEASE TIME:  {server.lease} seconds";
                    logDHCP(outTxt);
                    debug.Append(outTxt);
                }
                catch (Exception ex)
                {
                    string errTxt = $"Lease time is not valid [{leaseTimeDHCPtextbox.Text}]\r\nException: {ex.Message}";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                try
                {
                    server.renew = uint.Parse(renewTimeDHCPtextbox.Text.Trim());
                    outTxt = $"RENEW TIME:  {server.renew} seconds";
                    logDHCP(outTxt);
                    debug.Append(outTxt);
                }
                catch (Exception ex)
                {
                    string errTxt = $"Renew time is not valid [{renewTimeDHCPtextbox.Text}]\r\nException: {ex.Message}";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                try
                {
                    server.rebind = uint.Parse(rebindTimeDHCPtextbox.Text.Trim());
                    outTxt = $"REBIND TIME: {server.rebind} seconds";
                    logDHCP(outTxt);
                    debug.Append(outTxt);
                }
                catch (Exception ex)
                {
                    startDHCPbutton.Text = "Start";
                    return;
                }
                try
                {
                    server.serverPort = ushort.Parse(serverDHCPPortTextbox.Text);
                }
                catch (Exception ex)
                {
                    string errTxt = $"Server port number is not valid [{serverDHCPPortTextbox.Text}]\r\nException: {ex.Message}";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }
                try
                {
                    server.clientPort = ushort.Parse(clientDHCPPortTextbox.Text);
                }
                catch (Exception ex)
                {
                    string errTxt = $"Client port number is not valid [{clientDHCPPortTextbox.Text}]\r\nException: {ex.Message}";
                    MessageBox.Show(errTxt);
                    debug.Append(errTxt);
                    logDHCP(errTxt);
                    startDHCPbutton.Text = "Start";
                    return;
                }

                for (int i = 0; i < dnsDHCPlistbox.Items.Count; i++)
                {
                    server.dnsServers.Add(dnsDHCPlistbox.Items[i].ToString());
                    outTxt = $"DNS SERVER:  {server.dnsServers[i]}";
                    logDHCP(outTxt);
                    debug.Append(outTxt);
                }

                for (int i = 0; i < routersDHCPlistbox.Items.Count; i++)
                {
                    server.routers.Add(routersDHCPlistbox.Items[i].ToString());
                    outTxt = $"ROUTER:      {server.routers[i]}";
                    logDHCP(outTxt);
                    debug.Append(outTxt);
                }

                ///////////////
                /// TESTING ///
                ///////////////
                dhcp s = new dhcp();
                s.Server("0.0.0.0", 67);
            }
            else
            {
                startDHCPbutton.Text = "Start";

            }
        }

        private void dnsDHCPaddButton_Click(object sender, EventArgs e)
        {
            if (netUtils.misc.IsIP(dnsDHCPtextbox.Text))
            {
                if (dnsDHCPlistbox.Items.Contains(dnsDHCPtextbox.Text))
                {
                    debug.Append($"Address already exists in list of DNS Servers [{dnsDHCPtextbox.Text}]");
                    MessageBox.Show($"Address [{dnsDHCPtextbox.Text}] already exists in list");
                }
                else
                {
                    dnsDHCPlistbox.Items.Add(dnsDHCPtextbox.Text);
                    dnsDHCPtextbox.Text = "";
                    dnsDHCPtextbox.Focus();
                    debug.Append($"Added {dnsDHCPtextbox.Text} to DNS Servers");
                }
            }
            else
            {
                MessageBox.Show($"[{dnsDHCPtextbox.Text}] is not a valid IP address");
                debug.Append($"DNS server invalid [{dnsDHCPtextbox.Text}]");
            }

        }

        private void routersDHCPaddButton_Click(object sender, EventArgs e)
        {
            if (netUtils.misc.IsIP(routersDHCPtextbox.Text))
            {
                if (routersDHCPlistbox.Items.Contains(routersDHCPtextbox.Text))
                {
                    debug.Append($"Address already exists in list of Routers [{routersDHCPtextbox.Text}]");
                    MessageBox.Show($"Address [{routersDHCPtextbox.Text}] already exists in list");
                } else
                {
                    routersDHCPlistbox.Items.Add(routersDHCPtextbox.Text);
                    routersDHCPtextbox.Text = "";
                    routersDHCPtextbox.Focus();
                    debug.Append($"Added {routersDHCPtextbox.Text} to Routers");
                }
            } else
            {
                MessageBox.Show($"[{routersDHCPtextbox.Text}] is not a valid IP address");
                debug.Append($"Router invalid [{routersDHCPtextbox.Text}]");
            }
        }

        private void dnsDHCPremoveButton_Click(object sender, EventArgs e)
        {
            if (dnsDHCPlistbox.SelectedItems.Count > 0)
            {
                debug.Append($"Removing DNS Server [{dnsDHCPlistbox.Items[dnsDHCPlistbox.SelectedIndex].ToString()}]");
                dnsDHCPlistbox.Items.RemoveAt(dnsDHCPlistbox.SelectedIndex);
            }
        }

        private void routersDHCPremoveButton_Click(object sender, EventArgs e)
        {
            if (routersDHCPlistbox.SelectedItems.Count > 0)
            {
                debug.Append($"Removing Router [{routersDHCPlistbox.Items[routersDHCPlistbox.SelectedIndex].ToString()}]");
                routersDHCPlistbox.Items.RemoveAt(routersDHCPlistbox.SelectedIndex);
            }
        }

        private void outputDHCPtextbox_Enter(object sender, EventArgs e)
        {
            HideCaret(outputDHCPtextbox.Handle);
        }
    }
}
