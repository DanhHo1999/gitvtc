namespace _24_05_009_LTHDT_Bai_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            HangThucPham.SetToday(2018, 6, 1);
            Console.WriteLine(String.Format("{0,4} | {1,8} | {2,20} | {3,10} | {4,10} | {5}\n",
                "ID", "Name", "Price", "NSX", "HSD", "Kiem Tra"));




            HangThucPham gao = new HangThucPham(1, "Gao", 100000);
            gao.SetNsx(2018, 7, 10);
            gao.SetHsd(new DateOnly(2018, 7, 10));
            Console.WriteLine(gao.ToString());




            HangThucPham mi = new HangThucPham(2, "Mi", 5000,
                new DateOnly(2018, 3, 1),
                new DateOnly(2018, 9, 1)
                );
            Console.WriteLine(mi.ToString());




            HangThucPham nuoc = new HangThucPham(3, "Nuoc", 9999);
            nuoc.SetID(5);
            nuoc.SetPrice(10000);
            nuoc.SetNsx(2017, 3, 1);
            nuoc.SetHsd(2018, 3, 1);
            Console.WriteLine(nuoc.ToString());


            HangThucPham traSua = new HangThucPham(4, "Tra Sua", 50000);
            traSua.SetNsx(2022, 1, 1); // -> Fail: NSX>Today -> NSX = Today(default) = 1/6/2018
            traSua.SetHsd(2022, 2, 1);
            Console.WriteLine(traSua.ToString());

            HangThucPham miCay = new HangThucPham(5, "Mi Cay", 1000000);
            miCay.SetNsx(2018, 2, 2);
            miCay.SetHsd(2017, 1, 1); // -> Fail : HSD < NSX -> HSD = NSX
            Console.WriteLine(miCay.ToString());
        }
    }
}