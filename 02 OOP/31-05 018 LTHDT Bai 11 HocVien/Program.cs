namespace _31_05_018_LTHDT_Bai_11_HocVien
{
    class Program
    {
        static void Main(string[] args)
        {
            HocVien hv1=new HocVien("AAA", 1994,new float[] {4,6,7,5,6});
            HocVien hv2=new HocVien("BBB", 1992,new float[] {8,2,7,1,6});
            HocVien hv3=new HocVien("CCC", 1995,new float[] {8,6,8,9,6});
            HocVien hv4=new HocVien("DDD", 1996,new float[] {5,6,7,5,6});
            Console.WriteLine(hv1.ToString());
            Console.WriteLine(hv2.ToString());
            Console.WriteLine(hv3.ToString());
            Console.WriteLine(hv4.ToString());
            
        }

    }
}