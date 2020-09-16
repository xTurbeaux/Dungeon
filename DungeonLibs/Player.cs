using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibs
{
    public class Player : Character
    {
        public Origin CharacterOrigin { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int life, int maxLife, int block, int hitBonus,
                      Weapon equippedWeapon, Origin characterOrigin)
                     : base(name, life, maxLife, block, hitBonus)
        {
            EquippedWeapon = equippedWeapon;
            CharacterOrigin = characterOrigin;

            switch (CharacterOrigin)
            {
                case Origin.NewEngland:
                    MaxLife += 10;
                    Block += 1;
                    break;
                case Origin.DeepSouth:
                    HitBonus += 1;
                    Life += 10;
                    break;
                case Origin.Texans:
                    HitBonus += 5;
                    Block -= 5;
                    break;
                case Origin.BorderFolk:
                    EquippedWeapon.MaxDamage += 2;
                    EquippedWeapon.MinDamage += 2;
                    break;
                case Origin.CaliCrazies:
                    HitBonus += 10;
                    Block += 1;
                    break;
                case Origin.NorthernAlliance:
                    MaxLife += 5;
                    Life += 15;
                    break;
                case Origin.Midwesterners:
                    Life += 10;
                    HitBonus += 3;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("******{0}******\nLife: {1} of {2}\nHit Bonus: {3}\nWeapon: {4}\nBlock: {5}\nOrigin: {6}",
                Name,
                Life,
                MaxLife,
                CalcHitBonus(),
                EquippedWeapon,
                Block,
                CharacterOrigin);
        }

        public override int CalcHitBonus()
        {
            return HitBonus + EquippedWeapon.FragmentationChance;
        }

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }
    }
}
