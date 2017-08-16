using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GS_LOGIC;
using static GS_LOGIC.Constants;
using System.Net.NetworkInformation;
using log4net.Config;
using log4net;

namespace GS_GUI
{
    public partial class Form1 : Form
    {
        UDPServer server;
        List<UDPClient> clients;
        Dictionary<int, UDPClient> dataRecordings;
        delegate void SetTextCallback(string text);
        ILog logger = LogManager.GetLogger("CsvFileAppender");

        public Form1()
        {
            InitializeComponent();
            server = new UDPServer();
            clients = new List<UDPClient>();
            dataRecordings = new Dictionary<int, UDPClient>();
            initTabs();
            initComboBoxes();
            this.FormClosing += Form1_FormClosing;
            XmlConfigurator.Configure();
            
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
            initComboBox(cBListenNode, 0, -1);
            cBListenNode.SelectedValueChanged += clearTextArea;
            cBListenNode.SelectedValueChanged += stopListening;
            cBNic.SelectedValueChanged += stopListening;
            initComboNic(cBListenNode);
            initComboNic(cmbMonitoringBox);
        }

        void initComboNic(ComboBox box)
        {
            var arrInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            String[] dataSource = arrInterfaces.Select(e => e.Name).ToArray();
            box.DataSource = dataSource;
        }

