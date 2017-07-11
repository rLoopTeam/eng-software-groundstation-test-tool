using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_LOGIC
{
    public class PacketDefinition
    {
        public enum PacketTypes
        {
            POWER_CURRENT_TEMP
        }


        public static Dictionary<PacketTypes, uint> PTypes = new Dictionary<PacketTypes, uint>() {
            { PacketTypes.POWER_CURRENT_TEMP,0x3201 }
        };

        public String Name { get; set; }
        public String ParameterPrefix { get; set; }
        public int PacketType { get; set; }
        public String Node { get; set; }
        public Boolean DAQ { get; set; }
        public Param[] Parameters { get; set; }

    }

    public class Param
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public String Units  { get; set; }
        public int Size { get; set; }
    }

    public class Node
    {
        public String Ip { get; set; }
        public int Port { get; set; }
        public String Name { get; set; }
    }
}
