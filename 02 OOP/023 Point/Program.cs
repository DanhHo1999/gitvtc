namespace _023_Point
{
    internal class Program {
        public static void Main(string[] args) { 
            List<Point> points = new List<Point>();
            points.Add(new Point(1,1));
            points.Add(new Point(2,1));
            Console.WriteLine(points[0].Equals(points[1]));
        }
    }
}