using ProjetNarratif;
using ProjetNarratif.Classe;

var game = new Game();
game.Add(new ChoixChemin());
game.Add(new Lvl1());
game.Add(new Lvl2());
game.Add(new Champion());
game.Add(new Reward());
game.Add(new Devinette());

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