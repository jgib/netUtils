namespace netUtils
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clientPortDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverPortDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.poolStopDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.poolStartDHCPtextbox = new System.Windows.Forms.TextBox();
            this.stopServerDHCPbutton = new System.Windows.Forms.Button();
            this.startServerDHCPbutton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DHCPoutput = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(666, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.DHCPoutput);
            this.tabPage1.Controls.Add(this.clientPortDHCPtextbox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.serverPortDHCPtextbox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.poolStopDHCPtextbox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.poolStartDHCPtextbox);
            this.tabPage1.Controls.Add(this.stopServerDHCPbutton);
            this.tabPage1.Controls.Add(this.startServerDHCPbutton);
            this.tabPage1.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(658, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DHCP Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseDown);
            // 
            // clientPortDHCPtextbox
            // 
            this.clientPortDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientPortDHCPtextbox.Location = new System.Drawing.Point(9, 180);
            this.clientPortDHCPtextbox.Name = "clientPortDHCPtextbox";
            this.clientPortDHCPtextbox.Size = new System.Drawing.Size(76, 20);
            this.clientPortDHCPtextbox.TabIndex = 10;
            this.clientPortDHCPtextbox.Text = "68";
            this.clientPortDHCPtextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serverPortDHCPtextbox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Client Port:";
            // 
            // serverPortDHCPtextbox
            // 
            this.serverPortDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverPortDHCPtextbox.Location = new System.Drawing.Point(9, 130);
            this.serverPortDHCPtextbox.Name = "serverPortDHCPtextbox";
            this.serverPortDHCPtextbox.Size = new System.Drawing.Size(76, 20);
            this.serverPortDHCPtextbox.TabIndex = 8;
            this.serverPortDHCPtextbox.Text = "67";
            this.serverPortDHCPtextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serverPortDHCPtextbox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server Port:";
            // 
            // poolStopDHCPtextbox
            // 
            this.poolStopDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolStopDHCPtextbox.Location = new System.Drawing.Point(9, 80);
            this.poolStopDHCPtextbox.Name = "poolStopDHCPtextbox";
            this.poolStopDHCPtextbox.Size = new System.Drawing.Size(115, 20);
            this.poolStopDHCPtextbox.TabIndex = 6;
            this.poolStopDHCPtextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.poolStartDHCPtextbox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pool Stop:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pool Start:";
            // 
            // poolStartDHCPtextbox
            // 
            this.poolStartDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolStartDHCPtextbox.Location = new System.Drawing.Point(9, 30);
            this.poolStartDHCPtextbox.Name = "poolStartDHCPtextbox";
            this.poolStartDHCPtextbox.Size = new System.Drawing.Size(115, 20);
            this.poolStartDHCPtextbox.TabIndex = 3;
            this.poolStartDHCPtextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.poolStartDHCPtextbox_KeyPress);
            // 
            // stopServerDHCPbutton
            // 
            this.stopServerDHCPbutton.Enabled = false;
            this.stopServerDHCPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopServerDHCPbutton.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopServerDHCPbutton.Location = new System.Drawing.Point(122, 177);
            this.stopServerDHCPbutton.Name = "stopServerDHCPbutton";
            this.stopServerDHCPbutton.Size = new System.Drawing.Size(55, 23);
            this.stopServerDHCPbutton.TabIndex = 2;
            this.stopServerDHCPbutton.Text = "Stop";
            this.stopServerDHCPbutton.UseVisualStyleBackColor = true;
            this.stopServerDHCPbutton.Click += new System.EventHandler(this.stopServerDHCPbutton_Click);
            // 
            // startServerDHCPbutton
            // 
            this.startServerDHCPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerDHCPbutton.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServerDHCPbutton.Location = new System.Drawing.Point(122, 127);
            this.startServerDHCPbutton.Name = "startServerDHCPbutton";
            this.startServerDHCPbutton.Size = new System.Drawing.Size(55, 23);
            this.startServerDHCPbutton.TabIndex = 1;
            this.startServerDHCPbutton.Text = "Start";
            this.startServerDHCPbutton.UseVisualStyleBackColor = true;
            this.startServerDHCPbutton.Click += new System.EventHandler(this.startServerDHCPbutton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(658, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage2_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(669, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 22);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "✕";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Location = new System.Drawing.Point(625, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(22, 22);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.Text = "−";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Location = new System.Drawing.Point(647, 0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(22, 22);
            this.maximizeButton.TabIndex = 4;
            this.maximizeButton.Text = "◻";
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DHCPoutput
            // 
            this.DHCPoutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DHCPoutput.Location = new System.Drawing.Point(-1, 206);
            this.DHCPoutput.Multiline = true;
            this.DHCPoutput.Name = "DHCPoutput";
            this.DHCPoutput.ReadOnly = true;
            this.DHCPoutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DHCPoutput.Size = new System.Drawing.Size(658, 252);
            this.DHCPoutput.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(690, 504);
            this.Controls.Add(this.maximizeButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "net utils";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button startServerDHCPbutton;
        private System.Windows.Forms.Button maximizeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button stopServerDHCPbutton;
        private System.Windows.Forms.TextBox poolStartDHCPtextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox poolStopDHCPtextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverPortDHCPtextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clientPortDHCPtextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox DHCPoutput;
    }
}

