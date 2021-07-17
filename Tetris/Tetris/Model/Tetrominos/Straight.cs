using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A straight-line tetromino. Light blue colour
/// Define centre cell as third from left in left-to-right position
/// X X X X
/// </summary>
namespace Tetris.Model.Tetrominos
{
    public class Straight : Tetromino
    {
        public Straight(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.Straight;
        public override string CssClass => "tetris-lightblue-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CentrePieceRow, CentrePieceColumn);       // Add centre piece
                // Check orientation and add other cells accordingly
                if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow, CentrePieceColumn - 2);   // Add second cell to left
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                }
                else if (Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CentrePieceRow, CentrePieceColumn - 1);   // Add cell to left
                    cells.Add(CentrePieceRow, CentrePieceColumn + 1);   // Add cell to right
                    cells.Add(CentrePieceRow, CentrePieceColumn + 2);   // Add second cell to right
                }
                else if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow + 2, CentrePieceColumn);   // Add second cell above
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                }
                else // Downup
                {
                    cells.Add(CentrePieceRow + 1, CentrePieceColumn);   // Add cell above
                    cells.Add(CentrePieceRow - 1, CentrePieceColumn);   // Add cell below
                    cells.Add(CentrePieceRow - 2, CentrePieceColumn);   // Add second cell below
                }
                return cells;
            }
        }
    }
}
