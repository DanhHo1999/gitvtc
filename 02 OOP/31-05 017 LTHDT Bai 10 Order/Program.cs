namespace _31_05_017_LTHDT_Bai_10_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product sp1=new Product("Gao", "sp1",18000);
            Product sp3=new Product("Duong", "sp3",10000);
            Product sp4=new Product("Nuoc Tuong", "sp4",8000);

            Order order = new Order(5,10, DateOnly.FromDateTime(DateTime.Now));
            order.AddLineItem(sp4, 10);
            order.AddLineItem(sp1, 5);
            order.AddLineItem(sp3, 1);
            order.AddLineItem(sp1, 1);

            Console.WriteLine(order.ToString());
        }
    }
}