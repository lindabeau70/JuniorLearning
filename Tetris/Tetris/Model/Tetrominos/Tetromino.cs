using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Tetrominos
{
    public enum TetrominoStyle
    {
        Straight,
        Block,
        TShaped,
        LeftZigZag,
        RightZigZag,
        LShaped,
        ReverseLShaped,
        NumberOfTetrominoStyles
    }

    /// <summary>
    /// Orientation of Tetromino: left-to-right,
    /// up-to-down,right-to-left, down-to-up, 
    /// Starts as left-to-right and as rotated clockwise
    /// progresses through enum options in order listed
    /// </summary>
    public enum TetrominoOrientation
    {
        LeftRight,
        UpDown,
        RightLeft,
        DownUp
    }

    public class Tetromino
    {
        // Create the grid as set for the tetromino
        public Grid Grid { get; set; }

        // Orientation of tetromino defined and intialised to left-to-right
        public TetrominoOrientation Orientation { get; set; }
            = TetrominoOrientation.LeftRight;

        // Define properties for x & y coordinates of centre piece 
        public int CentrePieceRow { get; set; }
        public int CentrePieceColumn { get; set; }

        // Property to hold style of tetromino
        public virtual TetrominoStyle Style { get; }

        // Property to hold css class for this teromino - depends on style
        public virtual string CssClass { get; }

        // Cells currently occupied by this tetromino - depends on style
        public virtual CellCollection CoveredCells { get; }

        /// <summary>
        /// Base constructor for tetromino
        /// </summary>
        /// <param name="grid"><see cref="Grid"/> as defined for game</param>
        public Tetromino(Grid grid)
        {
            Grid = grid;
            CentrePieceRow = grid.Height;           // starts at top of grid
            CentrePieceColumn = grid.Width / 2;     // starts in middle column (x coord) of grid 
        }

        /// <summary>
        /// Checks if tetromino has space to move left
        /// </summary>
        /// <returns>True if space to move, false if blocked</returns>
        public bool CanMoveLeft()
        {
            // Check if any of the tetromino covered spaces is in the leftmost column
            // i.e. piece cannot move left
            if (CoveredCells.HasColumn(1))
                return false;

            // Check cells left of current leftmost cells in this tetromino to see if occupied
            foreach (var cell in CoveredCells.GetLeftmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column - 1))  // if Grid contains something to the left...
                    return false;
            }

            // Otherwise all good to the left
            return true;
        }

        /// <summary>
        /// Checks if tetromino has space to move right
        /// </summary>
        /// <returns>True if space to move, false if blocked</returns>
        public bool CanMoveRight()
        {
            // Check if any of the tetromino covered spaces are in the rightmost column
            if (CoveredCells.HasColumn(Grid.Width))
                return false;

            // Check cells to the right of current rightmost cells in this tetromino to see if occupied
            foreach (var cell in CoveredCells.GetRightmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column + 1))
                    return false;
            }

            // Otherwise all good to the right
            return true;
        }

        /// <summary>
        /// Method to move tetromino left (if able)
        /// </summary>
        public void MoveLeft()
        {
            if (CanMoveLeft())
                CentrePieceColumn--;  // if can't move left - do nothing
        }

        /// <summary>
        /// Method to move tetromino right (if able)
        /// </summary>
        public void MoveRight()
        {
            if (CanMoveRight())
                CentrePieceColumn++;
        }

        /// <summary>
        /// Checks if space below for tetromino to move down
        /// </summary>
        /// <returns>true if space to move down, false if blocked or at base of grid</returns>
        public bool CanMoveDown()
        {
            // Check if any of the tetromino cells are in lowest row of grid
            if (CoveredCells.HasRow(1))
                return false;

            // Check if any grid cells directly below lowest cells in the tetromino are occupied
            foreach (var cell in CoveredCells.GetLowest())
            {
                if (Grid.Cells.Contains(cell.Row - 1, cell.Column))
                    return false;
            }

            // Otherwise all good to move down
            return true;
        }

        /// <summary>
        /// Moves the tetromino down a space (if able)
        /// </summary>
        public void MoveDown()
        {
            if (CanMoveDown())
                CentrePieceRow--;
        }

        /// <summary>
        /// Makes the tetromino drop all the way
        /// </summary>
        /// <returns>The score for the number of rows hard dropped through</returns>
        public int Drop()
        {
            int scoreCounter = 0;
            while (CanMoveDown())
            {
                MoveDown();
                scoreCounter++;
            }
            return scoreCounter;
        }

        /// <summary>
        /// Returns whether the tetromino has any options to move
        /// </summary>
        /// <returns>true if can move in any of the three directions</returns>
        public bool CanMove()
        {
            return CanMoveDown() || CanMoveLeft() || CanMoveRight();
        }

        /// <summary>
        /// Rotate the tetromino clockwise around the centre piece
        /// </summary>
        public void Rotate()
        {
            // Use enum integer equivalent to move to next TetromionOrientation in the enum list
            // Wrapping back to start from end - % 4
            Orientation = (TetrominoOrientation)(((int)Orientation + 1) % 4);

            // Get the CoveredCells from the child implementation for the new orientation
            var coveredSpaces = CoveredCells;

            // Check for tetromino now occupying columns outside of the grid space
            // Checking most extreme outside columns first 
            if (coveredSpaces.HasColumn(-1))
                CentrePieceColumn += 2;
            else if (coveredSpaces.HasColumn(0))
                CentrePieceColumn++;
            else if (coveredSpaces.HasColumn(12))
                CentrePieceColumn -= 2;
            else if (coveredSpaces.HasColumn(11))
                CentrePieceColumn--;
        }

    }
}
