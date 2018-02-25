using System;
using AVLTree.Interfaces;

namespace AVLTree.Models
{
    public class BinarySearchTreeNode<T> : IBinarySearchTreeNode<T, BinarySearchTreeNode<T>>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public BinarySearchTreeNode<T> Left { get; set; }

        public BinarySearchTreeNode<T> Right { get; set; }

        public BinarySearchTreeNode<T> Parent { get; set; }

        public BinarySearchTreeNode(T value)
        {
            Value = value;
        }
    }
}
