using Entities.Actions;
using Entities.Actions.Attacks;
using Players;

namespace Entities.Characters
{

public abstract class Character
{
    public string Name { get; }

    public abstract int MaxHP { get; }
    public int HP { get; set; }

    public List<CharacterAction> Actions { get; } = new();

    public Character(string name)
    {
        Name = name;
        HP = MaxHP;
        Actions.Add(new DoNothingAction());
    }

    public void Act(CharacterAction action, Character target)
    {
        action.Execute(this, target);
    }

    public void DisplayActions()
    {
        int i = 0;
        foreach (CharacterAction action in Actions)
        {
            Console.WriteLine($"{i} - {action.Name}");
            i++;
        }
    }

    public void Battle(Player player, Party enemyParty)
    {
        enemyParty.DisplayMembers();
        Character target = player.Choose(enemyParty.Members);
        DisplayActions();
        CharacterAction action = player.Choose(Actions);

        Act(action, target);
        if (target.HP <= 0) 
        {
            Console.WriteLine();
            Console.WriteLine($"{target.Name} has been defeated!");
            Console.WriteLine();
            enemyParty.Members.Remove(target);
        }
    }

    public List<Attack> GetAttacks()
    {
        List<Attack> attacks = new();
        foreach (Attack attack in Actions)
        {
            attacks.Add(attack);
        }
        return attacks;
    }
}

}
