using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Classe
{
    internal class Devinette : Room
    {
        public static int x = 0;
        internal override string CreateDescription() =>
@"Dans votre sommeil, vous rencontré un ange.
Celui-ci vous pose une devinette:
Je suis grand quand je suis jeune et petit quand je suis vieux, qui suis-je?";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bougie":
                    Console.WriteLine("Bonne réponse");
                    Game.Finish();
                    break;
                default:
                    Console.WriteLine("Mauvaise réponse.");
                    x++;
                    if (x == 1) Console.WriteLine("Feu");
                    if (x == 2) Console.WriteLine("Lumière");
                    if (x == 3)
                    {
                        Console.WriteLine("Vous avez eu 3 mauvaises réponse.");
                        Game.Finish();
                    }
                    break;
            }
        }
    }
}
