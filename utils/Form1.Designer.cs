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
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDHCP = new System.Windows.Forms.TabPage();
            this.startDHCPbutton = new System.Windows.Forms.Button();
            this.snmDHCPtextbox = new System.Windows.Forms.TextBox();
            this.poolEndTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.poolStartTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDNS = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.broadcastDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverIdDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.leaseTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.renewTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rebindTimeDHCPtextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dnsDHCPaddButton = new System.Windows.Forms.Button();
            this.dnsDHCPremoveButton = new System.Windows.Forms.Button();
            this.dnsDHCPlistbox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.routersDHCPtextbox = new System.Windows.Forms.TextBox();
            this.routersDHCPlistbox = new System.Windows.Forms.ListBox();
            this.routersDHCPaddButton = new System.Windows.Forms.Button();
            this.routersDHCPremoveButton = new System.Windows.Forms.Button();
            this.outputDHCPtextbox = new System.Windows.Forms.TextBox();
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
            this.tabDHCP.Controls.Add(this.outputDHCPtextbox);
            this.tabDHCP.Controls.Add(this.routersDHCPremoveButton);
            this.tabDHCP.Controls.Add(this.routersDHCPaddButton);
            this.tabDHCP.Controls.Add(this.routersDHCPlistbox);
            this.tabDHCP.Controls.Add(this.routersDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label10);
            this.tabDHCP.Controls.Add(this.dnsDHCPlistbox);
            this.tabDHCP.Controls.Add(this.dnsDHCPremoveButton);
            this.tabDHCP.Controls.Add(this.dnsDHCPaddButton);
            this.tabDHCP.Controls.Add(this.textBox1);
            this.tabDHCP.Controls.Add(this.label9);
            this.tabDHCP.Controls.Add(this.label8);
            this.tabDHCP.Controls.Add(this.rebindTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label7);
            this.tabDHCP.Controls.Add(this.renewTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label6);
            this.tabDHCP.Controls.Add(this.leaseTimeDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label5);
            this.tabDHCP.Controls.Add(this.serverIdDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label4);
            this.tabDHCP.Controls.Add(this.broadcastDHCPtextbox);
            this.tabDHCP.Controls.Add(this.label3);
            this.tabDHCP.Controls.Add(this.snmDHCPtextbox);
            this.tabDHCP.Controls.Add(this.startDHCPbutton);
            this.tabDHCP.Controls.Add(this.poolEndTextbox);
            this.tabDHCP.Controls.Add(this.label2);
            this.tabDHCP.Controls.Add(this.poolStartTextbox);
            this.tabDHCP.Controls.Add(this.label1);
            this.tabDHCP.Location = new System.Drawing.Point(4, 24);
            this.tabDHCP.Name = "tabDHCP";
            this.tabDHCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabDHCP.Size = new System.Drawing.Size(796, 286);
            this.tabDHCP.TabIndex = 0;
            this.tabDHCP.Text = "DHCP";
            this.tabDHCP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabDHCP_MouseDown);
            // 
            // startDHCPbutton
            // 
            this.startDHCPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startDHCPbutton.Location = new System.Drawing.Point(11, 233);
            this.startDHCPbutton.Name = "startDHCPbutton";
            this.startDHCPbutton.Size = new System.Drawing.Size(245, 47);
            this.startDHCPbutton.TabIndex = 5;
            this.startDHCPbutton.Text = "Start";
            this.startDHCPbutton.UseVisualStyleBackColor = true;
            this.startDHCPbutton.Click += new System.EventHandler(this.startDHCPbutton_Click);
            // 
            // snmDHCPtextbox
            // 
            this.snmDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snmDHCPtextbox.Location = new System.Drawing.Point(125, 64);
            this.snmDHCPtextbox.Name = "snmDHCPtextbox";
            this.snmDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.snmDHCPtextbox.TabIndex = 2;
            // 
            // poolEndTextbox
            // 
            this.poolEndTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolEndTextbox.Location = new System.Drawing.Point(125, 35);
            this.poolEndTextbox.Name = "poolEndTextbox";
            this.poolEndTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolEndTextbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 11);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pool End:";
            // 
            // poolStartTextbox
            // 
            this.poolStartTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolStartTextbox.Location = new System.Drawing.Point(125, 6);
            this.poolStartTextbox.Name = "poolStartTextbox";
            this.poolStartTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolStartTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 11);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pool Start:";
            // 
            // tabDNS
            // 
            this.tabDNS.Location = new System.Drawing.Point(4, 24);
            this.tabDNS.Name = "tabDNS";
            this.tabDNS.Padding = new System.Windows.Forms.Padding(3);
            this.tabDNS.Size = new System.Drawing.Size(799, 348);
            this.tabDNS.TabIndex = 1;
            this.tabDNS.Text = "DNS";
            this.tabDNS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 11);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subnet Mask:";
            // 
            // broadcastDHCPtextbox
            // 
            this.broadcastDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.broadcastDHCPtextbox.Location = new System.Drawing.Point(125, 93);
            this.broadcastDHCPtextbox.Name = "broadcastDHCPtextbox";
            this.broadcastDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.broadcastDHCPtextbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 11);
            this.label4.TabIndex = 8;
            this.label4.Text = "Broadcast:";
            // 
            // serverIdDHCPtextbox
            // 
            this.serverIdDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverIdDHCPtextbox.Location = new System.Drawing.Point(125, 122);
            this.serverIdDHCPtextbox.Name = "serverIdDHCPtextbox";
            this.serverIdDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.serverIdDHCPtextbox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 11);
            this.label5.TabIndex = 10;
            this.label5.Text = "Server ID:";
            // 
            // leaseTimeDHCPtextbox
            // 
            this.leaseTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leaseTimeDHCPtextbox.Location = new System.Drawing.Point(125, 151);
            this.leaseTimeDHCPtextbox.Name = "leaseTimeDHCPtextbox";
            this.leaseTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.leaseTimeDHCPtextbox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 11);
            this.label6.TabIndex = 12;
            this.label6.Text = "Lease Time:";
            // 
            // renewTimeDHCPtextbox
            // 
            this.renewTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renewTimeDHCPtextbox.Location = new System.Drawing.Point(125, 180);
            this.renewTimeDHCPtextbox.Name = "renewTimeDHCPtextbox";
            this.renewTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.renewTimeDHCPtextbox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 11);
            this.label7.TabIndex = 14;
            this.label7.Text = "Renewal Time:";
            // 
            // rebindTimeDHCPtextbox
            // 
            this.rebindTimeDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rebindTimeDHCPtextbox.Location = new System.Drawing.Point(125, 209);
            this.rebindTimeDHCPtextbox.Name = "rebindTimeDHCPtextbox";
            this.rebindTimeDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.rebindTimeDHCPtextbox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 11);
            this.label8.TabIndex = 16;
            this.label8.Text = "Rebinding Time:";
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
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(391, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 18);
            this.textBox1.TabIndex = 18;
            // 
            // dnsDHCPaddButton
            // 
            this.dnsDHCPaddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dnsDHCPaddButton.Location = new System.Drawing.Point(298, 46);
            this.dnsDHCPaddButton.Name = "dnsDHCPaddButton";
            this.dnsDHCPaddButton.Size = new System.Drawing.Size(75, 23);
            this.dnsDHCPaddButton.TabIndex = 19;
            this.dnsDHCPaddButton.Text = "Add";
            this.dnsDHCPaddButton.UseVisualStyleBackColor = true;
            // 
            // dnsDHCPremoveButton
            // 
            this.dnsDHCPremoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dnsDHCPremoveButton.Location = new System.Drawing.Point(298, 75);
            this.dnsDHCPremoveButton.Name = "dnsDHCPremoveButton";
            this.dnsDHCPremoveButton.Size = new System.Drawing.Size(75, 23);
            this.dnsDHCPremoveButton.TabIndex = 20;
            this.dnsDHCPremoveButton.Text = "Remove";
            this.dnsDHCPremoveButton.UseVisualStyleBackColor = true;
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
            // routersDHCPtextbox
            // 
            this.routersDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routersDHCPtextbox.Location = new System.Drawing.Point(657, 6);
            this.routersDHCPtextbox.Name = "routersDHCPtextbox";
            this.routersDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.routersDHCPtextbox.TabIndex = 23;
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
            // routersDHCPaddButton
            // 
            this.routersDHCPaddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routersDHCPaddButton.Location = new System.Drawing.Point(576, 46);
            this.routersDHCPaddButton.Name = "routersDHCPaddButton";
            this.routersDHCPaddButton.Size = new System.Drawing.Size(75, 23);
            this.routersDHCPaddButton.TabIndex = 25;
            this.routersDHCPaddButton.Text = "Add";
            this.routersDHCPaddButton.UseVisualStyleBackColor = true;
            // 
            // routersDHCPremoveButton
            // 
            this.routersDHCPremoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routersDHCPremoveButton.Location = new System.Drawing.Point(576, 75);
            this.routersDHCPremoveButton.Name = "routersDHCPremoveButton";
            this.routersDHCPremoveButton.Size = new System.Drawing.Size(75, 23);
            this.routersDHCPremoveButton.TabIndex = 26;
            this.routersDHCPremoveButton.Text = "Remove";
            this.routersDHCPremoveButton.UseVisualStyleBackColor = true;
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
            this.outputDHCPtextbox.Size = new System.Drawing.Size(490, 176);
            this.outputDHCPtextbox.TabIndex = 27;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox poolEndTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startDHCPbutton;
        private System.Windows.Forms.TextBox snmDHCPtextbox;
        private System.Windows.Forms.TextBox renewTimeDHCPtextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox leaseTimeDHCPtextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox serverIdDHCPtextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox broadcastDHCPtextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rebindTimeDHCPtextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox dnsDHCPlistbox;
        private System.Windows.Forms.Button dnsDHCPremoveButton;
        private System.Windows.Forms.Button dnsDHCPaddButton;
        private System.Windows.Forms.TextBox routersDHCPtextbox;
        private System.Windows.Forms.Button routersDHCPremoveButton;
        private System.Windows.Forms.Button routersDHCPaddButton;
        private System.Windows.Forms.ListBox routersDHCPlistbox;
        private System.Windows.Forms.TextBox outputDHCPtextbox;
    }
}

