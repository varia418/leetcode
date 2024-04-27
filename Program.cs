namespace Min_Stack
{
    public class MinStack
    {
        private List<int> _stack;
        private List<int> _minStack;

        private int _min;
        public MinStack()
        {
            _stack = new();
            _minStack = new();
            _min = Int32.MaxValue;
        }

        public void Push(int val)
        {
            _stack.Add(val);
            if (val <= _min)
            {
                _minStack.Add(val);
                _min = val;
            }
        }

        public void Pop()
        {
            if (_stack.Count == 0) return;

            int val = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            if (val == _min)
            {
                _minStack.RemoveAt(_minStack.Count - 1);
                _min = _minStack.Count > 0 ? _minStack[_minStack.Count - 1] : Int32.MaxValue;
            }
        }

        public int Top()
        {
            return _stack[_stack.Count - 1];
        }

        public int GetMin()
        {
            return _min;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}