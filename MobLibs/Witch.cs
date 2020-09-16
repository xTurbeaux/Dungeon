using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibs;

namespace MobLibs
{
    public class Witch : Monster
    {
        public string WitchCry { get; set; }

        public Witch(string name, int life, int maxLife, int hitBonus, int block,
            int minDamage, int maxDamage, string description,
            string witchCry)
            : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            WitchCry = witchCry;

            if (Life <= 10)
            {
                MinDamage += 10;
                MaxLife += 10;
            }
        }


        public override string ToString()
        {
            return string.Format("{0}\nCry of the Witch: {1}",
                base.ToString(),
                WitchCry);
        }
    }
}
