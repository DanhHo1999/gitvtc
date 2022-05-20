namespace AAA
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Ax + Bx + C = 0");
                Console.Write("A = "); int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("B = "); int b = Convert.ToInt32(Console.ReadLine());
                Console.Write("C = "); int c = Convert.ToInt32(Console.ReadLine());
                int del = b * b - 4 * a * c;
                if (del < 0) Console.WriteLine("PTVN");
                else if (del == 0) Console.WriteLine("x1 = x2 = " + ((-b - Math.Sqrt(del)) / 2 / a));
                else
                {
                    Console.WriteLine("x1 = " + ((-b - Math.Sqrt(del)) / 2 / a));
                    Console.WriteLine("x2 = " + ((-b + Math.Sqrt(del)) / 2 / a));
                }
                Console.WriteLine();
            }
        }
    }
}