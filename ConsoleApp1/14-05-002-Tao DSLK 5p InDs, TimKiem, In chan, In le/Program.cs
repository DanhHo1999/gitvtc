namespace App {
    class Program {
        public class Node {
            public int data;
            public Node next;
            public Node(int data,Node next) { 
                this.data = data;
                this.next = next;
            }
        }

        static Node head, p;

        static void InDS() {
            p = head;
            while (p != null) {
                Console.Write(p.data+" ");
                p=p.next;
            }
        }
        static void Tim1PhanTu(int data) {
            p = head;
            bool founded=false;
            while (p != null) {
                if (p.data == data) { founded = true; }
                p = p.next;
            }
            if (founded)
            {
                Console.WriteLine("Tim thay phan tu");
            }
            else {
                Console.WriteLine("Khong tim thay phan tu");
            }
        }

        static void InPtuChan() {
            p = head;
            while (p != null) {
                if (p.data % 2 == 0) Console.Write(p.data+" ");
                p=p.next;
            }
        }static void InPtuLe() {
            p = head;
            while (p != null) {
                if (p.data % 2 != 0) Console.Write(p.data+" ");
                p=p.next;
            }
        }


        static void Main(string[] args) {
            head = new Node(10, null);
            p = new Node(9, head);
            head = p;
            p = new Node(8, head);
            head = p;
            p=new Node(7, head);
            head = p;
            p = new Node(6, head);
            head = p;

            Console.Write("InDS: "); InDS();
            Console.Write("\nTim 1 phan tu: "); Tim1PhanTu(6);
            Console.Write("In Phan Tu Chan: "); InPtuChan();
            Console.WriteLine();
            Console.Write("In Phan Tu Le: "); InPtuLe();
            Console.WriteLine(); Console.WriteLine();


        }


    }
}