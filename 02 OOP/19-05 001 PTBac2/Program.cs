namespace AAA
{
    class Program
    {
        
        static void Main(string[] args)
        {
            PTBac2 pt1 = new PTBac2(1, 9, 0);
            pt1.GiaiPhuongTrinh();

            PTBac2 pt2 = new PTBac2(3, 9, 0);
            pt2.GiaiPhuongTrinh();

            pt1 = new PTBac2(6, 9, 0);
            pt1.GiaiPhuongTrinh();

            pt1=new PTBac2(5, 2, 0);
            pt1.GiaiPhuongTrinh();
        }
    }
}