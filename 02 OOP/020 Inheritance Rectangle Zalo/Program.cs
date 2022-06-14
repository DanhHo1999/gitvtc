namespace _020_Inheritance_Rectangle_Zalo {
    public class Program {
        static void Main(string[] args) { 
            Rectangle r = new Rectangle(2,5);
            Console.WriteLine("Rectangle: "+r.ToString());
            Console.WriteLine("Area: " + r.area());

            Box b = new Box(2, 2, 2);
            Console.WriteLine("Box: "+b.ToString());
            Console.WriteLine("Area: "+b.area());
            Console.WriteLine("Volume: "+b.volume());
        }
    }
}