namespace DataStructures.Trees
{
    using System.Text;

    internal static class BinaryTreeDisplayer
    {
        public static string DisplayTree(Node node, TraversalType traversalType = TraversalType.Inorder)
        {
            var sb = new StringBuilder();
            
            switch (traversalType)
            {
                case TraversalType.Postorder:
                    BinaryTreeDisplayer.PrintPostorder(sb, node);
                    break;
                case TraversalType.Preorder:
                    BinaryTreeDisplayer.PrintPreorder(sb, node);
                    break;
                case TraversalType.Inorder:
                default:
                    BinaryTreeDisplayer.PrintInorder(sb, node);
                    break;
            }
            
            return sb.ToString();
        }
        private static void PrintInorder(StringBuilder sb, Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintInorder(sb, node.Left);

            sb.Append(node.Data + " ");

            PrintInorder(sb, node.Right);
        }

        private static void PrintPreorder(StringBuilder sb, Node node)
        {
            if (node == null)
            {
                return;
            }

            sb.Append(node.Data + " ");

            PrintPreorder(sb, node.Left);

            PrintPreorder(sb, node.Right);
        }

        private static void PrintPostorder(StringBuilder sb, Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintPreorder(sb, node.Left);

            PrintPreorder(sb, node.Right);

            sb.Append(node.Data + " ");
        }
    }
}