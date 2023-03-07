using MyLibraryUtils;
namespace _10_nuget
{
    public class MyStuff
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Brand { get; set; }
        public MyStuff(int _id, string _name, double _price, int _brand)
        {
            id = _id;
            Name = _name;
            Price = _price;
            Brand = _brand;
        }
        public override string ToString()
        {
            this.StuffMethod();
            return $"ID:{id,2}  |Name:{Name,20}  |Price:{Price,10}";
        }

    }
    public static class MyMethods
    {
        public static void StuffMethod(this MyStuff stuff)
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(((double)10150230).NumberToText());
            
        }
    }
}