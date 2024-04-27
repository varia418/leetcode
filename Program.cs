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
        int?[] rootArr = [3, 9, 20, null, null, 15, 7];
        TreeNode? root = CreateTree(rootArr);
        LevelOrder(root);
        Console.WriteLine("Hello, World!");
    }

    private static IList<IList<int>> result = new List<IList<int>>();

    public static IList<IList<int>> LevelOrder(TreeNode? root, int level = 0)
    {
        if (root is null)
        {
            return new List<IList<int>>();
        }

        if (result.Count < level + 1)
        {
            result.Add(new List<int>());
        }

        result[level].Add(root.val);
        LevelOrder(root.left, level + 1);
        LevelOrder(root.right, level + 1);

        return result;
    }
}