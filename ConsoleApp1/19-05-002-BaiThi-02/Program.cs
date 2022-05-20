    namespace AAA{
        class Program {
            static void Main(string[] args) {
                //Cau A
                Console.Write("a. Nhap so N: ");
                int N=Convert.ToInt32(Console.ReadLine());

                while (N / 10 != 0) {
                    Console.Write(N%10+" ");
                    N /= 10;
                }
                Console.WriteLine(N%10);





                //Cau B
                Console.Write("b. Nhap so N: ");
                N = Convert.ToInt32(Console.ReadLine());
                
                string str="";
                while (N > 0) {
                    str += N % 2;
                    N /= 2;
                }
                char[] binaryString=str.ToCharArray();
                Array.Reverse(binaryString);
                Console.WriteLine(binaryString);
                    
                { 
                    
                }
            }
        }
    }