﻿using System;
using System.Collections.Generic;
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
            XILINX_SIM,
            ASI_MONITOR_SYSTEM,
            HE_THERMAL_MONITOR
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
            ASI_DATA,
            LGU_STATUS,
            PUSHER_DATA,
            FCU_DATA,
            HE_DATA
        };

        public static Dictionary<Nodes, int> Remotes = new Dictionary<Nodes, int>()
        {
            { Nodes.POWER_NODE_A,9110 },
            { Nodes.POWER_NODE_B,9111 },
            { Nodes.FLIGHT_CONTROL,9531 },
            { Nodes.LANDING_GEAR,9548 },
            { Nodes.GIMBAL_CONTROL,9619 },
            { Nodes.XILINX_SIM,9170 },
            { Nodes.ASI_MONITOR_SYSTEM,9616 },
            { Nodes.HE_THERMAL_MONITOR,9608}
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
            { PacketTypes.ASI_DATA,Nodes.ASI_MONITOR_SYSTEM },
            { PacketTypes.LGU_STATUS, Nodes.LANDING_GEAR },
            { PacketTypes.PUSHER_DATA, Nodes.FLIGHT_CONTROL },
            { PacketTypes.FCU_DATA, Nodes.FLIGHT_CONTROL },
            {PacketTypes.HE_DATA,Nodes.HE_THERMAL_MONITOR }
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
            { PacketTypes.ASI_DATA,0x1701 },
            { PacketTypes.LGU_STATUS, 0x7002 },
            { PacketTypes.PUSHER_DATA, 0x1801 },
            { PacketTypes.FCU_DATA, 0x0200  },
            {PacketTypes.HE_DATA, 24577 }
        };

        public static Dictionary<PacketTypes, PacketDefinition> AllPackets = new Dictionary<PacketTypes, PacketDefinition>()
        {
            {
                PacketTypes.HE_DATA,
                new PacketDefinition
                {
            Name = "HE Data",
            PacketType = 24577,
            Node = Nodes.HE_THERMAL_MONITOR,
            DAQ = false,
            ParameterPrefix = "HE ",
            Parameters = new Param [] {
                new Param {
                    Type = typeof(uint),
                    Units = "",
                    Size = 4,
                    Name = "Fault Flags"
                },
                new Param {
                    Type = typeof(uint),
                    Units = "",
                    Size = 4,
                    Name = "Solenoid Faults"
                },
                new Param {
                    Type = typeof(uint),
                    Units = "",
                    Size = 4,
                    Name = "DS2482 1 Fault Flags"
                },
                new Param {
                    Type = typeof(uint),
                    Units = "",
                    Size = 4,
                    Name = "DS2482 2 Fault Flags"
                },
               new Param  {
                    Type = typeof(uint),
                    Units = "",
                    Size = 4,
                    Name = "DS18B20 Fault Flags"
                },
               new Param  {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "Sensors Count"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "1 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "1 ROM ID"
                },
              new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "2 Temperature"
                },
               new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "2 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "3 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "3 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "4 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "4 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "5 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "5 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "6 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "6 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "7 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "7 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "8 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "8 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "9 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "9 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "10 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "10 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "11 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "11 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "12 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "12 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "13 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "13 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "14 Temperature"
                },
               new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "14 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "15 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "15 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "16 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "16 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "17 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "17 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "18 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "18 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "19 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "19 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "20 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "20 ROM ID"
                },
               new Param  {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "21 Temperature"
                },
               new Param  {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "21 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "22 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "22 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "23 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "23 ROM ID"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "24 Temperature"
                },
                new Param {
                    Type = typeof(UInt64),
                    Units = "",
                    Size = 8,
                    Name = "24 ROM ID"
                },
                new Param {
                    Type = typeof(UInt16),
                    Units = "",
                    Size = 2,
                    Name = "Left Highest Sensor Index"
                },
                new Param {
                    Type = typeof(UInt16),
                    Units = "",
                    Size = 2,
                    Name = "Right Highest Sensor Index"
                },
                new Param {
                    Type = typeof(UInt16),
                    Units = "",
                    Size = 2,
                    Name = "Brake Motor Highest Sensor Index"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Left Highest Temp"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Right Highest Temp"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Brake Motor Highest Temp"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Left Average Temp"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Right Average Temp"
                },
                new Param {
                    Type = typeof(float),
                    Units = "",
                    Size = 4,
                    Name = "Brake Motor Average Temp"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "Left Overtemp State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "Right Overtemp State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "Brake Motor Overtemp State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "1 Solenoid Open State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "2 Solenoid Open State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "3 Solenoid Open State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "4 Solenoid Open State"
                },
                new Param {
                    Type = typeof(byte),
                    Units = "",
                    Size = 1,
                    Name = "Manual Control Mode"
                }
            }
        }
            },
            {
                PacketTypes.POWER_A_BMS,
                new PacketDefinition{
      Name =  "Power A BMS",
      ParameterPrefix = "Power A BMS ",
      PacketType = 0x3401,
      Node= Nodes.POWER_NODE_A,
      DAQ= false,
      Parameters =new Param[] {
        new Param {Name =  "Faults", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 1", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 2", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Pack Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Highest Cell Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Lowest Cell Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "2 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "3 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "4 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "5 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "6 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "7 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "8 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "9 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "10 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "11 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "12 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "13 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "14 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "15 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "16 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "17 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "18 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "2 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "3 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "4 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "5 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "6 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "7 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "8 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "9 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "10 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "11 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "12 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "13 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "14 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "15 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "16 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "17 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "18 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "2 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "3 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "4 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "5 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "6 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "7 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "8 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "9 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "10 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "11 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "12 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "13 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "14 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "15 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "16 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "17 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "18 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Voltage Updates", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Battery Spare", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Charger State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Temp State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Num Temp Sensors", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name =  "Highest Sensor Value", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Average Temp", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Highest Sensor Index", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name =  "Temp Scan Count", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Node Pressure", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "TNode Temp", Type = typeof(float), Units = "", Size = 4} }



                } },
                        {
                PacketTypes.POWER_B_BMS,
                new PacketDefinition{
      Name =  "Power B BMS",
      ParameterPrefix = "Power B BMS ",
      PacketType = 0x3401,
      Node= Nodes.POWER_NODE_B,
      DAQ= false,
      Parameters =new Param[] {
                new Param {Name =  "Faults", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 1", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 2", Type = typeof(UInt32), Units = "", Size = 4},
       new Param {Name =  "Device Faults 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Pack Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Highest Cell Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Lowest Cell Volts", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "2 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "3 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "4 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "5 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "6 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "7 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "8 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "9 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "10 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "11 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "12 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "13 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "14 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "15 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "16 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "17 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "18 Module Voltage", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "2 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "3 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "4 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "5 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "6 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "7 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "8 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "9 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "10 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "11 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "12 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "13 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "14 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "15 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "16 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "17 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "18 Module Spare", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "1 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "2 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "3 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "4 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "5 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "6 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "7 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "8 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "9 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "10 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "11 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "12 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "13 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "14 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "15 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "16 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "17 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "18 Module Resistor", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Voltage Updates", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Battery Spare", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Charger State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Temp State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name =  "Num Temp Sensors", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name =  "Highest Sensor Value", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Average Temp", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "Highest Sensor Index", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name =  "Temp Scan Count", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name =  "Node Pressure", Type = typeof(float), Units = "", Size = 4},
                new Param {Name =  "TNode Temp", Type = typeof(float), Units = "", Size = 4} }
    }
            },
                        {
                PacketTypes.POWER_A_COOLING,new PacketDefinition {
      Name = "Power A Cooling",
      ParameterPrefix = "Power A Cooling ",
      PacketType = 0x3601,
      Node = Nodes.POWER_NODE_A,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover1/2 Temp", Type = typeof(Int32), Units = "degF", Size = 4},
                new Param {Name = "Hover1/2 Cooling State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover1/2 Solenoid State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover1/2 Solenoid Pin", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover3/4 Temp", Type = typeof(Int32), Units = "degF", Size = 4},
                new Param {Name = "Hover3/4 Cooling State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover3/4 Solenoid State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover3/4 Solenoid Pin", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover5/6 Temp", Type = typeof(Int32), Units = "degF", Size = 4},
                new Param {Name = "Hover5/6 Cooling State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover5/6 Solenoid State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover5/6 Solenoid Pin", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover7/8 Temp", Type = typeof(Int32), Units = "degF", Size = 4},
                new Param {Name = "Hover7/8 Cooling State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover7/8 Solenoid State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "Hover7/8 Solenoid Pin", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "EddyBrake Temp", Type = typeof(Int32), Units = "degF", Size = 4},
                new Param {Name = "EddyBrake Cooling State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "EddyBrake Solenoid State", Type = typeof(byte), Units = "", Size = 1},
                new Param {Name = "EddyBrake Solenoid Pin", Type = typeof(byte), Units = "", Size = 1}

          }
    }
        },
            {PacketTypes.LASER_OPTO_SENSOR, new PacketDefinition {
      Name = "Laser Opto Sensor",
      ParameterPrefix = "LaserOpto ",
      PacketType = 0x1101,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param{Name = "Fault flags", Type = typeof(UInt32), Units = "", Size = 4}, // top-level fault flags
                new Param{Name = "Spare", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 1", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 1", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 1", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 2", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 2", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 2", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 3", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 3", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 3", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 4", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 4", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 4", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 5", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 5", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 5", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 5", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 5", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 5", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 6", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 6", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 6", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 6", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 6", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 6", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 7", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 7", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 7", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 7", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 7", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 7", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Fault flags 8", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Laser error packet count 8", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "First byte wrong 8", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Raw distance 8", Type = typeof(float), Units = "", Size = 4},
                new Param{Name = "Filtered value 8", Type = typeof(float), Units = "mm", Size = 4},
                new Param{Name = "Spare 8", Type = typeof(UInt32), Units = "", Size = 4}
      }
    }
            }, {PacketTypes.ACCEL_CAL_FULL, new PacketDefinition
            {
      Name = "Accel Cal Full",
      ParameterPrefix = "Accel ",
      PacketType = 0x1001,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "0 Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "0 X Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "0 Y Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "0 Z Raw", Type = typeof(Int16), Units = "RAW", Size = 2},

                new Param {Name = "1 Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "1 X Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "1 Y Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "1 Z Raw", Type = typeof(Int16), Units = "RAW", Size = 2}
      }

    }
            },
    {PacketTypes.ACCEL_DATA_FULL, new PacketDefinition {
      Name = "Accel Data Full",
      ParameterPrefix = "Accel ",
      PacketType = 0x1003,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "0 Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "0 X Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "0 Y Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "0 Z Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
               new Param  {Name = "0 X Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "0 Y Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "0 Z Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "0 Pitch", Type = typeof(float), Units = "°", Size = 4},
               new Param  {Name = "0 Roll", Type = typeof(float), Units = "°", Size = 4},
               new Param  {Name = "0 Current Accel", Type = typeof(Int32), Units = "mmss", Size = 4},
                new Param {Name = "0 Current Velocity", Type = typeof(Int32), Units = "mms", Size = 4},
                new Param {Name = "0 Previous Velocity", Type = typeof(Int32), Units = "mms", Size = 4},
                new Param {Name = "0 Current Displacement", Type = typeof(Int32), Units = "mm", Size = 4},
                new Param {Name = "0 Previous Displacement", Type = typeof(Int32), Units = "mm", Size = 4},

                new Param {Name = "1 Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "1 X Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "1 Y Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
                new Param {Name = "1 Z Raw", Type = typeof(Int16), Units = "RAW", Size = 2},
               new Param  {Name = "1 X Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "1 Y Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "1 Z Gs", Type = typeof(float), Units = "Gs", Size = 4},
               new Param  {Name = "1 Pitch", Type = typeof(float), Units = "°", Size = 4},
               new Param  {Name = "1 Roll", Type = typeof(float), Units = "°", Size = 4},
               new Param  {Name = "1 Current Accel", Type = typeof(Int32), Units = "mmss", Size = 4},
               new Param  {Name = "1 Current Velocity", Type = typeof(Int32), Units = "mms", Size = 4},
               new Param  {Name = "1 Previous Velocity", Type = typeof(Int32), Units = "mms", Size = 4},
               new Param  {Name = "1 Current Displacement", Type = typeof(Int32), Units = "mm", Size = 4},
               new Param  {Name = "1 Previous Displacement", Type = typeof(Int32), Units = "mm", Size = 4}
      }
    }
            }, {PacketTypes.THROTTLE_PARAMETERS, new PacketDefinition
        {
      Name = "Throttle parameters",
      ParameterPrefix = "Throttle ",
      PacketType = 0x1503,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[]{
                new Param {Name = "Fault Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "AMC Fault Flags", Type = typeof(UInt32), Units = "", Size = 4},

                new Param {Name = "Requested RPM 1", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 2", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 3", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 4", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 5", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 6", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 7", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Requested RPM 8", Type = typeof(UInt16), Units = "", Size = 2},

                new Param {Name = "Current RPM 1", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 2", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 3", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 4", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 5", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 6", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 7", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Current RPM 8", Type = typeof(UInt16), Units = "", Size = 2},

                new Param {Name = "ASI RPM 1", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 2", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 3", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 4", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 5", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 6", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 7", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "ASI RPM 8", Type = typeof(UInt16), Units = "", Size = 2},

                new Param {Name = "State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Current Index", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "AMC State", Type = typeof(uint), Units = "", Size = 1}
      }
    }
}, {PacketTypes.BRAKE_DATA, new PacketDefinition {
      Name = "Brake data",
      ParameterPrefix = "Brake ",
      PacketType =0x1402,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[]{
                new Param{Name = "Fault flags 1", Type = typeof(UInt32), Units =  "A", Size = 4},

                new Param{Name = "I Beam mm 1 Target", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead screw mm 1 Target", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead screw um 1 Target", Type = typeof(UInt32), Units =  "um", Size = 4},

                new Param{Name = "I Beam mm 1 Current", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead Screw mm 1 Current", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "MLP 1 Current", Type = typeof(float), Units =  "mm", Size = 4},

                new Param{Name = "Spare 1_1", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Spare 1_2", Type = typeof(UInt32), Units =  "", Size = 4},

                new Param{Name = "Limit Extend 1", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Retract 1", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Extend Edge 1", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Retract Edge 1", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "SW Error 1", Type = typeof(uint), Units =  "", Size = 1},

                new Param{Name = "ADC Sample 1", Type = typeof(UInt16), Units =  "", Size = 2},
                new Param{Name = "ADC Zero 1", Type = typeof(UInt16), Units =  "", Size = 2},
                new Param{Name = "ADC Minus Zero 1", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "System Span 1", Type = typeof(float), Units =  "", Size = 4},
                new Param{Name = "Position mm 1", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Linear Velocity 1", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Linear Acceleration 1", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Current Position 1", Type = typeof(UInt32), Units =  "", Size = 4},

                new Param{Name = "Fault flags 2", Type = typeof(UInt32), Units =  "A", Size = 4},

                new Param{Name = "I Beam mm 2 Target", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead screw mm 2 Target", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead screw um 2 Target", Type = typeof(UInt32), Units =  "um", Size = 4},

                new Param{Name = "I Beam mm 2 Current", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Lead Screw mm 2 Current", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "MLP 2 Current", Type = typeof(float), Units =  "mm", Size = 4},

                new Param{Name = "Spare 2_1", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Spare 2_2", Type = typeof(UInt32), Units =  "", Size = 4},

                new Param{Name = "Limit Extend 2", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Retract 2", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Extend Edge 2", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Limit Retract Edge 2", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "SW Error 2", Type = typeof(uint), Units =  "", Size = 1},

                new Param{Name = "ADC Sample 2", Type = typeof(UInt16), Units =  "", Size = 2},
                new Param{Name = "ADC Zero 2", Type = typeof(UInt16), Units =  "", Size = 2},
                new Param{Name = "ADC Minus Zero 2", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "System Span 2", Type = typeof(float), Units =  "", Size = 4},
                new Param{Name = "Position mm 2", Type = typeof(float), Units =  "mm", Size = 4},
                new Param{Name = "Linear Velocity 2", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Linear Acceleration 2", Type = typeof(UInt32), Units =  "", Size = 4},
                new Param{Name = "Current Position 2", Type = typeof(UInt32), Units =  "", Size = 4},

                new Param{Name = "State", Type = typeof(uint), Units =  "", Size = 1},
                new Param{Name = "Calibration State", Type = typeof(uint), Units =  "", Size = 1}
      }
    }
}, {PacketTypes.MOTOR_PARAMETERS, new PacketDefinition
       {
      Name = "Motor parameters",
      ParameterPrefix = "Motor ",
      PacketType = 0x1406,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param{Name = "Microstep Resolution 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Max Acceleration 1", Type = typeof(Int32), Units = "", Size = 4},
                new Param{Name = "Microns per Revolution 1", Type = typeof(Int32), Units = "", Size = 4},
                new Param{Name = "Steps per Revolution 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Max Angular Velocity 1", Type = typeof(Int32), Units = "", Size = 4},

                new Param{Name = "Microstep Resolution 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Max Acceleration 2", Type = typeof(Int32), Units = "", Size = 4},
                new Param{Name = "Microns per Revolution 2", Type = typeof(Int32), Units = "", Size = 4},
                new Param{Name = "Steps per Revolution 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Max Angular Velocity 2", Type = typeof(Int32), Units = "", Size = 4},
                new Param{Name = "Lowest Cell Volts", Type = typeof(float), Units = "", Size = 4}
      }
    }
            },
    {PacketTypes.FORWARD_LASER_DISTANCE_SENSOR, new PacketDefinition {
      Name = "Forward Laser Distance Sensor",
      ParameterPrefix = "ForwardLaser ",
      PacketType = 0x1201,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param{Name = "Fault flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Distance (mm)", Type = typeof(UInt32), Units = "mm", Size = 4},
                new Param{Name = "Previous dist (mm)", Type = typeof(UInt32), Units = "mm", Size = 4},
                new Param{Name = "Velocity", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Distance Raw", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Acceleration", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Prev Accel", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Binary dist", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Missed start", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Bad distance", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Error code", Type = typeof(UInt32), Units = "", Size = 4}
            }
    }
    },{PacketTypes.FLIGHT_CONTROL_LASER_CONTRAST_0, new PacketDefinition {
      Name = "Flight Control - Laser Contrast 0",
      ParameterPrefix = "LaserContrast0 ",
      PacketType = 0x1301,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param{Name = "System Fault Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Spare 0", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Spare 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Spare 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Spare 3", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Laser Fault Flags", Type = typeof(UInt32), Units = "", Size = 4},

                new Param{Name = "Rising Count", Type = typeof(UInt16), Units = "", Size = 2},
                new Param{Name = "Falling Count", Type = typeof(UInt16), Units = "", Size = 2},

                // 55 stripes
                new Param{Name = "Rise_00", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_01", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_02", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_03", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_04", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_05", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_06", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_07", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_08", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_09", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Rise_10", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_11", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_12", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_13", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_14", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_15", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_16", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_17", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_18", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_19", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Rise_20", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_21", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_22", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_23", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_24", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_25", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_26", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_27", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_28", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_29", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Rise_30", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_31", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_32", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_33", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_34", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_35", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_36", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_37", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_38", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_39", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Rise_40", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_41", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_42", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_43", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_44", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_45", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_46", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_47", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_48", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_49", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Rise_50", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_51", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_52", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Rise_53", Type = typeof(UInt64), Units = "ns", Size = 8},

                // 55 stripes
                new Param{Name = "Fall_00", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_01", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_02", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_03", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_04", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_05", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_06", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_07", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_08", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_09", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Fall_10", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_11", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_12", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_13", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_14", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_15", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_16", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_17", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_18", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_19", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Fall_20", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_21", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_22", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_23", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_24", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_25", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_26", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_27", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_28", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_29", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Fall_30", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_31", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_32", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_33", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_34", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_35", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_36", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_37", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_38", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_39", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Fall_40", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_41", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_42", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_43", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_44", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_45", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_46", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_47", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_48", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_49", Type = typeof(UInt64), Units = "ns", Size = 8},

                new Param{Name = "Fall_50", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_51", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_52", Type = typeof(UInt64), Units = "ns", Size = 8},
                new Param{Name = "Fall_53", Type = typeof(UInt64), Units = "ns", Size = 8}
      }
    }
    }, {PacketTypes.ASI_DATA, new PacketDefinition
            {
      Name = "ASI Data",
      ParameterPrefix = "ASI ",
      PacketType = 0x1701,
      Node = Nodes.ASI_MONITOR_SYSTEM,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "Fault Flags Root", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "State", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Scan Index", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Current Command", Type = typeof(UInt16), Units = "", Size = 2},

                new Param {Name = "1 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "1 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "1 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "1 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "1 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "2 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "2 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "2 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "2 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "2 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "3 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "3 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "3 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "3 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "3 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "4 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "4 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "4 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "4 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "4 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "5 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "5 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "5 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "5 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "5 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "6 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "6 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "6 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "6 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "6 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "7 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "7 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "7 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "7 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "7 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},

                new Param {Name = "8 Controller Fault", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "8 Temperature", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "8 Motor Current", Type = typeof(float), Units = "", Size = 4},
                new Param {Name = "8 HE RPM", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "8 Throttle Voltage", Type = typeof(float), Units = "", Size = 4},
      }

    }
            }, {PacketTypes.LGU_STATUS, new PacketDefinition
            {
      Name = "LGU Status",
      ParameterPrefix = "LGU ",
      PacketType = 0x7002,
      Node = Nodes.LANDING_GEAR,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "Fault Flags Root", Type = typeof(UInt32), Units = "", Size = 4},

                new Param {Name = "Fault Flags 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "ADC Value 1", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Actual Extension 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Computed Height 1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Switch Extend 1", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Switch Retract 1", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Spare 1_1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 2_1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 3_1", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 4_1", Type = typeof(UInt32), Units = "", Size = 4},

                new Param {Name = "Fault Flags 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "ADC Value 2", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Actual Extension 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Computed Height 2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Switch Extend 2", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Switch Retract 2", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Spare 1_2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 2_2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 3_2", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 4_2", Type = typeof(UInt32), Units = "", Size = 4},

                new Param {Name = "Fault Flags 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "ADC Value 3", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Actual Extension 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Computed Height 3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Switch Extend 3", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Switch Retract 3", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Spare 1_3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 2_3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 3_3", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 4_3", Type = typeof(UInt32), Units = "", Size = 4},

                new Param {Name = "Fault Flags 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "ADC Value 4", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "Actual Extension 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Computed Height 4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Switch Extend 4", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Switch Retract 4", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Spare 1_4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 2_4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 3_4", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "Spare 4_4", Type = typeof(UInt32), Units = "", Size = 4},
      }

    }
            },
    {PacketTypes.PUSHER_DATA, new PacketDefinition {
      Name = "Pusher Data",
      ParameterPrefix = "Pusher ",
      PacketType = 0x1801,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param{Name = "Fault flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param{Name = "Status", Type = typeof(uint), Units = "", Size = 1},
                new Param{Name = "Edge Flag 1", Type = typeof(uint), Units = "", Size = 1},
                new Param{Name = "Edge Flag 2", Type = typeof(uint), Units = "", Size = 1},
                new Param{Name = "Switch State 1", Type = typeof(uint), Units = "", Size = 1},
                new Param{Name = "Switch State 2", Type = typeof(uint), Units = "", Size = 1},
                new Param{Name = "Switch timer", Type = typeof(UInt32), Units = "", Size = 4}
            }
    }
    }, {PacketTypes.FCU_DATA, new PacketDefinition
            {
      Name = "FCU Data",
      ParameterPrefix = "",
      PacketType = 0x0200,
      Node = Nodes.FLIGHT_CONTROL,
      DAQ = false,
      Parameters = new Param[] {
                new Param {Name = "All Flags", Type = typeof(UInt32), Units = "", Size = 4},
                new Param {Name = "FCU Mission State", Type = typeof(UInt16), Units = "", Size = 2},
                new Param {Name = "FCU Mission TrackDB", Type = typeof(uint), Units = "", Size = 1},
                new Param {Name = "Pod Health Fault Flags", Type = typeof(UInt32), Units = "", Size = 4}
      }

    }
            }
        };

        public static UInt16[] CRCHashtable = new UInt16[]
{
                0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
  0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
  0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
  0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
  0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
  0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
  0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
  0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
  0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
  0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
  0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12,
  0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
  0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41,
  0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
  0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
  0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
  0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
  0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
  0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
  0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
  0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
  0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
  0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
  0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
  0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
  0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
  0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
  0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
  0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
  0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
  0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
  0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
};
    }
}
