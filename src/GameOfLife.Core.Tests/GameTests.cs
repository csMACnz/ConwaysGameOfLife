using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GivenA5x5SquareWorldInitialisedWithHorizontalBlinker_WhenNextStateIsRequested_ThenVerticalBlinkerAppears()
        {
            // D D D D D
            // D D D D D
            // D A A A D
            // D D D D D
            // D D D D D
            var inputState = new [,]
            {
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Alive, State.Alive, State.Alive, State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
            };
            
            //Expected
            // D D D D D
            // D D A D D
            // D D A D D
            // D D A D D
            // D D D D D
            var expectedStates = new[,]
            {
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
            };
            
            SquareWorldInputOutputTest(inputState, expectedStates);
        }
        [TestMethod]
        public void GivenA5x5SquareWorldInitialisedWithVerticalBlinker_WhenNextStateIsRequested_ThenHorizontalBlinkerAppears()
        {
            // D D D D D
            // D D A D D
            // D D A D D
            // D D A D D
            // D D D D D
            var inputState = new[,]
            {
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
            };

            // D D D D D
            // D D D D D
            // D A A A D
            // D D D D D
            // D D D D D
            var expectedState = new[,]
            {
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Alive, State.Alive, State.Alive, State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
            };

            SquareWorldInputOutputTest(inputState, expectedState);
        }

        private static void SquareWorldInputOutputTest(State[,] inputStates, State[,] expectedStates)
        {
            var world = new WrappingSquareWorld(5, 5);

            var state = world.CreateState(inputStates);

            var nextState = Game.GetNextState(world, state);

            foreach (var row in Enumerable.Range(0, expectedStates.Rank))
            {
                foreach (var column in Enumerable.Range(0, expectedStates.GetLength(row)))
                {
                    var expectedState = expectedStates[row, column];

                    Assert.AreEqual(expectedState, nextState.GetState(world.GetCell(row, column)));
                }
            }
        }
    }
}
