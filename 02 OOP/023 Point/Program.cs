namespace _023_Point
{
    internal class Program {
        public static void Main(string[] args) { 
            List<Point> points = new List<Point>();
            points.Add(new Point(4,1));
            points.Add(new Point(1,4));
            points.Add(new Point(8,5));
            points.Add(new Point(1,2));
            points.Add(new Point(1,2));
            points.Add(new Point(2,2));
            points.Add(new Point(1,4));
            points.Add(new Point(3,2));
            points.Add(new Point(1,2));
            points.Add(new Point(5,2));
            points.Add(new Point(2,2));
            points.Add(new Point(4,1));

            points.Sort();

            foreach (Point p in points)
            {
                Console.WriteLine(p.getX() + "," + p.getY());
            }
        }
    }
}