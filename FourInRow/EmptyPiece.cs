using System;

namespace FourInRow {
  [Serializable]
  public class EmptyPiece : BasePiece {
    public override string Name => "empty";

    public override string PieceColor => ".";
  }
}