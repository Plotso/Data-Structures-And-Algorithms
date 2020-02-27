namespace DataStructures.Trees
{
    /// <summary>
    /// Implement basic BinarySearchTree data structure 
    /// </summary>
    public class BinarySearchTree
    {
        private Node _root;
        
        /// <param name="root">The root of binary tree. If value is null, the first inserted item would be the root</param>
        public BinarySearchTree(Node root = null)
        {
            _root = root;
        }

        public Node GetRoot() => _root;
        
        public string DisplayTree(TraversalType traversal = TraversalType.Inorder) 
            => BinaryTreeDisplayer.DisplayTree(_root, traversal);

        public void Insert(int data)
        {
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }

            InsertNode(_root, new Node(data));
        }

        private void InsertNode(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
            }

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                    return;
                }
                InsertNode(root.Left, newNode);
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                    return;
                }
                InsertNode(root.Right, newNode);
            }
        }
    }
}