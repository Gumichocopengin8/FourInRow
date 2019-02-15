using System;

namespace FourInRow {
 [Serializable]
  public abstract class BasePiece {
    public abstract string Name { get; }

    public abstract string PieceColor { get; }
  }
}