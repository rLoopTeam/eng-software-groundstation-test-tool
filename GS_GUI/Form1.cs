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
            initComboBoxes();
        }

        private void initTabs()
        {
            initTabControl(PacketTypes.POWER_A_BMS, tabPowerBMS, 1, 6);
            initTabControl(PacketTypes.LASER_OPTO_SENSOR, tabLaserOpto, 72, 77);
            initTabControl(PacketTypes.POWER_A_COOLING, tabPowerCooling, 51, 56);
            initTabControl(PacketTypes.ACCEL_DATA_FULL, tabAccel, 122, 128);
            initTabControl(PacketTypes.THROTTLE_PARAMETERS, tabThrottles, 150, 156);
            initTabControl(PacketTypes.BRAKE_DATA, tabBrakes, 174, 180);
            initTabControl(PacketTypes.MOTOR_PARAMETERS, tabSteppers, 220, 226);
        }
        void initComboBoxes()
        {
            initComboBox(comboBoxPowerTemp, 0, 2);
            initComboBox(comboBoxPowerBMS, 6, 2);
            initComboBox(comboBoxAccelerometers, 10, 2);
        }
        private void btnPowerSinglePacket_Click(object sender, EventArgs e)
        {
            PacketTypes packetType = (PacketTypes)comboBoxPowerTemp.SelectedItem;
            String[] payload = { tBSpare.Text, tbCount.Text, tBTemp.Text};
            byte[] udp = PacketMaker.makeUDP(packetType, payload);
            server.sendPacket(udp, packetType);
        }

        private void buttonPowerBMSSingle_Click(object sender, EventArgs e)
        {
            PacketTypes type = (PacketTypes)comboBoxPowerBMS.SelectedItem;
            sendSinglePacket(type, tabPowerBMS, 1);
        }

        private void buttonPowerCoolingSingle_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.POWER_A_COOLING, tabPowerCooling, 51);
        }

        private void buttonSingleLaserOpto_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.LASER_OPTO_SENSOR, tabLaserOpto, 72);
        }

        private void buttonSingleAccelerometers_Click(object sender, EventArgs e)
        {
            PacketTypes TYPE = (PacketTypes)comboBoxAccelerometers.SelectedItem;

            if (TYPE == PacketTypes.ACCEL_DATA_FULL)
            {
                sendSinglePacket(PacketTypes.ACCEL_DATA_FULL, tabAccel, 122);
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

        private void buttonSinglePacketThrottles_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.THROTTLE_PARAMETERS, tabThrottles, 150);
        }

        private void buttonSingleBrakes_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.BRAKE_DATA, tabBrakes, 174);
        }

        private void buttonSingleSteppers_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.MOTOR_PARAMETERS, tabSteppers, 220);
        }

        void initComboBox(ComboBox box, int startPosition, int length)
        {
            Enum[] dataSource = new Enum[length];
            Array.Copy(Enum.GetValues(typeof(PacketTypes)), startPosition, dataSource, 0, length);
            box.DataSource = dataSource;
        }

        void initTabControl(PacketTypes TYPE, TabPage tabPage, int txtBoxOffset, int lblOffset)
        {
            Param[] parameters = AllPackets[TYPE].Parameters;

            for (int i = 0; i < parameters.Length; i++)
            {
                String textBoxName = String.Format("textBox{0}", txtBoxOffset + i);
                String labelName = String.Format("label{0}", lblOffset + i);
                TextBox txtBox = (TextBox)tabPage.Controls[textBoxName];
                Label lbl = (Label)tabPage.Controls[labelName];

                txtBox.Text = "0";
                txtBox.TabIndex = i + 1;
                txtBox.KeyPress += checkInputHandler;
                lbl.Text = parameters[i].Name;
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

        void sendSinglePacket(PacketTypes packetType, TabPage page, int textBoxOffset)
        {
            String[] arrValues = GetValues(page, packetType, textBoxOffset);
            byte[] udp = PacketMaker.makeUDP(packetType, arrValues);
            server.sendPacket(udp, packetType);
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
