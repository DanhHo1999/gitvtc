namespace _26_05_013_LTHDT_Bai_8 {
    class Program {
        static void Main(string[] args) {

            CDList list = new CDList(5);
            list.AddCD(new CD(1, "DD",3,10000));
            list.AddCD(new CD(2, "CC", 10, 40000));
            list.AddCD(new CD(3, "AA", 5, 200000));
            list.AddCD(new CD(4, "BB", 2, 20000));
            list.AddCD(new CD(5, "EE", 6, 100000));
            

            
            Console.WriteLine("CD number: "+list.GetCDNum());

            Console.WriteLine("Total Price: "+list.TotalPrice().ToString("#,###0.00 VND")+"\n\n");

            list.toString();

            list.PriceDescending().toString();

            list.NameAscending().toString();

            list.DefaultSort().toString();

            
            
        }
    }
}