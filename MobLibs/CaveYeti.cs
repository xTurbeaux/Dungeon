using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibs;

namespace MobLibs
{
    public class CaveYeti : Monster
    {
        public string YetiYell { get; set; }

        public CaveYeti(string name, int life, int maxLife, int hitBonus, int block,
            int minDamage, int maxDamage, string description,
            string yetiYell)
            : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            YetiYell = yetiYell;

            if (Life <= 5)
            {
                MinDamage += 10;
                MaxDamage += 10;
            }
        }


        public override string ToString()
        {
            return string.Format("{0}\nYeti Yell: {1}",
                base.ToString(),
                YetiYell);
        }
    }
}
