using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class GameState
    {
        private readonly Dictionary<Cell, State> _states;

        public GameState(Dictionary<Cell, State> states)
        {
            _states = new Dictionary<Cell, State>(states);
        }

        public State GetState(Cell cell)
        {
            State result;
            _states.TryGetValue(cell, out result);
            return result;
        }
    }
}
