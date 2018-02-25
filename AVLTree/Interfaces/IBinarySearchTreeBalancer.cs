using System;

namespace AVLTree.Interfaces
{
    public interface IBinarySearchTreeBalancer<T, TNode>
        where T : IComparable<T>
        where TNode : IBinarySearchTreeNode<T, TNode>
    {
        void Balance(TNode node, BinarySearchTree<T, TNode> tree);
    }
}
