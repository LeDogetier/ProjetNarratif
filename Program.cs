using ProjetNarratif;
using ProjetNarratif.Classe;

var game = new Game();
game.Add(new ChoixChemin());
game.Add(new Lvl1force());
game.Add(new Lvl1savoir());
game.Add(new Lvl2forceaxe());
game.Add(new Lvl2savoir());
game.Add(new Reward());

while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.Clear();
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();