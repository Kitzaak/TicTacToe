// See https://aka.ms/new-console-template for more information

using TicTacToe;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, Tic Tac Toe World!");
        Console.WriteLine("Let's play a game!");
        var board = new Board();
        var game = new Engine();

        string? userInput;

        Console.Write(board.Show(game.Pieces()));

        while (!game.IsOver())
        {
            Console.Write($"{game.NextMark} please make a move.\n");
            Console.Write($"row col =>           ");
            Console.SetCursorPosition(Console.CursorLeft - 10, Console.CursorTop);
            userInput = Console.ReadLine();
            var coords = userInput.Split(' ');
            int row = Int16.Parse(coords[0]);
            int col = Int16.Parse(coords[1]);
            game.Move(row, col);  
            Console.SetCursorPosition(0, Console.CursorTop - 6);         
            Console.Write(board.Show(game.Pieces()));
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write($"Good job, {game.WhoWon()}!");
    }
}