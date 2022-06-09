using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_05_001_PTBac2
{
    public class PTBac2
    {
        private int A;
        private int B;
        private int C;
        private int delta;
        public PTBac2(int _A, int _B, int _C)
        {
            delta = _B * _B - 4 * _A * _C;
            A = _A;
            B = _B;
            C = _C;
            Console.Write(string.Format("Giai Phuong Trinh Bac 2  |  {0}*X*X + {1}*X + {2} = 0  |  ", A, B, C));
        }
        public void GiaiPhuongTrinh()
        {
            if (delta < 0)
            {
                Console.WriteLine("PTVN");
            }
            else if (delta == 0)
            {
                float N = -B / (2 * A);

                Console.WriteLine("Nghiem Kep: X = " + N);
            }
            else
            {
                double N1 = (-B - Math.Sqrt(delta)) / (2 * A);
                double N2 = (-B + Math.Sqrt(delta)) / (2 * A);

                Console.WriteLine("Nghiem Phan Biet: X1 = " + N1 + ",   X2 = " + N2 + "\n");
            }

        }


    }
}
