using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void CanConstruct()
        {
            var gameState = new GameState(new Dictionary<Cell, State>());

            Assert.IsNotNull(gameState);
        }

        [TestMethod]
        public void GivenAStateWith2Cells_WhenAskedForTheLiveCellsState_ThenReturnsAliveState()
        {
            var liveCell = new Cell();
            var deadCell = new Cell();
            var gameState = new GameState(new Dictionary<Cell, State> {{liveCell, State.Alive}, {deadCell, State.Dead}});

            State actualLiveCellState = gameState.GetState(liveCell);

            Assert.AreEqual(State.Alive, actualLiveCellState);
        }

        [TestMethod]
        public void GivenAStateWith2Cells_WhenAskedForTheDeadCellsState_ThenReturnsDeadState()
        {
            var liveCell = new Cell();
            var deadCell = new Cell();
            var gameState = new GameState(new Dictionary<Cell, State> { { liveCell, State.Alive }, { deadCell, State.Dead } });

            State actualDeadCellState = gameState.GetState(deadCell);

            Assert.AreEqual(State.Dead, actualDeadCellState);
        }
    }
}
