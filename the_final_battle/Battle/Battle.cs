namespace FinalBattle.Battle;

using FinalBattle.Parties;
using FinalBattle.Players;
using FinalBattle.Actions;
using FinalBattle.Characters;

public class Battle
{
    public Party Heroes { get; private set; }
    public Party Monsters { get; private set; }
    public Party ActiveParty { get; private set; }
    private Party OpposingParty => ActiveParty == Heroes ? Monsters : Heroes;

    public Battle(Party heroes, Party monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
        ActiveParty = Heroes;
    }

    public void Run()
    {
        while(RunRound());
    }

    private bool RunRound()
    {
        foreach (Character character in ActiveParty.Characters)
        {
            Console.WriteLine("It is " + character.Name + "'s turn...");

            IPlayer player = ActiveParty.Player;
            IAction action = player.ChooseAction(character);
            Character target = player.ChooseCharacter(OpposingParty);

            action.Run(character, target);

            if (target.IsDefeated) 
            {
                OpposingParty.Characters.Remove(target);
                Console.WriteLine(target.Name + " has been defeated!");
                Console.WriteLine();
            }
            if (OpposingParty.IsDefeated)
            {
                Console.WriteLine("Monster party was defeated!");
                Console.WriteLine();
                EndBattle();
                return false;
            }
            Console.WriteLine();
        }
        EndTurn();
        return true;
    }

    private void EndTurn() => ActiveParty = OpposingParty;

    private void EndBattle()
    {
        Console.WriteLine("The battle is over");
        if (Heroes.IsDefeated)
        {
            Console.WriteLine("The hero's party lost!");
            Console.WriteLine("The Uncoded One's forces have prevailed...");
        }
        else
        {
            Console.WriteLine("The hero's party won the battle!");
        }
        Console.WriteLine();
    }

    public void DisplayStatus()
    {

    }
}
