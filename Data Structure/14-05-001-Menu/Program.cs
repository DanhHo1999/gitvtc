namespace AAA
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("A = "); int A= Convert.ToInt32(Console.ReadLine());
            Console.Write("B = "); int B= Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("\nA = "+A+", B = "+B);
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Minus");
                Console.WriteLine("3. Mul");
                Console.WriteLine("4. Div");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");
                n=Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    Console.WriteLine(A + " + " + B + " = " + (A + B));
                }
                else if (n == 2) {
                    Console.WriteLine(A + " - " + B + " = " + (A - B));
                }else if (n == 3) {
                    Console.WriteLine(A + " * " + B + " = " + (A * B));
                }else if (n == 4) {
                    Console.WriteLine(A + " / " + B + " = " + (A / B));
                }
            } while (n!=5);
        }
    }
}