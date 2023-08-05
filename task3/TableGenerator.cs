using Spectre.Console;

namespace task3;

public class TableGenerator
{
    public void GenerateTable(List<Move> moves, Rules rules)
    {
        var table = new Table();
        GenerateCols(table, moves);
        GenerateRows(table, moves, rules);
        AnsiConsole.Write(table);
    }

    private void GenerateCols(Table table, List<Move> moves)
    {
        table.AddColumn("[green]PC[/]\\[blue]Player[/]");
        foreach (var move in moves)
        {
            table.AddColumn($"[blue]{move.Name}[/]");
        }
    }

    private void GenerateRows(Table table, List<Move> moves, Rules rules)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            var row = table.AddRow($"[green]{moves[i].Name}[/]");
            for (int j = 0; j < moves.Count; j++)
            {
                row.UpdateCell(i, j + 1, rules.DetermineWinner(j, i, "Win", "Lose"));
            }
        }
    }
}