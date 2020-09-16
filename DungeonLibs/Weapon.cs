using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibs
{
    public class Weapon
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _fragmentationChance;
        private bool _isTwoHanded;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int FragmentationChance
        {
            get { return _fragmentationChance; }
            set { _fragmentationChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value < MaxDamage ? value : MaxDamage / 2;

            }
        }

        public Weapon(string name, int minDamage, int maxDamage, int fragmentationChance, bool isTwoHanded)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            FragmentationChance = fragmentationChance;
            IsTwoHanded = isTwoHanded;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1} to {2} damage\n Bonus hit: +{3}\n{4}",
                Name,
                MinDamage,
                MaxDamage,
                FragmentationChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }


    }
}
