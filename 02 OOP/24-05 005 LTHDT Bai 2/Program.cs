namespace AAA
{
    class Program
    {
        public class SinhVien {
            private int id;
            private string name;
            private float TH, LT;
            public SinhVien(int _id, string _name) { 
                id = _id;
                name = _name;
            }
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
            public String ToString() {
                String str = "";
                return str;
            }

        }
        static void Main(string[] args)
        {
            
        }
    }
}