using System;

namespace FourInRow {
  internal class MainClass {
    public static void Main(string[] args) {
      Console.Write("Input the number of board length: ");
      var n = int.Parse(Console.ReadLine());
      var board = new Board(n);

      while(true) { // while not win
        if(PlayInput("white", new WhitePiece())) {
          Console.WriteLine("White win!!");
          break;
        }

        if(PlayInput("black", new BlackPiece())) {
          Console.WriteLine("Black win!!");
          break;
        }
      }

      bool PlayInput(string name, Piece piece) {
        Console.Write(name + " turn: ");
        var position = Console.ReadLine().Split(' ');
        var row = int.Parse(position[0]);
        var col = int.Parse(position[1]);
        if(board.GetBoard(row, col).Name == "empty") board.SetBoard(row, col, piece);
        board.Print();
        var win = board.CheckBoard(board.GetBoard(row, col).PieceColor);
        return win;
      }
    }
  }
}