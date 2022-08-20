using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;



namespace ClassLibrary1
{
    public class Class1
    {
        // kiem tra so nguyen to
         public bool CHECK_SNT(long n)
        {
             int dem = 0;
            if (n < 2) return false;
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0) dem ++;
            } 
            if (dem == 1 )return true ;
            else return false;  
        }
        // Tim so lon nhat 
        public long MAX_PQ(long x, long y)
        {
            long max;
            if (x >= y) max = x;
            else max = y;
            return max;
        }
        // tim uoc chung lon nhat
        public int UOC_CHUNG_LON_NHAT(long x, long y)
        {
          int uoc = 1;
          for (int i=1; i <= x; i++)
          {
              if (x%i == 0 && y%i == 0) uoc = i;
          }
          return uoc;
        }
        // tim so n
        public long TINH_N (long x, long y)
        {
            long n;
            n = x*y;
            return n;
        }
        // tim Ole
        public long TINH_OLE (long x, long y)
        {
            return (x - 1) * (y - 1);
        }
        // tim E
        public long TINH_E (long x, long y)
        {
            long e=(x - 1) * (y - 1),dem=0;
            for (long i=2 ; i<(x - 1) * (y - 1) ; i++ )
            {
                for (long j=2;j<i;j++)
                {
                    if (i % j == 0 && ((x - 1) * (y - 1)) % j == 0) dem++;
                }
                if (dem == 0) 
                {
                    e = i;
                    break;
                }
            }
            return e;

        }
        public List<long> TaoKhoa(long x, long y)
        {
            List<long> Khoa = new List<long>(); // khai báo mảng chứa khóa 1,2 PriKey 3,4 PubKey

            long N = x * y; 
            long phi = (x - 1) * (y - 1); 
            long E = 0;
            for (long i = 17; i < phi; i++) 
            {
                if (UOC_CHUNG_LON_NHAT(i, phi) == 1)
                {
                    E = i;

                    break;
                }
            }
            //long k = nd(soE, phi);

            long k = 1;
            while (((phi * k + 1) % E != 0))
            { k++; }

            long soD = (phi * k + 1) / E; //tính số D

            Khoa.Add(soD);
            Khoa.Add(N);
            Khoa.Add(E);
            Khoa.Add(N);
            return Khoa;
        }
     //   public long TINHA(long m, long d, long n)
     //   {
     //       long kq;
     //       kq = m % n;
     //       for (long f = 1; f < d; f++)
     //       {
     //           kq = (kq * m) % n;
     //       }
     //       return kq;
        public long TINHA(long a, long b, long p)
         {
             long ret = 1;
             a %= p;
             b %= p - 1;
             while (b > 0) //vòng lặp phân tích b thành cơ số 2
             {
                 if (b % 2 > 0)  //ở vị trí có số 1 thì nhân với a^(2^i) tương ứng. Tất cả các phép nhân đều có phép mod p theo sau.
                     ret = ret * a % p;
                 a = a * a % p;  //tính tiếp a^(2^(i+1)), a^1 -> a^2 -> a^4 -> a^8 -> a^16 v.v...
                 b /= 2;
             }
             return (long)ret;
        }
       
       public String getMD5(String txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
           foreach (Byte b in buffer)
           {

               str += b.ToString("x2");
           }
            return str;
        }
       public byte[] hash(string xau)
       {
           byte[] textBytes = Encoding.Default.GetBytes(xau);
           try
           {
               MD5CryptoServiceProvider cryptHandler;
               cryptHandler = new MD5CryptoServiceProvider();
               byte[] hash = cryptHandler.ComputeHash(textBytes);

               return hash;
           }
           catch
           {
               throw;
           }
       }
    }
}
