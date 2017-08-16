using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_LOGIC.Constants;

namespace GS_LOGIC
{
    public class PacketMaker
    {
        public static byte[] makeUDP(PacketTypes type, byte[] payload)
        {
            return _makeUDP(type, payload);
        }
        public static byte[] makeUDP(PacketTypes type, String[] stringValues)
        {
            //convert the represented string values to bytes
            byte[] payload = retrievePayload(type, stringValues);
            return _makeUDP(type, payload);
        }
        private static byte[] _makeUDP(PacketTypes type, byte[] payload)
        {
            //initialize sizes, these correspond to the udp packet structures
            int sequenceSize = 4;
            int packetTypeSize = 2;
            int payloadLengthDef = 2;
            int payloadLengthSize = payload.Length;
            int crcSize = 2;

            int packetSize = sequenceSize + packetTypeSize + payloadLengthDef + payloadLengthSize + crcSize;

            byte[] packet = new byte[packetSize];

            byte[] sequence = BitConverter.GetBytes(1);
            byte[] packettype = BitConverter.GetBytes(PTypes[type]);
            byte[] payloadLength = BitConverter.GetBytes((ushort)payloadLengthSize);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(sequence);
                Array.Reverse(packettype);
                Array.Reverse(payloadLength); 
            }

            packet[0] = sequence[0];
            packet[1] = sequence[1];
            packet[2] = sequence[2];
            packet[3] = sequence[3];
            packet[4] = packettype[0];
            packet[5] = packettype[1];
            packet[6] = payloadLength[0];
            packet[7] = payloadLength[1];
            packet.Insert(8, payload);

            byte[] crc = CalculateCRC(packet, packetSize-2);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(crc);
            }

            packet[packetSize - 2] = crc[0];
            packet[packetSize - 1] = crc[1];

            return packet;
        }

        public static byte[] retrievePayload(PacketTypes type, String[] values)
        {
            var parameters = Constants.AllPackets[type].Parameters;

            int payloadSize = 0;
            //establish the final payload byte size
            int numberOfParametersInLoop = 0;
            bool countParam = false;

            //establish if there is a loop of parameters in the packet type
            //if true count how many of the parameters are looped
            //this information is used later to determine the payload, and therefore the packet size
            for(int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].BeginLoop) countParam = true;
                if (countParam) numberOfParametersInLoop++;
                if (parameters[i].EndLoop) countParam = false;
            }
            //count the number of times the loop occurs in the stream of values
            //this occurs so that we can establish the payload size
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].BeginLoop)
                {
                    int numberLoops = (values.Length - i) / numberOfParametersInLoop;
                    int sizePerLoop = 0;
                    for (int j = 0; j < numberOfParametersInLoop; j++)
                    {
                        sizePerLoop += parameters[i + j].Size;
                    }
                    payloadSize += sizePerLoop * numberLoops;
                }else
                {
                    payloadSize += parameters[i].Size;
                }  
            }

            //create bytearray to populate with the payload
            byte[] payload = new byte[payloadSize];
            int nextPayloadPosition = 0;

            //loop through all the values and convert them all to bytes
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].BeginLoop)
                {
                    int j = 0;
                    for (; j < values.Length - i; j++)
                    {
                        int k = -1;
                        do
                        {
                            k++;
                            String value = values[i+k+j];
                            //convert the value into byte-array
                            byte[] parameterByteArray = GetByteArray(value, parameters[i].Type);
                            //insert converted values into the payload array
                            payload.Insert(nextPayloadPosition, parameterByteArray);
                            nextPayloadPosition += parameters[i+k].Size;

                        } while (!parameters[k+i].EndLoop);
                        j += k;
                    }
                    i += j;
                }else
                {
                    String value = values[i];
                    //convert the value into byte-array
                    byte[] parameterByteArray = GetByteArray(value, parameters[i].Type);
                    //insert converted values into the payload array
                    payload.Insert(nextPayloadPosition, parameterByteArray);
                    nextPayloadPosition += parameters[i].Size;
                }
            }

            return payload;
        }

        public static byte[] CalculateCRC(byte[] packet, int packetLength)
        {
            //VOODOO CRC calculation extracted from current GS
            var crc = 0x0000;

            int j, i, c;
            for (i = 0; i < packetLength; i++)
            {
                c = packet[i];
                if (c > 255) throw new ArgumentException();
                j = ((crc >> 8) ^ c) & 0xFF;
                crc = CRCHashtable[j] ^ (crc << 8);
            }
            crc += 1;
            byte[] arr = BitConverter.GetBytes(crc);
            return arr;
        }

        private static byte[] GetFloatToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(float.Parse(value));
            return payload;
        }

        private static byte[] GetInt8ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(sbyte.Parse(value));
            return payload;
        }

        private static byte[] GetInt16ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(Int16.Parse(value));
            return payload;
        }

        private static byte[] GetInt32ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(Int32.Parse(value));
            return payload;
        }

        private static byte[] GetInt64ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(Int64.Parse(value));
            return payload;
        }

        private static byte[] GetUInt8ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(byte.Parse(value));
            return payload;
        }

        private static byte[] GetUInt16ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(UInt16.Parse(value));
            return payload;
        }

        private static byte[] GetUInt32ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(UInt32.Parse(value));
            return payload;
        }

        private static byte[] GetUInt64ToBytes(String value)
        {
            byte[] payload = BitConverter.GetBytes(UInt64.Parse(value));
            return payload;
        }

        private static byte[] GetByteArray(String value, Type type)
        {
            switch (type.ToString())
            {
                case "System.Byte":
                    return GetUInt8ToBytes(value);
                case "System.UInt16":
                    return GetUInt16ToBytes(value);
                case "System.UInt32":
                    return GetUInt32ToBytes(value);
                case "System.Int16":
                    return GetInt16ToBytes(value);
                case "System.Int32":
                    return GetInt32ToBytes(value);
                case "System.Int64":
                    return GetInt64ToBytes(value);
                case "System.UInt64":
                    return GetUInt64ToBytes(value);
                case "System.Single":
                    return GetFloatToBytes(value);
                default: return new byte[] { 0 };
            }
        }
    }
}
