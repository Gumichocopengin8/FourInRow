using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace FourInRow {
  internal class MainClass {
    private const string saveFile = "../../FourInRow.xml";

    public static void Main(string[] args) {
      Board board = null;
      Console.Write("Do you want to resume an old game? (Y/N): ");
      var input = Console.ReadLine();
      if(input[0] == 'y' || input[0] == 'Y') 
        Deserialize(ref board);

      if(board == null) {
        Console.Write("Input the number of board length: ");
        var n = checkValidLength();
        board = new Board(n);
      }

      while(true) { // while not win
        if(PlayInput(board, "white", new WhitePiece())) {
          Console.WriteLine("White win!!");
          break;
        }

        if(PlayInput(board, "black", new BlackPiece())) {
          Console.WriteLine("Black win!!");
          break;
        }

        if(save(board)) break;
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
      board.Print();
      var win = board.CheckBoard(board.GetBoard(row, col).PieceColor);
      return win;
    }

    private static bool save(Board board) {
      Console.Write("Do you wanna save? (Y/N):");
      var input = Console.ReadLine();
      if(input[0] == 'y' || input[0] == 'Y') {
        Serialize(board);
        return true;
      }

      return false;
    }

    private static void Serialize(Board board) {
      Stream saveStream = File.Create(saveFile);
      var formatter = new SoapFormatter();

      try {
        formatter.Serialize(saveStream, board);
      } catch(SerializationException e) {
        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        throw;
      } finally {
        saveStream.Close();
      }
    }

    private static void Deserialize(ref Board board) {
      try {
        var loadStream = new FileStream(saveFile, FileMode.Open);
        var deserializer = new SoapFormatter();

        try {
          board = (Board) deserializer.Deserialize(loadStream);
          board.Print();
        } catch(SerializationException e) {
          Console.WriteLine(e.Message);
        }
        loadStream.Close();
      } catch(FileNotFoundException e) {
        Console.WriteLine(e.Message);
      }
    }
  }
}