        //This action is tied to the 'Send Packet' button of the 'Power Temp' tab
        private void btnPowerSinglePacket_Click(object sender, EventArgs e)
        {
            PacketTypes packetType = (PacketTypes)comboBoxPowerTemp.SelectedItem;
            String[] payload = { tBSpare.Text, tbCount.Text, tBTemp.Text };
            byte[] udp = PacketMaker.makeUDP(packetType, payload);
            server.sendPacket(udp, packetType);
        }
        //This action is tied to the 'Send Packet' button of the 'Power BMS' tab
        private void buttonPowerBMSSingle_Click(object sender, EventArgs e)
        {
            PacketTypes type = (PacketTypes)comboBoxPowerBMS.SelectedItem;
            sendSinglePacket(type, tabPowerBMS, 1);
        }
        //This action is tied to the 'Send Packet' button of the 'Power Cooling' tab
        private void buttonPowerCoolingSingle_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.POWER_A_COOLING, tabPowerCooling, 51);
        }
        //This action is tied to the 'Send Packet' button of the 'Laser Opto' tab
        private void buttonSingleLaserOpto_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.LASER_OPTO_SENSOR, tabLaserOpto, 72);
        }
        //This action is tied to the 'Send Packet' button of the 'Accelerometers' tab
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
        //This action is tied to the 'Send' button of the 'Throttles' tab
        private void buttonSinglePacketThrottles_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.THROTTLE_PARAMETERS, tabThrottles, 150);
        }
        //This action is tied to the 'Send' button of the 'Brakes' tab
        private void buttonSingleBrakes_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.BRAKE_DATA, tabBrakes, 174);
        }
        //This action is tied to the 'Send Packet' button of the 'Steppers' tab
        private void buttonSingleSteppers_Click(object sender, EventArgs e)
        {
            sendSinglePacket(PacketTypes.MOTOR_PARAMETERS, tabSteppers, 220);
        }
        //This function initialises a combobox, sometimes needed when there are multiple nodes that can send the same type of packet
        void initComboBox(ComboBox box, int startPosition, int length)
        {
            //Initialise a new array that will be populated by the values from which the combobox will be populated
            Enum[] dataSource;
            //populate the recently initialised array with the desired values
            if (length == -1)
            {
                var arr = Enum.GetValues(typeof(PacketTypes));
                dataSource = new Enum[arr.Length];
                arr.CopyTo(dataSource, 0);
            }
            else
            {
                dataSource = new Enum[length];
                Array.Copy(Enum.GetValues(typeof(PacketTypes)), startPosition, dataSource, 0, length);
            }
            //bind the array to the combobox
            box.DataSource = dataSource;
        }
        //because there are too many parameters, it is easier and faster to initialise labels and textboxes programatically instead of using the  Visual Studio Design tool
        void initTabControl(PacketTypes TYPE, TabPage tabPage, int txtBoxOffset, int lblOffset)
        {
            Param[] parameters = AllPackets[TYPE].Parameters;

            //each tab has as many labels and textboxes as the number of parameters we have to test
            for (int i = 0; i < parameters.Length; i++)
            {
                //first we formate the textbox name and label, I made it as such as the names follow each other when I created them with the design,
                //by creating them one after the other the name (number) automatically follows the previous one 
                String textBoxName = String.Format("textBox{0}", txtBoxOffset + i);
                String labelName = String.Format("label{0}", lblOffset + i);
                //Retrieve the controls using their name
                TextBox txtBox = (TextBox)tabPage.Controls[textBoxName];
                Label lbl = (Label)tabPage.Controls[labelName];

                //Initialise the textbox to "0" otherwise you will get an exception when converting it to bytes when you'll create the packet
                txtBox.Text = "0";
                //change the tabindex, it's friendlier for the user, that way you can navigate using the tab button
                txtBox.TabIndex = i + 1;
                //inputcontrol, still needs work, for now only allowing numbers and decimals
                txtBox.KeyPress += checkInputHandler;
                //initialise label text with parameter name
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
        //This function handles the getting of parameter values and sending them
        void sendSinglePacket(PacketTypes packetType, TabPage page, int textBoxOffset)
        {
            //Retrieve the values from the corresponding tab page
            String[] arrValues = GetValues(page, packetType, textBoxOffset);
            //make the appropriate formatted udp packet corresponding to the packet type
            byte[] udp = PacketMaker.makeUDP(packetType, arrValues);
            //sends the packet to the relevant port using the packettype
            server.sendPacket(udp, packetType);
        }
        //this one is used to retrieve the values from the textboxes from a certain tab, using the tabpage, packettype and the offset from which the textboxnumbering begins
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

        public void displayListeningPackets(String result)
        {
            if (this.tbListenResult.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(displayListeningPackets);
                this.Invoke(d, new object[] { result });
            }
            else
            {
                var now = DateTime.Now.ToString("HH:mm:ss.fff") + "\n";
                tbListenResult.AppendText($"Receieved at: {now}");
                tbListenResult.AppendText(result);
                tbListenResult.AppendText(Environment.NewLine);
            }
        }

        private void clearTextArea(object sender, EventArgs e)
        {
            tbListenResult.ResetText();
        }

        private void stopListening(object sender, EventArgs e)
        {
            foreach(var client in clients)
                client.StopListening();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            foreach (var client in clients)
                client.StopListening();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label238_Click(object sender, EventArgs e)
        {

        }

        private void btnAddListen_Click(object sender, EventArgs e)
        {
            if (!lstListen.Items.Contains((PacketTypes)cBListenNode.SelectedItem))
                lstListen.Items.Add((PacketTypes)cBListenNode.SelectedItem);
        }

        private void btnStartListening_Click_1(object sender, EventArgs e)
        {
            if (lstListen.Items.Count == 0) { MessageBox.Show("Nothing to monitor", "Issue"); return; }

            foreach(var t in lstListen.Items)
            {
                var client = new UDPClient();
                client.dataReceived += displayListeningPackets;
                clients.Add(client);
                PacketTypes type = (PacketTypes)t;
                String nicName = (String)cBNic.SelectedItem;
                Nodes node = NodesTypes[type];
                NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.Name == nicName).First();
                var address = nic.GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                if (address != null)
                {
                    var ipv4Address = address.Address.ToString();
                    client.StartListening(node, ipv4Address);
                }
                tbListenResult.AppendText(string.Format("Started listening for: {0}", t));
                tbListenResult.AppendText(Environment.NewLine);
            }

            btnStartListening.Enabled = false;
            btnStopListening.Enabled = true;
        }

        private void btnClearListen_Click(object sender, EventArgs e)
        {
            lstListen.Items.Clear();
        }

        private void btnStopListening_Click_1(object sender, EventArgs e)
        {
            btnStartListening.Enabled = true;

            foreach (var client in clients)
            {
                client.StopListening();
            }

            clients.Clear();

            tbListenResult.AppendText("Stopped listening");
            tbListenResult.AppendText(Environment.NewLine);
        }

        private void tbListenResult_TextChanged(object sender, EventArgs e)
        {
            tbListenResult.SelectionStart = tbListenResult.Text.Length;
            // scroll it automatically
            tbListenResult.ScrollToCaret();
        }

        private void monitorPortButton_Click(object sender, EventArgs e)
        {
            var portVal = 0;

            var checkInt = int.TryParse(portEntryTextBox.Text, out portVal);

            if (!checkInt)
            {
                outputListBox.Items.Add("Port entry not an integer, come on... play nice");
                return;
            }

            // Start port monitoring if not already doing so
            if (dataRecordings.ContainsKey(portVal))
            {
                outputListBox.Items.Add("Port entry already being monitoreed.  Stop monitoring the port to start again");
                return;
            }

            var client = new UDPClient();
            client.rawDataReceived += StoreUDP;
            String nicName = (String)cmbMonitoringBox.SelectedItem;
            NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.Name == nicName).First();
            var address = nic.GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            if (address != null)
            {
                var ipv4Address = address.Address.ToString();
                client.StartListening(portVal, ipv4Address);
                dataRecordings.Add(portVal, client);
                outputListBox.Items.Add($"Monitoring started of port: {portVal}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var portVal = 0;

            var checkInt = int.TryParse(portEntryTextBox.Text, out portVal);

            if (!checkInt)
            {
                outputListBox.Items.Add("Port entry not an integer, come on... play nice");
                return;
            }

            if (!dataRecordings.ContainsKey(portVal))
            {
                outputListBox.Items.Add("Port entry not being monitoreed.");
                return;
            }

            dataRecordings[portVal].StopListening();
            dataRecordings.Remove(portVal);
            outputListBox.Items.Add($"Port: {portVal} not being monitoreed.");
        }

        public void StoreUDP(String result)
        {
            if (this.tbListenResult.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(StoreUDP);
                this.Invoke(d, new object[] { result });
            }
            else
            {
                logger.Info(result);
            }
        }
    }
}
