using System;
using ProjetNarratif.Classe;

namespace ProjetNarratif.Classe
{
    internal class Lvl2 : Room
    {
        Personnage Dragon = new Personnage(30, 5, 0, 0);
        Personnage JeanLoup = new Personnage(30, 8, 0, 0);
        int action = new Random().Next(3);
        internal override string CreateDescription() =>
@$"
Un Dragon descend du ciel et arrive dans l'arène
Vous pouvez [a]ttaquer ou [b]loquer vous avez {JeanLoup.hp} hp, {JeanLoup.damage} damage et {JeanLoup.block} block.
Le Dragon à {Dragon.hp}hp.
Le Dragon va vous attaquer pour {action * Dragon.damage}";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "a":
                        Dragon.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le dragon pour {JeanLoup.damage} damage. Le Dragon à {Dragon.hp} hp");
                    if (Dragon.hp <= 0)
                    {
                        Console.WriteLine("Vous avez vaincu le dragon");
                        Game.Transition<Champion>();
                    }
                    JeanLoup.hp -= action * Dragon.damage;
                    if (JeanLoup.hp <= 0 && Dragon.hp > 0)
                    {
                        Console.WriteLine("Vous êtes mort");
                        Game.Finish();
                    }
                    else if (Dragon.hp > 0)
                    {
                        Console.WriteLine($"Le dragon vous frappe pour {action * Dragon.damage} vous avez {JeanLoup.hp}hp");
                    }
                    action = new Random().Next(3);
                    break;
                case "b":
                    if (action * Dragon.damage <= JeanLoup.block)
                    {
                        Console.WriteLine("Vous avez bloquer les dégats du dragon.");
                    }
                    else
                    {
                        JeanLoup.hp -= action * Dragon.damage - JeanLoup.block;
                        if (JeanLoup.hp <= 0)
                        {
                            Console.WriteLine("Vous êtes mort");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine($"Le dragon vous frappe pour {action * Dragon.damage}, vous bloquez {JeanLoup.block}. Vous avez {JeanLoup.hp}hp");
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
