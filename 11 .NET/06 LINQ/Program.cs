using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LINQ
{
    public class MyStuff { 
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Brand { get; set; }
        public MyStuff(int _id, string _name, double _price,int _brand) { 
            id= _id;
            Name= _name;
            Price= _price;
            Brand= _brand;
        }public MyStuff(int _id, string _name, double _price) { 
            id= _id;
            Name= _name;
            Price= _price;
        }
        public override string ToString() {
            return $"ID:{id,2}  |Name:{Name,20}  |Price:{Price,10}";
        }
    }
    public class WeirdStuff {
        public int id;
        public WeirdStuff(int _id) {
            id= _id;
        }
    }
    public class MyBrand { 
        public int id;
        public string name;
        public static string GetName(List<MyBrand> list,int id)
        {
            foreach (MyBrand brand in list) { 
                if(brand.id==id)return brand.name;
            }
            throw new Exception("No Brand Name Founded");
        }
        public MyBrand(int id, string name) { 
            this.name= name;
            this.id= id;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var myBrands=new List<MyBrand>() { 
                new MyBrand(1,"Brand A"),
                new MyBrand(2,"Brand B"),
                new MyBrand(3,"Brand C")
            };
            var myStuffs = new List<MyStuff>()
            {
                new MyStuff(1,"AAA",100,1),
                new MyStuff(2,"BBB",400),
                new MyStuff(3,"CCC",800,2),
                new MyStuff(4,"ADD",1200,2),
                new MyStuff(5,"EEE",300,1),
                new MyStuff(6,"FFF",120,2),
                new MyStuff(7,"GGA",50,4),
                new MyStuff(8,"HHA",10),
            };
            Console.WriteLine(myStuffs[0]);
            IEnumerable<MyStuff> query = 
                from m in myStuffs.ToList()
                where m.id >3
                select m;
            
            Console.WriteLine("CC");
            var query2 = query.SelectMany((m) =>
            {
                Console.WriteLine($"PROCESSING {m.id}");
                return new string[] { m.id +"-1", m.id +"-2", m.id +"-3", m.id +"-4"};
            });
            Console.WriteLine(query.Count());
            Console.WriteLine(query2.Count());


            var sum= query.Sum((m) => { return null; });

            var normalJoinedList = myStuffs.Join(myBrands, x => { return x.Brand; }, x => { return x.id; },
                (m, b) => {
                    return new {m.Name,b.name };
                }
                ).ToList();
            Console.WriteLine("normalJoinedList");
            foreach (var item in normalJoinedList) Console.WriteLine(item);


            var groupJoinedList = myBrands.GroupJoin(myStuffs, brand => { return brand.id; }, stuff => { return stuff.Brand; },
                (brands, stuffs) => {
                    return new { brand = brands.name,stuffs };
                }
                ).ToList();
            Console.WriteLine("groupJoinedList");
            foreach (var item in groupJoinedList) {
                Console.WriteLine($"{item.brand}        Count:{item.stuffs.Count()}");
            }

            Console.WriteLine("normalJoinedList");
            foreach (var item in normalJoinedList) Console.WriteLine(item);

            Console.WriteLine($"SUM:{sum}");

            myStuffs.OrderBy(x=>x,new MyStuffComparer()).ToList().ForEach((stuff) => { Console.WriteLine(stuff); });
            Console.WriteLine("GroupBy:");
            myStuffs.GroupBy(x => x.Brand)
                .OrderBy(x=>x.Key)
                .Distinct(new MyStupidComparer())
                .ToList().ForEach
                (x => {
                //Console.WriteLine($"Child Group Name:{MyBrand.GetName(myBrands,x.Key)}");
                x.ToList().ForEach((y) => { Console.WriteLine($"{y.Name} - {y.Brand}"); });
            });
            
            Console.WriteLine(myStuffs.SingleOrDefault((x) => { return false; })?.ToString());
            Console.WriteLine(string.Join("\n\n", myBrands)); ;

            IOrderedEnumerable<IGrouping<int, MyStuff>> query3 = from p in myStuffs
                         group p by p.Brand into gr
                         orderby gr.Key
                         select gr;
            query3.ToList().ForEach(group => { Console.WriteLine($"Brand: {""}\nSL:{group.Count()}");
                group.ToList().ForEach(mystuff => { Console.WriteLine(mystuff.ToString()); });
            });
            
            var query4=from p in myStuffs select p;
            Console.WriteLine("\nquery4");
            var kq4 = query4.Join(myBrands, x => x.Brand, x => x.id,
                (stuff, brand) => { return new { ten = stuff.Name, gia = stuff.Price, thuonghieu = brand.name }; }
                );
            var kq5 = from stuff in myStuffs
                      join   brand in myBrands on stuff.Brand equals brand.id
                      orderby brand.id
                      select new { ten = stuff.Name, gia = stuff.Price, thuonghieu = brand.name };
            
            var kq4a=kq4.OrderBy(x => x.thuonghieu);
            Console.WriteLine("kq4");
            kq4.ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
            Console.WriteLine("kq4a");
            kq4a.ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
            Console.WriteLine("kq5");
            kq5.ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
            var kq6= from stuff in myStuffs
                     join brand in myBrands on stuff.Brand equals brand.id 
                     into newTable from brand in newTable.DefaultIfEmpty()
                     select new { ten = stuff.Name, gia = stuff.Price, brand?.id };
            Console.WriteLine("kq6");
            kq6.ToList().ForEach(x => { Console.WriteLine(x.ToString()); });

            Console.Write("DONE"); Console.Read();
        }
    }

    public class MyStupidComparer : IEqualityComparer<IGrouping<int, MyStuff>>
    {
        public bool Equals(IGrouping<int, MyStuff> x, IGrouping<int, MyStuff> y)
        {
            
            return true;
        }

        public int GetHashCode(IGrouping<int, MyStuff> obj)
        {
            return 999 ;
        }
    }
    public class MyStuffComparer : IComparer<MyStuff>
    {
        public int Compare(MyStuff x, MyStuff y)
        {
            if(x.Price>y.Price) return 1;else if(x.Price<y.Price)return -1;else
            return 0;
        }
    }
}
