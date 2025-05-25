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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.icmpButton = new System.Windows.Forms.Button();
            this.pointerTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tranTimestampTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.recvTimestampTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.origTimestampTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gwInetAddrTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.origDatagramTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.inetHeaderTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sequenceTextBox = new System.Windows.Forms.TextBox();
            this.identifierTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checksumTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RFCtext = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeList = new System.Windows.Forms.ComboBox();
            this.ICMPipAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.rrComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dnsValueTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dnsPreferenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dnsConfigListView = new System.Windows.Forms.ListView();
            this.dnsAddButton = new System.Windows.Forms.Button();
            this.dnsRemoveButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dnsStartServerButton = new System.Windows.Forms.Button();
            this.dnsStopServerButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.dnsPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dnsUdpRadio = new System.Windows.Forms.RadioButton();
            this.dnsTcpRadio = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dnsPreferenceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnsPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(903, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.icmpButton);
            this.tabPage1.Controls.Add(this.pointerTextBox);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.dataTextBox);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.tranTimestampTextBox);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.recvTimestampTextBox);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.origTimestampTextBox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.gwInetAddrTextBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.origDatagramTextBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.inetHeaderTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.sequenceTextBox);
            this.tabPage1.Controls.Add(this.identifierTextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.checksumTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.codeTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.RFCtext);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TypeList);
            this.tabPage1.Controls.Add(this.ICMPipAddressTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(895, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ICMP";
            // 
            // icmpButton
            // 
            this.icmpButton.Location = new System.Drawing.Point(266, 234);
            this.icmpButton.Name = "icmpButton";
            this.icmpButton.Size = new System.Drawing.Size(91, 23);
            this.icmpButton.TabIndex = 29;
            this.icmpButton.Text = "Send Packet";
            this.icmpButton.UseVisualStyleBackColor = true;
            this.icmpButton.Click += new System.EventHandler(this.icmpButton_Click);
            // 
            // pointerTextBox
            // 
            this.pointerTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointerTextBox.Location = new System.Drawing.Point(52, 234);
            this.pointerTextBox.Name = "pointerTextBox";
            this.pointerTextBox.ReadOnly = true;
            this.pointerTextBox.Size = new System.Drawing.Size(100, 20);
            this.pointerTextBox.TabIndex = 28;
            this.pointerTextBox.TextChanged += new System.EventHandler(this.pointerTextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Pointer";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTextBox.Location = new System.Drawing.Point(42, 272);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.Size = new System.Drawing.Size(315, 122);
            this.dataTextBox.TabIndex = 26;
            this.dataTextBox.TextChanged += new System.EventHandler(this.dataTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Data";
            // 
            // tranTimestampTextBox
            // 
            this.tranTimestampTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tranTimestampTextBox.Location = new System.Drawing.Point(266, 205);
            this.tranTimestampTextBox.Name = "tranTimestampTextBox";
            this.tranTimestampTextBox.ReadOnly = true;
            this.tranTimestampTextBox.Size = new System.Drawing.Size(91, 20);
            this.tranTimestampTextBox.TabIndex = 24;
            this.tranTimestampTextBox.TextChanged += new System.EventHandler(this.tranTimestampTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(182, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Tran. Timestamp";
            // 
            // recvTimestampTextBox
            // 
            this.recvTimestampTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recvTimestampTextBox.Location = new System.Drawing.Point(102, 204);
            this.recvTimestampTextBox.Name = "recvTimestampTextBox";
            this.recvTimestampTextBox.ReadOnly = true;
            this.recvTimestampTextBox.Size = new System.Drawing.Size(74, 20);
            this.recvTimestampTextBox.TabIndex = 22;
            this.recvTimestampTextBox.TextChanged += new System.EventHandler(this.recvTimestampTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Recv. Timestamp";
            // 
            // origTimestampTextBox
            // 
            this.origTimestampTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origTimestampTextBox.Location = new System.Drawing.Point(266, 168);
            this.origTimestampTextBox.Name = "origTimestampTextBox";
            this.origTimestampTextBox.ReadOnly = true;
            this.origTimestampTextBox.Size = new System.Drawing.Size(91, 20);
            this.origTimestampTextBox.TabIndex = 20;
            this.origTimestampTextBox.TextChanged += new System.EventHandler(this.origTimestampTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Orig. Timestamp";
            // 
            // gwInetAddrTextBox
            // 
            this.gwInetAddrTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwInetAddrTextBox.Location = new System.Drawing.Point(84, 167);
            this.gwInetAddrTextBox.Name = "gwInetAddrTextBox";
            this.gwInetAddrTextBox.ReadOnly = true;
            this.gwInetAddrTextBox.Size = new System.Drawing.Size(92, 20);
            this.gwInetAddrTextBox.TabIndex = 18;
            this.gwInetAddrTextBox.TextChanged += new System.EventHandler(this.gwInetAddrTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "GW Inet Addr";
            // 
            // origDatagramTextBox
            // 
            this.origDatagramTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origDatagramTextBox.Location = new System.Drawing.Point(266, 131);
            this.origDatagramTextBox.Name = "origDatagramTextBox";
            this.origDatagramTextBox.ReadOnly = true;
            this.origDatagramTextBox.Size = new System.Drawing.Size(91, 20);
            this.origDatagramTextBox.TabIndex = 16;
            this.origDatagramTextBox.TextChanged += new System.EventHandler(this.origDatagramTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Orig. Datagram";
            // 
            // inetHeaderTextBox
            // 
            this.inetHeaderTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inetHeaderTextBox.Location = new System.Drawing.Point(84, 130);
            this.inetHeaderTextBox.Name = "inetHeaderTextBox";
            this.inetHeaderTextBox.ReadOnly = true;
            this.inetHeaderTextBox.Size = new System.Drawing.Size(92, 20);
            this.inetHeaderTextBox.TabIndex = 14;
            this.inetHeaderTextBox.TextChanged += new System.EventHandler(this.inetHeaderTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Inet Header";
            // 
            // sequenceTextBox
            // 
            this.sequenceTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequenceTextBox.Location = new System.Drawing.Point(266, 93);
            this.sequenceTextBox.Name = "sequenceTextBox";
            this.sequenceTextBox.ReadOnly = true;
            this.sequenceTextBox.Size = new System.Drawing.Size(91, 20);
            this.sequenceTextBox.TabIndex = 12;
            this.sequenceTextBox.TextChanged += new System.EventHandler(this.sequenceTextBox_TextChanged);
            // 
            // identifierTextBox
            // 
            this.identifierTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identifierTextBox.Location = new System.Drawing.Point(84, 93);
            this.identifierTextBox.Name = "identifierTextBox";
            this.identifierTextBox.ReadOnly = true;
            this.identifierTextBox.Size = new System.Drawing.Size(44, 20);
            this.identifierTextBox.TabIndex = 11;
            this.identifierTextBox.TextChanged += new System.EventHandler(this.identifierTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Sequence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Identifier";
            // 
            // checksumTextBox
            // 
            this.checksumTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checksumTextBox.Location = new System.Drawing.Point(266, 51);
            this.checksumTextBox.Name = "checksumTextBox";
            this.checksumTextBox.ReadOnly = true;
            this.checksumTextBox.Size = new System.Drawing.Size(91, 20);
            this.checksumTextBox.TabIndex = 8;
            this.checksumTextBox.TextChanged += new System.EventHandler(this.checksumTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Checksum";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.Location = new System.Drawing.Point(84, 51);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(44, 20);
            this.codeTextBox.TabIndex = 6;
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code";
            // 
            // RFCtext
            // 
            this.RFCtext.AutoSize = true;
            this.RFCtext.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFCtext.Location = new System.Drawing.Point(470, 15);
            this.RFCtext.Name = "RFCtext";
            this.RFCtext.Size = new System.Drawing.Size(0, 15);
            this.RFCtext.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // TypeList
            // 
            this.TypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeList.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeList.FormattingEnabled = true;
            this.TypeList.Items.AddRange(new object[] {
            "0  [Echo Reply]",
            "3  [Destination Unreachable]",
            "4  [Source Quench]",
            "5  [Redirect]",
            "8  [Echo]",
            "11 [Time Exceeded]",
            "12 [Parameter Problem]",
            "13 [Timestamp]",
            "14 [Timestamp Reply]",
            "15 [Information Request]",
            "16 [Information Reply]"});
            this.TypeList.Location = new System.Drawing.Point(266, 10);
            this.TypeList.Name = "TypeList";
            this.TypeList.Size = new System.Drawing.Size(178, 23);
            this.TypeList.TabIndex = 2;
            this.TypeList.SelectedIndexChanged += new System.EventHandler(this.TypeList_SelectedIndexChanged);
            // 
            // ICMPipAddressTextBox
            // 
            this.ICMPipAddressTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ICMPipAddressTextBox.Location = new System.Drawing.Point(84, 12);
            this.ICMPipAddressTextBox.Name = "ICMPipAddressTextBox";
            this.ICMPipAddressTextBox.Size = new System.Drawing.Size(92, 20);
            this.ICMPipAddressTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dnsTcpRadio);
            this.tabPage2.Controls.Add(this.dnsUdpRadio);
            this.tabPage2.Controls.Add(this.dnsPortNumericUpDown);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.dnsStopServerButton);
            this.tabPage2.Controls.Add(this.dnsStartServerButton);
            this.tabPage2.Controls.Add(this.dnsRemoveButton);
            this.tabPage2.Controls.Add(this.dnsAddButton);
            this.tabPage2.Controls.Add(this.dnsConfigListView);
            this.tabPage2.Controls.Add(this.dnsPreferenceNumericUpDown);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.dnsValueTextBox);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.domainTextBox);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.rrComboBox);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DNS";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(895, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DHCP";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(895, 400);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SNMP";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(895, 400);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "LDAP";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Resource Record";
            // 
            // rrComboBox
            // 
            this.rrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rrComboBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rrComboBox.FormattingEnabled = true;
            this.rrComboBox.Items.AddRange(new object[] {
            "A",
            "CNAME",
            "MX",
            "NS",
            "PTR",
            "TXT"});
            this.rrComboBox.Location = new System.Drawing.Point(6, 19);
            this.rrComboBox.Name = "rrComboBox";
            this.rrComboBox.Size = new System.Drawing.Size(91, 23);
            this.rrComboBox.TabIndex = 1;
            this.rrComboBox.SelectedIndexChanged += new System.EventHandler(this.rrComboBox_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(119, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Domain";
            // 
            // domainTextBox
            // 
            this.domainTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainTextBox.Location = new System.Drawing.Point(122, 19);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.ReadOnly = true;
            this.domainTextBox.Size = new System.Drawing.Size(219, 20);
            this.domainTextBox.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(398, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Value";
            // 
            // dnsValueTextBox
            // 
            this.dnsValueTextBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnsValueTextBox.Location = new System.Drawing.Point(401, 19);
            this.dnsValueTextBox.Name = "dnsValueTextBox";
            this.dnsValueTextBox.ReadOnly = true;
            this.dnsValueTextBox.Size = new System.Drawing.Size(219, 20);
            this.dnsValueTextBox.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(674, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Preference";
            // 
            // dnsPreferenceNumericUpDown
            // 
            this.dnsPreferenceNumericUpDown.Location = new System.Drawing.Point(677, 19);
            this.dnsPreferenceNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dnsPreferenceNumericUpDown.Name = "dnsPreferenceNumericUpDown";
            this.dnsPreferenceNumericUpDown.ReadOnly = true;
            this.dnsPreferenceNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.dnsPreferenceNumericUpDown.TabIndex = 7;
            // 
            // dnsConfigListView
            // 
            this.dnsConfigListView.BackColor = System.Drawing.SystemColors.Control;
            this.dnsConfigListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.dnsConfigListView.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnsConfigListView.FullRowSelect = true;
            this.dnsConfigListView.HideSelection = false;
            this.dnsConfigListView.Location = new System.Drawing.Point(6, 77);
            this.dnsConfigListView.Name = "dnsConfigListView";
            this.dnsConfigListView.Size = new System.Drawing.Size(883, 317);
            this.dnsConfigListView.TabIndex = 8;
            this.dnsConfigListView.UseCompatibleStateImageBehavior = false;
            this.dnsConfigListView.View = System.Windows.Forms.View.Details;
            // 
            // dnsAddButton
            // 
            this.dnsAddButton.Location = new System.Drawing.Point(122, 48);
            this.dnsAddButton.Name = "dnsAddButton";
            this.dnsAddButton.Size = new System.Drawing.Size(59, 23);
            this.dnsAddButton.TabIndex = 9;
            this.dnsAddButton.Text = "Add";
            this.dnsAddButton.UseVisualStyleBackColor = true;
            this.dnsAddButton.Click += new System.EventHandler(this.dnsAddButton_Click);
            // 
            // dnsRemoveButton
            // 
            this.dnsRemoveButton.Location = new System.Drawing.Point(187, 48);
            this.dnsRemoveButton.Name = "dnsRemoveButton";
            this.dnsRemoveButton.Size = new System.Drawing.Size(59, 23);
            this.dnsRemoveButton.TabIndex = 10;
            this.dnsRemoveButton.Text = "Remove";
            this.dnsRemoveButton.UseVisualStyleBackColor = true;
            this.dnsRemoveButton.Click += new System.EventHandler(this.dnsRemoveButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "DNS Record";
            this.columnHeader1.Width = 748;
            // 
            // dnsStartServerButton
            // 
            this.dnsStartServerButton.Location = new System.Drawing.Point(739, 43);
            this.dnsStartServerButton.Name = "dnsStartServerButton";
            this.dnsStartServerButton.Size = new System.Drawing.Size(72, 23);
            this.dnsStartServerButton.TabIndex = 11;
            this.dnsStartServerButton.Text = "Start Server";
            this.dnsStartServerButton.UseVisualStyleBackColor = true;
            this.dnsStartServerButton.Click += new System.EventHandler(this.dnsStartServerButton_Click);
            // 
            // dnsStopServerButton
            // 
            this.dnsStopServerButton.Location = new System.Drawing.Point(817, 43);
            this.dnsStopServerButton.Name = "dnsStopServerButton";
            this.dnsStopServerButton.Size = new System.Drawing.Size(72, 23);
            this.dnsStopServerButton.TabIndex = 12;
            this.dnsStopServerButton.Text = "Stop Server";
            this.dnsStopServerButton.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(645, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Port";
            // 
            // dnsPortNumericUpDown
            // 
            this.dnsPortNumericUpDown.Location = new System.Drawing.Point(677, 46);
            this.dnsPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dnsPortNumericUpDown.Name = "dnsPortNumericUpDown";
            this.dnsPortNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.dnsPortNumericUpDown.TabIndex = 14;
            this.dnsPortNumericUpDown.Value = new decimal(new int[] {
            53,
            0,
            0,
            0});
            // 
            // dnsUdpRadio
            // 
            this.dnsUdpRadio.AutoSize = true;
            this.dnsUdpRadio.Checked = true;
            this.dnsUdpRadio.Location = new System.Drawing.Point(539, 46);
            this.dnsUdpRadio.Name = "dnsUdpRadio";
            this.dnsUdpRadio.Size = new System.Drawing.Size(48, 17);
            this.dnsUdpRadio.TabIndex = 15;
            this.dnsUdpRadio.TabStop = true;
            this.dnsUdpRadio.Text = "UDP";
            this.dnsUdpRadio.UseVisualStyleBackColor = true;
            // 
            // dnsTcpRadio
            // 
            this.dnsTcpRadio.AutoSize = true;
            this.dnsTcpRadio.Location = new System.Drawing.Point(593, 46);
            this.dnsTcpRadio.Name = "dnsTcpRadio";
            this.dnsTcpRadio.Size = new System.Drawing.Size(46, 17);
            this.dnsTcpRadio.TabIndex = 16;
            this.dnsTcpRadio.TabStop = true;
            this.dnsTcpRadio.Text = "TCP";
            this.dnsTcpRadio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "net utils";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dnsPreferenceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnsPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox ICMPipAddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeList;
        private System.Windows.Forms.Label RFCtext;
        private System.Windows.Forms.TextBox checksumTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inetHeaderTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sequenceTextBox;
        private System.Windows.Forms.TextBox identifierTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox origDatagramTextBox;
        private System.Windows.Forms.TextBox tranTimestampTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox recvTimestampTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox origTimestampTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox gwInetAddrTextBox;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox pointerTextBox;
        private System.Windows.Forms.Button icmpButton;
        private System.Windows.Forms.ComboBox rrComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dnsPreferenceNumericUpDown;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox dnsValueTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListView dnsConfigListView;
        private System.Windows.Forms.Button dnsRemoveButton;
        private System.Windows.Forms.Button dnsAddButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button dnsStopServerButton;
        private System.Windows.Forms.Button dnsStartServerButton;
        private System.Windows.Forms.RadioButton dnsTcpRadio;
        private System.Windows.Forms.RadioButton dnsUdpRadio;
        private System.Windows.Forms.NumericUpDown dnsPortNumericUpDown;
    }
}

