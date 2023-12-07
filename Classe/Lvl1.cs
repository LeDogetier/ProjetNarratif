using System;
using ProjetNarratif.Classe;


namespace ProjetNarratif.Classe
{
    internal class Lvl1 : Room
    { 
        Personnage Méchant = new Personnage(20, 4, 0, 0);
        Personnage JeanLoup = new Personnage(hp, 5, 0, 5);
        int action = new Random().Next(3);
        internal override string CreateDescription() =>
        @$"Vous arrivez dans une arène.
Le roi vous dit que vous devez combattre une série d'ennemies pour gagner votre liberté.
Il appel le premier.
Un Minotaur entre dand l'arène
Vous pouvez [a]ttaquer ou [b]loquer vous avez {JeanLoup.hp} hp, {JeanLoup.damage} attaque et {JeanLoup.block} block.
Le minotaur à {Méchant.hp}hp.
Le minotaur va vous attaquer pour {action * Méchant.damage}";

        internal static bool faux = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "a":
                    Méchant.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le minotaur pour {JeanLoup.damage} damage. Le Minotaur à {Méchant.hp} hp");
                    if (Méchant.hp <= 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Minotaur");
                        Game.Transition<Lvl2>();
                    }
                    JeanLoup.hp -= action * Méchant.damage;
                    if (JeanLoup.hp <= 0 && Méchant.hp > 0)
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
                case "b":
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
