using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches.Attributes
{
    public class Weapon
    {
        public int Speed { get; set; }
        public bool IsMelee { get; set; }
        public AttackType AttackType { get; set; }

        public Weapon(int speed, bool isMelee, AttackType attackType)
        {
            this.Speed = speed;
            this.IsMelee = isMelee;
            this.AttackType = setMelee(IsMelee);
        }
        public AttackType setMelee(bool isMelee)
        {
            if (isMelee == true)
            {
                return AttackType.Melee;
            }
            else
            {
                return AttackType.Ranged;
            }
        }
    }
}
