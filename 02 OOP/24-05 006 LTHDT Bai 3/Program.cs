namespace AAA {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine((new TamGiac(3,4,5).toString()));
            Console.WriteLine((new TamGiac(0,4,5).toString()));
            Console.WriteLine((new TamGiac(-3,4,5).toString()));
            Console.WriteLine((new TamGiac(8,4,5).toString()));
            Console.WriteLine((new TamGiac(83,4,5).toString()));
        }
    }
}