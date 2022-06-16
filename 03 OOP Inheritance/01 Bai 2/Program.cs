namespace _01_Bai_2 {
    internal class Program {
        public static void Main(string[] args) {
            SGK[] sGKs = new SGK[3];
            sGKs[0]=new SGK(31,DateOnly.FromDateTime(DateTime.Now),100,3,"NXB A",true);
            sGKs[1]=new SGK(52,DateOnly.FromDateTime(DateTime.Now),300,7,"NXB B",false);
            sGKs[2]=new SGK(12,DateOnly.FromDateTime(DateTime.Now),500,2,"NXB A",true);

            STK[] sTKs=new STK[3];
            sTKs[0] = new STK(155, DateOnly.FromDateTime(DateTime.Now), 321, 23, "NXB B", 1.1);
            sTKs[1] = new STK(32, DateOnly.FromDateTime(DateTime.Now), 112, 12, "NXB A", 1.1);
            sTKs[2] = new STK(51, DateOnly.FromDateTime(DateTime.Now), 200, 5, "NXB B", 1.1);

            double total = 0;
            foreach (var s in sGKs) {
                total += s.ThanhTien();
            }
            Console.WriteLine(String.Format("Thanh Tien SGK : {0,10:#,##0.00}", total));

            total = 0;
            foreach (var s in sTKs)
            {
                total += s.ThanhTien();
            }
            Console.WriteLine(String.Format("Thanh Tien STK : {0,10:#,##0.00}", total));

            total = 0;
            int t = 0;
            foreach (var s in sGKs)
            {
                total += s.getPrice();t++;
            }
            Console.WriteLine(String.Format("Average SGK : {0,10:#,##0.00}", (total/t)));


            total = 0;
            t = 0;
            foreach (var s in sTKs)
            {
                total += s.getPrice(); t++;
            }
            Console.WriteLine(String.Format("Average STK : {0,10:#,##0.00}", (total/t)));

            string str = Console.ReadLine();
            Console.WriteLine("SGK:");
            foreach (var s in sGKs)
            {
                if (String.Equals(s.getNxb(), str)) Console.WriteLine(s.ToString());
            }
            Console.WriteLine("STK:");
            foreach (var s in sTKs)
            {
                if (String.Equals(s.getNxb(), str)) Console.WriteLine(s.ToString());
            }

        }
    }
}