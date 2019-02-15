using System;

namespace FourInRow {
  internal class MainClass {
    public static void Main(string[] args) {
      Console.Write("Input the number of board length: ");
      var n = checkValidLength();
      var board = new Board(n);

      while(true) { // while not win
        if(PlayInput(board, "white", new WhitePiece())) {
          Console.WriteLine("White win!!");
          break;
        }

        if(PlayInput(board, "black", new BlackPiece())) {
          Console.WriteLine("Black win!!");
          break;
        }
      }
    }

    private static int checkValidLength() {
      var n = 0;
      do {
        n = int.Parse(Console.ReadLine());
        if(n < 4) {
          Console.WriteLine("length should be equal or more than 4");
          Console.Write("Input the number of board length: ");
        }
      } while(n < 4);

      return n;
    }
    
    private static bool PlayInput(Board board, string name, BasePiece piece) {
      Console.Write(name + " turn: ");
      var position = Console.ReadLine().Split(' ');
      var row = int.Parse(position[0]) - 1;
      var col = int.Parse(position[1]) - 1;
      if(board.GetBoard(row, col).Name == "empty") board.SetBoard(row, col, piece);
      board.Serialize();
      board.Print();
      var win = board.CheckBoard(board.GetBoard(row, col).PieceColor);
      return win;
    }
  }
}