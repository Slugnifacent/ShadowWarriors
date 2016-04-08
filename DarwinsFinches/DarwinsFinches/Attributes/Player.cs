using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches.Attributes
{
    public class Player
    {
        public int HP { get; set; }
        public int Speed { get; set; }
        public int MinMeleeDamage { get; set; }
        public int MaxMeleeDamage { get; set; }
        public int MinRangedDamage { get; set; }
        public int MaxRangedDamage { get; set; }
        public Weapons MeleeWeapon { get; set; }
        public Weapons RangedWeapon { get; set; }

        public Player(int hp, int speed, int minMeleeDamage, int maxMeleeDamage, int minRangedDamage, int maxRangedDamage, Weapons meleeWeapon, Weapons rangedWeapon)
        {
            this.HP = hp;
            this.Speed = speed;
            
            this.MeleeWeapon = meleeWeapon;
            this.RangedWeapon = rangedWeapon;
            this.ApplyMeleeDamage(meleeWeapon);
            this.ApplyRangedDamage(rangedWeapon);
        }
        //Sword,
        //Axe,
        //Mace,
        //Lightning,
        //Bow,
        //Fireball
        public void ApplyMeleeDamage(Weapons meleeWeapon)
        {
            switch (meleeWeapon)
            {
                case Weapons.Sword: //if enemy HP = 100, 3-5 hits
                    this.MinMeleeDamage = 20; //5 hits
                    this.MaxMeleeDamage = 35;// 3 hits
                    break;
                case Weapons.Axe: //if enemy HP = 100, 3-4 hits
                    this.MinMeleeDamage = 25; // 4 hits
                    this.MaxMeleeDamage = 35; // 3 hits
                    break;
                case Weapons.Mace: //if enemy HP = 100, 2-3 hits
                    this.MinMeleeDamage = 35; // 3 hits
                    this.MaxMeleeDamage = 50; // 2 hits
                    break;
            }
        }
        public void ApplyRangedDamage(Weapons rangedWeapon)
        {
            switch (rangedWeapon)
            {
                case Weapons.Lightning: //if enemy HP = 100, 3-5 hits
                    this.MinRangedDamage = 20;
                    this.MaxRangedDamage = 35;
                    break;
                case Weapons.Bow: //if enemy HP = 100, 3-4 hits
                    this.MinRangedDamage = 25;
                    this.MaxRangedDamage = 35;
                    break;
                case Weapons.Fireball: //if enemy HP = 100, 2-3 hits
                    this.MinRangedDamage = 35;
                    this.MaxRangedDamage = 50;
                    break;
            }
        }
        
    }
}
