using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    /// <summary>
    /// A Left skewed zig-zag tetromino. Red in colour
    /// Centre cell is lower corner.  In starting orientation,
    /// of left-to-right has one to right, one above and one above and left
    /// X X 
    ///  [X]X
    /// </summary>
    public class LeftZigZag : Tetromino
    {
        public LeftZigZag(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.LeftZigZag;

        public override string CssClass => "tetris-red-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CentrePieceRow, CentrePieceColumn);       // Add centre piece cell
                // Check orientation and add other cells accordingly
                if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn - 1);   // Add cell above and to left
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                }
                else if (Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn + 1);   // Add cell below and to right
                }
                else if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn + 1);   // Add cell to right and above
                }
                else // Downup
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn - 1);   // Add cell to left and below
                }
                return cells;
            }
        }
    }
}
