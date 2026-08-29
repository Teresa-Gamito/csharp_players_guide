using FinalBattle.Battle;
using FinalBattle.Characters;
using FinalBattle.Items;
using FinalBattle.Parties;
using FinalBattle.Players;
using FinalBattle.Gear;

Console.Clear();
Console.WriteLine("Final Battle!");
Console.WriteLine();

(IPlayer player1, IPlayer player2) = PlayerHuman.ChoosePlayers();

// hero party
Party heroes = new Party(player1);

string name = heroes.Player.GetPlayerName();
heroes.Characters.Add(new TrueProgrammer(name));
heroes.Characters.Add(new VimFletcher());
heroes.Characters[0].EquipGear(new Sword());
heroes.Characters[1].EquipGear(new VimsBow());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());

List<Party> monsters = new List<Party>();
// monster party 1
monsters.Add(new Party(player2));
monsters[0].Characters.Add(new Skeleton());
monsters[0].Characters[0].EquipGear(new Dagger());
monsters[0].Items.Add(new HealthPotion());
// monster party 2
monsters.Add(new Party(player2));
monsters[1].Characters.Add(new Skeleton());
monsters[1].Characters.Add(new Skeleton());
monsters[1].UnequipedGear.Add(new Dagger());
monsters[1].UnequipedGear.Add(new Dagger());
monsters[1].Items.Add(new HealthPotion());
// monster party 3
monsters.Add(new Party(player2));
monsters[2].Characters.Add(new StoneAmarok());
monsters[2].Characters.Add(new StoneAmarok());
// monster party 4
monsters.Add(new Party(player2));
monsters[3].Characters.Add(new UncodedOne());
monsters[3].Items.Add(new HealthPotion());

Console.WriteLine();

foreach (Party monsterParty in monsters)
{
    Battle battle = new Battle(heroes, monsterParty);
    battle.Run();
    if (heroes.IsDefeated) return;
}
