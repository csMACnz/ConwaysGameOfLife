using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class DefaultRulesStateTransformer
    {
        public State GetNextState(State currentState, IEnumerable<State> neighbours)
        {
            var liveNeighbourCount = GetLiveNeighbourCount(neighbours);
            if (currentState == State.Alive)
            {
                return GetNextStateForLiveCellFromLiveNeighbourCount(liveNeighbourCount);
            }
            return GetNextStateForDeadCellFromLiveNeighbourCount(liveNeighbourCount);
        }

        private State GetNextStateForLiveCellFromLiveNeighbourCount(int liveNeighbourCount)
        {
            if (liveNeighbourCount < 2 || liveNeighbourCount > 3)
            {
                return State.Dead;
            }
            return State.Alive;
        }

        private State GetNextStateForDeadCellFromLiveNeighbourCount(int liveNeighbourCount)
        {
            if (liveNeighbourCount == 3)
            {
                return State.Alive;
            }
            return State.Dead;
        }

        private int GetLiveNeighbourCount(IEnumerable<State> neighbours)
        {
            return neighbours.Count(s => s == State.Alive);
        }
    }
}
