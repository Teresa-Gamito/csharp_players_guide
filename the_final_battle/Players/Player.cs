namespace FinalBattle.Players;

using FinalBattle.Actions;
using FinalBattle.Characters;
using FinalBattle.Parties;

public interface IPlayer
{
    public string GetPlayerName();

    public IAction ChooseAction(Character character);
    public Character ChooseCharacter(Party party);
}

public class PlayerAI : IPlayer
{
    public string GetPlayerName()
    {
        return "AI";
    }

    public IAction ChooseAction(Character character)
    {
        Thread.Sleep(100);
        return new AttackAction();
    }

    public Character ChooseCharacter(Party party)
    {
        return party.Characters[0];
    }
}
