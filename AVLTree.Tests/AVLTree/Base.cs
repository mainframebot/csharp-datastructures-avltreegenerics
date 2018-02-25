using AVLTree.Models;

namespace AVLTree.Tests.AVLTree
{
    public abstract class Base
    {
        public BinarySearchTree<int, AvlTreeNode<int>> BalancedExample { get { return GenerateTree(Items);} }
        public BinarySearchTree<int, AvlTreeNode<int>> LeftHeavyRightRotationExample {  get { return GenerateTree(ItemsLeftHeavyRightRotation);} }
        public BinarySearchTree<int, AvlTreeNode<int>> LeftHeavyRightLeftRotationExample {  get { return GenerateTree(ItemsLeftHeavyRightLeftRotation);} }
        public BinarySearchTree<int, AvlTreeNode<int>> RightHeavyLeftRotationExample { get { return GenerateTree(ItemsRightHeavyLeftRotation); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RightHeavyLeftRightRotationExample { get { return GenerateTree(ItemsRightHeavyLeftRightRotation); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveCase1Example { get { return GenerateTree(ItemsRemoveCase1); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveCase2Example { get { return GenerateTree(ItemsRemoveCase2); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveCase3Example { get { return GenerateTree(ItemsRemoveCase3); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveRootCase1Example { get { return GenerateTree(ItemsRemoveRootCase1); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveRootCase2Example { get { return GenerateTree(ItemsRemoveRootCase2); } }
        public BinarySearchTree<int, AvlTreeNode<int>> RemoveRootCase3Example { get { return GenerateTree(ItemsRemoveRootCase3); } }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Items Balanced
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:
        //                    5
        //                 /     \
        //                3       8
        //               / \     / \
        //              2   4   7   9        

        public int[] Items = { 5, 3, 8, 2, 4, 7, 9 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // How to do a left rotation:
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Step 1.                              Step 2.                             Step 3                                  Step 4.
        // 1.1 Tree before rotation             2.1 Move out original root          3.1 New Roots.Left = old Roots.Right    4.1 New Root.Left = old Root
        //                                      2.2 Right child = new root   

        //                (old)                   (old)           (new)                   (old)           (new)                             (new)
        //                  1                       1               3                       1               3                                 3
        //               /     \                   /             /     \                   / \               \                             /     \       
        //              a       3                 a             2       4                 a   2               4                           1       4
        //                    /   \                            / \     / \                   / \             / \                         / \     / \ 
        //                   2     4                          b   c   d   e                 b   c           d   e                       a   2   d   e
        //                  / \   / \                                                                                                      / \   
        //                 b   c d   e                                                                                                    b   c

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // How to do a right rotation:
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Step 1.                              Step 2.                             Step 3                                  Step 4.
        // 1.1 Tree before rotation             2.1 Move out original root          3.1 New Roots.Right = old Roots.Left    4.1 New Root.Right = old Root
        //                                      2.2 Left child = new root                                                   

        //                (old)                   (old)           (new)                   (old)           (new)                             (new)
        //                  4                       4               2                       4               2                                 2
        //               /     \                     \           /     \                   / \             /                               /     \       
        //              2       e                     e         1       3                 3   e           1                               1       4
        //            /   \                                    / \     / \               / \             / \                             / \     / \ 
        //           1     3                                  a   b   c   d             c   d           a   b                           a   b   3   e
        //          / \   / \                                                                                                                  / \
        //         a  b  c   d                                                                                                                c   d

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Balancing, LeftHeavy examples
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do right rotation if tree.State = LeftHeavy !!!! and tree.Left.BalanceFactor (right height - left height) <= 0 !!!! (add)
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                               Result:

        //                    15                                    10
        //                 /      \                               /     \
        //               10        20                            5       15
        //              /  \                                    /       /  \
        //             5    14                                 2       14   20
        //            /
        //           2*   

        // Note: BalanceFactor at 10: 1 (right height) - 2 (left height) = -1

        public int[] ItemsLeftHeavyRightRotation = { 15, 10, 20, 5, 14 };
        public int ItemLeftHeavyRightRotationAdd = 2;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do right rotation if tree.State = LeftHeavy !!!! and tree.Left.BalanceFactor (right height - left height) <= 0 !!!! (remove)
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:

        //                    5                                     3
        //                 /     \                               /     \  
        //                3       8*                            2       5
        //               / \     / \                                   /
        //              2   4   7*  9*                                4

        // Note: BalanceFactor at 3: 1 (right height) - 1 (left height) = 0  

        public int[] ItemsLeftHeavyRightRotationRemove = { 7, 9, 8 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do left.left & right rotation if tree.State = LeftHeavy !!!! and tree.Left.BalanceFactor (right height - left height) > 0 !!!!
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                               Left.Left Rotation Result:          Right Rotation Result:

        //                    15                                    15                                  14
        //                 /      \                               /     \                             /     \
        //               10        20                           14       20                         10       15
        //              /  \                                    /                                  /  \        \
        //             5    14                                10                                  5    12       20
        //                 /                                 /  \
        //               12*                                5    12

        // Note: BalanceFactor at 10: 2 (right height) - 1 (left height) = 1

        public int[] ItemsLeftHeavyRightLeftRotation = { 15, 10, 20, 5, 14 };
        public int ItemLeftHeavyRightLeftRotationAdd = 12;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Balancing, RightHeavy examples
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do left rotation if tree.State = RightHeavy !!!! and tree.Right.BalanceFactor (right height - left height) => 0 !!!! (add)
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                               Result:

        //                    10                                    15                                        
        //                 /      \                               /     \
        //                5        15                           10       18
        //                        /  \                         /  \        \ 
        //                      14    18                      5    14        20
        //                             \
        //                              20*     

        // Note: BalanceFactor at 15: 2 (right height) - 1 (left height) = 1

        public int[] ItemsRightHeavyLeftRotation = { 10, 5, 15, 14, 18 };
        public int ItemRightHeavyLeftRotationAdd = 20;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do left rotation if tree.State = RightHeavy !!!! and tree.Right.BalanceFactor (right height - left height) => 0 !!!! (remove)
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                               Result:

        //                    5                                     8
        //                 /     \                               /     \  
        //                3*      8                             5       9
        //               / \     / \                             \
        //              2*  4*  7   9                             7

        // Note: BalanceFactor at 8: 1 (right height) - 1 (left height) = 0

        public int[] ItemsRightHeavyLeftRotationRemove = { 2, 4, 3 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Do right.right & left rotation if tree.State = RightHeavy !!!! and tree.Right.BalanceFactor (right height - left height) < 0 !!!!
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Right.Right Rotation Result:            Left Rotation Result:

        //                    10                                    10                                  15                                        
        //                 /      \                               /     \                             /     \
        //                5        16                            5       15                         10       16
        //                        /  \                                  /  \                       /  \        \ 
        //                      15    18                               14   16                    5    14       18
        //                      /                                            \
        //                    14*                                             18           

        // Note: BalanceFactor at 16: 1 (right height) - 2 (left height) = -1  

        public int[] ItemsRightHeavyLeftRightRotation = { 10, 5, 16, 15, 18 };
        public int ItemRightHeavyLeftRightRotationAdd = 14;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Traversal examples
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // PreOrder = Process, Left, Right
        // ------------------------------------------------------------------------------------------------------------------------------------------------------
 
        public int[] ItemsPreOrder = { 5, 3, 2, 4, 8, 7, 9 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // InOrder = Left, Process, Right
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        public int[] ItemsInOrder = { 2, 3, 4, 5, 7, 8, 9 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // PostOrder = Left, Right, Process
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        public int[] ItemsPostOrder = { 2, 4, 3, 7, 9, 8, 5 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Traversal examples
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveCase1, Remove(8): Removed node has no right child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:

        //                    4                                     4   
        //                 /     \                               /     \
        //                2       8                             2       6
        //               / \     /                             / \     / \
        //              1   3   6                             1   3   5   7
        //                     / \
        //                    5   7  

        public int[] ItemsRemoveCase1 = { 4, 2, 8, 1, 3, 6, 5, 7 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveCase2, Remove(6): Removed node has a right child and it has no left child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:
        //                    4                                     4
        //                 /     \                               /     \
        //                2       6                             2       7
        //               / \     / \                           / \     / \
        //              1   3   5   7                         1   3   5   8
        //                           \
        //                            8

        public int[] ItemsRemoveCase2 = { 4, 2, 6, 1, 3, 5, 7, 8 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveCase3, Remove(6): Removed node has a right child and it has a left child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:
        //                    4                                     4
        //                 /     \                               /     \
        //                2       6                             2       7
        //               / \     / \                           / \     / \
        //              1   3   5   8                         1   3   5   8
        //                         / 
        //                        7  

        public int[] ItemsRemoveCase3 = { 4, 2, 6, 1, 3, 5, 8, 7 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveRootCase1, Remove(4): Removed node has no right child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        //  Setup:                          Result:

        //                    4                                     2   
        //                 /                                          
        //                2                                                                                                          

        public int[] ItemsRemoveRootCase1 = { 4, 2 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveRootCase2, Remove(4): Removed node has a right child and it has no left child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:

        //                    4                                     6
        //                 /     \                               /     \
        //                2       6                             2       9
        //               / \       \                           / \    
        //              1   3       9                         1   3   


        public int[] ItemsRemoveRootCase2 = { 4, 2, 6, 1, 3, 9 };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // RemoveRootCase3, Remove(4): Removed node has a right child and it has a left child
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // Setup:                           Result:

        //                    4                                     6
        //                 /     \                               /     \
        //                2       9                             2       9
        //               / \     /                             / \     
        //              1   3   6                             1   3          

        public int[] ItemsRemoveRootCase3 = { 4, 2, 9, 1, 3, 6 };


        private BinarySearchTree<int, AvlTreeNode<int>> GenerateTree(int[] items)
        {
            var tree = new BinarySearchTree<int, AvlTreeNode<int>>();
            foreach (var item in items)
            {
                tree.Add(item);
            }

            return tree;
        }
    }
}
