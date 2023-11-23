using ProjetNarratif.Classe;

namespace ProjetNarratif.Classe
{
    internal class ChoixChemin : Room
    {
        internal override string CreateDescription() =>
@"Voulez-vous prendre le chemin de la [force] ou le chemin du [savoir]";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "force":
                    Game.Transition<Lvl1force>();
                    break;
                case "savoir":
                    Game.Transition<Lvl1savoir>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
