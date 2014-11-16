using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class DefaultRulesStateTransformerTests
    {
        private DefaultRulesStateTransformer _defaultRulesStateTransformer;

        [TestInitialize]
        public void Setup()
        {
            _defaultRulesStateTransformer = new DefaultRulesStateTransformer();
        }

        [TestMethod]
        public void GivenTheCurrentStateIsAlive_WhenThereAreZeroAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new[] {State.Dead});
            Assert.AreEqual(State.Dead, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsAlive_WhenThereIsOneAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new [] { State.Alive });
            Assert.AreEqual(State.Dead, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsAlive_WhenThereAreTwoAliveNeighbours_ThenNewStateIsAlive()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new[] { State.Alive, State.Alive });
            Assert.AreEqual(State.Alive, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsAlive_WhenThereAreThreeAliveNeighbours_ThenNewStateIsAlive()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new[] { State.Alive, State.Alive, State.Alive });
            Assert.AreEqual(State.Alive, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsAlive_WhenThereAreFourAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new[] { State.Alive, State.Alive, State.Alive, State.Alive });
            Assert.AreEqual(State.Dead, newState);
        }
        [TestMethod]
        public void GivenTheCurrentStateIsDead_WhenThereAreZeroAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Dead, new[] { State.Dead });
            Assert.AreEqual(State.Dead, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsDead_WhenThereIsOneAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Dead, new[] { State.Alive });
            Assert.AreEqual(State.Dead, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsDead_WhenThereAreTwoAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Dead, new[] { State.Alive, State.Alive });
            Assert.AreEqual(State.Dead, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsDead_WhenThereAreThreeAliveNeighbours_ThenNewStateIsAlive()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Alive, new[] { State.Alive, State.Alive, State.Alive });
            Assert.AreEqual(State.Alive, newState);
        }

        [TestMethod]
        public void GivenTheCurrentStateIsDead_WhenThereAreFourAliveNeighbours_ThenNewStateIsDead()
        {
            var newState = _defaultRulesStateTransformer.GetNextState(State.Dead, new[] { State.Alive, State.Alive, State.Alive, State.Alive });
            Assert.AreEqual(State.Dead, newState);
        }
    }
}
