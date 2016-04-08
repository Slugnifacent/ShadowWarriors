using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DarwinsFinches.Attributes;

namespace DarwinsFinches
{
    public class AverageStats
    {
        public int AvgHP { get; set; }
        public int AvgSpeed { get; set; }
        public int AvgDamage { get; set; }
        public string GreatestColor { get; set; }
        public AttackType GreatestAttackType { get; set; }
    }
}
