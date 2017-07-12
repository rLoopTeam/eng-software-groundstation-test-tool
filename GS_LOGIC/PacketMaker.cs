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
        public static byte[] makeUDP(PacketTypes type, String[] stringValues)
        {

            byte[] payload = retrievePayload(type, stringValues);

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


            for (int i = 0; i < payload.Length; i++)
            {
                packet[8 + i] = payload[i];
            }

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

            //Establish the payloadsize
            int payloadSize = 0;

            foreach (var elem in parameters)
            {
                payloadSize += elem.Size;
            }


            byte[] payload = new byte[payloadSize];
            int nextPayloadPosition = 0;

            for (int i = 0; i < parameters.Length; i++)
            {
                String value = values[i];
                byte[] parameterByteArray = GetByteArray(value, parameters[i].Type);
                for (int y = 0; y < parameters[i].Size; y++)
                {
                    payload[nextPayloadPosition] = parameterByteArray[y];
                    nextPayloadPosition++;
                }
            }

            return payload;
        }

        public static byte[] CalculateCRC(byte[] packet, int packetLength)
        {
            //from current GS
            var crc = 0x0000;

            int j, i, c;
            for (i = 0; i < packetLength; i++)
            {
                c = packet[i];
                if (c > 255) throw new ArgumentException();
                j = ((crc >> 8) ^ c) & 0xFF;
                crc = CRCHashtable[j] ^ (crc << 8);
            }

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
                    return BitConverter.GetBytes(byte.Parse(value));
                case "System.UInt16":
                    return BitConverter.GetBytes(UInt16.Parse(value));
                case "System.UInt32":
                    return BitConverter.GetBytes(UInt32.Parse(value));
                case "System.Int16":
                    return BitConverter.GetBytes(Int16.Parse(value));
                case "System.Int32":
                    return BitConverter.GetBytes(Int32.Parse(value));
                case "System.Int64":
                    return BitConverter.GetBytes(Int64.Parse(value));
                case "System.Single":
                    return BitConverter.GetBytes(float.Parse(value));
                default: return new byte[] { 0 };
            }
        }
    }
}
