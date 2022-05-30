namespace _30_05_014_LTHDT_Bai_9 {
    internal class Program {
        static void Main(string[] args) {
            CongNhan a = new CongNhan(1,"Ho","Danh",100);
            Console.WriteLine(a.ToString());


            CongNhan[] list = new CongNhan[5];
            list[0] = a;
            Console.WriteLine(list.Length);
        }
    }
}