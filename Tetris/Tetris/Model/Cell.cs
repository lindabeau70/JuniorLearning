using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string CssClass { get; set; } // as filled by different colours (dif tetrominos diff colours)
                                             // needs own css class
        /// <summary>
        /// Cell constructor - no css details
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="column">column index</param>
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Cell constructor - with css details
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="column">column index</param>
        /// <param name="css">css class name</param>
        public Cell(int row, int column, string css)
        {
            Row = row;
            Column = column;
            CssClass = css;
        }
    }
}
