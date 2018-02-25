using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Add : Base
    {
        [Test]
        public void Add_Should_Generate_Valid_Tree()
        {
            var tree = BalancedExample;

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(5));

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(3));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(4));

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(8));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(7));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(9));

            Assert.That(tree.Count, Is.EqualTo(Items.Length));
        }

        [Test]
        public void Add_Should_Generate_Valid_Tree_With_Duplicate_Value()
        {
            var tree = BalancedExample;

            tree.Add(4);

            Assert.That(tree.Root.Left.Right.Right.Value, Is.EqualTo(4));
        }
    }
}
