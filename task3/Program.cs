namespace task3;

public class Program
{
    
    private void IsArgumentsValid(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0 || args.Distinct().Count() < args.Length)
        {
            Console.WriteLine("Incorrect arguments. There should be greater than 2, odd number of unique arguments. Example: Rock Paper Scissors");
            Environment.Exit(1);
        }
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        program.IsArgumentsValid(args);
        Game game = new Game(args);
        game.StartGame();
    }
}