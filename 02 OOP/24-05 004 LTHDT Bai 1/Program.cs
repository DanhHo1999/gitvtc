namespace AAA {
    class Program {
        public class ToaDo
        {
            private int x;
            private int y;
            public ToaDo() { }
            public ToaDo(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int getX() { return x; }
            public int getY() { return y; }
            public void setX(int x) { this.x = x; }
            public void setY(int y) { this.y = y; }
            public String toString() {
                String str = "X : " + x + ", Y : " + y;
                return str;
            }

        }
        static void Main(string[] args) { 
            ToaDo toaDo = new ToaDo(3,8);
            Console.WriteLine(toaDo.toString());
        }
    }
}