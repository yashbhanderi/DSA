namespace CSharp.Topics.StackQueue
{
    public class Deque<T>
    {
        private LinkedList<T> _linkedList = new LinkedList<T>();

        public void PushFront(T item)
        {
            _linkedList.AddFirst(item);
        }

        public void PushRear(T item)
        {
            _linkedList.AddLast(item);
        }

        public T PopFront()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            T item = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return item;
        }

        public T PopRear()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            T item = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            return item;
        }

        public T PeekFront()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            return _linkedList.First.Value;
        }

        public T PeekRear()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            return _linkedList.Last.Value;
        }

        public int Count => _linkedList.Count;
        public bool IsEmpty() => _linkedList.Count == 0;
    }
}