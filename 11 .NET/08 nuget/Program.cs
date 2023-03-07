using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _08_nuget
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
            List<MyStuff> list = JsonConvert.DeserializeObject<List<MyStuff>>(File.ReadAllText("myJson.json"));
            
            Console.WriteLine(list[3]);
            Console.WriteLine("DONE"); Console.Read();
        }
    }
}
