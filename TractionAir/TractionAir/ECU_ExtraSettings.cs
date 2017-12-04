using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir
{
    class ECU_ExtraSettings
    {
        public int BoardCode { get; set; }

        public string SerialNumber { get; set; }

        public int pressureCell { get; set; }

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
    }
}
