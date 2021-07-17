using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    /// <summary>
    /// A T-Shaped tetromino. Purple in colour
    /// Centre cell is join of T.  In starting orientation,
    /// of left-to-right has one to left, one to right and one above
    ///   X
    /// X X X
    /// </summary>
    public class TShaped : Tetromino
    {
        public TShaped(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.TShaped;

        public override string CssClass => "tetris-purple-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CentrePieceRow, CentrePieceColumn);       // Add centre piece cell
                // Check orientation and add other cells accordingly
                if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                }
                else if (Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                }
                else if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                }
                else // Downup
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                }
                return cells;
            }
        }
    }
}
