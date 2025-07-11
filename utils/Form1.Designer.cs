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
            this.tabDNS = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.poolStartTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.poolEndTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startDHCPbutton = new System.Windows.Forms.Button();
            this.snmDHCPcheckbox = new System.Windows.Forms.CheckBox();
            this.snmDHCPtextbox = new System.Windows.Forms.TextBox();
            this.routerDHCPcheckbox = new System.Windows.Forms.CheckBox();
            this.routerDHCPtextbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabDHCP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Location = new System.Drawing.Point(863, 1);
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
            this.maximizeButton.Location = new System.Drawing.Point(886, 1);
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
            this.closeButton.Location = new System.Drawing.Point(909, 1);
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
            this.tabControl1.Size = new System.Drawing.Size(933, 376);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDHCP
            // 
            this.tabDHCP.BackColor = System.Drawing.SystemColors.Control;
            this.tabDHCP.Controls.Add(this.startDHCPbutton);
            this.tabDHCP.Controls.Add(this.groupBox1);
            this.tabDHCP.Controls.Add(this.poolEndTextbox);
            this.tabDHCP.Controls.Add(this.label2);
            this.tabDHCP.Controls.Add(this.poolStartTextbox);
            this.tabDHCP.Controls.Add(this.label1);
            this.tabDHCP.Location = new System.Drawing.Point(4, 24);
            this.tabDHCP.Name = "tabDHCP";
            this.tabDHCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabDHCP.Size = new System.Drawing.Size(925, 348);
            this.tabDHCP.TabIndex = 0;
            this.tabDHCP.Text = "DHCP";
            this.tabDHCP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabDHCP_MouseDown);
            // 
            // tabDNS
            // 
            this.tabDNS.Location = new System.Drawing.Point(4, 24);
            this.tabDNS.Name = "tabDNS";
            this.tabDNS.Padding = new System.Windows.Forms.Padding(3);
            this.tabDNS.Size = new System.Drawing.Size(925, 348);
            this.tabDNS.TabIndex = 1;
            this.tabDNS.Text = "DNS";
            this.tabDNS.UseVisualStyleBackColor = true;
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
            // poolStartTextbox
            // 
            this.poolStartTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolStartTextbox.Location = new System.Drawing.Point(125, 6);
            this.poolStartTextbox.Name = "poolStartTextbox";
            this.poolStartTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolStartTextbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 11);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pool End:";
            // 
            // poolEndTextbox
            // 
            this.poolEndTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolEndTextbox.Location = new System.Drawing.Point(125, 34);
            this.poolEndTextbox.Name = "poolEndTextbox";
            this.poolEndTextbox.Size = new System.Drawing.Size(131, 18);
            this.poolEndTextbox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.routerDHCPtextbox);
            this.groupBox1.Controls.Add(this.routerDHCPcheckbox);
            this.groupBox1.Controls.Add(this.snmDHCPtextbox);
            this.groupBox1.Controls.Add(this.snmDHCPcheckbox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(11, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 230);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DHCP Options";
            // 
            // startDHCPbutton
            // 
            this.startDHCPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startDHCPbutton.Location = new System.Drawing.Point(11, 294);
            this.startDHCPbutton.Name = "startDHCPbutton";
            this.startDHCPbutton.Size = new System.Drawing.Size(245, 47);
            this.startDHCPbutton.TabIndex = 5;
            this.startDHCPbutton.Text = "Start";
            this.startDHCPbutton.UseVisualStyleBackColor = true;
            this.startDHCPbutton.Click += new System.EventHandler(this.startDHCPbutton_Click);
            // 
            // snmDHCPcheckbox
            // 
            this.snmDHCPcheckbox.AutoSize = true;
            this.snmDHCPcheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snmDHCPcheckbox.Location = new System.Drawing.Point(6, 17);
            this.snmDHCPcheckbox.Name = "snmDHCPcheckbox";
            this.snmDHCPcheckbox.Size = new System.Drawing.Size(98, 15);
            this.snmDHCPcheckbox.TabIndex = 0;
            this.snmDHCPcheckbox.Text = "Subnet Mask";
            this.snmDHCPcheckbox.UseVisualStyleBackColor = true;
            this.snmDHCPcheckbox.CheckedChanged += new System.EventHandler(this.snmDHCPcheckbox_CheckedChanged);
            // 
            // snmDHCPtextbox
            // 
            this.snmDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snmDHCPtextbox.Enabled = false;
            this.snmDHCPtextbox.Location = new System.Drawing.Point(110, 14);
            this.snmDHCPtextbox.Name = "snmDHCPtextbox";
            this.snmDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.snmDHCPtextbox.TabIndex = 2;
            // 
            // routerDHCPcheckbox
            // 
            this.routerDHCPcheckbox.AutoSize = true;
            this.routerDHCPcheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routerDHCPcheckbox.Location = new System.Drawing.Point(6, 38);
            this.routerDHCPcheckbox.Name = "routerDHCPcheckbox";
            this.routerDHCPcheckbox.Size = new System.Drawing.Size(63, 15);
            this.routerDHCPcheckbox.TabIndex = 3;
            this.routerDHCPcheckbox.Text = "Router";
            this.routerDHCPcheckbox.UseVisualStyleBackColor = true;
            this.routerDHCPcheckbox.CheckedChanged += new System.EventHandler(this.routerDHCPcheckbox_CheckedChanged);
            // 
            // routerDHCPtextbox
            // 
            this.routerDHCPtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routerDHCPtextbox.Enabled = false;
            this.routerDHCPtextbox.Location = new System.Drawing.Point(110, 38);
            this.routerDHCPtextbox.Name = "routerDHCPtextbox";
            this.routerDHCPtextbox.Size = new System.Drawing.Size(131, 18);
            this.routerDHCPtextbox.TabIndex = 4;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 381);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox snmDHCPtextbox;
        private System.Windows.Forms.CheckBox snmDHCPcheckbox;
        private System.Windows.Forms.CheckBox routerDHCPcheckbox;
        private System.Windows.Forms.TextBox routerDHCPtextbox;
    }
}

