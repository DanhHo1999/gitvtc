namespace AAA
{
    class Program
    {
        public class SinhVien {
            private int id;
            private string name;
            private float TH, LT;
            public SinhVien() { }
            public SinhVien(int _id, string _name,float _TH, float _LT)
            {
                id = _id;
                name= _name;
                TH = _TH;
                LT = _LT;
            }
            public void SetID(int _id) {
                id = _id;    
            }
            public void SetName(string name) {
                this.name = name;
            }
            public string GetName() { 
                return this.name;
            }
            public int GetID() { 
                return id;
            }
            public void SetTH(float TH) { 
                this.TH= TH;
            }
            public void SetLT(float LT) { 
                this.LT= LT;
            }
            public float GetLT() { 
                return LT;
            }
            public float GetTH() {
                return TH;
            }
            public String toString()
            {
                String str = String.Format("Id : {0}    |    Name : {1,10}    |    LT : {2}    |    TH : {3}    |    TB : {4,5:N2}", id, name, LT, TH, (LT + TH) / 2);
                return str;
            }

        }
        static void Main(string[] args)
        {
            SinhVien sv1 = new SinhVien(1, "Danh", 5, 8);
            SinhVien sv2 = new SinhVien(2, "Phong", 7, 6);


            SinhVien sv3 = new SinhVien();
            sv3.SetID(3);
            Console.Write("Name = "); sv3.SetName(Console.ReadLine());
            Console.Write("LT = "); sv3.SetLT(Convert.ToInt32(Console.ReadLine()));
            Console.Write("TH = "); sv3.SetTH(Convert.ToInt32(Console.ReadLine()));

            
            Console.WriteLine(sv1.toString());
            Console.WriteLine(sv2.toString());
            Console.WriteLine(sv3.toString());
        }
    }
}