using System;
using AVLTree.Enum;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree
{
    public class AvlTreeBalancer<T, TNode> : IBinarySearchTreeBalancer<T, TNode>
        where T : IComparable<T>
        where TNode : IBinarySearchTreeNode<T, TNode>
    {
        private AvlTreeNode<T> _node;

        private BinarySearchTree<T, AvlTreeNode<T>> _tree;

        public void Balance(TNode node, BinarySearchTree<T, TNode> tree)
        {
            if(node == null || tree == null)
                throw new ArgumentNullException();

            _node = node as AvlTreeNode<T>;
            _tree = tree as BinarySearchTree<T, AvlTreeNode<T>>;

            RotateTree();
        }

        private void RotateTree()
        {
            switch (_node.State)
            {
                case TreeState.RightHeavy:
                    if (_node.Right.BalancingFactor < 0)
                    {
                        RotateLeftRight(_node);
                    }
                    else
                    {
                        RotateLeft(_node);
                    }
                    break;
                case TreeState.LeftHeavy:
                    if (_node.Left.BalancingFactor > 0)
                    {
                        RotateRightLeft(_node);
                    }
                    else
                    {
                        RotateRight(_node);
                    }
                    break;
            }
        }

        private void RotateLeft(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> oldRoot = node;
            AvlTreeNode<T> newRoot = node.Right;

            oldRoot.Right = newRoot.Left;

            if (oldRoot.Right != null)
                oldRoot.Right.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Left = oldRoot;
            oldRoot.Parent = newRoot;
        }

        private void RotateLeftRight(AvlTreeNode<T> node)
        {
            RotateRight(node.Right);
            RotateLeft(node);
        }

        private void RotateRight(AvlTreeNode<T> node)
        {
            AvlTreeNode<T> oldRoot = node;
            AvlTreeNode<T> newRoot = node.Left;

            oldRoot.Left = newRoot.Right;

            if(oldRoot.Left != null)
                oldRoot.Left.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Right = oldRoot;
            oldRoot.Parent = newRoot;
        }

        private void RotateRightLeft(AvlTreeNode<T> node)
        {
            RotateLeft(node.Left);
            RotateRight(node);
        }

        private void RotateParent(AvlTreeNode<T> oldRoot, AvlTreeNode<T> newRoot)
        {
            if(oldRoot.Parent == null)
            {
                _tree.Root = newRoot;
                newRoot.Parent = null;
            }
            else
            {
                if (oldRoot.Parent.Left != null && oldRoot.Parent.Left.Value.Equals(oldRoot.Value))
                {
                    oldRoot.Parent.Left = newRoot;
                }
                else if (oldRoot.Parent.Right != null && oldRoot.Parent.Right.Value.Equals(oldRoot.Value))
                {
                    oldRoot.Parent.Right = newRoot;
                }

                newRoot.Parent = oldRoot.Parent;
                oldRoot.Parent = newRoot;
            }
        }
    }
}
