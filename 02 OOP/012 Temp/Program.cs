namespace _26_05_012_Temp
{
    interface CC
    {
        
    }
    internal class AA {
       public int a = 5;
       public AA(int _a) {
            Console.WriteLine("AA: "+_a);
        }
    }

    internal class BB : CC
    {
        public int b = 6;
        public BB()
        {

            
        }
         
    }
    public class Program {
        static void Main(string[] args)
        {
            BB bb=new BB();
        }
    }
}