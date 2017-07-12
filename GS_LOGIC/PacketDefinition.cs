using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_LOGIC.Constants;

namespace GS_LOGIC
{

    public class PacketDefinition
    {
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
        public Type Type { get; set; }
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
