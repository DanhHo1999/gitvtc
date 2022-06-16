namespace _02_Bai_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GiaoDichVang[] vangs = new GiaoDichVang[3];
            vangs[0] = new GiaoDichVang(1,100,10,"sk");
            vangs[1] = new GiaoDichVang(3,200,12,"KG");
            vangs[2] = new GiaoDichVang(7,3100,2,"A");

            GiaoDichTienTe[] tiens=new GiaoDichTienTe[3];
            tiens[0] = new GiaoDichTienTe(51, 3, 10, 20000, "usd");
            tiens[1] = new GiaoDichTienTe(22, 10000, 17, 1, "vn");
            tiens[2] = new GiaoDichTienTe(13, 3, 15, 18000, "ca");

            double total = 0;
            foreach (GiaoDichVang vang in vangs)
            {
                Console.Write(vang.GetQuantity() + (vang == vangs[vangs.Count<GiaoDichVang>() - 1] ? " = " : " + "));
                total += vang.GetQuantity();
            }
            Console.WriteLine(total);
            total = 0;
            foreach (GiaoDichTienTe tien in tiens)
            {
                Console.Write(tien.GetQuantity() + (tien == tiens[tiens.Count<GiaoDichTienTe>() - 1] ? " = " : " + "));
                total += tien.GetQuantity();
            }
            Console.WriteLine(total);


            total = 0;
            int t = 0;

            foreach (GiaoDichVang vang in vangs)
            {
                t++;
                total += vang.ThanhTien();
            }
            Console.WriteLine(total/t);

            t = 0; total = 0;
            foreach (var tien in tiens)
            {
                t++;
                total += tien.ThanhTien();
            }
            Console.WriteLine(total/t);

        }
    }
}