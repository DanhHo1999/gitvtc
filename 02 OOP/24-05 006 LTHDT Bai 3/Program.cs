namespace AAA {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine((new Triangle(3,4,5).toString()));
            Console.WriteLine((new Triangle(0,4,5).toString()));
            Console.WriteLine((new Triangle(-3,4,5).toString()));
            Console.WriteLine((new Triangle(8,4,5).toString()));
            Console.WriteLine((new Triangle(83,4,5).toString()));
        }
    }
}