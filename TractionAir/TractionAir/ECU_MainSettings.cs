using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir
{
    public class ECU_MainSettings
    {
        public int BoardCode { get; set; }

        public string PressureGroup { get; set; }

        public string Owner { get; set; }

        public string Country { get; set; }

        public DateTime BuildDate { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string VehicleRef { get; set; }

        public string SpeedStages { get; set; }

        public DateTime DateMod { get; set; }

        public string Notes { get; set; }

        public string SerialNumber { get; set; }

        public int PressureCell { get; set; }

        public string PT1Serial { get; set; }

        public string PT2Serial { get; set; }

        public string PT3Serial { get; set; }

        public string PT4Serial { get; set; }

        public string PT5Serial { get; set; }

        public string PT6Serial { get; set; }

        public string PT7Serial { get; set; }

        public string PT8Serial { get; set; }

        public int LoadedOffRoad { get; set; }

        public int LoadedOnRoad { get; set; }

        public int UnloadedOnRoad { get; set; }

        public int MaxTraction { get; set; }

        public string SerialCodeBot { get; set; }

        public bool MaxTractionBeep { get; set; }

        public bool EnableGPSButtons { get; set; }

        public bool EnableGPSOverride { get; set; }

        public int StepUpDelay { get; set; }

        public int Distance { get; set; }

        public int UnloadedOffRoad { get; set; }
    }
}
