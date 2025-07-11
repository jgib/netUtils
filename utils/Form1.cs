using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using debug = netUtils.verbose;

namespace netUtils
{
    public partial class mainForm : Form
    {
        public DateTime lastClick;
        public double doubleClickThreshold = 150;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public mainForm()
        {
            InitializeComponent();
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

            for (int i = 0; i < 7; i++)
            {
                debug.Append($"TEST [{i}]");
            }
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
            if (startDHCPbutton.Text == "Start")
            {
                startDHCPbutton.Text = "Stop";
            } else
            {
                startDHCPbutton.Text = "Start";
            }
        }

        private void snmDHCPcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            snmDHCPtextbox.Enabled = snmDHCPcheckbox.Checked;
        }

        private void routerDHCPcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            routerDHCPtextbox.Enabled = routerDHCPcheckbox.Checked;
        }
    }
}
