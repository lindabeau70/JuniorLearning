using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    /// <summary>
    /// Define 3 game states
    /// ToDo: check if this is right spot
    /// </summary>
    public enum GameState
    {
        NotStarted,
        Playing,
        GameOver
    }

    public class Grid
    {
        public int Width { get; } = 10;
        public int Height { get; } = 20;
        public CellCollection Cells { get; set; } = new CellCollection();

        public GameState State { get; set; } = GameState.NotStarted;

        public bool IsStarted
        {
            get
            {
                return State == GameState.Playing || State == GameState.GameOver;
            }
        }
    }
}
