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
    }
}
