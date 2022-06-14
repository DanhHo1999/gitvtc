namespace _021_Inheritance_Bai_1
{
    public class Program {
        public static void Main(string[] args) {
            ChuyenNoiThanh[] chuyenNoiThanhs = new ChuyenNoiThanh[2];
            chuyenNoiThanhs[0] = new ChuyenNoiThanh(1,"AAA",12,3,100,200);
            chuyenNoiThanhs[1] = new ChuyenNoiThanh(2,"BBB",15,2,50,100);
            ChuyenNgoaiThanh[] chuyenNgoaiThanhs= new ChuyenNgoaiThanh[2];
            chuyenNgoaiThanhs[0] = new ChuyenNgoaiThanh(3,"CCC",20,"ABCD",5,200);
            chuyenNgoaiThanhs[1] = new ChuyenNgoaiThanh(4,"DDD",20,"DDDD",3,120);
            int tong=0;
            for (int i = 0; i < chuyenNoiThanhs.Length; i++) { 
                tong+=chuyenNoiThanhs[i].getIncome();
            }
            Console.WriteLine("Tong Chuyen Noi Thanh: "+tong);
            int tong2=0;
            for (int i = 0; i < chuyenNgoaiThanhs.Length; i++) { 
                tong2+= chuyenNgoaiThanhs[i].getIncome();
            }
            Console.WriteLine("Tong Chuyen Noi Thanh: "+tong2);
            Console.WriteLine("Tong: "+(tong+tong2));
        }
    }
}