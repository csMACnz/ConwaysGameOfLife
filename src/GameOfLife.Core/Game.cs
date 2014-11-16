using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class Game
    {
        private readonly WrappingSquareWorld _world;
        private GameState _state;

        public Game(WrappingSquareWorld world, GameState initialState)
        {
            _world = world;
            _state = initialState;
        }

        public void Tick()
        {
            _state = GetNextState(_world, _state);
        }

        public static GameState GetNextState(WrappingSquareWorld world, GameState state)
        {
            var transformer = new DefaultRulesStateTransformer();
            var inProgressState = new Dictionary<Cell, State>();
            foreach (var cell in world.WorldCells)
            {
                var currentState = state.GetState(cell);
                var neighbours = world.GetNeighbours(cell);
                var neighbourState = neighbours.Select(state.GetState);
                var nextState = transformer.GetNextState(currentState, neighbourState);
                inProgressState[cell] = nextState;
            }
            return new GameState(inProgressState);
        }
    }
}
