namespace FinalBattle.Parties;
    
using FinalBattle.Characters;
using FinalBattle.Players;
using FinalBattle.Items;
using FinalBattle.Gear;

public class Party
{
    public IPlayer Player { get; }
    public List<Character> Characters { get; } = new List<Character>();
    public List<IItem> Items { get; } = new List<IItem>();
    public List<IGear> UnequipedGear { get; } = new List<IGear>();

    public Party(IPlayer player, params List<Character> characters)
    {
        Player = player;
        Characters = characters;
    }

    public bool IsDefeated
    {
        get
        {
            if (Characters.Count == 0) return true;
            foreach(Character character in Characters)
            {
                if (!character.IsDefeated) return false;
            }
            return true;
        }
    }
}
