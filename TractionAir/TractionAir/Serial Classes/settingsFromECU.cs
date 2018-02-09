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

        public string boardVersion { get; set; }

        public string version { get; set; }

        public string speedControl { get; set; }

        public int loadedOffRoad { get; set; }

        public int notLoaded { get; set; }

        public int unloadedOffRoad { get; set; }

        public int maxTraction { get; set; }

        public int psiLoadedOnRoad { get; set; }

        public int psiLoadedOffRoad { get; set; }

        public int psiNotLoaded { get; set; }

        public int psiUnloadedOffRoad { get; set; }

        public int psiMaxTraction { get; set; }

        public int stepUpDelay { get; set; }

        public bool maxTractionBeep { get; set; }

        public bool enableGPSButtons { get; set; }

        public int crc { get; set; }

    }
}
