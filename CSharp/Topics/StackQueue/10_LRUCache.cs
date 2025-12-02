using CSharp.Topics.LinkedLists;

namespace CSharp.Topics.StackQueue
{
    public class ListNode
    {
        public int val;
        public ListNode? prev;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? prev = null, ListNode? next = null)
        {
            this.val = val;
            this.prev = next;
            this.next = next;
        }
    }

    public class LRUCache
    {
        int capacity;
        int currentSize;
        Dictionary<int, (int, ListNode)> map;
        ListNode head = null;
        ListNode tail = null;

        public LRUCache(int capacity)
        {
            map = new Dictionary<int, (int, ListNode)>();
            this.capacity = capacity;
            currentSize = 0;
        }

        public int Get(int key)
        {
            // key already exists
            if (map.TryGetValue(key, out var value))
            {
                DeleteNode(value.Item2);
                head = AddFirst(value.Item2, head);

                return value.Item1;
            }
            else return -1;
        }

        public void Put(int key, int value)
        {
            // key already exists
            if (map.TryGetValue(key, out var listNode))
            {
                listNode.Item1 = value;
                listNode.Item2.val = key;

                DeleteNode(listNode.Item2);
                head = AddFirst(listNode.Item2, head);

                map[key] = listNode;
            }
            // key not exists
            else
            {
                var newNode = new ListNode(key);

                // add new node at first | Update head pointer to new node
                head = AddFirst(newNode, head);

                // add new value with its value & reference in map
                map.Add(key, (value, head));

                currentSize++;

                if (currentSize > capacity)
                {
                    if (tail is null)
                    {
                        tail = GetTailNode(head);
                    }

                    // Remove from map
                    map.Remove(tail.val);

                    // Remove from list
                    tail = EvictLeastRecentlyUsedNode(head, tail);

                    currentSize--;
                }
            }
        }

        public static void Run()
        {
            // LRUCache lRUCache = new LRUCache(2);
            // lRUCache.Put(1, 0); // cache is {1=1}
            // lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            // System.Console.WriteLine(lRUCache.Get(1));    // return 1
            // lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            // System.Console.WriteLine(lRUCache.Get(2));    // returns -1 (not found)
            // lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            // System.Console.WriteLine(lRUCache.Get(1));    // return -1 (not found)
            // System.Console.WriteLine(lRUCache.Get(3));    // return 3
            // System.Console.WriteLine(lRUCache.Get(4));    // return 4

            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(2, 1); // cache is {1=1, 2=2}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            System.Console.WriteLine(lRUCache.Get(2));    // returns -1 (not found)
            lRUCache.Put(1, 1); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            lRUCache.Put(4, 1); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            System.Console.WriteLine(lRUCache.Get(2));    // return 4
        }

        private static ListNode AddFirst(ListNode node, ListNode? head = null)
        {
            if (head == null || head == node)
            {
                head = node;
            }
            else
            {
                head.prev = node;
                node.next = head;
                head = node;
            }

            return head;
        }

        private static void DeleteNode(ListNode node)
        {
            var prevNode = node.prev;
            var nextNode = node.next;

            // Given node is already first
            if (prevNode is null)
            {
                return;
            }
            // Given node is last 
            else if (nextNode is null)
            {
                prevNode.next = null;
            }
            // Given node is between other nodes
            else
            {
                prevNode.next = nextNode;
                nextNode.prev = prevNode;
            }
        }

        private static ListNode GetTailNode(ListNode head)
        {
            ListNode ptr = head;
            while (ptr.next != null)
            {
                ptr = ptr.next;
            }

            return ptr;
        }

        private static ListNode EvictLeastRecentlyUsedNode(ListNode head, ListNode tail)
        {
            // Evict last node from list
            if (tail.prev == null)
            {
                return tail;
            }

            var prevNode = tail.prev;
            tail = prevNode;
            tail.next = null;

            return tail;
        }
    }
}