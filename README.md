Vincent Chagnon
# ProjetNarratif

Ajout:


Classe Personnage:
	     class Personnage : Room
    {
        public int hp, damage, intelligence, block;
        public Personnage(int personnagehp, int personnagedamage, int personnageintelligence, int personnageblock)
        {
            this.hp = personnagehp;
            this.damage = personnagedamage;
            this.intelligence = personnageintelligence;
            this.block = personnageblock;
        }
        internal override string CreateDescription() =>
@"Voulez-vous prendre le chemin de la [force]";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "force":
                    //Game.Transition<Lvl1force>();
                    break;
                case "savoir":
                    //Game.Transition<Lvl1savoir>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }


Système de combat:
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