using System.Security.Cryptography.X509Certificates;

namespace ProjetNarratif.Classe
{
    internal class Reward : Room
    {
        internal override string CreateDescription() =>
@$"Comme récompense, vous avez le choix entre un [couteau], qui inflige 2 de bleed,
 Une [hache], qui double vos dégats
ou un [bouclier], qui ajoute 2 à votre bloque.";

        internal static bool faux = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "couteau":
                    bool couteau = true;
                    int x = 1;
                    break;
                case "hache":
                    Armes hache = new Armes(2, 0);
                    x = 2;
                    break;
                case "bouclier":
                    Armes bouclier = new Armes(0, 2);
                    x = 3;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
            Game.Transition<Lvl2forceaxe>();
        }
    }
}
