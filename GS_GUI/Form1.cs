using System;
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
            initComboBoxes();
            initPowerBMSTabControls();
            initPowerCoolingTabControls();
            initLaserOptoTabControls();
            initAccelerometersTabControls();
        }
        void initComboBoxes()
        {
            Enum[] PowerTempDatasource = new Enum[2];
            Enum[] PowerBMSDatasource = new Enum[2];
            Enum[] AccelerometersDataSource = new Enum[2];

            Array.Copy(Enum.GetValues(typeof(PacketTypes)), 0, PowerTempDatasource, 0, 2);
            Array.Copy(Enum.GetValues(typeof(PacketTypes)), 6, PowerBMSDatasource, 0, 2);
            Array.Copy(Enum.GetValues(typeof(PacketTypes)), 10, AccelerometersDataSource, 0, 2);

            comboBoxPowerTemp.DataSource = PowerTempDatasource;
            comboBoxPowerBMS.DataSource = PowerBMSDatasource;
            comboBoxAccelerometers.DataSource = AccelerometersDataSource;

        }

        void initPowerBMSTabControls()
        {
            for (int i = 1; i < 51; i++)
            {
                String textBoxName = String.Format("textBox{0}", i);
                TextBox txtBox = (TextBox)tabPowerBMS.Controls[textBoxName];
                txtBox.Text = "0";
                txtBox.TabIndex = i + 1;
                txtBox.KeyPress += checkInputHandler;
            }
        }

        void initLaserOptoTabControls()
        {
            for (int i = 0; i < AllPackets[PacketTypes.LASER_OPTO_SENSOR].Parameters.Length; i++)
            {
                String textBoxName = String.Format("textBox{0}", i+72);
                String labelName = String.Format("label{0}", i + 77);

                TextBox txtBox = (TextBox)tabLaserOpto.Controls[textBoxName];
                Label label = (Label)tabLaserOpto.Controls[labelName];

                txtBox.Text = "0";
                txtBox.TabIndex = i + 1;
                txtBox.KeyPress += checkInputHandler;

                label.Text = AllPackets[PacketTypes.LASER_OPTO_SENSOR].Parameters[i].Name;

            }

        }

        void initPowerCoolingTabControls()
        {
            for (int i = 0; i < 21; i++)
            {
                String textBoxName = String.Format("textBox{0}", 51 + i);
                String labelName = String.Format("label{0}", 56 + i);
                TextBox txtBox = (TextBox)tabPowerCooling.Controls[textBoxName];
                Label lbl = (Label)tabPowerCooling.Controls[labelName];

                txtBox.Text = "0";
                txtBox.TabIndex = i + 1;
                txtBox.KeyPress += checkInputHandler;
                lbl.Text = Constants.AllPackets[PacketTypes.POWER_A_COOLING].Parameters[i].Name;
            }
        }

        void initAccelerometersTabControls()
        {
            for (int i = 0; i < 28; i++)
            {
                String textBoxName = String.Format("textBox{0}", 122 + i);
                String labelName = String.Format("label{0}", 128 + i);
                TextBox txtBox = (TextBox)tabAccel.Controls[textBoxName];
                Label lbl = (Label)tabAccel.Controls[labelName];

                txtBox.Text = "0";
                txtBox.TabIndex = i + 1;
                txtBox.KeyPress += checkInputHandler;
                lbl.Text = Constants.AllPackets[PacketTypes.ACCEL_DATA_FULL].Parameters[i].Name;
            }

        }

        //https://stackoverflow.com/a/463335/7948667
        private void checkInputHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // TODO: handle difference in decimal notations
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void btnPowerSinglePacket_Click(object sender, EventArgs e)
        {
            PacketTypes packetType = (PacketTypes)comboBoxPowerTemp.SelectedItem;
            String[] payload = { GetString("tabPowerTemp", "tBSpare"), GetString("tabPowerTemp", "tBCount"), GetString("tabPowerTemp", "tBTemp") };
            byte[] udp = PacketMaker.makeUDP(packetType, payload);
            server.sendPacket(udp, packetType);
        }

        private void buttonPowerBMSSingle_Click(object sender, EventArgs e)
        {
            PacketTypes type = (PacketTypes)comboBoxPowerBMS.SelectedItem;
            String[] arrValues = GetValues(tabPowerBMS, type, 1);
            byte[] udp = PacketMaker.makeUDP(type, arrValues);
            server.sendPacket(udp, type);
        }

        private void buttonPowerCoolingSingle_Click(object sender, EventArgs e)
        {
            String[] arrValues = GetValues(tabPowerCooling, PacketTypes.POWER_A_COOLING, 51);
            byte[] udp = PacketMaker.makeUDP(PacketTypes.POWER_A_COOLING, arrValues);
            server.sendPacket(udp, PacketTypes.POWER_A_COOLING);
        }

        private void buttonSingleLaserOpto_Click(object sender, EventArgs e)
        {
            PacketTypes TYPE = PacketTypes.LASER_OPTO_SENSOR;

            String[] arrValues = GetValues(tabLaserOpto, TYPE, 72);
            byte[] udp = PacketMaker.makeUDP(TYPE, arrValues);
            server.sendPacket(udp, TYPE);
        }

        private void buttonSingleAccelerometers_Click(object sender, EventArgs e)
        {
            PacketTypes TYPE = (PacketTypes)comboBoxAccelerometers.SelectedItem;

            if(TYPE == PacketTypes.ACCEL_DATA_FULL)
            {
                String[] arrValues = GetValues(tabAccel, PacketTypes.ACCEL_DATA_FULL, 122); ;
                byte[] udp = PacketMaker.makeUDP(TYPE, arrValues);
                server.sendPacket(udp, TYPE);

            }
            else
            {
                String val1 = textBox122.Text;
                String val2 = textBox123.Text;
                String val3 = textBox124.Text;
                String val4 = textBox125.Text;

                String val5 = textBox136.Text;
                String val6 = textBox137.Text;
                String val7 = textBox138.Text;
                String val8 = textBox139.Text;

                String[] arrValues = { val1, val2, val3, val4, val5, val6, val7, val8 };
                byte[] udp = PacketMaker.makeUDP(TYPE, arrValues);
                server.sendPacket(udp, TYPE);
            }

        }

        private String GetString(String Tab, String Control)
        {
            TabPage tab = TabControl_Systems.TabPages[Tab];
            String str = tab.Controls[Control].Text;
            return str;
        }


        private String[] GetValues(TabPage page, PacketTypes type, int TextBoxOffset)
        {
            var parameters = Constants.AllPackets[type].Parameters;
            var tabControls = page.Controls;

            String[] arrValues = new String[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                String textBoxName = String.Format("textBox{0}", i + TextBoxOffset);
                String value = tabControls[textBoxName].Text;
                arrValues[i] = value;
            }

            return arrValues;
        }


    }
}
