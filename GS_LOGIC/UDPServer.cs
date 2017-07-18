using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static GS_LOGIC.Constants;

namespace GS_LOGIC
{
    public class UDPServer
    {
        UdpClient server;

        public UDPServer()
        {
            server = new UdpClient();
        }

        public void sendPacket(byte[] packet,PacketTypes packetType)
        {
            int port = Remotes[AllPackets[packetType].Node];
            IPEndPoint host = new IPEndPoint(IPAddress.Broadcast, port);
            server.Send(packet, packet.Length, host);
        }
    }
}
