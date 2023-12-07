using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Classe
{
     class Personnage : Room
    {
        public int hp, damage, intelligence, block;
        public Personnage(int personnagehp, int personnagedamage, int personnageintelligence, int personnageblock)
        {
            this.hp = personnagehp;
            this.damage = personnagedamage;
            this.intelligence = personnageintelligence;
            this.block = personnageblock;
        }
        internal override string CreateDescription() =>
@"Voulez-vous prendre le chemin de la [force]";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "force":
                    //Game.Transition<Lvl1force>();
                    break;
                case "savoir":
                    //Game.Transition<Lvl1savoir>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
    public class Armes
    {
        public int damage, block, bleed;
        public Armes(int statdamage, int statblock, int statbleed)
        {
            this.damage = statdamage;
            this.block = statblock;
            this.bleed = statbleed;
        }
    }
}
