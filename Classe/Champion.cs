using System;
namespace ProjetNarratif.Classe
{
    internal class Champion : Room
    {
        internal static bool isKeyCollected;
        Personnage JeanLoup = new Personnage(10, 2, 0, 0, 0);
        Personnage Bap = new Personnage(50, 10, 0, 20, 0);
        internal override string CreateDescription() =>
@$"Après avoir vaincu le Minotaur, un dragon descend du ciel. Vous pouvez [attaquer] ou [bloquer] vous avez {JeanLoup.hp} hp, {JeanLoup.damage} block et {JeanLoup.block} block";
        int action = new Random().Next(3);
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "attaquer":
                    Bap.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le minotaur pour {JeanLoup.damage} damage. Le Minotaur à {Bap.hp} hp");
                    if (Bap.hp == 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Minotaur");
                        Game.Transition<Lvl2forceaxe>();
                    }
                    Console.WriteLine($"Le Champion vous frappe pour {action * Bap.damage}. Vous avez {JeanLoup.hp - action * Bap.damage}hp");
                    break;
                case "bloquer":
                    Console.WriteLine("Le coffre s'ouvre et tu obiens une clé.");
                    isKeyCollected = true;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
