﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibs
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            
            int diceRoll = new Random().Next(1, 21);
            System.Threading.Thread.Sleep(30);
            if (diceRoll + attacker.CalcHitBonus() >= defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name,
                    defender.Name,
                    damageDealt);

                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
