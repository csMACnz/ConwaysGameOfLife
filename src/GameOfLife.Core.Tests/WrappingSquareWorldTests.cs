using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class WrappingSquareWorldTests
    {
        [TestMethod]
        public void GivenAThreeByThreeWorldIsRequired_WhenAThreeByThreeWorldIsConstructed_ThenSucceeds()
        {
            var world = new WrappingSquareWorld(3, 3);
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void GivenAThreeByThreeWorld_WhenWorldCellsAreRetrieved_ThenNineAreReturned()
        {
            var world = new WrappingSquareWorld(3, 3);
            var cells = world.WorldCells;
            Assert.AreEqual(9, cells.Count());
        }

        [TestMethod]
        public void GivenAThreeByThreeWorld_WhenEachCellAsksForSiblings_ThenEightSiblingsReturned()
        {
            var world = new WrappingSquareWorld(3, 3);
            foreach (var cell in world.WorldCells)
            {
                var siblings = world.GetNeighbours(cell);
                Assert.AreEqual(8, siblings.Count());
            }
        }

        [TestMethod]
        public void GivenAThreeByThreeWorld_WhenEachCellAsksForSiblings_ThenItselfIsNotReturned()
        {
            var world = new WrappingSquareWorld(3, 3);
            foreach (var cell in world.WorldCells)
            {
                var siblings = world.GetNeighbours(cell).ToList();
                CollectionAssert.DoesNotContain(siblings, cell);
            }
        }

        [TestMethod]
        public void GivenAThreeByThreeWorld_WhenEachCellAsksForSiblings_ThenEachSiblingIsUnique()
        {
            var world = new WrappingSquareWorld(3, 3);
            foreach (var cell in world.WorldCells)
            {
                var neighbours = world.GetNeighbours(cell).ToList();
                Assert.AreEqual(neighbours.Count(), neighbours.Distinct().Count());
            }
        }
    }
}
