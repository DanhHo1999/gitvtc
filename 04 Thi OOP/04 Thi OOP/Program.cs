namespace _04_Thi_OOP
{
    internal class Program
    {
        static ListXeTai trucks = new ListXeTai();
        static ListXeKhach cars = new ListXeKhach();
        public static void Main(string[] args)
        {
            cars.AddXe(new XeKhach("XeK_A", "AA11", "Danh", 5, 10000, 15)); //Fail so ghe 12,30,45
            cars.AddXe(new XeKhach("XeK_A", "AA11", "Danh", 5, 100000, 12));
            cars.AddXe(new XeKhach("XeK_A", "BB22", "Danh", 5, 20000, 30)); //Fail ID
            cars.AddXe(new XeKhach("XeK_B", "BB22", "Danh", 5, 2000000, 30));
            cars.AddXe(new XeKhach("XeK_C", "BB22", "Danh", 2, 30000, 12)); //Fail So xe
            cars.AddXe(new XeKhach("XeK_C", "CC33", "Danh", 2, 30000, 12));
            cars.AddXe(new XeKhach("XeK_D", "DD44", "Danh", 10, -1000, 45));  //Fail Gia ve < 0
            cars.AddXe(new XeKhach("XeK_D", "DD44", "Danh", 10, 10000, 45));

            cars.Traversal();
            Console.WriteLine();

            cars.RemoveByID("XeK_C");
            cars.Traversal();

            cars.ShowTotalPrice();
            Console.WriteLine();

            cars.Sort();
            cars.Traversal();

            Console.WriteLine();Console.WriteLine();Console.WriteLine();
            trucks.AddXe(new XeTai("XeT_A", "EE55", "Danh", 10, 1000000));
            trucks.AddXe(new XeTai("XeT_B", "FF66", "Danh", 20, 1000000));
            trucks.AddXe(new XeTai("XeT_C", "FF66", "Danh", 10, 1000000)); //Fail
            trucks.AddXe(new XeTai("XeT_C", "GG77", "Danh", 12, 50000));
            trucks.AddXe(new XeTai("XeT_C", "DD88", "Danh", 2, 3000000)); //Fail
            trucks.AddXe(new XeTai("XeT_D", "DD88", "Danh", 2, 3000000));

            trucks.Traversal();
            Console.WriteLine();

            trucks.RemoveByID("XeT_C");
            trucks.Traversal();

            trucks.ShowTotalPrice();
            Console.WriteLine();

            trucks.Sort();
            trucks.Traversal();

        }
    }
}