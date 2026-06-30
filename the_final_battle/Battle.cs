using Entities;
using Entities.Characters;

public class Battle
{
    public List<Party> Parties { get; } = new();

    public Party FirstParty => Parties[0]; 
    public Character FirstCharacter => FirstParty.Members[0]; 

    public Character ActiveCharacter { get; set; }
    public Party ActiveParty
    {
        get
        {
            foreach (Party party in Parties)
            {
                if (party.Members.Contains(ActiveCharacter)) return party;
            }
            return FirstParty;
        }
    }

    public Character NextCharacter
    {
        get
        {
            if (ActiveCharacter == ActiveParty.Members.Last())
            {
                return NextParty.Members.First();
            }
            return ActiveParty.Members[ActiveParty.Members.IndexOf(ActiveCharacter) + 1];
        }
    }
    public Party NextParty
    {
        get
        {
            if (ActiveParty == Parties.Last())
            {
                return Parties.First();
            }
            return Parties[Parties.IndexOf(ActiveParty) + 1];

        }
    }

    public Battle(params Party[] parties)
    {
        foreach (Party party in parties)
        {
            Parties.Add(party);
        }
        ActiveCharacter = FirstCharacter;
    }

    public Party? RunTurn()
    {
        Display.Battle(this);

        ActiveCharacter.Battle(ActiveParty.Player, NextParty);
        if (NextParty.IsDefeated) return ActiveParty;

        ActiveCharacter = NextCharacter;

        return null;
    }

    public Party RunBattle()
    {
        while (true)
        {
            Party? winningParty = RunTurn();

            if (winningParty == null) continue;
            return winningParty;
        }
    }
}
