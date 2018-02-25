using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Remove : Base
    {
        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveCase1()
        {
            var tree = RemoveCase1Example;

            tree.Remove(8);

            Assert.That(tree.Root.Value, Is.EqualTo(4));

            Assert.That(tree.Root.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(1));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(3));

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(6));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(5));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(7));

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveCase1.Length - 1));
        }

        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveCase2()
        {
            var tree = RemoveCase2Example;

            tree.Remove(6);

            Assert.That(tree.Root.Value, Is.EqualTo(4));

            Assert.That(tree.Root.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(1));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(3));

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(7));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(5));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(8));

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveCase2.Length - 1));
        }

        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveCase3()
        {
            var tree = RemoveCase3Example;

            tree.Remove(6);

            Assert.That(tree.Root.Value, Is.EqualTo(4));

            Assert.That(tree.Root.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(1));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(3));

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(7));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(5));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(8));

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveCase3.Length - 1));
        }

        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveRootCase1()
        {
            var tree = RemoveRootCase1Example;

            tree.Remove(4);

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(2));

            Assert.That(tree.Root.Left, Is.Null);
            Assert.That(tree.Root.Right, Is.Null);

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveRootCase1.Length - 1));
        }

        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveRootCase2()
        {
            var tree = RemoveRootCase2Example;

            tree.Remove(4);

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(6));

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(1));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(3));

            Assert.That(tree.Root.Right.Value, Is.EqualTo(9));

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveRootCase2.Length - 1));
        }

        [Test]
        public void Remove_Should_Remain_Valid_Using_RemoveRootCase3()
        {
            var tree = RemoveRootCase3Example;

            tree.Remove(4);

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(6));

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(2));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(1));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(3));

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(9));
            Assert.That(tree.Root.Right.Left, Is.Null);

            Assert.That(tree.Count, Is.EqualTo(ItemsRemoveRootCase3.Length - 1));
        }
    }
}
