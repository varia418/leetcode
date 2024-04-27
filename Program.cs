internal class Program
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    private static void Main(string[] args)
    {
        // ListNode head = new ListNode(1,
        //     new ListNode(2,
        //         new ListNode(3,
        //             new ListNode(4))));

        ListNode head = new ListNode(1);

        ReorderList(head);
        System.Console.WriteLine();
    }
    public static void ReorderList(ListNode head)
    {
        if (head.next is null)
        {
            return;
        }
        ListNode clonedHead = head;
        ListNode tail = new ListNode(clonedHead.val);
        ListNode resultHead = new ListNode(clonedHead.val);
        ListNode result = resultHead;

        var headCursor = clonedHead.next;
        int count = 1;

        while (headCursor is not null)
        {
            var currentNode = new ListNode(headCursor.val, tail);
            tail = currentNode;
            headCursor = headCursor.next;
            count++;
        }

        for (int i = 0; i < count / 2; i++)
        {
            if (i != 0)
            {
                result.next = new ListNode(clonedHead.val);
                result = result.next;
                clonedHead = clonedHead.next;
            }
            else
            {
                clonedHead = clonedHead.next;
            }

            result.next = new ListNode(tail.val);
            result = result.next;
            tail = tail.next;
        }

        if (count % 2 == 1)
        {
            result.next = new ListNode(clonedHead.val);
        }

        head.next = resultHead.next;
    }
}