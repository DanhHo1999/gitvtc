namespace _21_05_003_Inheritance
{
    class Program
    {
        public class A
        {
            private int id = 5;
            public int getID()
            {
                return id;
            }

        }
        public class B : A
        {

        }

        static void Main(string[] args)
        {

            A a = new A();
            Console.WriteLine(a.getID());

            B b = new B();
            Console.WriteLine(b.getID());

        }
    }
}