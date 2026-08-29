namespace FinalBattle.Battle;

using FinalBattle.Parties;
using FinalBattle.Players;
using FinalBattle.Actions;
using FinalBattle.Characters;
using FinalBattle.GameConsole;
using FinalBattle.Items;
using FinalBattle.Gear;

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
            Console.WriteLine("It is " + character + "'s turn...\n");
            GameConsole.DisplayBattleStatus(this, character);

            IPlayer player = ActiveParty.Player;

            IAction action = player.ChooseAction(character, this);

            action.Run(character, this);

            if (OpposingParty.IsDefeated)
            {
                Console.WriteLine("Monster party was defeated!");
                Console.WriteLine();
                EndBattle();
                if (ActiveParty == Heroes)
                {
                    ActiveParty.Loot(OpposingParty.Items);
                    ActiveParty.Loot(OpposingParty.UnequipedGear);
                }
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

    public Party GetCharacterParty(Character character)
    {
        return Heroes.Characters.Contains(character) ? Heroes : Monsters;
    }
    public Party GetOpposingParty(Character character)
    {
        return GetCharacterParty(character) == Heroes ? Monsters : Heroes;
    }
}
