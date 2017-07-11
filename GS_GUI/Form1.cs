﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS_LOGIC;
using static GS_LOGIC.Constants;

namespace GS_GUI
{
    public partial class Form1 : Form
    {
        UDPServer server;
        public Form1()
        {
            InitializeComponent();
            server = new UDPServer();
            initTabs();
        }

        private void initTabs()
        {
            TabPage powertab = tC_Systems.TabPages["tabPower"];
            ComboBox list = (ComboBox)powertab.Controls["cBNodelist"];

            Enum[] datasource = new Enum[9];
            Array.Copy(Enum.GetValues(typeof(PacketTypes)), 0, datasource, 0, 8);
            
            list.DataSource = datasource;
        }

        private void btnPowerSinglePacket_Click(object sender, EventArgs e)
        {
            TabPage powertab = tC_Systems.TabPages["tabPower"];

            byte[] payload = new byte[8];

            byte[] count = UInt16ToBytes("tabPower", "tBSpare");
            byte[] spare = UInt16ToBytes("tabPower", "tBCount");
            byte[] temp = Float32ToBytes("tabPower", "tBTemp");

            payload.Insert(0,count);
            payload.Insert(2, spare);
            payload.Insert(4, temp);

            ComboBox list = (ComboBox)powertab.Controls["cBNodelist"];
            PacketTypes packetType = (PacketTypes)list.SelectedItem;

            byte[] udp = PacketMaker.makeUDP(packetType, payload);
            server.sendPacket(udp, packetType);

        }


        private byte[] FloatToBytes (String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(float.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] Int8ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(sbyte.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] Int16ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(Int16.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] Int32ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(Int32.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] Int64ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(Int64.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] UInt8ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(byte.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] UInt16ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(UInt16.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] UInt32ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(UInt32.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] UInt64ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(UInt64.Parse(tab.Controls[Control].Text));
            return payload;
        }

        private byte[] Float32ToBytes(String Tab, String Control)
        {
            TabPage tab = tC_Systems.TabPages[Tab];
            byte[] payload = BitConverter.GetBytes(float.Parse(tab.Controls[Control].Text));
            return payload;
        }
    }
}
