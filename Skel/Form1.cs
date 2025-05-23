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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                verbose.check();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            verbose.close();
        }
    }
}
