namespace _24_05_006_LTHDT_Bai_3
{
    class Program
    {

        static void Main(string[] args)
        {
            Triangle t = new Triangle(20, 15, 10);
            string str = t.toString();
            Console.WriteLine(str);

            Console.WriteLine(new Triangle(3, 4, 5).toString());
            Console.WriteLine(new Triangle(20, 15, 10).toString());
            Console.WriteLine(new Triangle(0, 4, 5).toString());
            Console.WriteLine(new Triangle(-3, 4, 5).toString());
            Console.WriteLine(new Triangle(83, 4, 5).toString());
            Console.WriteLine(new Triangle(8, 4, 5).toString());
        }
    }
}