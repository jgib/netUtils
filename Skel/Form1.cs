﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void calcICMPpacket()
        {
            verbose.write("Calculate ICMP Packet:");
            misc.icmpPacket.Clear();
            byte tmpType = byte.Parse(TypeList.SelectedItem.ToString().Substring(0, TypeList.SelectedItem.ToString().IndexOf(' ')));
            misc.icmpPacket.Add(tmpType);
            if (!codeTextBox.ReadOnly && codeTextBox.Text != "")
            {
                misc.icmpPacket.Add(Convert.ToByte(codeTextBox.Text, 16));
            } else
            {
                misc.icmpPacket.Add(0);
            }

            // pad null bytes for checksum
            misc.icmpPacket.Add(0);
            misc.icmpPacket.Add(0);

            switch (tmpType)
            {
                case 0:
                case 8:
                    if (identifierTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 1), 16));
                    }
                    if (identifierTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 2), 16));
                    }

                    if (sequenceTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 1), 16));
                    }
                    if (sequenceTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 2), 16));
                    }

                    if (dataTextBox.Text != "")
                    {
                        for (int i = 0; i < dataTextBox.Text.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"{dataTextBox.Text[i - 1]}{dataTextBox.Text[i]}", 16));
                            }
                            if ((i == dataTextBox.Text.Length - 1) && (i % 2 == 0))
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"0{dataTextBox.Text[i]}", 16));
                            }
                        }
                    }
                    break;
                case 3:
                case 4:
                case 11:
                    // pad unused data
                    misc.icmpPacket.Add(0);
                    misc.icmpPacket.Add(0);
                    misc.icmpPacket.Add(0);
                    misc.icmpPacket.Add(0);

                    if (inetHeaderTextBox.Text != "")
                    {
                        for (int i = 0; i < inetHeaderTextBox.Text.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"{inetHeaderTextBox.Text[i - 1]}{inetHeaderTextBox.Text[i]}", 16));
                            }
                            if ((i == inetHeaderTextBox.Text.Length - 1) && (i % 2 == 0))
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"0{inetHeaderTextBox.Text[i]}", 16));
                            }
                        }
                    }
                    switch (origDatagramTextBox.Text.Length)
                    {
                        case 0:
                            for (int i = 0; i < 8; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 1:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 1), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 2:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 3:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 1), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 4:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 5:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 1), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 6:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 7:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 1), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 8:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 9:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 1), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 10:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 11:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 1), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 12:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 13:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 1), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 14:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 15:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 1), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 16:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 2), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                    }
                    break;
                case 5:
                    if (gwInetAddrTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 5)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(4, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 6)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (gwInetAddrTextBox.Text.Length == 7)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(6, 1), 16));
                    }
                    if (gwInetAddrTextBox.Text.Length == 8)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(gwInetAddrTextBox.Text.Substring(6, 2), 16));
                    }

                    if (inetHeaderTextBox.Text != "")
                    {
                        for (int i = 0; i < inetHeaderTextBox.Text.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"{inetHeaderTextBox.Text[i - 1]}{inetHeaderTextBox.Text[i]}", 16));
                            }
                            if ((i == inetHeaderTextBox.Text.Length - 1) && (i % 2 == 0))
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"0{inetHeaderTextBox.Text[i]}", 16));
                            }
                        }
                    }
                    switch (origDatagramTextBox.Text.Length)
                    {
                        case 0:
                            for (int i = 0; i < 8; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 1:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 1), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 2:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 3:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 1), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 4:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 5:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 1), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 6:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 7:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 1), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 8:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 9:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 1), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 10:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 11:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 1), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 12:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 13:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 1), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 14:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 15:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 1), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 16:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 2), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                    }
                    break;
                case 12:
                    if (pointerTextBox.Text.Length > 0)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(pointerTextBox.Text, 16));
                    }
                    
                    // pad unused data
                    misc.icmpPacket.Add(0);
                    misc.icmpPacket.Add(0);
                    misc.icmpPacket.Add(0);

                    if (inetHeaderTextBox.Text != "")
                    {
                        for (int i = 0; i < inetHeaderTextBox.Text.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"{inetHeaderTextBox.Text[i - 1]}{inetHeaderTextBox.Text[i]}", 16));
                            }
                            if ((i == inetHeaderTextBox.Text.Length - 1) && (i % 2 == 0))
                            {
                                misc.icmpPacket.Add(Convert.ToByte($"0{inetHeaderTextBox.Text[i]}", 16));
                            }
                        }
                    }
                    switch (origDatagramTextBox.Text.Length)
                    {
                        case 0:
                            for (int i = 0; i < 8; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 1:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 1), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 2:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            for (int i = 0; i < 7; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 3:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 1), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 4:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            for (int i = 0; i < 6; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 5:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 1), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 6:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            for (int i = 0; i < 5; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 7:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 1), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 8:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            for (int i = 0; i < 4; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 9:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 1), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 10:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            for (int i = 0; i < 3; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 11:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 1), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 12:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            for (int i = 0; i < 2; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 13:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 1), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 14:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            for (int i = 0; i < 1; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 15:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 1), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                        case 16:
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(0, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(2, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(4, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(6, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(8, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(10, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(12, 2), 16));
                            misc.icmpPacket.Add(Convert.ToByte(origDatagramTextBox.Text.Substring(14, 2), 16));
                            for (int i = 0; i < 0; i++)
                            {
                                misc.icmpPacket.Add(0);
                            }
                            break;
                    }

                    break;
                case 13:
                case 14:
                    if (identifierTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 1), 16));
                    }
                    if (identifierTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 2), 16));
                    }

                    if (sequenceTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 1), 16));
                    }
                    if (sequenceTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 2), 16));
                    }
                    
                    if (origTimestampTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(2, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 5)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(4, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 6)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (origTimestampTextBox.Text.Length == 7)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(origTimestampTextBox.Text.Substring(6, 1), 16));
                    }
                    if (recvTimestampTextBox.Text.Length == 8)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(6, 2), 16));
                    }

                    if (recvTimestampTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 5)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(4, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 6)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (recvTimestampTextBox.Text.Length == 7)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(6, 1), 16));
                    }
                    if (recvTimestampTextBox.Text.Length == 8)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(recvTimestampTextBox.Text.Substring(6, 2), 16));
                    }

                    if (tranTimestampTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 1), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 5)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(4, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 6)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (tranTimestampTextBox.Text.Length == 7)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(6, 1), 16));
                    }
                    if (tranTimestampTextBox.Text.Length == 8)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(2, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(4, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(tranTimestampTextBox.Text.Substring(6, 2), 16));
                    }
                    break;
                case 15:
                case 16:
                    if (identifierTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (identifierTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 1), 16));
                    }
                    if (identifierTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(identifierTextBox.Text.Substring(2, 2), 16));
                    }

                    if (sequenceTextBox.Text.Length == 0)
                    {
                        misc.icmpPacket.Add(0);
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 1)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 1), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 2)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(0);
                    }
                    if (sequenceTextBox.Text.Length == 3)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 1), 16));
                    }
                    if (sequenceTextBox.Text.Length == 4)
                    {
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(0, 2), 16));
                        misc.icmpPacket.Add(Convert.ToByte(sequenceTextBox.Text.Substring(2, 2), 16));
                    }
                    break;
            }

            UInt16 tmpCksum = misc.calcCksum(misc.icmpPacket);
            if (misc.icmpPacket.Count > 3)
            {
                misc.icmpPacket[2] = (byte)(tmpCksum >> 8);
                misc.icmpPacket[3] = (byte)(tmpCksum);
            }
            checksumTextBox.Text = tmpCksum.ToString("X4");
            misc.printPayload(misc.icmpPacket);
        }

        private void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TypeList.SelectedItem.ToString())
            {
                case "0  [Echo Reply]":
                    verbose.write("Selected ICMP TYPE 0");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Data ...\r\n   +-+-+-+-+-";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = false;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "3  [Destination Unreachable]":
                    verbose.write("Selected ICMP TYPE 3");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |                             unused                            |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |      Internet Header + 64 bits of Original Data Datagram      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = true;
                    sequenceTextBox.ReadOnly      = true;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = false;
                    origDatagramTextBox.ReadOnly  = false;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "4  [Source Quench]":
                    verbose.write("Selected ICMP TYPE 4");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |                             unused                            |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |      Internet Header + 64 bits of Original Data Datagram      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = true;
                    sequenceTextBox.ReadOnly      = true;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = false;
                    origDatagramTextBox.ReadOnly  = false;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "5  [Redirect]":
                    verbose.write("Selected ICMP TYPE 5");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |                 Gateway Internet Address                      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |      Internet Header + 64 bits of Original Data Datagram      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = true;
                    sequenceTextBox.ReadOnly      = true;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = false;
                    origDatagramTextBox.ReadOnly  = false;
                    gwInetAddrTextBox.ReadOnly    = false;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "8  [Echo]":
                    verbose.write("Selected ICMP TYPE 8");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Data ...\r\n   +-+-+-+-+-";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = false;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "11 [Time Exceeded]":
                    verbose.write("Selected ICMP TYPE 11");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |                             unused                            |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |      Internet Header + 64 bits of Original Data Datagram      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = true;
                    sequenceTextBox.ReadOnly      = true;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = false;
                    origDatagramTextBox.ReadOnly  = false;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "12 [Parameter Problem]":
                    verbose.write("Selected ICMP TYPE 12");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |     Code      |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |    Pointer    |                   unused                      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |      Internet Header + 64 bits of Original Data Datagram      |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = true;
                    sequenceTextBox.ReadOnly      = true;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = false;
                    origDatagramTextBox.ReadOnly  = false;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = false;
                    break;
                case "13 [Timestamp]":
                    verbose.write("Selected ICMP TYPE 13");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |      Code     |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Originate Timestamp                                       |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Receive Timestamp                                         |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Transmit Timestamp                                        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = false;
                    recvTimestampTextBox.ReadOnly = false;
                    tranTimestampTextBox.ReadOnly = false;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "14 [Timestamp Reply]":
                    verbose.write("Selected ICMP TYPE 14");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |      Code     |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Originate Timestamp                                       |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Receive Timestamp                                         |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Transmit Timestamp                                        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = false;
                    recvTimestampTextBox.ReadOnly = false;
                    tranTimestampTextBox.ReadOnly = false;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "15 [Information Request]":
                    verbose.write("Selected ICMP TYPE 15");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |      Code     |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
                case "16 [Information Reply]":
                    verbose.write("Selected ICMP TYPE 16");
                    RFCtext.Text =
                        "    0                   1                   2                   3\r\n    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |     Type      |      Code     |          Checksum             |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\r\n   |           Identifier          |        Sequence Number        |\r\n   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                    codeTextBox.ReadOnly          = false;
                    checksumTextBox.ReadOnly      = false;
                    identifierTextBox.ReadOnly    = false;
                    sequenceTextBox.ReadOnly      = false;
                    dataTextBox.ReadOnly          = true;
                    inetHeaderTextBox.ReadOnly    = true;
                    origDatagramTextBox.ReadOnly  = true;
                    gwInetAddrTextBox.ReadOnly    = true;
                    origTimestampTextBox.ReadOnly = true;
                    recvTimestampTextBox.ReadOnly = true;
                    tranTimestampTextBox.ReadOnly = true;
                    pointerTextBox.ReadOnly       = true;
                    break;
            }
            calcICMPpacket();
        }

        private void icmpButton_Click(object sender, EventArgs e)
        {
            if (misc.validateIP(ICMPipAddressTextBox.Text))
            {
                verbose.write("Creating socket");
                Socket icmpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                //icmpSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
                //icmpSocket.Bind(new IPEndPoint(IPAddress.Parse(ICMPipAddressTextBox.Text), 0));

                verbose.write("Converting payload");
                var payload = new byte[misc.icmpPacket.Count];
                for (int i = 0; i < misc.icmpPacket.Count; i++)
                {
                    payload[i] = misc.icmpPacket[i];
                }
                verbose.write($"Sending packet to {ICMPipAddressTextBox.Text}");
                misc.printPayload(misc.icmpPacket);
                int nBytes = icmpSocket.SendTo(payload, new IPEndPoint(IPAddress.Parse(ICMPipAddressTextBox.Text), 0));
                verbose.write($"Sent {nBytes} bytes");
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void checksumTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void identifierTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void sequenceTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void dataTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void inetHeaderTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void origDatagramTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void gwInetAddrTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void origTimestampTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void recvTimestampTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void tranTimestampTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void pointerTextBox_TextChanged(object sender, EventArgs e)
        {
            calcICMPpacket();
        }

        private void rrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rrComboBox.SelectedItem)
            {
                case "A":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = true;
                    break;
                case "CNAME":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = true;
                    break;
                case "MX":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = false;
                    break;
                case "NS":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = true;
                    break;
                case "PTR":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = true;
                    break;
                case "TXT":
                    domainTextBox.ReadOnly = false;
                    dnsValueTextBox.ReadOnly = false;
                    dnsPreferenceNumericUpDown.ReadOnly = true;
                    break;
            }
        }

        private void dnsAddButton_Click(object sender, EventArgs e)
        {
            switch (rrComboBox.SelectedItem)
            {
                case "A":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} IN A {dnsValueTextBox.Text}"));
                    break;
                case "CNAME":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} IN CNAME {dnsValueTextBox.Text}"));
                    break;
                case "MX":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} IN MX {dnsPreferenceNumericUpDown.Value} {dnsValueTextBox.Text}"));
                    break;
                case "NS":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} IN NS {dnsValueTextBox.Text}"));
                    break;
                case "PTR":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} IN PTR {dnsValueTextBox.Text}"));
                    break;
                case "TXT":
                    dnsConfigListView.Items.Add(new ListViewItem($"{domainTextBox.Text} TXT {dnsValueTextBox.Text}"));
                    break;
            }
            verbose.write($"Added [{dnsConfigListView.Items[dnsConfigListView.Items.Count - 1].Text}] to list");
        }

        private void dnsRemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in dnsConfigListView.SelectedItems)
            {
                verbose.write($"Removing from list [{lvi.Text}]");
                dnsConfigListView.Items.Remove(lvi);
            }
        }

        private async void runDNSserver()
        {
            if (dnsUdpRadio.Checked)
            {
                int dnsPort = int.Parse(dnsPortNumericUpDown.Value.ToString());
                verbose.write($"Starting DNS server UDP:{dnsPort}");
                UdpClient dnsListener = new UdpClient(dnsPort);
                verbose.write($"Started listen socket");
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, dnsPort);
                verbose.write($"Created endpoint group for socket {groupEP.Address.ToString()}:{groupEP.Port}");
                try
                {
                    while (misc.dnsServerRunning)
                    {
                        byte[] dnsData = dnsListener.Receive(ref groupEP);
                        if (!misc.dnsServerRunning)
                        {
                            verbose.write($"Cease incomming DNS connections for socket {groupEP.Address.ToString()}:{groupEP.Port}");
                            break;
                        }
                        verbose.write($"Received DNS data:");
                        misc.printPayload(dnsData.ToList<byte>());

                        UInt16 dnsID = 0;
                        bool dnsQR = false;
                        byte dnsOPCODE = 0;
                        bool dnsAA = false;
                        bool dnsTC = false;
                        bool dnsRD = false;
                        bool dnsRA = false;
                        byte dnsZ = 0; //future use, must be zero
                        byte dnsRCODE = 0;
                        UInt16 dnsQDCOUNT = 0;
                        UInt16 dnsANCOUNT = 0;
                        UInt16 dnsNSCOUNT = 0;
                        UInt16 dnsARCOUNT = 0;
                        string dnsQNAME = "";
                        UInt16 dnsQTYPE = 0;
                        UInt16 dnsQCLASS = 0;

                        for (int i = 0; i < dnsData.Length; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    dnsID = (UInt16)dnsData[i - 1];
                                    dnsID <<= 8;
                                    dnsID += (UInt16)dnsData[i];
                                    verbose.write($"ID: {dnsID}");
                                    break;
                                case 2:
                                    if ((dnsData[i] & 0b10000000) == 1)
                                    {
                                        dnsQR = true;
                                    }
                                    else
                                    {
                                        dnsQR = false;
                                    }
                                    verbose.write($"QR: {dnsQR}");

                                    dnsOPCODE = (byte)(dnsData[i] & 0b01111000);
                                    verbose.write($"OPCODE: {dnsOPCODE}");

                                    if ((dnsData[i] & 0b00000100) == 1)
                                    {
                                        dnsAA = true;
                                    }
                                    else
                                    {
                                        dnsAA = false;
                                    }
                                    verbose.write($"AA: {dnsAA}");

                                    if ((dnsData[i] & 0b00000010) == 1)
                                    {
                                        dnsTC = true;
                                    }
                                    else
                                    {
                                        dnsTC = false;
                                    }
                                    verbose.write($"TC: {dnsTC}");

                                    if ((dnsData[i] & 0b00000001) == 1)
                                    {
                                        dnsRD = true;
                                    }
                                    else
                                    {
                                        dnsRD = false;
                                    }
                                    verbose.write($"RD: {dnsRD}");

                                    break;
                                case 3:
                                    if ((dnsData[i] & 0b10000000) == 1)
                                    {
                                        dnsRA = true;
                                    }
                                    else
                                    {
                                        dnsRA = false;
                                    }
                                    verbose.write($"RA: {dnsRA}");

                                    dnsZ = (byte)(dnsData[i] & 0b01110000);
                                    verbose.write($"Z: {dnsZ}");

                                    dnsRCODE = (byte)(dnsData[i] & 0b00001111);
                                    verbose.write($"RCODE: {dnsRCODE}");

                                    break;
                                case 5:
                                    dnsQDCOUNT = (UInt16)dnsData[i - 1];
                                    dnsQDCOUNT <<= 8;
                                    dnsQDCOUNT += (UInt16)dnsData[i];
                                    verbose.write($"QDCOUNT: {dnsQDCOUNT}");

                                    break;
                                case 7:
                                    dnsANCOUNT = (UInt16)dnsData[i - 1];
                                    dnsANCOUNT <<= 8;
                                    dnsANCOUNT += (UInt16)dnsData[i];
                                    verbose.write($"ANCOUNT: {dnsANCOUNT}");

                                    break;
                                case 9:
                                    dnsNSCOUNT = (UInt16)dnsData[i - 1];
                                    dnsNSCOUNT <<= 8;
                                    dnsNSCOUNT += (UInt16)dnsData[i];
                                    verbose.write($"NSCOUNT: {dnsNSCOUNT}");

                                    break;
                                case 11:
                                    dnsARCOUNT = (UInt16)dnsData[i - 1];
                                    dnsARCOUNT <<= 8;
                                    dnsARCOUNT += (UInt16)dnsData[i];
                                    verbose.write($"ARCOUNT: {dnsARCOUNT}");

                                    break;
                            }
                        }
                        if (dnsData.Length > 13)
                        {
                            int pos = 13;
                            int len = (int)dnsData[pos - 1];
                            while (len != 0)
                            {
                                if (dnsData.Length > (pos + len))
                                {
                                    dnsQNAME += Encoding.ASCII.GetString(dnsData, pos, len);
                                    dnsQNAME += ".";
                                    pos += len + 1;
                                    len = (int)dnsData[pos - 1];
                                }
                            }
                            verbose.write($"QNAME: {dnsQNAME}");

                            if (dnsData.Length > (pos + 3))
                            {
                                dnsQTYPE = (UInt16)dnsData[pos];
                                dnsQTYPE <<= 8;
                                dnsQTYPE += (UInt16)dnsData[pos + 1];
                                verbose.write($"QTYPE: {dnsQTYPE}");

                                dnsQCLASS = (UInt16)dnsData[pos + 2];
                                dnsQCLASS <<= 8;
                                dnsQCLASS += (UInt16)dnsData[pos + 3];
                                verbose.write($"QCLASS: {dnsQCLASS}");
                            }
                        }

                        switch (dnsQTYPE)
                        {
                            case 1:
                                // A
                                // check if A record exists in config that matches the request
                                // send back  the same payload with answer section appended.
                                verbose.write("Received request for resource record type [A]");
                                foreach (ListViewItem lvi in dnsConfigListView.Items)
                                {
                                    // do regex that matches: www IN A 1.2.3.4
                                    string pattern = @"(\S+)\s+IN\s+A\s+(\d+)\.(\d+)\.(\d+)\.(\d+)";
                                    if (Regex.IsMatch(lvi.Text, pattern))
                                    {
                                        verbose.write($"Found matching record in configuration [{lvi.Text}]");
                                        Match match = Regex.Match(lvi.Text, pattern);
                                        if (match.Groups.Count == 6)
                                        {
                                            if (string.Compare(match.Groups[1].Value, dnsQNAME.TrimEnd('.'), true) == 0)
                                            {
                                                List<byte> dnsReplyData = dnsData.ToList<byte>();
                                                dnsReplyData.Add(192); // DNS compression
                                                dnsReplyData.Add(12); // Point to byte 12
                                                dnsReplyData.Add(1); // A RR
                                                dnsReplyData.Add(1); // IN
                                                dnsReplyData.Add(0x03); // TTL of 900s
                                                dnsReplyData.Add(0x84);
                                                dnsReplyData.Add(4); // Length of data
                                                dnsReplyData.Add(byte.Parse(match.Groups[2].Value));
                                                dnsReplyData.Add(byte.Parse(match.Groups[3].Value));
                                                dnsReplyData.Add(byte.Parse(match.Groups[4].Value));
                                                dnsReplyData.Add(byte.Parse(match.Groups[5].Value));
                                                IPEndPoint dnsLocalIP = dnsListener.Client.LocalEndPoint as IPEndPoint;
                                                misc.sendUDPdata(dnsReplyData.ToArray(), groupEP.Address.ToString(), groupEP.Port, dnsLocalIP.Address.ToString(), dnsLocalIP.Port);
                                            }
                                        }
                                    }
                                }
                                break;
                            case 2:
                                // NS
                                break;
                            case 5:
                                // CNAME
                                break;
                            case 12:
                                // PTR
                                break;
                            case 15:
                                // MX
                                break;
                            case 16:
                                // TXT
                                break;
                        }
                    }
                }
                catch (SocketException ex)
                {
                    verbose.write($"EXCEPTION: {ex.ToString()}");
                    MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    verbose.write($"Closing active DNS socket");
                    dnsListener.Close();
                }
            }
        }

        private void dnsStartServerButton_Click(object sender, EventArgs e)
        {
            //runDNSserver();
            misc.dnsServerRunning = true;
            Task.Run(() => runDNSserver());
        }

        private void dnsStopServerButton_Click(object sender, EventArgs e)
        {
            misc.dnsServerRunning = false;
            //send udp or tcp connection to localhost to close active socket
            //misc.sendUDPdata(Encoding.ASCII.GetBytes("STOP DNS SOCKET"), "127.0.0.1", 53);
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipProperties = netInterface.GetIPProperties();
                foreach (UnicastIPAddressInformation addr in ipProperties.UnicastAddresses)
                {
                    if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        verbose.write($"Sending disconnect packet to {addr.Address.ToString()}:{dnsPortNumericUpDown.Value}");
                        misc.sendUDPdata(Encoding.ASCII.GetBytes("STOP DNS SOCKET"), addr.Address.ToString(), (int)dnsPortNumericUpDown.Value);
                    }
                }
            } // needs work... not actually closing the current listening socket for some reason...
        }
    }
}
