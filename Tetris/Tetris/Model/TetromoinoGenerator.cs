using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tetris.Model.Tetrominos;

namespace Tetris.Model
{
    public class TetromoinoGenerator
    {
        public TetrominoStyle Next(params TetrominoStyle[] unusableStyles)
        {
            //TODO - why so many blocks???  And two in a row.

            Random rand = new Random(DateTime.Now.Millisecond);

            TetrominoStyle[] allowableStyles = new TetrominoStyle[(int)TetrominoStyle.NumberOfTetrominoStyles-unusableStyles.Length];
            int index = 0;
            for(int i=0; i<(int)TetrominoStyle.NumberOfTetrominoStyles; i++)
            {
                if (!unusableStyles.Contains((TetrominoStyle)i))
                {
                    allowableStyles[index] = (TetrominoStyle)i;
                    index++;
                }
            }

            return allowableStyles[rand.Next(0, allowableStyles.Length)];

        }

        public Tetromino CreateFromStyle(TetrominoStyle style, Grid grid)
        {
            return style switch
            {
                TetrominoStyle.Block        => new Block(grid),
                TetrominoStyle.Straight     => new Straight(grid),
                TetrominoStyle.TShaped      => new TShaped(grid),
                TetrominoStyle.LeftZigZag   => new LeftZigZag(grid),
                TetrominoStyle.RightZigZag  => new RightZigZag(grid),
                TetrominoStyle.LShaped      => new LShaped(grid),
                TetrominoStyle.ReverseLShaped => new ReverseLShaped(grid),
                _                           => new Block(grid)
            };
        }
    }
}
