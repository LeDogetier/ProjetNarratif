using System;

namespace ProjetNarratif.Classe
{
    internal class Lvl1force : Room
    {
        public Personnage JeanLoup = new Personnage(20, 2, 0, 5, 0);
        Personnage Méchant = new Personnage(5, 4, 0, 0, 0);
        int action = new Random().Next(3);
        internal override string CreateDescription() =>
        @$"Vous arrivez dans une arène. Un minotaur vous attend au milieu. Vous pouvez [attaquer] ou [bloquer] vous avez {JeanLoup.hp} hp, {JeanLoup.damage} block et {JeanLoup.block} block. Le minotaur va vous attaquer pour {action * Méchant.damage}";

        internal static bool faux = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "attaquer":
                    Méchant.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le minotaur pour {JeanLoup.damage} damage. Le Minotaur à {Méchant.hp} hp");
                    if (Méchant.hp <= 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Minotaur");
                        Game.Transition<Reward>();
                    }
                    JeanLoup.hp -= action * Méchant.damage;
                    if (JeanLoup.hp <= 0)
                    {
                        Console.WriteLine("Vous êtes mort");
                        Game.Finish();
                    }
                    else
                    {
                        Console.WriteLine($"Le minotaur vous frappe pour {action * Méchant.damage} vous avez {JeanLoup.hp}hp");
                    }
                    action = new Random().Next(3);
                    break;
                case "bloquer":
                    if (action * Méchant.damage <= JeanLoup.block)
                    {
                        Console.WriteLine("Vous avez bloquer les dégats du Minotaur.");
                    }
                    else
                    {
                        JeanLoup.hp -= action * Méchant.damage - JeanLoup.block;
                        if (JeanLoup.hp <= 0)
                        {
                            Console.WriteLine("Vous êtes mort");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine($"Le minotaur vous frappe pour {action * Méchant.damage}, vous bloquez {JeanLoup.block}. Vous avez {JeanLoup.hp}hp");
                        }
                    }
                    action = new Random().Next(3);
                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    //Game.Transition<>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
