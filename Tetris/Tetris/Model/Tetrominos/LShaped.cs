using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    /// <summary>
    /// A L-Shaped tetromino. Orange in colour
    /// Centre cell is corner cell.  In starting orientation,
    /// of left-to-right has two to left and one above
    ///     X
    /// X X X
    /// </summary>
    public class LShaped : Tetromino
    {
        public LShaped(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.LShaped;
        public override string CssClass => "tetris-orange-cell";

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
                    cells.Add(CentrePieceRow, CentrePieceColumn - 2);   // Add second cell to left
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                }
                else if (Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                    cells.Add(CentrePieceRow, CentrePieceColumn + 2);   // Add second cell to right
                }
                else if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow + 2, CentrePieceColumn);   // Add second cell above
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                }
                else // Downup
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow - 2, CentrePieceColumn);   // Add second cell below
                }
                return cells;
            }
        }
    }
}
