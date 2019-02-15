using System;

namespace FourInRow {
  [Serializable]
  public class BlackPiece : BasePiece {
    public override string Name => "black";

    public override string PieceColor => "@";
  }
}