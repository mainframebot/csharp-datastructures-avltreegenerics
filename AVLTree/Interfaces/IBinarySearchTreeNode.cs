using System;

namespace AVLTree.Interfaces
{
    public interface IBinarySearchTreeNode<T, TNode>
        where T : IComparable<T>
    {
        T Value { get; set; }

        TNode Left { get; set; }

        TNode Right { get; set; }

        TNode Parent { get; set; }
    }
}
