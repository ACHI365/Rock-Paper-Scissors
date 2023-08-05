namespace task3
{
    public class Game
    {
        private readonly List<Move> _moves;
        private readonly Rules _rules;
        private readonly HmacGenerator _hmacGenerator;
        private readonly TableGenerator _tableGenerator;
        private readonly DisplaySettings _displaySettings;

        public Game(string[] moveNames)
        {
            _moves = moveNames.Select((name, index) => new Move(name, index + 1)).ToList();
            _rules = new Rules(_moves);
            _hmacGenerator = new HmacGenerator();
            _tableGenerator = new TableGenerator();
            _displaySettings = new DisplaySettings();
        }

        public void StartGame()
        {
            bool validInput = true;
            string input;
            do
            {
                input = CoreLoop(ref validInput);
            } while (!input.Equals("0"));
        }

        private String CoreLoop(ref bool validInput)
        {
            var computerMove = GenerateComputerMove();
            if (validInput)
            {
                _hmacGenerator.GenerateNewKey();
                _displaySettings.DisplayMenu(computerMove, _hmacGenerator, _moves);
                validInput = false;
            }
            return ReadMove(ref validInput, computerMove);
        }

        private Move GenerateComputerMove()
        {
            int computerMoveIndex = new Random().Next(1, _moves.Count + 1);
            return _moves[computerMoveIndex - 1];
        }

        private string ReadMove(ref bool validInput, Move computerMove)
        {
            Console.Write("Enter your move: ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;
            return DetermineOutcome(input, ref validInput, computerMove);
        }

        private String DetermineOutcome(string input, ref bool validInput, Move computerMove)
        {
            if (input == "?")
            {
                ShowTable(ref validInput);
            }
            else
            {
                ProcessInput(input, ref validInput, computerMove);
            }

            return input;
        }

        private void ShowTable(ref bool validInput)
        {
            _tableGenerator.GenerateTable(_moves, _rules);
            validInput = false;
        }

        private void ProcessInput(string input, ref bool validInput, Move computerMove)
        {
            if (int.TryParse(input, out var userMoveIndex) && userMoveIndex >= 1 && userMoveIndex <= _moves.Count)
            {
                PlayGame(userMoveIndex, computerMove);
                validInput = true;
            }
            else
            {
                Console.WriteLine(input.Equals("0") ? "Goodbye!" : "Invalid input. Try again.");
            }
        }

        private void PlayGame(int userMoveIndex, Move computerMove)
        {
            Move userMove = _moves[userMoveIndex - 1];
            _displaySettings.DisplayResults(userMove, computerMove, _rules, _hmacGenerator);
        }
    }
}