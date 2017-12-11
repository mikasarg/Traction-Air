using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir.Serial_Classes
{
    public class settingsFromECU
    {
        public int boardCode { get; set; }

        public string topSerial { get; set; }

        public string botSerial { get; set; }

        public string speedControl { get; set; }

        public int notLoaded { get; set; }

        public int loadedOnRoad { get; set; }

        public int loadedOffRoad { get; set; }

        public int maxTraction { get; set; }

        public int stepUpDelay { get; set; }

        public bool maxTractionBeep { get; set; }

        public bool enableGPSButtons { get; set; }

        public bool enableGPSOverride { get; set; }

    }
}
