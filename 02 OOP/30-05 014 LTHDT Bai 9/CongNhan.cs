using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_014_LTHDT_Bai_9
{
    internal class CongNhan
    {
        int maCn;
        string mHo;
        string mTen;
        int mSoSP;
        public int getMaCN() { return maCn; }
        public string getMHo() { return mHo; }
        public string getMTen() { return mTen; }
        public int getSoSP() { return mSoSP; }
        public void SetMaCN(int maCn) { this.maCn = maCn; } 
        public void SetMHo(string mHo) { this.mHo = mHo; }
        public void SetMTen(string mTen) { this.mTen = mTen; }
        public void setSoSP(int soSP) {
            if (soSP > 0) this.mSoSP = soSP;
            else this.mSoSP = 0;
            
        }
        public CongNhan(int _maso) {
            SetMaCN(_maso);
        }
        public CongNhan(int _maSo, string _mHo, string _mTen, int _soSP) {
            SetMaCN(_maSo);
            SetMHo(_mHo);
            SetMTen(_mTen);
            setSoSP(_soSP);
        }
        public double TinhLuong() {
            switch (mSoSP) {
                case int dump when (mSoSP<200): return mSoSP * 0.5;
                case int dump when (mSoSP>=200&&mSoSP<400): return mSoSP * 0.55;
                case int dump when (mSoSP>=400&&mSoSP<600): return mSoSP * 0.6;
                case int dump when (mSoSP>=600): return mSoSP * 0.65;
                default:return 0;
            }
        }
        public string ToString() {
            return String.Format("ID : {0,2} | Ho va ten: {1,20} | So SP: {2,5} | Luong: {3,15:#,##0.00}",maCn,mHo+" "+mTen,mSoSP,TinhLuong());
        }
    }
}
