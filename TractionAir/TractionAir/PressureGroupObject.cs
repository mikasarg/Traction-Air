using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir
{
    public class PressureGroupObject
    {
        public string Description { get; set; }

        public int LoadedOnRoad { get; set; }

        public int LoadedOffRoad { get; set; }

        public int UnloadedOnRoad { get; set; }

        public int MaxTraction { get; set; }

        public DateTime DateMod { get; set; }

        public int Id { get; set; }
    }
}
