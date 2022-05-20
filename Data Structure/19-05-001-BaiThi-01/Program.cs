namespace NameSpace
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int k)
            {
                data = k;
            }
        }

        static void insertHead(ref Node head, int data)
        {
            Node p = new Node(data);
            p.next = head;
            head = p;
        }

        static bool search(Node head, int key)
        {
            Node p = head;
            while (p != null)
            {
                if (p.data == key) return true;
                p = p.next;
            }
            return false;
        }
        static int max(Node head)
        {
            Node p = head;
            if (p == null) { Console.WriteLine("List is Null"); return 0; }
            int max = p.data;
            while (p.next != null)
            {
                if (p.next.data > max) max = p.next.data;
                p = p.next;
            }
            return max;
        }
        static void delete(ref Node head, int key)
        {
            if (head == null) return;
            if (head.data == key)
            {
                head = head.next; return;
            }
            Node p = head;
            while (p.next != null)
            {
                if (p.next.data == key)
                {
                    p.next = p.next.next;
                    return;
                }
                p = p.next;
            }
        }
        


        static void Traversal(Node head)
        {
            Node p = head;
            while (p != null)
            {
                Console.Write(p.data+"  ");
                p = p.next;
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Node head = new Node(100);

            for (int i = 90; i >= 10; i -= 10) insertHead(ref head, i);

            Console.WriteLine(search(head, 80));
            Console.WriteLine(search(head, 85));


            Console.WriteLine(max(head));

            insertHead(ref head, 70);
            insertHead(ref head, 100);
            insertHead(ref head, 100);
            insertHead(ref head, 70);
            insertHead(ref head, 70);

            delete(ref head, 100);

            while (search(head, 70)) delete(ref head, 70);

            Traversal(head);

        }
    }
}