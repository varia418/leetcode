internal class Program
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    private static void Main(string[] args)
    {
        // var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        var head = new ListNode(1, new ListNode(2));
        var result = RemoveNthFromEnd(head, 2);
    }
    public static ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        if (head.next is null)
            return null;

        var slow = head;
        var fast = head;

        int listLength = 1;
        while (fast.next is not null && fast.next.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
            listLength += 2;
        }

        if (fast.next is not null)
        {
            listLength++;
        }

        int positionFromStart = listLength - n + 1;

        if (positionFromStart == 1)
        {
            return head.next;
        }

        ListNode previousNode = null;
        ListNode cursor = head;

        for (int i = 0; i < positionFromStart; i++)
        {
            if (i == positionFromStart - 1)
            {
                previousNode.next = cursor.next;
                break;
            }
            else
            {
                previousNode = cursor;
                cursor = cursor.next;
            }
        }

        return head;
    }
}