namespace IsSubtree
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    internal class Program
    {
        static TreeNode? CreateTree(int?[] treeArr, int index = 0)
        {
            if (index >= treeArr.Length) return null;

            if (treeArr[index] is null) return null;

            TreeNode node = new TreeNode(
                (int)treeArr[index]!,
                CreateTree(treeArr, index * 2 + 1),
                CreateTree(treeArr, index * 2 + 2)
            );

            return node;
        }
        static bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root is null && subRoot is null) return true;

            if (root?.val == subRoot?.val)
            {
                bool leftBranchIsSubTree = IsSubtree(root?.left, subRoot?.left);
                bool rightBranchIsSubTree = IsSubtree(root?.right, subRoot?.right);
                return leftBranchIsSubTree && rightBranchIsSubTree;
            }
            return IsSubtree(root?.left, subRoot) || IsSubtree(root?.right, subRoot);
        }
        static void Main(string[] args)
        {
            int?[] rootArr = { 3, 4, 5, 1, 2, null, null, null, null, 0 };
            int?[] subRootArr = { 4, 1, 2 };

            TreeNode root = CreateTree(rootArr)!;
            TreeNode subRoot = CreateTree(subRootArr);

            Console.WriteLine(IsSubtree(root, subRoot));
        }
    }
}