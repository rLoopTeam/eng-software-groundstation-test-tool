using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_LOGIC.PacketDefinition;

namespace GS_LOGIC
{
    public class Constants
    {
        public enum Nodes
        {
            POWER_NODE_A,
            POWER_NODE_B,
            FLIGHT_CONTROL,
            LANDING_GEAR,
            GIMBAL_CONTROL,
            XILINX_SIM
        };

        public static Dictionary<Nodes, int> Remotes = new Dictionary<Nodes,int>()
        {
            { Nodes.POWER_NODE_A,9110 },
            { Nodes.POWER_NODE_B,9111 },
            { Nodes.FLIGHT_CONTROL,9100 },
            { Nodes.LANDING_GEAR,9120 },
            { Nodes.GIMBAL_CONTROL,9130 },
            { Nodes.XILINX_SIM,9170 }
        };

        public static Dictionary<PacketTypes, Nodes> NodesTypes = new Dictionary<PacketTypes, Nodes>() {
            { PacketTypes.POWER_A_CURRENT_TEMP,Nodes.POWER_NODE_A },
            { PacketTypes.POWER_B_CURRENT_TEMP,Nodes.POWER_NODE_B },
            { PacketTypes.POWER_A_CURRENT_TEMP_LOCATIONS,Nodes.POWER_NODE_A },
            { PacketTypes.POWER_B_CURRENT_TEMP_LOCATIONS,Nodes.POWER_NODE_B },
            { PacketTypes.POWER_A_ROM_ID,Nodes.POWER_NODE_A },
            { PacketTypes.POWER_B_ROM_ID,Nodes.POWER_NODE_B },
            { PacketTypes.POWER_A_BMS,Nodes.POWER_NODE_A },
            { PacketTypes.POWER_B_BMS,Nodes.POWER_NODE_B },
            { PacketTypes.POWER_A_COOLING,Nodes.POWER_NODE_A },
            { PacketTypes.AUTO_SEQUENCE_TEST,Nodes.FLIGHT_CONTROL },
            { PacketTypes.ACCEL_CAL_FULL,Nodes.FLIGHT_CONTROL },
            { PacketTypes.ACCEL_DATA_FULL,Nodes.FLIGHT_CONTROL },
            { PacketTypes.BRAKE_CAL_FULL,Nodes.FLIGHT_CONTROL },
            { PacketTypes.BRAKE_DATA,Nodes.FLIGHT_CONTROL },
            { PacketTypes.THROTTLE_PARAMETERS,Nodes.FLIGHT_CONTROL },
            { PacketTypes.MOTOR_PARAMETERS,Nodes.FLIGHT_CONTROL },
            { PacketTypes.LASER_OPTO_SENSOR,Nodes.FLIGHT_CONTROL },
            { PacketTypes.FORWARD_LASER_DISTANCE_SENSOR,Nodes.FLIGHT_CONTROL },
            { PacketTypes.FLIGHT_CONTROL_LASER_CONTRAST_0,Nodes.FLIGHT_CONTROL },
        };
        public enum PacketTypes
        {
            POWER_A_CURRENT_TEMP,
            POWER_B_CURRENT_TEMP,
            POWER_A_CURRENT_TEMP_LOCATIONS,
            POWER_B_CURRENT_TEMP_LOCATIONS,
            POWER_A_ROM_ID,
            POWER_B_ROM_ID,
            POWER_A_BMS,
            POWER_B_BMS,
            POWER_A_COOLING,
            AUTO_SEQUENCE_TEST,
            ACCEL_CAL_FULL,
            ACCEL_DATA_FULL,
            BRAKE_CAL_FULL,
            BRAKE_DATA,
            THROTTLE_PARAMETERS,
            MOTOR_PARAMETERS,
            LASER_OPTO_SENSOR,
            FORWARD_LASER_DISTANCE_SENSOR,
            FLIGHT_CONTROL_LASER_CONTRAST_0,
        };


        public static Dictionary<PacketTypes, ushort> PTypes = new Dictionary<PacketTypes, ushort>() {
            { PacketTypes.POWER_A_CURRENT_TEMP,0x3201 },
            { PacketTypes.POWER_B_CURRENT_TEMP,0x3201 },
            { PacketTypes.POWER_A_CURRENT_TEMP_LOCATIONS,0x3203 },
            { PacketTypes.POWER_B_CURRENT_TEMP_LOCATIONS,0x3203 },
            { PacketTypes.POWER_A_ROM_ID,0x3205 },
            { PacketTypes.POWER_B_ROM_ID,0x3205 },
            { PacketTypes.AUTO_SEQUENCE_TEST,0x1901 },
            { PacketTypes.POWER_A_BMS,0x3401 },
            { PacketTypes.POWER_B_BMS,0x3401 },
            { PacketTypes.POWER_A_COOLING,0x3601 },
            { PacketTypes.ACCEL_CAL_FULL,0x1001 },
            { PacketTypes.ACCEL_DATA_FULL,0x1003 },
            { PacketTypes.BRAKE_CAL_FULL,0x0000 },
            { PacketTypes.BRAKE_DATA,0x1402 },
            { PacketTypes.THROTTLE_PARAMETERS,0x1503 },
            { PacketTypes.MOTOR_PARAMETERS,0x1406 },
            { PacketTypes.LASER_OPTO_SENSOR,0x1101 },
            { PacketTypes.FORWARD_LASER_DISTANCE_SENSOR,0x1201 },
            { PacketTypes.FLIGHT_CONTROL_LASER_CONTRAST_0,0x1301 },
        };
    }
}
