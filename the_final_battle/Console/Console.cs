namespace FinalBattle.GameConsole;

using System.Text;
using FinalBattle.Battle;

public static class GameConsole
{
    public static void DisplayBattleStatus(Battle battle)
    {
        
    }

    private void PrintSpacing(string title, char character)
    {
        int width = 100;
        width -= title.Length - 2;

        StringBuilder builder = new StringBuilder();
    }
}
