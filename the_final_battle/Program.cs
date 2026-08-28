using FinalBattle.Battle;
using FinalBattle.Characters;
using FinalBattle.Parties;
using FinalBattle.Players;

Console.Clear();
Console.WriteLine("Final Battle!");
Console.WriteLine();

(IPlayer player1, IPlayer player2) = PlayerHuman.ChoosePlayers();

Party heroes = new Party(player1);
string name = heroes.Player.GetPlayerName();
heroes.Characters.Add(new TrueProgrammer(name));

List<Party> monsters = new List<Party>();
monsters.Add(new Party(player2, new Skeleton()));
monsters.Add(new Party(player2, new Skeleton(), new Skeleton()));
monsters.Add(new Party(player2, new UncodedOne()));

foreach (Party monsterParty in monsters)
{
    Battle battle = new Battle(heroes, monsterParty);
    battle.Run();
    if (heroes.IsDefeated) return;
}
