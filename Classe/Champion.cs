using System;
namespace ProjetNarratif.Classe
{
    internal class Champion : Room
    {
        internal static bool isKeyCollected;
        Personnage JeanLoup = new Personnage(30, 10, 0, 10);
        Personnage Bap = new Personnage(40, 10, 0, 0);
        //Armes Cool = new Armes();
        internal override string CreateDescription() =>
@$"
Après avoir vaincu le Dragon, le roi envoie le champion de l'arène
Vous pouvez [a]ttaquer ou [b]loquer vous avez {JeanLoup.hp} hp, {JeanLoup.damage} block et {JeanLoup.block} block.
Le minotaur à {Bap.hp}hp.
Le minotaur va vous attaquer pour {action * Bap.damage}";
        int action = new Random().Next(3);
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "a":
                    Bap.hp -= JeanLoup.damage;
                    Console.WriteLine($"Vous frapper le Champion pour {JeanLoup.damage} damage. Le Champion à {Bap.hp} hp");
                    if (Bap.hp <= 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Champion");
                        Game.Finish();
                    }
                    JeanLoup.hp -= action * Bap.damage;
                    if (JeanLoup.hp <= 0)
                    {
                        Console.WriteLine("Vous êtes mort");
                        Game.Finish();
                    }
                    else
                    {
                        Console.WriteLine($"Le Champion vous frappe pour {action * Bap.damage} vous avez {JeanLoup.hp}hp");
                    }
                    action = new Random().Next(3);
                    break;
                case "b":
                    if (action * Bap.damage <= JeanLoup.block)
                    {
                        Console.WriteLine("Vous avez bloquer les dégats du Champion.");
                    }
                    else
                    {
                        JeanLoup.hp -= action * Bap.damage - JeanLoup.block;
                        if (JeanLoup.hp <= 0)
                        {
                            Console.WriteLine("Vous êtes mort");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine($"Le Champion vous frappe pour {action * Bap.damage}, vous bloquez {JeanLoup.block}. Vous avez {JeanLoup.hp}hp");
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
