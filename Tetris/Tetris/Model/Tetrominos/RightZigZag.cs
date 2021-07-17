using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    /// <summary>
    /// A right skewed zig-zag tetromino. Green in colour
    /// Centre cell is lower corner.  In starting orientation,
    /// of left-to-right has one to left, one above and one above and right
    ///   X X
    /// X[X]
    /// </summary>
    public class RightZigZag : Tetromino
    {
        public RightZigZag(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.RightZigZag;

        public override string CssClass => "tetris-green-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CentrePieceRow, CentrePieceColumn);       // Add centre piece cell

                // Check orientation and add other cells accordingly
                if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);       // Add cell to left
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);       // Add cell above
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn + 1);   // Add cell above and to right
                }
                else if (Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);       // Add cell to right
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);       // Add cell below
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn - 1);   // Add cell below and to left
                }
                else if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);       // Add cell above
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);       // Add cell to right
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn + 1);   // Add cell to right and below
                }
                else // Downup
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);       // Add cell to left
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn - 1);   // Add cell to left and above
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);       // Add cell below
                }
                return cells;
            }
        }
    }
}
