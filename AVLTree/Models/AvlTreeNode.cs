using System;
using AVLTree.Enum;
using AVLTree.Interfaces;

namespace AVLTree.Models
{
    public class AvlTreeNode<T> : IBinarySearchTreeNode<T, AvlTreeNode<T>>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public AvlTreeNode<T> Left { get ; set; }

        public AvlTreeNode<T> Right { get; set; }

        public AvlTreeNode<T> Parent { get; set; }

        public int LeftHeight { get { return MaxChildHeight(Left); } }

        public int RightHeight { get { return MaxChildHeight(Right); } }

        public int BalancingFactor { get { return RightHeight - LeftHeight; } }

        public TreeState State { get { return DetermineTreeState(); } }

        public AvlTreeNode(T value)
        {
            Value = value;
        }

        private int MaxChildHeight(AvlTreeNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }

            return 0;
        }

        private TreeState DetermineTreeState()
        {
            if (LeftHeight - RightHeight > 1)
            {
                return TreeState.LeftHeavy;
            }

            if (RightHeight - LeftHeight > 1)
            {
                return TreeState.RightHeavy;
            }

            return TreeState.Balanced;
        }
    }
}
