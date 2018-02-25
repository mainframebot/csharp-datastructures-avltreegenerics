using System;
using System.Collections;
using System.Collections.Generic;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree
{
    public class BinarySearchTree<T, TNode> : IEnumerable<T>
        where T : IComparable<T>
        where TNode : IBinarySearchTreeNode<T, TNode>
    {
        public TNode Root { get; set; } 

        public int Count { get; set; }

        public void Clear()
        {
            Root = default(TNode);
            Count = 0;
        }

        public void Add(T value)
        {
            if(value == null)
                throw new ArgumentNullException();

            var node = (TNode)Activator.CreateInstance(typeof(TNode), value);

            Add(node);
        }

        public void Add(TNode node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                AddNode(Root, node);
            }

            Count++;
        }

        private void AddNode(TNode current, TNode node)
        {
            if (node.Value.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                {
                    node.Parent = current;
                    current.Left = node;
                }
                else
                {
                    AddNode(current.Left, node);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    node.Parent = current;
                    current.Right = node;
                }
                else
                {
                    AddNode(current.Right, node);
                }
            }

            new AvlTreeBalancer<T, TNode>().Balance(current, this);
        }

        public bool Contains(T value)
        {
            return FindNode(value) != null;
        }

        private TNode FindNode(T value)
        {
            TNode current = Root;

            while (current != null)
            {
                int result = value.CompareTo(current.Value);

                if (result < 0)
                {
                    current = current.Left;
                }
                else if (result > 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public bool Remove(T value)
        {
            if (value.Equals(null))
                throw new ArgumentException();

            TNode current;

            current = FindNode(value);

            if (current.Equals(null))
                return false;

            Count--;

            // RemoveCase1, node to be removed has no right child
            if (current.Right == null)
            {
                RemoveCase1(current);
            }
            else
            {
                // RemoveCase2, node to be removed has a right child but that child node has no left child
                if (current.Right.Left == null)
                {
                    RemoveCase2(current);
                }
                else
                {
                    // RemoveCase3, node to be removed has a right child that has a left child
                    RemoveCase3(current);
                }
            }

            if (current.Parent == null)
            {
                if (Root != null)
                {
                    new AvlTreeBalancer<T, TNode>().Balance(Root, this);
                }
            }
            else
            {
                new AvlTreeBalancer<T, TNode>().Balance(current.Parent, this);
            }
            
            return true;
        }

        private void RemoveCase1(TNode current)
        {
            if (current.Parent == null)
            {
                SetRootReferences(current.Left);
            }
            else
            {
                int result = current.Parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                    current.Parent.Left = current.Left;
                }
                else if (result < 0)
                {
                    current.Parent.Right = current.Left;
                }

                if (current.Left != null)
                {
                    current.Left.Parent = current.Parent;

                    if (current.Left.Left != null)
                        current.Left.Left.Parent = current.Left;

                    if (current.Left.Right != null)
                        current.Left.Right.Parent = current.Left;
                }
            }
        }

        private void RemoveCase2(TNode current)
        {
            current.Right.Left = current.Left;

            if (current.Parent == null)
            {
                current.Right.Left = current.Left;
                SetRootReferences(current.Right);
            }
            else
            {
                int result = current.Parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                    current.Parent.Left = current.Right;
                }
                else if (result < 0)
                {
                    current.Parent.Right = current.Right;
                }

                if (current.Right != null)
                {
                    current.Right.Parent = current.Parent;

                    if (current.Right.Left != null)
                        current.Right.Left.Parent = current.Right;

                    if (current.Right.Right != null)
                        current.Right.Right.Parent = current.Right;
                } 
            }
        }

        private void RemoveCase3(TNode current)
        {
            // Find left-most child of the node to be removed right child's
            TNode leftmostNode = current.Right.Left;
            TNode leftmostParentNode = current.Right;

            while (leftmostNode.Left != null)
            {
                leftmostParentNode = leftmostNode;
                leftmostNode = leftmostNode.Left;
            }

            // Set the left-most parent's left node to the left-most's right node
            leftmostParentNode.Left = leftmostNode.Right;

            // Set the left-most node's child nodes to those of the node being removed
            leftmostNode.Left = current.Left;
            leftmostNode.Right = current.Right;

            if (current.Parent == null)
            {
                SetRootReferences(leftmostNode);
            }
            else
            {
                int result = current.Parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                    current.Parent.Left = leftmostNode;
                }
                else if (result < 0)
                {
                    current.Parent.Right = leftmostNode;
                }

                leftmostNode.Parent = current.Parent;

                if (leftmostNode.Left != null)
                    leftmostNode.Left.Parent = leftmostNode;

                if (leftmostNode.Right != null)
                    leftmostNode.Right.Parent = leftmostNode;
            }
        }

        private void SetRootReferences(TNode replacementNode)
        {
            Root = replacementNode;

            Root.Parent = default(TNode);

            if (Root.Left != null)
                Root.Left.Parent = Root;

            if (Root.Right != null)
                Root.Right.Parent = Root;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, Root);
        }

        public void PreOrderTraversal(Action<T> action, TNode node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, Root);
        }

        public void PostOrderTraversal(Action<T> action, TNode node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, Root);
        }

        public void InOrderTraversal(Action<T> action, TNode node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Root != null)
            {
                Stack<TNode> stack = new Stack<TNode>();

                bool goLeft = true;

                TNode current = Root;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right == null)
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }
                    else
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
