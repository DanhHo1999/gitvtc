namespace ConsoleApp1
{
    class Program
    {
        public class Node
        {
            public Node(int _data, Node _next)
            {
                data = _data;
                next = _next;
            }
            public Node next;
            public int data;
        }
        static void ShowAll(ref Node head)
        {
            Node p = head;
            while (p != null)
            {
                Console.WriteLine(p.data);
                p = p.next;
            }
        }
        static void Main(string[] args)
        {
            Node head = new Node(5, new Node(9, new Node(6, null)));
            ShowAll(ref head);
        }
    }
}