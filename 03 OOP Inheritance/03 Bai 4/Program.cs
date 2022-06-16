namespace _03_Bai_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GiaoDichDat[] dats = new GiaoDichDat[4];
            dats[0] = new GiaoDichDat(1, 100, "B",100);
            dats[1] = new GiaoDichDat(2, 200, "C", 500);
            dats[2] = new GiaoDichDat(3, 400, "A", 110);
            dats[3] = new GiaoDichDat(4, 300, "A", 320);

            GiaoDichNha[] nhas = new GiaoDichNha[4];
            nhas[0] = new GiaoDichNha(5, 241, "thuong","AAA", 200);
            nhas[1] = new GiaoDichNha(6, 141, "thuong","BBB", 100);
            nhas[2] = new GiaoDichNha(6, 3441, "thuong","CCC", 50);
            nhas[3] = new GiaoDichNha(7, 241, "thuong", "DDD", 200);
            double total = 0;
            int t = 0;
            foreach (GiaoDichDat dat in dats) {
                total += dat.GetDienTich();
            }
            Console.WriteLine("Tong Dien Tich Dat: "+total);
            total = 0;
            foreach (var nha in nhas) {
                total += nha.GetDienTich();
            }
            Console.WriteLine("Tong Dien Tich Nha: "+total);
            foreach (GiaoDichDat dat in dats)
            {
                t++;
                total += dat.ThanhTien();
            }
            Console.WriteLine("Average Dat: " + (total / t));
            t = 0;total = 0;
            foreach (var nha in nhas)
            {
                t++;
                total += nha.ThanhTien();
            }
            Console.WriteLine("Average Nha: " + (total / t));
        }
    }
}