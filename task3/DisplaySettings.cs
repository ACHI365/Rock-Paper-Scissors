namespace task3;

public class DisplaySettings
{
    public void DisplayMenu(Move computerMove, HmacGenerator hmacGenerator, List<Move> moves)
    {
        Console.WriteLine($"HMAC: {hmacGenerator.GenerateHmac(computerMove.Name)}");
        DisplayMoves(moves);
        DisplayAdditionalOpts();
    }

    private void DisplayAdditionalOpts()
    {
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    private void DisplayMoves(List<Move> moves)
    {
        Console.WriteLine("Available moves:");
        foreach (var move in moves)
        {
            Console.WriteLine($"{move.Index} - {move.Name}");
        }
    }

    public void DisplayResults(Move userMove, Move computerMove, Rules rules, HmacGenerator hmacGenerator)
    {
        DisplaySelectedMoves(userMove, computerMove);
        DisplayWinner(userMove, computerMove, rules, hmacGenerator);
    }

    private string Winner(Move userMove, Move computerMove, Rules rules, HmacGenerator hmacGenerator)
    {
        return rules.DetermineWinner(userMove.Index, computerMove.Index, "You win!", "Computer wins!");
    }

    private void DisplayWinner(Move userMove, Move computerMove, Rules rules, HmacGenerator hmacGenerator)
    {
        Console.WriteLine(Winner(userMove, computerMove, rules, hmacGenerator));
        Console.WriteLine($"HMAC key: {hmacGenerator.GetKey()}");
        Console.WriteLine("----------------------------------------------------------------------------------");
    }

    private void DisplaySelectedMoves(Move userMove, Move computerMove)
    {
        Console.WriteLine($"Your move: {userMove.Name}");
        Console.WriteLine($"Computer move: {computerMove.Name}");
    }
}