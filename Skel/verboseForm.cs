using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace netUtils
{

    public partial class verboseForm : Form
    {

        int verboseCount = 0;
        public verboseForm()
        {
            InitializeComponent();
        }

        private void verboseForm_Load(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (verbose.text.Length != verboseCount)
            {
                textBox1.Clear();
                textBox1.AppendText(verbose.text);
                verboseCount = verbose.text.Length;
                this.Refresh();
            }
        }
    }
}
