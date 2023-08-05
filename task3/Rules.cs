namespace task3;
public class Rules
{
    private readonly int _numMoves;
    public Rules(List<Move> moves)
    {
        _numMoves = moves.Count;
    }

    public string DetermineWinner(int userMoveIndex, int computerMoveIndex, string winner, string loser)
    {
        int halfNumMoves = _numMoves / 2;
        int distance = (computerMoveIndex - userMoveIndex + _numMoves) % _numMoves;
        return distance == 0 ? "Draw" : distance > halfNumMoves ? winner : loser;
    }
}