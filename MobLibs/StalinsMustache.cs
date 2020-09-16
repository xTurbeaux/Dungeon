using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibs;

namespace MobLibs
{
    public class StalinsMustache : Monster
    {
        public string BristleShield { get; set; }

        public StalinsMustache(string name, int life, int maxLife, int hitBonus, int block,
            int minDamage, int maxDamage, string description,
            string bristleShield)
            : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            BristleShield = bristleShield;

            if (Life <= 7)
            {
                Block += 15;
                MinDamage += 2;
            }
        }


        public override string ToString()
        {
            return string.Format("{0}\nThe manic stache thickens: {1}",
                base.ToString(),
                BristleShield);
        }
    }
}
