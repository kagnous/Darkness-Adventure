using System;
using System.Collections.Generic;
using System.Windows;

namespace Darkness_Adventure
{
    public class Player
    {
        public string name;
        public int lifeMax;
        public int life;
        public string weaponName;
        public int weaponDamage;
        public int level;
        public int exp;
        public int nextLevel;
        public int gold;
        public int fragments;

        public List<Game.item> inventaire;

        public Player()
        {
            name = "sans nom";
            lifeMax = 20;
            life = lifeMax;
            inventaire = new List<Game.item>();
            gold = exp = level = fragments = 0;
            nextLevel = 100;
            weaponDamage = 1;
            weaponName = "Epée en fer";
        }

        public bool Damaged(int damage)
        {
            life -= damage;
            Console.WriteLine($"Vous subissez {damage} dégâts ({life}/{lifeMax}pv)");
            if (life <= 0)
            {
                Console.WriteLine("GAME OVER");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetExp(int exp_)
        {
            exp += exp_;
            if (level < 10 && exp >= nextLevel)
            {
                Console.WriteLine("NIVEAU SUPERIEUR !!!");
                exp = 0;
                level++;
                lifeMax += 5;
                life += 5;
                weaponDamage += 1;
                nextLevel = nextLevel * 2;
                if (level >= 10)
                {
                    nextLevel = 0;
                }
            }
        }

        public string DisplayInventaire()
        {
            string toDisplay = "Inventaire :\n";
            if (gold != 0)
            {
                toDisplay += $"{gold} pièces d'or\n";
            }
            if (inventaire.Count == 0)
            {
                toDisplay += $"Vide\n";
            }
            int nbPotion = 0;
            int nbCape = 0;
            for (int i = 0; i < inventaire.Count; i++)
            {
                switch (inventaire[i])
                {
                    case Game.item.cape:
                        nbCape++;
                        break;
                    case Game.item.health_potion:
                        nbPotion++;
                        break;
                }
            }
            if (nbPotion > 0)
            {
                toDisplay += $"Potion x{nbPotion}\n";
            }
            if (nbCape > 0)
            {
                toDisplay += $"Cape de furtivité x{nbCape}\n";
            }
            return toDisplay;
        }

        public override string ToString()
        {
            string toDisplay = "";
            toDisplay += $"\t{name} lv {level}\n{life}/{lifeMax} pv\t{exp}/{nextLevel} exp";
            toDisplay += $"\nArme : {weaponName} ({weaponDamage} dégâts)\nFragments solaires : {fragments}/3";
            return toDisplay;
        }
    }
}