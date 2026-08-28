namespace FinalBattle.Parties;
    
using FinalBattle.Characters;
using FinalBattle.Players;
using FinalBattle.Items;

public class Party
{
    public IPlayer Player { get; set; }
    public List<Character> Characters { get; set; }
    public List<IItem> Items { get; set; } = new List<IItem>();

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
