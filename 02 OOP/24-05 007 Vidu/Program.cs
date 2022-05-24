namespace AAA {
    class Program {
        public class ToaDo{
            int x;
            int y;
            public ToaDo(){ 

            }
            public ToaDo SetX(int _x)
            {
                x = _x;
                return this;
            }
            public ToaDo SetY(int _y)
            {
                y = _y;
                return this;
            }
            public ToaDo showToaDo()
            {
                Console.WriteLine("X = " + x + ", Y = " + y);
                return this;
            }
        }
        static void Main(string[] args) {

            

        }
    }
}