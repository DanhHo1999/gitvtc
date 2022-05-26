namespace _26_05_012_Temp
{
    class Program {
        static void Main(string[] args)
        {

            BaseClass base1 = new BaseClass();
           // Error: base1.protectedInt = 5;

            SubClass sub1 = new SubClass();

            // Error: sub1.protectedInt = 5;
            sub1.publicInt = 5;
        }
    }
}