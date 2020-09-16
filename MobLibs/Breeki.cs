using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibs;

namespace MobLibs
{
    public class Breeki : Monster
    {
        public string CheekiHide { get; set; }

        public Breeki(string name, int life, int maxLife, int hitBonus, int block,
            int minDamage, int maxDamage, string description,
            string cheekiHide)
            : base(name, life, maxLife, hitBonus, block, minDamage, maxDamage, description)
        {
            CheekiHide = cheekiHide;

            if (Life <= 7)
            {
                Block += 10;
                MaxLife += 10;
            }
        }


        public override string ToString()
        {
            return string.Format("{0}\nBreeki got Cheeki: {1}",
                base.ToString(),
                CheekiHide);
        }
    }
}
