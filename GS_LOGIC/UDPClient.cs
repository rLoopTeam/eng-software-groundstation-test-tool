using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GS_LOGIC;
using static GS_LOGIC.Constants;
using System.Threading;

namespace GS_LOGIC
{
    public class UDPClient
    {
        private Thread t;
        private UdpClient server { get; set; }
        IPEndPoint endpoint;
        static IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

        public delegate void dataReceivedDelegate(String toPrint);
        public event dataReceivedDelegate dataReceived;
        public void StopListening()
        {
            if (t != null && t.IsAlive)
            {
                t.Abort();
                // Shutdown and end connection
                server.Close();
            }
        }

        public void StartListening(Nodes node, String ipAddr)
        {
            try
            {
                t = new Thread(listen);
                var address = IPAddress.Parse(ipAddr);
                endpoint = new IPEndPoint(address, Constants.Remotes[node]);
                server = new UdpClient(endpoint);
                t.Start();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        void listen()
        {
            try
            {
                Console.WriteLine("Waiting for a connection... ");

                // Enter the listening loop.
                while (true)
                {
                    
                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = server.Receive(ref RemoteIpEndPoint);

                    //string returnData = Encoding.ASCII.GetString(receiveBytes);

                    //deconstruct packet;
                    byte[] sequence = receiveBytes.Slice(0, 4);
                    byte[] type = receiveBytes.Slice(4, 2);
                    byte[] payload = receiveBytes.Slice(6, receiveBytes.Length - 2);
                    byte[] crc = receiveBytes.Slice(receiveBytes.Length - 2, 2);

                    byte[] reversedSequence = (sequence.Reverse()).ToArray();
                    byte[] reversedType = (type.Reverse()).ToArray();
                    byte[] reversedPayload = (payload.Reverse()).ToArray();
                    byte[] reversedCrc = (crc.Reverse()).ToArray();

                    String toPrint = "";
                    toPrint += "Sequence: ";
                    toPrint += BitConverter.ToString(reversedSequence);
                    toPrint += Environment.NewLine;

                    toPrint += "Type: ";
                    toPrint += BitConverter.ToString(reversedType);
                    toPrint += Environment.NewLine;

                    toPrint += "Payload: ";
                    toPrint += BitConverter.ToString(reversedPayload);
                    toPrint += Environment.NewLine;

                    toPrint += "CRC: ";
                    toPrint += BitConverter.ToString(reversedCrc);
                    toPrint += Environment.NewLine;


                    dataReceived?.Invoke(toPrint);

                    //Console.Write("Sequence: ");
                    //Console.Write(BitConverter.ToString(reversedSequence));
                    ////foreach (var item in reversedSequence)
                    ////    Console.Write(item);
                    //Console.WriteLine();

                    //Console.Write("Type: ");
                    //Console.Write(BitConverter.ToString(reversedType));
                    ////foreach (var item in reversedType)
                    ////    Console.Write(item);
                    //Console.WriteLine();

                    //Console.Write("Payload: ");
                    //Console.Write(BitConverter.ToString(reversedPayload));
                    ////foreach (var item in reversedPayload)
                    ////    Console.Write(item);
                    //Console.WriteLine();

                    //Console.Write("CRC: ");
                    //Console.Write(BitConverter.ToString(reversedCrc));
                    ////foreach (var item in reversedCrc)
                    ////    Console.Write(item);
                    //Console.WriteLine();

                    /*
                    Console.WriteLine("This is the message you received: ");
                    Console.Write("Hex, order: ");
                    Console.Write(BitConverter.ToString(receiveBytes));

                    Console.WriteLine();
                    Console.Write("Bytes, order: ");
                    foreach (var item in receiveBytes)
                        Console.Write(item);
                        */
                    //Console.WriteLine();
                    //Console.WriteLine("This message was sent from " +
                    //                            RemoteIpEndPoint.Address.ToString() +
                    //                            " on their port number " +
                    //                            RemoteIpEndPoint.Port.ToString());
                }
            }
            catch (SocketException e)
            {
                // Shutdown and end connection
                server.Close();
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}



