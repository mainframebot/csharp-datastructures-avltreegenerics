using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class Contains : Base
    {
        [Test]
        public void Contains_Should_Find_Matching_Value()
        {
            Assert.That(BalancedExample.Contains(9), Is.True);
        }

        [Test]
        public void Contains_Should_Not_Find_NonMatching_Value()
        {
            Assert.That(BalancedExample.Contains(21), Is.False);
        }
    }
}
