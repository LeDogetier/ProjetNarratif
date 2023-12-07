using ProjetNarratif.Classe;
using System.Security.Cryptography.X509Certificates;

namespace ProjetNarratif.Classe
{
    internal class ChoixChemin : Room
    {
        public static int hp = 10;
        static bool clef = false;
        internal override string CreateDescription() =>
@"Vous vous réveillé.
Vous vous demandé ou vous êtes.
À votre droite, se trouve un [portrait].
A votre gauche, se trouve un [lit].
Devant vous se trouve un [porte] barré.";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "porte":
                    if (clef == true)
                    {
                        Game.Transition<Lvl1>();
                    }
                    else
                    {
                        Console.WriteLine("La porte est barrée");
                    }
                    break;
                case "lit":
                    Console.WriteLine("Vous faites une sieste en espérant vous réveiller ailleur");
                    Console.WriteLine("Vous vous réveillé au même endroit");
                    break;
                case "portrait":
                    Console.WriteLine("Vous examiné le portrait.\n" +
                        "C'est un grand hommme.\n" +
                        "Il porte un casque gris\n" +
                        "Il porte une armure grise avec une cape rouge lacérée.\n" +
                        "Il emploi tridant illuminé d'une flamme sortie tout droit de l'enfers.\n" +
                        "Avec ses muscles ardent, il peut vous broiller le cranne à main nue.\n" +
                        "Vous pouvé regarder [derrière] le portrait ou continuer d'explorer la pièce.");
                    string p = Console.ReadLine();
                    if (p == "derrière")
                    {
                        clef = true;
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
