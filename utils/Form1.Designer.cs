namespace netUtils
{
    partial class mainForm
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
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDHCP = new System.Windows.Forms.TabPage();
            this.outputDHCPtextbox = new System.Windows.Forms.TextBox();
            this.routersDHCPremoveButton = new System.Windows.Forms.Button();
            this.routersDHCPaddButton = new System.Windows.Forms.Button();
            this.routersDHCPlistbox = new System.Windows.Forms.ListBox();
            this.routersDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dnsDHCPlistbox = new System.Windows.Forms.ListBox();
            this.dnsDHCPremoveButton = new System.Windows.Forms.Button();
            this.dnsDHCPaddButton = new System.Windows.Forms.Button();
            this.dnsDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rebindTimeLabel = new System.Windows.Forms.Label();
            this.rebindTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.renewTimeLabel = new System.Windows.Forms.Label();
            this.renewTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.leaseTimeLabel = new System.Windows.Forms.Label();
            this.leaseTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.serverIdLabel = new System.Windows.Forms.Label();
            this.serverIdDHCPtextbox = new System.Windows.Forms.TextBox();
            this.broadcastLabel = new System.Windows.Forms.Label();
            this.broadcastDHCPtextbox = new System.Windows.Forms.TextBox();
            this.snmLabel = new System.Windows.Forms.Label();
            this.snmDHCPtextbox = new System.Windows.Forms.TextBox();
            this.startDHCPbutton = new System.Windows.Forms.Button();
            this.poolEndTextbox = new System.Windows.Forms.TextBox();
            this.poolEndLabel = new System.Windows.Forms.Label();
            this.poolStartTextbox = new System.Windows.Forms.TextBox();
            this.poolStartLabel = new System.Windows.Forms.Label();
            this.tabDNS = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverDHCPPortTextbox = new System.Windows.Forms.TextBox();
            this.clientDHCPPortTextbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabDHCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Location = new System.Drawing.Point(734, 1);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(23, 23);
            this.minimizeButton.TabIndex = 0;
            this.minimizeButton.Text = "−";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Location = new System.Drawing.Point(757, 1);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(23, 23);
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.Text = "◻";
            this.maximizeButton.UseVisualStyleBackColor = false;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(780, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "✕";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabDHCP);
            this.tabControl1.Controls.Add(this.tabDNS);
            this.tabControl1.Location = new System.Drawing.Point(-1, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 314);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDHCP
            // 
            this.tabDHCP.BackColor = System.Drawing.SystemColors.Control;
            this.tabDHCP.Controls.Add(this.clientDHCPPortTextbox);
            this.tabDHCP.Controls.Add(this.serverDHCPPortTextbox);
            this.tabDHCP.Controls.Add(this.label2);
            this.tabDHCP.Controls.Add(this.label1);
            this.tabDHCP.Controls.Add(this.outputDHCPtextbox);
            this.tabDHCP.Controls.Add(this.routersDHCPremoveButton);
            this.tabDHCP.Controls.Add(this.routersDHCPaddButton);
            this.tabDHCP.Controls.Add(this.routersDHCPlistbox);
            this.tabDHCP.Controls.Add(this.routersDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label10);
            this.tabDHCP.Controls.Add(this.dnsDHCPlistbox);
            this.tabDHCP.Controls.Add(this.dnsDHCPremoveButton);
            this.tabDHCP.Controls.Add(this.dnsDHCPaddButton);
            this.tabDHCP.Controls.Add(this.dnsDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label9);
            this.tabDHCP.Controls.Add(this.rebindTimeLabel);
            this.tabDHCP.Controls.Add(this.rebindTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.renewTimeLabel);
            this.tabDHCP.Controls.Add(this.renewTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.leaseTimeLabel);
            this.tabDHCP.Controls.Add(this.leaseTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.serverIdLabel);
            this.tabDHCP.Controls.Add(this.serverIdDHCPtextbox);
            this.tabDHCP.Controls.Add(this.broadcastLabel);
            this.tabDHCP.Controls.Add(this.broadcastDHCPtextbox);
            this.tabDHCP.Controls.Add(this.snmLabel);
            this.tabDHCP.Controls.Add(this.snmDHCPtextbox);
            this.tabDHCP.Controls.Add(this.startDHCPbutton);
            this.tabDHCP.Controls.Add(this.poolEndTextbox);
            this.tabDHCP.Controls.Add(this.poolEndLabel);
            this.tabDHCP.Controls.Add(this.poolStartTextbox);
            this.tabDHCP.Controls.Add(this.poolStartLabel);
            this.tabDHCP.Location = new System.Drawing.Point(4, 24);
            this.tabDHCP.Name = "tabDHCP";
            this.tabDHCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabDHCP.Size = new System.Drawing.Size(796, 286);
            this.tabDHCP.TabIndex = 0;
            this.tabDHCP.Text = "DHCP";
            this.tabDHCP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabDHCP_MouseDown);
            // 
            // outputDHCPtextbox
            // 
            this.outputDHCPtextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputDHCPtextbox.Location = new System.Drawing.Point(298, 104);
            this.outputDHCPtextbox.Multiline = true;
            this.outputDHCPtextbox.Name = "outputDHCPtextbox";
            this.outputDHCPtextbox.ReadOnly = true;
            this.outputDHCPtextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputDHCPtextbox.Size = new System.Drawing.Size(490, 176);
            this.outputDHCPtextbox.TabIndex = 27;
            this.outputDHCPtextbox.Enter += new System.EventHandler(this.outputDHCPtextbox_Enter);
            // 
            // routersDHCPremoveButton
            // 
            this.routersDHCPremoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routersDHCPremoveButton.Location = new System.Drawing.Point(576, 75);
            this.routersDHCPremoveButton.Name = "routersDHCPremoveButton";
            this.routersDHCPremoveButton.Size = new System.Drawing.Size(75, 23);
            this.routersDHCPremoveButton.TabIndex = 16;
            this.routersDHCPremoveButton.Text = "Remove";
            this.routersDHCPremoveButton.UseVisualStyleBackColor = true;
            this.routersDHCPremoveButton.Click += new System.EventHandler(this.routersDHCPremoveButton_Click);
            // 
            // routersDHCPaddButton
            // 
            this.routersDHCPaddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routersDHCPaddButton.Location = new System.Drawing.Point(576, 46);
            this.routersDHCPaddButton.Name = "routersDHCPaddButton";
            this.routersDHCPaddButton.Size = new System.Drawing.Size(75, 23);
            this.routersDHCPaddButton.TabIndex = 15;
            this.routersDHCPaddButton.Text = "Add";
            this.routersDHCPaddButton.UseVisualStyleBackColor = true;
            this.routersDHCPaddButton.Click += new System.EventHandler(this.routersDHCPaddButton_Click);
            // 
            // routersDHCPlistbox
            // 
            this.routersDHCPlistbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routersDHCPlistbox.FormattingEnabled = true;
            this.routersDHCPlistbox.ItemHeight = 11;
            this.routersDHCPlistbox.Location = new System.Drawing.Point(657, 30);
            this.routersDHCPlistbox.Name = "routersDHCPlistbox";
            this.routersDHCPlistbox.Size = new System.Drawing.Size(131, 68);
            this.routersDHCPlistbox.TabIndex = 24;
            // 
            // routersDHCPtextbox
            // 
            this.routersDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routersDHCPtextbox.Location = new System.Drawing.Point(657, 6);
            this.routersDHCPtextbox.Name = "routersDHCPtextbox";
            this.routersDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.routersDHCPtextbox.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(590, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 11);
            this.label10.TabIndex = 22;
            this.label10.Text = "Routers:";
            // 
            // dnsDHCPlistbox
            // 
            this.dnsDHCPlistbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dnsDHCPlistbox.FormattingEnabled = true;
            this.dnsDHCPlistbox.ItemHeight = 11;
            this.dnsDHCPlistbox.Location = new System.Drawing.Point(391, 30);
            this.dnsDHCPlistbox.Name = "dnsDHCPlistbox";
            this.dnsDHCPlistbox.Size = new System.Drawing.Size(131, 68);
            this.dnsDHCPlistbox.TabIndex = 21;
            // 
            // dnsDHCPremoveButton
            // 
            this.dnsDHCPremoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dnsDHCPremoveButton.Location = new System.Drawing.Point(298, 75);
            this.dnsDHCPremoveButton.Name = "dnsDHCPremoveButton";
            this.dnsDHCPremoveButton.Size = new System.Drawing.Size(75, 23);
            this.dnsDHCPremoveButton.TabIndex = 13;
            this.dnsDHCPremoveButton.Text = "Remove";
            this.dnsDHCPremoveButton.UseVisualStyleBackColor = true;
            this.dnsDHCPremoveButton.Click += new System.EventHandler(this.dnsDHCPremoveButton_Click);
            // 
            // dnsDHCPaddButton
            // 
            this.dnsDHCPaddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dnsDHCPaddButton.Location = new System.Drawing.Point(298, 46);
            this.dnsDHCPaddButton.Name = "dnsDHCPaddButton";
            this.dnsDHCPaddButton.Size = new System.Drawing.Size(75, 23);
            this.dnsDHCPaddButton.TabIndex = 12;
            this.dnsDHCPaddButton.Text = "Add";
            this.dnsDHCPaddButton.UseVisualStyleBackColor = true;
            this.dnsDHCPaddButton.Click += new System.EventHandler(this.dnsDHCPaddButton_Click);
            // 
            // dnsDHCPtextbox
            // 
            this.dnsDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dnsDHCPtextbox.Location = new System.Drawing.Point(391, 6);
            this.dnsDHCPtextbox.Name = "dnsDHCPtextbox";
            this.dnsDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.dnsDHCPtextbox.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(296, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 11);
            this.label9.TabIndex = 17;
            this.label9.Text = "DNS Servers:";
            // 
            // rebindTimeLabel
            // 
            this.rebindTimeLabel.AutoSize = true;
            this.rebindTimeLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rebindTimeLabel.Location = new System.Drawing.Point(9, 211);
            this.rebindTimeLabel.Name = "rebindTimeLabel";
            this.rebindTimeLabel.Size = new System.Drawing.Size(110, 11);
            this.rebindTimeLabel.TabIndex = 16;
            this.rebindTimeLabel.Text = "Rebinding Time:";
            // 
            // rebindTimeDHCPtextbox
            // 
            this.rebindTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rebindTimeDHCPtextbox.Location = new System.Drawing.Point(125, 209);
            this.rebindTimeDHCPtextbox.Name = "rebindTimeDHCPtextbox";
            this.rebindTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.rebindTimeDHCPtextbox.TabIndex = 8;
            this.rebindTimeDHCPtextbox.Text = "86400";
            // 
            // renewTimeLabel
            // 
            this.renewTimeLabel.AutoSize = true;
            this.renewTimeLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renewTimeLabel.Location = new System.Drawing.Point(23, 182);
            this.renewTimeLabel.Name = "renewTimeLabel";
            this.renewTimeLabel.Size = new System.Drawing.Size(96, 11);
            this.renewTimeLabel.TabIndex = 14;
            this.renewTimeLabel.Text = "Renewal Time:";
            // 
            // renewTimeDHCPtextbox
            // 
            this.renewTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renewTimeDHCPtextbox.Location = new System.Drawing.Point(125, 180);
            this.renewTimeDHCPtextbox.Name = "renewTimeDHCPtextbox";
            this.renewTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.renewTimeDHCPtextbox.TabIndex = 7;
            this.renewTimeDHCPtextbox.Text = "86400";
            // 
            // leaseTimeLabel
            // 
            this.leaseTimeLabel.AutoSize = true;
            this.leaseTimeLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaseTimeLabel.Location = new System.Drawing.Point(37, 153);
            this.leaseTimeLabel.Name = "leaseTimeLabel";
            this.leaseTimeLabel.Size = new System.Drawing.Size(82, 11);
            this.leaseTimeLabel.TabIndex = 12;
            this.leaseTimeLabel.Text = "Lease Time:";
            // 
            // leaseTimeDHCPtextbox
            // 
            this.leaseTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leaseTimeDHCPtextbox.Location = new System.Drawing.Point(125, 151);
            this.leaseTimeDHCPtextbox.Name = "leaseTimeDHCPtextbox";
            this.leaseTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.leaseTimeDHCPtextbox.TabIndex = 6;
            this.leaseTimeDHCPtextbox.Text = "259200";
            // 
            // serverIdLabel
            // 
            this.serverIdLabel.AutoSize = true;
            this.serverIdLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIdLabel.Location = new System.Drawing.Point(44, 124);
            this.serverIdLabel.Name = "serverIdLabel";
            this.serverIdLabel.Size = new System.Drawing.Size(75, 11);
            this.serverIdLabel.TabIndex = 10;
            this.serverIdLabel.Text = "Server ID:";
            // 
            // serverIdDHCPtextbox
            // 
            this.serverIdDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverIdDHCPtextbox.Location = new System.Drawing.Point(125, 122);
            this.serverIdDHCPtextbox.Name = "serverIdDHCPtextbox";
            this.serverIdDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.serverIdDHCPtextbox.TabIndex = 5;
            // 
            // broadcastLabel
            // 
            this.broadcastLabel.AutoSize = true;
            this.broadcastLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.broadcastLabel.Location = new System.Drawing.Point(44, 95);
            this.broadcastLabel.Name = "broadcastLabel";
            this.broadcastLabel.Size = new System.Drawing.Size(75, 11);
            this.broadcastLabel.TabIndex = 8;
            this.broadcastLabel.Text = "Broadcast:";
            // 
            // broadcastDHCPtextbox
            // 
            this.broadcastDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.broadcastDHCPtextbox.Location = new System.Drawing.Point(125, 93);
            this.broadcastDHCPtextbox.Name = "broadcastDHCPtextbox";
            this.broadcastDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.broadcastDHCPtextbox.TabIndex = 4;
            // 
            // snmLabel
            // 
            this.snmLabel.AutoSize = true;
            this.snmLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snmLabel.Location = new System.Drawing.Point(30, 66);
            this.snmLabel.Name = "snmLabel";
            this.snmLabel.Size = new System.Drawing.Size(89, 11);
            this.snmLabel.TabIndex = 6;
            this.snmLabel.Text = "Subnet Mask:";
            // 
            // snmDHCPtextbox
            // 
            this.snmDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snmDHCPtextbox.Location = new System.Drawing.Point(125, 64);
            this.snmDHCPtextbox.Name = "snmDHCPtextbox";
            this.snmDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.snmDHCPtextbox.TabIndex = 3;
            // 
            // startDHCPbutton
            // 
            this.startDHCPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startDHCPbutton.Location = new System.Drawing.Point(11, 233);
            this.startDHCPbutton.Name = "startDHCPbutton";
            this.startDHCPbutton.Size = new System.Drawing.Size(99, 47);
            this.startDHCPbutton.TabIndex = 5;
            this.startDHCPbutton.Text = "Start";
            this.startDHCPbutton.UseVisualStyleBackColor = true;
            this.startDHCPbutton.Click += new System.EventHandler(this.startDHCPbutton_Click);
            // 
            // poolEndTextbox
            // 
            this.poolEndTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolEndTextbox.Location = new System.Drawing.Point(125, 35);
            this.poolEndTextbox.Name = "poolEndTextbox";
            this.poolEndTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolEndTextbox.TabIndex = 2;
            // 
            // poolEndLabel
            // 
            this.poolEndLabel.AutoSize = true;
            this.poolEndLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poolEndLabel.Location = new System.Drawing.Point(51, 37);
            this.poolEndLabel.Name = "poolEndLabel";
            this.poolEndLabel.Size = new System.Drawing.Size(68, 11);
            this.poolEndLabel.TabIndex = 2;
            this.poolEndLabel.Text = "Pool End:";
            // 
            // poolStartTextbox
            // 
            this.poolStartTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolStartTextbox.Location = new System.Drawing.Point(125, 6);
            this.poolStartTextbox.Name = "poolStartTextbox";
            this.poolStartTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolStartTextbox.TabIndex = 1;
            // 
            // poolStartLabel
            // 
            this.poolStartLabel.AutoSize = true;
            this.poolStartLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poolStartLabel.Location = new System.Drawing.Point(37, 8);
            this.poolStartLabel.Name = "poolStartLabel";
            this.poolStartLabel.Size = new System.Drawing.Size(82, 11);
            this.poolStartLabel.TabIndex = 0;
            this.poolStartLabel.Text = "Pool Start:";
            // 
            // tabDNS
            // 
            this.tabDNS.Location = new System.Drawing.Point(4, 24);
            this.tabDNS.Name = "tabDNS";
            this.tabDNS.Padding = new System.Windows.Forms.Padding(3);
            this.tabDNS.Size = new System.Drawing.Size(796, 286);
            this.tabDNS.TabIndex = 1;
            this.tabDNS.Text = "DNS";
            this.tabDNS.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 11);
            this.label1.TabIndex = 28;
            this.label1.Text = "Server Port:";
            this.toolTip1.SetToolTip(this.label1, "Port for server to listen [UDP]");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 11);
            this.label2.TabIndex = 29;
            this.label2.Text = "Client Port:";
            this.toolTip1.SetToolTip(this.label2, "Port for client to listen [UDP]");
            // 
            // serverDHCPPortTextbox
            // 
            this.serverDHCPPortTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverDHCPPortTextbox.Location = new System.Drawing.Point(218, 233);
            this.serverDHCPPortTextbox.Name = "serverDHCPPortTextbox";
            this.serverDHCPPortTextbox.Size = new System.Drawing.Size(38, 18);
            this.serverDHCPPortTextbox.TabIndex = 9;
            this.serverDHCPPortTextbox.Text = "67";
            // 
            // clientDHCPPortTextbox
            // 
            this.clientDHCPPortTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientDHCPPortTextbox.Location = new System.Drawing.Point(218, 257);
            this.clientDHCPPortTextbox.Name = "clientDHCPPortTextbox";
            this.clientDHCPPortTextbox.Size = new System.Drawing.Size(38, 18);
            this.clientDHCPPortTextbox.TabIndex = 10;
            this.clientDHCPPortTextbox.Text = "68";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 319);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.maximizeButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "mainForm";
            this.Text = "Net Utils";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseDown);
            this.tabControl1.ResumeLayout(false);
            this.tabDHCP.ResumeLayout(false);
            this.tabDHCP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button maximizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDHCP;
        private System.Windows.Forms.TabPage tabDNS;
        private System.Windows.Forms.TextBox poolStartTextbox;
        private System.Windows.Forms.Label poolStartLabel;
        private System.Windows.Forms.TextBox poolEndTextbox;
        private System.Windows.Forms.Label poolEndLabel;
        private System.Windows.Forms.Button startDHCPbutton;
        private System.Windows.Forms.TextBox snmDHCPtextbox;
        private System.Windows.Forms.TextBox renewTimeDHCPtextbox;
        private System.Windows.Forms.Label leaseTimeLabel;
        private System.Windows.Forms.TextBox leaseTimeDHCPtextbox;
        private System.Windows.Forms.Label serverIdLabel;
        private System.Windows.Forms.TextBox serverIdDHCPtextbox;
        private System.Windows.Forms.Label broadcastLabel;
        private System.Windows.Forms.TextBox broadcastDHCPtextbox;
        private System.Windows.Forms.Label snmLabel;
        private System.Windows.Forms.TextBox dnsDHCPtextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label rebindTimeLabel;
        private System.Windows.Forms.TextBox rebindTimeDHCPtextbox;
        private System.Windows.Forms.Label renewTimeLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox dnsDHCPlistbox;
        private System.Windows.Forms.Button dnsDHCPremoveButton;
        private System.Windows.Forms.Button dnsDHCPaddButton;
        private System.Windows.Forms.TextBox routersDHCPtextbox;
        private System.Windows.Forms.Button routersDHCPremoveButton;
        private System.Windows.Forms.Button routersDHCPaddButton;
        private System.Windows.Forms.ListBox routersDHCPlistbox;
        private System.Windows.Forms.TextBox outputDHCPtextbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverDHCPPortTextbox;
        private System.Windows.Forms.TextBox clientDHCPPortTextbox;
    }
}

