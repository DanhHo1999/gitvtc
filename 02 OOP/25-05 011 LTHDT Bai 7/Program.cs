namespace _25_05_011_LTHDT_Bai_7 {
    internal class Program {
        static void Main(string[] args) {
            HinhTron hinh1 = new HinhTron(new ToaDo(5, 5, "O"), 10.5);
            Console.WriteLine(hinh1.ToString());

            HinhTron hinh2 = new HinhTron(new ToaDo(1, 2, "B"), 3);
            Console.WriteLine(hinh2.ToString());

        }
    }
}