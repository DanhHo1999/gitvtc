using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Drives
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public void Save(Stream stream)
        {
            byte[] bytes_id = BitConverter.GetBytes(Id);
            stream.Write(bytes_id, 0, 4);

            byte[] bytes_price = BitConverter.GetBytes(Price);
            stream.Write(bytes_price, 0, 8);

            byte[] bytes_name = Encoding.UTF8.GetBytes(Name);
            byte[] bytes_length = BitConverter.GetBytes(bytes_name.Length);
            stream.Write(bytes_length, 0, 4);
            stream.Write(bytes_name, 0, bytes_name.Length);
        }
        public void Restore(Stream stream) { 
            byte[] bytes_id = new byte[4];
            stream.Read(bytes_id, 0, 4);
            Id = BitConverter.ToInt32(bytes_id, 0);

            byte[] bytes_price = new byte[8];
            stream.Read(bytes_price, 0, 8);
            Price = BitConverter.ToDouble(bytes_price, 0);

            
            byte[] bytes_length = new byte[4];
            stream.Read(bytes_length, 0, 4);
            
            byte[] bytes_name = new byte[BitConverter.ToInt32(bytes_length, 0)];
            stream.Read(bytes_name, 0, BitConverter.ToInt32(bytes_length, 0));
            Name=Encoding.UTF8.GetString(bytes_name);
        }
    }
    internal class Program
    {
        public static void ListFilesAndDirectories(string _dir)
        {
            var files= Directory.GetFiles(_dir).ToList();files.Sort();
            foreach (var file in files) Console.WriteLine($"Files: {file}");

            var dirs = Directory.GetDirectories(_dir).ToList();dirs.Sort();
            foreach (var dir in dirs) {
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Dirs:  {dir}");
                ListFilesAndDirectories(dir);
            }
        }
        static void Main(string[] args)
        {
            string path = "data.dat";
            var stream =new FileStream(path,FileMode.OpenOrCreate);
            //Product product = new Product() { Id = 10, Price = 12345, Name = "San Pham ABC" };
            //product.Save(stream);
            Product product = new Product();
            product.Restore(stream);
            Console.WriteLine($"ID:{product.Id}\nName:{product.Name}\nPrice:{product.Price}");
            Console.WriteLine("Done"); Console.Read();
        }
    }
}
