namespace _26_05_012_Temp
{
    public abstract class AA {
       protected AA(int _a) {
            Console.WriteLine("HHH: "+_a);
        }
    }

    internal class CC : AA
    {
        public CC(int _b):base(_b+1)
        {
            Console.WriteLine(_b);
        }
         
    }
    public class Program {
        static void Main(string[] args)
        {
            CC bb = new CC(2);
            var a= new AAA();
        }
    }
}