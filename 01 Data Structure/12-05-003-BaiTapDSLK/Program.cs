namespace AAA {
    class Program {
        public class Node { 
            public int data;
            public Node next;
            public Node(int _data, Node _next) {
                data = _data;
                next = _next;
            }
        }
        static void Traversal(ref Node head) {
            Console.Write("Danh sach : ");
            Node p=head;
            while (p != null) { 
                Console.Write(p.data+" ");
                p = p.next;
            }
            Console.WriteLine();
        }
        static void InsertTail(int _data,ref Node head) {
            Node p = head;
            while (p.next != null) {
                p=p.next;
            }
            p.next = new Node(_data, null);
        }
        static void InsertHead(int _data, ref Node head) { 
            Node p=new Node(_data, head);
            head = p;
        }
        static void InsertMiddle_InsertK_AfterNumberX(int _x,int _k, ref Node head) {
            Node p = head;
            while (p!= null) {
                if (p.data == _x) { 
                    Node nodeK=new Node(_k, p.next);
                    p.next=nodeK;
                    return;
                }
                p = p.next;
            }
            Console.WriteLine("Number "+_x+" no exist");
        }
        

        
        static void RemoveHead(ref Node head) { 
            head=head.next;
        }

        static void RemoveTail(ref Node head) {
            Node p = head;
            if(p==null) return;
            if(p.next==null) head=null;
            while (p.next.next != null) { 
                
                p=p.next;
            }
            p.next=null;
        }
        static void RemoveMiddle_RemoveXFromList(int _x, ref Node head)
        {
            Node p = head;
            while (p.next != null)
            {
                if (p.next.data == _x)
                {
                    p.next = p.next.next;

                }
                p = p.next;
            }
        }

        static void Main(string[] args) {

            Node head=null;
            InsertHead(5, ref head);
            InsertHead(7, ref head);
            InsertHead(9, ref head);
            InsertHead(15, ref head);
            InsertHead(11, ref head);

            
            InsertMiddle_InsertK_AfterNumberX(7,100,ref head);

            //11 15 9 7 100 5

            RemoveTail(ref head);

            //11 15 9 7 100

            RemoveMiddle_RemoveXFromList(7,ref head);

            //Nhap so k:
            //int k = Convet.ToInt32(Console.ReadLine());
            //RemoveMiddle_RemoveXFromList(k,ref head);


            //11 15 9 100

            Traversal(ref head);

            
        }
    }
}