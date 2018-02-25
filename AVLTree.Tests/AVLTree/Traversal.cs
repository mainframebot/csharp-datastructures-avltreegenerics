using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Traversal : Base
    {
        [Test]
        public void PreOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            BalancedExample.PreOrderTraversal(item => Assert.That(ItemsPreOrder[index++], Is.EqualTo(item)));
        }

        [Test]
        public void InOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            BalancedExample.InOrderTraversal(item => Assert.That(ItemsInOrder[index++], Is.EqualTo(item)));
        }

        [Test]
        public void PostOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            BalancedExample.PostOrderTraversal(item => Assert.That(ItemsPostOrder[index++], Is.EqualTo(item)));
        }
    }
}
