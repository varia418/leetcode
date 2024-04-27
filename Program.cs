internal class Program
{
    public class LRUCache
    {
        public class Node
        {
            public int Key;
            public int Value;
            public Node? Prev;
            public Node? Next;

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
                Prev = null;
                Next = null;
            }
        }

        private int _capacity;
        private Dictionary<int, Node> _cache;
        private Node _left;
        private Node _right;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new();
            _left = new Node(0, 0);
            _right = new Node(0, 0);

            _left.Next = _right;
            _right.Prev = _left;
        }

        public int Get(int key)
        {
            bool keyExists = _cache.ContainsKey(key);

            if (!keyExists) return -1;

            var node = _cache[key];
            Remove(node);
            Insert(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            bool keyExists = _cache.ContainsKey(key);
            var node = new Node(key, value);

            if (keyExists)
            {
                Remove(_cache[key]);
            }

            if (!keyExists && _cache.Count() == _capacity)
            {
                Node lru = _left.Next!;
                Remove(lru);
                _cache.Remove(lru.Key);
            }

            Insert(node);
            _cache[key] = node;
        }

        public void Remove(Node node)
        {
            var (prev, next) = (node.Prev, node.Next);
            prev!.Next = next;
            next!.Prev = prev;
        }

        public void Insert(Node node)
        {
            var (last, right) = (_right.Prev, _right);
            last!.Next = node;
            node.Next = right;
            node.Prev = last;
            right.Prev = node;
        }
    }

    private static void Main(string[] args)
    {
        int value;
        LRUCache lRUCache = new LRUCache(2);

        string[] actions = ["put", "put", "get", "put", "get", "put", "get", "get", "get"];
        (int Key, int? Value)[] values =
        {
            (1, 1),
            (2, 2),
            (1, null),
            (3, 3),
            (2, null),
            (4, 4),
            (1, null),
            (3, null),
            (4, null),
        };

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "put":
                    lRUCache.Put(values[i].Key, (int)values[i].Value!);
                    break;
                case "get":
                    value = lRUCache.Get(values[i].Key);
                    System.Console.WriteLine(value);
                    break;
            }
        }
    }
}