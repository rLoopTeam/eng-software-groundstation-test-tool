using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_LOGIC.Constants;

namespace GS_LOGIC
{
    public static class Mission
    {
        public static void upperBoundaryTest()
        {
            var healthCheckParams = (AllPackets[PacketTypes.POWER_A_BMS]).NominalConditions.Select(c => c.Parameter).ToArray();

        }
    }
}
