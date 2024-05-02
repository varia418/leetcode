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

    public static TreeNode? CreateTree(int?[] treeArr, int index = 0)
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
        int[] preorder = [3, 9, 20, 15, 7];
        int[] inorder = [9, 3, 15, 20, 7];
        TreeNode? result = BuildTree(preorder, inorder);
        System.Console.WriteLine();
    }

    public static TreeNode? BuildTree(int[] preorder, int[] inorder)
    {
        // if (preorder.Length == 0 || inorder.Length == 0) return null;

        // TreeNode root = new TreeNode(preorder[0]);

        // int rootIndex = inorder.ToList().IndexOf(preorder[0]);
        // int[] leftInorder = inorder.Take(rootIndex).ToArray();
        // int[] leftPreorder = preorder.Skip(1).Take(leftInorder.Length).ToArray();
        // root.left = BuildTree(leftPreorder, leftInorder);

        // int[] rightInorder = inorder.Skip(rootIndex + 1).ToArray();
        // int[] rightPreorder = preorder.Skip(leftInorder.Length + 1).ToArray();
        // root.right = BuildTree(rightPreorder, rightInorder);

        // return root;

        TreeNode? root = BuildTree(0, preorder.Length - 1, preorder, 0, inorder.Length - 1, inorder);
        return root;
    }

    private static TreeNode? BuildTree(int startPre, int endPre, int[] preorder, int startIn, int endIn, int[] inorder)
    {
        if (startPre > endPre || startPre >= preorder.Length) return null;

        TreeNode root = new TreeNode(preorder[startPre]);

        int rootIndex = startIn;

        while (inorder[rootIndex] != preorder[startPre])
        {
            rootIndex++;
        }

        root.left = BuildTree(
            startPre + 1,
            startPre + rootIndex - startIn,
            preorder,
            startIn,
            rootIndex - 1,
            inorder);

        root.right = BuildTree(
            startPre + 1 + rootIndex - startIn,
            endPre,
            preorder,
            rootIndex + 1,
            endIn,
            inorder);

        return root;
    }
}