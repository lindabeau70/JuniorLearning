using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    /// <summary>
    /// A square or block tetromino.  Yellow colour
    /// Cells do not rotate.  Define lower-left cell as centre cell.
    /// X X
    /// X X
    /// </summary>
    public class Block : Tetromino
    {
        public Block(Grid grid) : base(grid) {}

        public override TetrominoStyle Style => TetrominoStyle.Block;
        public override string CssClass => "tetris-yellow-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CentrePieceRow, CentrePieceColumn);  // Add centre piece as per location defined in base class
                cells.Add(CentrePieceRow, CentrePieceColumn + 1);  // Another to right of it
                cells.Add(CentrePieceRow + 1, CentrePieceColumn);  // One above
                cells.Add(CentrePieceRow + 1, CentrePieceColumn + 1); // Above and to right
                return cells;
            }
        }
    }
}
