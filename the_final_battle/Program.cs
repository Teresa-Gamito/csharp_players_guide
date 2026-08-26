using FinalBattle.Battle;
using FinalBattle.Characters;
using FinalBattle.Parties;
using FinalBattle.Players;

IPlayer player1 = new PlayerAI();
IPlayer player2 = new PlayerAI();

Party heroes = new Party(player1);
string name = heroes.Player.GetPlayerName();
heroes.Characters.Add(new TrueProgrammer(name));

List<Party> monsters = new List<Party>
{ 
    new Party(player2),
    new Party(player2)
};

monsters[0].Characters.Add(new Skeleton());

monsters[1].Characters.Add(new Skeleton());
monsters[1].Characters.Add(new Skeleton());

Battle battle = new Battle(heroes, monsters);
battle.Run();
