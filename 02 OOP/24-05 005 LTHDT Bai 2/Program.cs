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
            public SinhVien SetID(int _id) {
                id = _id;    
                return this;
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
            
            SinhVien sv3 = new SinhVien();
            sv3.SetID(3).SetID(4).SetName("AAA");
        }
    }
}