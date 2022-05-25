namespace _24_05_008_LTHDT_Bai_4 {
    internal class Program {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("{0,20} {1,20} {2,20} {3,20} {4,15}", "Owner", "Type", "Capacity", "Price", "Tax"));

            Vehicle xe1 = new Vehicle("Nguyen Thu Loan", "Future Neo", 35000000, 100);
            Console.WriteLine(xe1.toString());

            Vehicle xe2 = new Vehicle("Le Minh Tinh", "Ford Ranger", 250000000, 3000);
            Console.WriteLine(xe2.toString());

            Console.WriteLine(new Vehicle("Nguyen Minh Triet", "Landscape", 1000000000, 1500).toString());
        }
    }
}

