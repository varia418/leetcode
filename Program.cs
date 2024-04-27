internal class Program
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    private static void Main(string[] args)
    {
        int?[][] inputArr = [[3, null], [3, 0], [3, null]];

        Dictionary<int, IList<Node>> uncompletedNodes = new();

        Node head = new Node(inputArr[0][0] ?? 0);
        Node current = head;

        if (inputArr[0][1] != null)
        {
            uncompletedNodes.Add(inputArr[0][1] ?? 0, new List<Node>() { current });
        }

        foreach (var pair in inputArr.Skip(1))
        {
            var newNode = new Node(pair[0] ?? 0);
            current.next = newNode;
            current = newNode;

            if (pair[1] is null)
            {
                continue;
            }

            if (uncompletedNodes.ContainsKey(pair[1] ?? 0))
            {
                uncompletedNodes[pair[1] ?? 0].Add(newNode);
            }
            else
            {
                uncompletedNodes.Add(pair[1] ?? 0, new List<Node>() { newNode });
            }
        }

        current = head;
        int i = 0;
        while (current is not null)
        {
            if (uncompletedNodes.ContainsKey(i))
            {
                foreach (var node in uncompletedNodes[i])
                {
                    node.random = current;
                }
            }
            current = current.next;
            i++;
        }

        CopyRandomList(head);
    }

    public static Node CopyRandomList(Node head)
    {
        if (head is null)
        {
            return null;
        }

        Dictionary<Node, IList<Node>> uncompletedNodes = new();
        Node clonedHead = new Node(head.val);
        Node cloneCursor = clonedHead;
        Node current = head;

        if (current.random is not null)
        {
            uncompletedNodes.Add(current.random, new List<Node>() { cloneCursor });
        }

        current = current.next;
        while (current is not null)
        {
            var newNode = new Node(current.val);
            cloneCursor.next = newNode;
            cloneCursor = cloneCursor.next;

            if (current.random is null)
            {
                current = current.next;
                continue;
            }

            if (uncompletedNodes.ContainsKey(current.random))
            {
                uncompletedNodes[current.random].Add(newNode);
            }
            else
            {
                uncompletedNodes.Add(current.random, new List<Node>() { newNode });
            }

            current = current.next;
        }

        cloneCursor = clonedHead;
        current = head;

        while (current is not null)
        {
            if (uncompletedNodes.ContainsKey(current))
            {
                foreach (var node in uncompletedNodes[current])
                {
                    node.random = cloneCursor;
                }
            }

            current = current.next;
            cloneCursor = cloneCursor.next;
        }

        return clonedHead;
    }
}