namespace AAA
{
    class Program
    {
        public class StudentNode
        {
            public int student_id;
            public string name;
            public bool isMale;
            public float point;
            public StudentNode next;

            public StudentNode(int MS, string hoTen, bool isMale, float average, StudentNode svtt)
            {
                this.student_id = MS;
                this.name = hoTen;
                this.isMale = isMale;
                this.point = average;
                this.next = svtt;
            }
            public StudentNode(ref StudentNode last) {
                this.student_id = last.student_id + 1;                                      //Default


                this.name = "Nguyen Van " + Convert.ToChar((last.name.Last<char>() + 1));   //Default
                this.isMale = !last.isMale;                                                 //Default
                this.point = 1 + ((last.name.Last<char>() + 1))%9;                          //Default


                last.next = this;   //Tail.next chỉ vào hs mới
                last = this;        //Hs mới trở thành tail
                
            }
            
            static void XuatSV(ref StudentNode sv)
            {
                string gt;
                if (sv.isMale) gt = "Nam"; else gt = "Nu";
                Console.WriteLine("MS: " + sv.student_id + "     Ho Ten: " + sv.name + "     Gioi tinh: " + gt + "     Average: " + sv.point);
            }
            static void XuatDSHocVien(ref StudentNode svDauTien) {
                StudentNode tam = svDauTien;
                while (tam != null) {
                    XuatSV(ref tam);
                    tam = tam.next;
                }
            }

            static void LietKeTrungBinhLonHon5(ref StudentNode svDauTien) {
                Console.WriteLine("\n\nDanh sach hoc sinh co diem lon hon 5 : ");
                StudentNode tam = svDauTien;
                while (tam != null)
                {
                    if (tam.point >= 5) {
                        XuatSV(ref tam);
                    }
                    tam = tam.next;
                }
            }
            static void LietKeTrungBinhCaoNhat(ref StudentNode svDauTien) {
                Console.WriteLine("\n\nDanh sach hoc sinh co trung binh cao nhat : ");
                StudentNode tam = svDauTien;
                float max = 0;
                while (tam != null) { 
                    if(max<tam.point) max = tam.point;
                    tam=tam.next;
                }
                tam=svDauTien;
                while (tam != null)
                {
                    if (tam.point ==max)
                    {
                        XuatSV(ref tam);
                    }
                    tam = tam.next;

                }
            }
            

            static void DemSoLuongHocVienNam(ref StudentNode svDauTien) {
                Console.Write("\n\nSo luong hoc vien nam : ");
                StudentNode tam = svDauTien;
                int count = 0;
                while (tam != null)
                {
                    if(tam.isMale) count++;
                    tam = tam.next;
                }
                Console.Write(count);
            }
            static void TimSV( ref StudentNode svDauTien) {
                Console.Write("\n\nNhap ma so: ");
                int id = Convert.ToInt32(Console.ReadLine());
                StudentNode tam = svDauTien;
                while (tam != null) {
                    if (tam.student_id == id) {
                        XuatSV(ref tam);
                    }
                    tam = tam.next;    
                }
            }




            static void Main(string[] args)
            {
                StudentNode svDauTien = new StudentNode(1, "Nguyen Van A", true, 9, null);
                StudentNode svCuoiCung = svDauTien;

                //Tao them 10 hoc vien mặc định
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);

                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                new StudentNode(ref svCuoiCung);
                
                //Tao 1 hoc vien
                svCuoiCung.next=new StudentNode(svCuoiCung.student_id+1,"Ho Thanh Danh",true,10,null);  //Tail.next chỉ vào hs mới
                svCuoiCung=svCuoiCung.next;                                                             //Hs mới trở thành tail


                XuatDSHocVien(ref svDauTien);
                LietKeTrungBinhLonHon5(ref svDauTien);
                LietKeTrungBinhCaoNhat(ref svDauTien);
                DemSoLuongHocVienNam(ref svDauTien);

                //Loop TimSV
                while (true) TimSV(ref svDauTien);

            }
        }
    }
}