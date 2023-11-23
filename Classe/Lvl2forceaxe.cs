using System;

namespace ProjetNarratif.Classe
{
    internal class Lvl2forceaxe : Room
    {
        internal static bool isKeyCollected;
        int action = new Random().Next(3);
        internal override string CreateDescription() =>
@$"Après avoir vaincu le Minotaur, un dragon descend du ciel. Vous pouvez [attaquer] ou [bloquer] vous avez {JeanLoup.hp} hp, {JeanLoup.damage} damage et {JeanLoup.block} block";
        Personnage Dragon = new Personnage(10, 2, 0, 0, 0);
        Personnage JeanLoup = new Personnage(30, 5, 0, 10, 0);
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "attaquer":
                        Dragon.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le minotaur pour {JeanLoup.damage} damage. Le Minotaur à {Dragon.hp} hp");
                    if (Dragon.hp == 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Minotaur");
                        Game.Transition<Lvl2forceaxe>();
                    }
                    JeanLoup.hp -= action * Dragon.damage;
                    if (JeanLoup.hp <= 0)
                    {
                        Console.WriteLine("Vous êtes mort");
                        Game.Finish();
                    }
                    else
                    {
                        Console.WriteLine($"Le minotaur vous frappe pour {action * Dragon.damage} vous avez {JeanLoup.hp}hp");
                    }
                    action = new Random().Next(3);
                    break;
                case "bloquer":
                    if (action * Dragon.damage <= JeanLoup.block)
                    {
                        Console.WriteLine("Vous avez bloquer les dégats du Minotaur.");
                    }
                    else
                    {
                        JeanLoup.hp -= action * Dragon.damage;
                        if (JeanLoup.hp <= 0)
                        {
                            Console.WriteLine("Vous êtes mort");
                            Game.Finish();
                        }
                        else
                        {
                            JeanLoup.hp -= action * Dragon.damage - JeanLoup.block;
                            Console.WriteLine($"Le minotaur vous frappe pour {action * Dragon.damage}, vous bloquez {JeanLoup.block}. Vous avez {JeanLoup.hp}hp");
                        }
                    }
                    action = new Random().Next(3);
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
