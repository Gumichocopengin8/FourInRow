using System;

namespace FourInRow {
  [Serializable]
  public class Board {
    private BasePiece[,] board;

    public Board() { // constructor
      board = new BasePiece[4, 4];
    }

    public Board(int len) { // constructor
      board = new BasePiece[len, len];
      for(var i = 0; i < len; i++)
        for(var j = 0; j < len; j++)
          board[i, j] = new EmptyPiece();
    }

    public BasePiece GetBoard(int row, int col) {
      return board[row, col];
    }

    public void SetBoard(int row, int col, BasePiece val) {
      board[row, col] = val;
    }

    private int GetBoardSize() {
      return board.GetLength(0);
    }

    public void Print() {
      var len = GetBoardSize();
      for(var i = 0; i < len; i++) {
        Console.Write(i + 1);
        for(var j = 0; j < len; j++) Console.Write(board[i, j].PieceColor);
          Console.WriteLine();
      }
    }

    public bool CheckBoard(string target) { // check win or not
      var len = GetBoardSize();
      for(var i = 0; i < len; i++) // horizontal check
        for(var j = 0; j < len - 3; j++)
          if(board[i, j].PieceColor == target && board[i, j + 1].PieceColor == target &&
             board[i, j + 2].PieceColor == target && board[i, j + 3].PieceColor == target)
            return true;

      for(var i = 0; i < len - 3; i++) // vertical check
        for(var j = 0; j < len; j++)
          if(board[i, j].PieceColor == target && board[i + 1, j].PieceColor == target &&
             board[i + 2, j].PieceColor == target && board[i + 3, j].PieceColor == target)
            return true;

      for(var i = 3; i < len; i++) // diagonal check, bottom left to top right
        for(var j = 0; j < len - 3; j++)
          if(board[i, j].PieceColor == target && board[i - 1, j + 1].PieceColor == target &&
             board[i - 2, j + 2].PieceColor == target && board[i - 3, j + 3].PieceColor == target)
            return true;

      for(var i = 3; i < len; i++) // diagonal check, bottom right to top left
        for(var j = 3; j < len; j++)
          if(board[i, j].PieceColor == target && board[i - 1, j - 1].PieceColor == target &&
             board[i - 2, j - 2].PieceColor == target && board[i - 3, j - 3].PieceColor == target)
            return true;
      return false;
    }
    
    public void Serialize() {      
      SaveLoad.Serialize(board);
    }

    public void Deserialize() {
      // try {
      //   var loadStream = new FileStream(saveFile, FileMode.Open);
      //   var deserializer = new SoapFormatter();
      //
      //   try {
      //     board = deserializer.Deserialize(loadStream) as BasePiece[,];
      //   } catch(SerializationException e) {
      //     Console.WriteLine(e.Message);
      //   }
      //   loadStream.Close();
      // } catch(FileNotFoundException e) {
      //   Console.WriteLine(e.Message);
      // }
      // SaveLoad.Deserialize(ref board);
    }
  }
}