namespace AAA
{
    class Program
    {

        static void Main(string[] args)
        {
            PTBac2 pt1 = new PTBac2().CreateNew(1, 9, 0);
            pt1.GiaiPhuongTrinh();

            new PTBac2().CreateNew(3, 9, 0).GiaiPhuongTrinh();

            new PTBac2().CreateNew(6, 9, 0).GiaiPhuongTrinh();

            new PTBac2().CreateNew(5, 2, 0).GiaiPhuongTrinh();

        }
    }
}