using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Clear : Base
    {
        [Test]
        public void Clear_Should_Empty_Tree()
        {
            var tree = BalancedExample;

            tree.Clear();

            Assert.That(tree.Root, Is.Null);
            Assert.That(tree.Count, Is.EqualTo(0));
        }
    }
}
