internal class Program
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
    private static void Main(string[] args)
    {
        int?[] rootArr = [1, 2, 3, 4];
        TreeNode? root = CreateTree(rootArr);
        RightSideView(root);
    }
    private static IList<int> result = new List<int>();
    public static IList<int> RightSideView(TreeNode root)
    {
        AddRightSideNodeToList(root, 0);
        return result;
    }
    public static void AddRightSideNodeToList(TreeNode root, int level)
    {
        if (root == null) return;

        if (result.Count <= level)
        {
            result.Add(root.val);
        }
        result[level] = root.val;

        if (root.left is not null)
        {
            AddRightSideNodeToList(root.left, level + 1);
        }

        if (root.right is not null)
        {
            AddRightSideNodeToList(root.right, level + 1);
        }
    }
}