using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Enumeration : Base
    {
        [Test]
        public void Enumeration_Should_TraverseTree_InOrder()
        {
            var tree = BalancedExample;
            var counter = 0;

            foreach (var node in tree)
            {
                Assert.That(node, Is.EqualTo(ItemsInOrder[counter]));
                counter++;
            }

            Assert.That(counter, Is.EqualTo(ItemsInOrder.Length));
        }
    }
}
