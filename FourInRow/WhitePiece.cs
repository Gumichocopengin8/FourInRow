using System;

namespace FourInRow {
  [Serializable]
  public class WhitePiece : BasePiece {
    public override string Name => "white";

    public override string PieceColor => "o";
  }
}