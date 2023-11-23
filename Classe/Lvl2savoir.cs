namespace ProjetNarratif.Classe
{
    internal class Lvl2savoir : Room
    {
        public Personnage Brandon = new Personnage(10, 0, 2, 5, 0);
        public Personnage Mage = new Personnage(20, 0, 4, 0, 0);
        int action = new Random().Next(3);
        internal override string CreateDescription() =>
@$"Vous avancé dans la ruine, un mage se trouve devant vous.
Vous pouvez [attaquer] ou [bloquer] vous avez {Brandon.hp} hp, {Brandon.damage} block et {Brandon.block} block. Le minotaur va vous attaquer pour {action * Mage.damage}";
        internal static bool faux = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "attaquer":
                    Mage.hp -= Brandon.damage;
                    Console.WriteLine($"Vous frapper le minotaur pour {Brandon.damage} damage. Le Minotaur à {Mage.hp} hp");
                    if (Mage.hp <= 0)
                    {
                        Console.WriteLine("Vous avez vaincu le Minotaur");
                        Game.Transition<Lvl2forceaxe>();
                    }
                    Brandon.hp -= action * Mage.damage;
                    if (Brandon.hp <= 0)
                    {
                        Console.WriteLine("Vous êtes mort");
                        Game.Finish();
                    }
                    else
                    {
                        Console.WriteLine($"Le minotaur vous frappe pour {action * Mage.damage} vous avez {Brandon.hp}hp");
                    }
                    action = new Random().Next(3);
                    break;
                case "bloquer":
                    if (action * Mage.damage <= Brandon.block)
                    {
                        Console.WriteLine("Vous avez bloquer les dégats du Minotaur.");
                    }
                    else
                    {
                        Brandon.hp -= action * Mage.damage - Brandon.block;
                        if (Brandon.hp <= 0)
                        {
                            Console.WriteLine("Vous êtes mort");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine($"Le minotaur vous frappe pour {action * Mage.damage}, vous bloquez {Brandon.block}. Vous avez {Brandon.hp}hp");
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
