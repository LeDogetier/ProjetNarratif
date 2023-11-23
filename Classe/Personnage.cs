using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Classe
{
    internal class Personnage
    {
        public int hp, damage, intelligence, block, bleed;
        public Personnage(int personnagehp, int personnagedamage, int personnageintelligence, int personnageblock, int personnagebleed)
        {
            this.hp = personnagehp;
            this.damage = personnagedamage;
            this.intelligence = personnageintelligence;
            this.block = personnageblock;
            this.bleed = personnagebleed;
        }
    }
    internal class Armes
    {
        public int damage, block;
        public Armes(int statdamage, int statblock)
        {
            this.damage = statdamage;
            this.block = statblock;
        }
    }
}
