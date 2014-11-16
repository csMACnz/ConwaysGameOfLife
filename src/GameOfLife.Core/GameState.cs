using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class GameState
    {
        private readonly Dictionary<Cell, State> _states;

        public GameState(Dictionary<Cell, State> states)
        {
            _states = states;
        }

        public State GetState(Cell cell)
        {
            if (!_states.ContainsKey(cell))
            {
                return State.Dead;
            }
            return _states[cell];
        }
    }
}
