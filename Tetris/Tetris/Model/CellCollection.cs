using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    /// <summary>
    /// Will be used for both the Grid and for individual tetrominos
    /// Grid - only cells occupied are included in CellCollection
    /// Tetrominos - has the current cells for tetromino
    /// </summary>
    public class CellCollection
    {
        private readonly List<Cell> _cells = new List<Cell>();

        /// <summary>
        /// Checks if any occupied cells in given row
        /// </summary>
        /// <param name="row">index of row to be checked</param>
        /// <returns></returns>
        public bool HasRow(int row)
        {
            return _cells.Any(c => c.Row == row);
        }

        /// <summary>
        /// Checks if any occupied cells in given column
        /// </summary>
        /// <param name="column">index of column to be checked</param>
        /// <returns></returns>
        public bool HasColumn(int column)
        {
            return _cells.Any(c => c.Column == column);
        }

        /// <summary>
        /// Checks if cell at given coords is occupied
        /// </summary>
        /// <param name="row">Row coordinate</param>
        /// <param name="column">Column coordinate</param>
        /// <returns></returns>
        public bool Contains(int row, int column)
        {
            return _cells.Any(c => c.Row == row && c.Column == column);
        }

        /// <summary>
        /// To add a cell to the collection
        /// </summary>
        /// <param name="row">Row coordinate for cell</param>
        /// <param name="column">Column coordinate for cell</param>
        public void Add(int row, int column)
        {
            _cells.Add(new Cell(row, column));
        }

        /// <summary>
        /// Adds a collection of cells to this collection
        /// which is relevant for tetromino becoming stuck - part of grid
        /// </summary>
        /// <param name="cells">A <see cref="List<Cells>"/> to be added to the current collection</param>
        /// <param name="cssClass">The css class associated with added cells</param>
        public void AddMany(List<Cell> cells, string cssClass)
        {
            foreach(var cell in cells)
            {
                _cells.Add(new Cell(cell.Row, cell.Column, cssClass));
            }
        }

        /// <summary>
        /// To extract list of all occupied cells
        /// This is particularly relevant when adding tetromino to grid 
        /// - to extract tetromino cells for adding to grid
        /// </summary>
        /// <returns>List of Cells</returns>
        public List<Cell> GetAll()
        {
            return _cells;
        }

        /// <summary>
        /// Gets the CSS class of a cell
        /// </summary>
        /// <param name="row">Row index of cell</param>
        /// <param name="column">Column index of cell</param>
        /// <returns></returns>
        public string GetCssClass(int row, int column)
        {
            var matching = _cells.FirstOrDefault(x => (x.Row == row && x.Column == column));

            if (matching != null)
                return matching.CssClass;

            return "";
        }

        /// <summary>
        /// Reassigning css class on a row
        /// Relevant for making completed row "flash" prior to removal
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="cssClass">css class name</param>
        public void SetCssClass(int row, string cssClass)
        {
            _cells.Where(x => x.Row == row)
                .ToList()
                .ForEach(x => x.CssClass = cssClass);
        }

        public List<Cell> GetAllInRow(int row)
        {
            return _cells.Where(x => (x.Row == row)).ToList();
        }

        /// <summary>
        /// Remove 'passed' rows and move higher cells down to fill
        /// </summary>
        /// <param name="rows">List of rows to be removed</param>
        public void CollapseRows(List<int> rows)
        {
            // Get all cells in the completed rows
            var selectedCells = _cells.Where(x => rows.Contains(x.Row));

            // Add above cells to temp collection 
            List<Cell> toRemove = selectedCells.ToList<Cell>();
           

            // Remove all cells in the tempory collection from
            // the real collection
            _cells.RemoveAll(x => toRemove.Contains(x));

            // Collapse rows above complete rows by moving them down.
            foreach(var cell in _cells)
            {
                int numberOfLessRows = rows.Where(x => (x < cell.Row)).Count(); // original had <= but should never be equal so redundant I think
                cell.Row -= numberOfLessRows;
            }
        }

        /// <summary>
        /// Return list of rightmost cell for each row occupied in collection
        /// </summary>
        /// <returns><see cref="List{Cell}" /></returns>
        public List<Cell> GetRightmost()
        {
            List<Cell> cells = new List<Cell>();
            foreach (var cell in _cells)
            {
                if(!Contains(cell.Row, cell.Column + 1))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }

        /// <summary>
        /// Return list of leftmost cell for each row occupied in collection
        /// </summary>
        /// <returns><see cref="List<Cell>" /></returns>
        public List<Cell> GetLeftmost()
        {
            List<Cell> cells = new List<Cell>();
            foreach (var cell in _cells)
            {
                if (!Contains(cell.Row, cell.Column - 1))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }

        /// <summary>
        /// Return list of lowest cell for each column occupied in collection
        /// </summary>
        /// <returns><see cref="List<Cell>" /></returns>
        public List<Cell> GetLowest()
        {
            List<Cell> cells = new List<Cell>();
            foreach (var cell in _cells)
            {
                if (!Contains(cell.Row - 1, cell.Column))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }
    }
}
