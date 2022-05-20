namespace App
{
    class Program
    {
        //Hiện danh sách từ N -> 0
        static void Show(int N)
        {
            if (N >= 0)
            {
                Console.Write(N + " ");
                N = N - 1;
                Show(N);
            }
            return;
        }
        static void Main(string[] args)
        {

            Show(5);
        }
    }
}