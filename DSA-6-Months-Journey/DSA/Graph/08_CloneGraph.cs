namespace DSA.Graph
{
    public class CloneGraph
    {

        public static void Main()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);

            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var map = new Dictionary<int, Node>();
            DFS(node1, map);

            System.Console.WriteLine(headNode.val);

            headNode.val = 100;

            System.Console.WriteLine(node1.val);
            System.Console.WriteLine(headNode.val);
        }

        public static Node headNode = null;

        public static void DFS(Node node, Dictionary<int, Node> map)
        {
            if (node is null) return;

            var newNode = new Node(node.val);
            map.Add(node.val, newNode);
            if (headNode == null)
            {
                headNode = newNode;
            }

            foreach (var e in node.neighbors)
            {
                if (!map.ContainsKey(e.val))
                {
                    DFS(e, map);
                }
                newNode.neighbors.Add(map[e.val]);
            }
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}