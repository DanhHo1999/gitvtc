using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_05_013_LTHDT_Bai_8
{
    internal class CD
    {
        int id;
        string name;
        int songs;
        float price;
        public CD setID(int _id) {
            if (_id > 0)id = _id; else id = 999999;
            return this;
        }
        public CD setName(string _name) {
            if (_name == "" || _name == null)
                name = "Chua xac dinh";
                return this;
        }
        public int getId() {return id;}
        public string getName() {return name;}  
        public int getSongs() {return songs;}
        public float getPrice() {return price;}
        public CD SetSongs(int _songs) {
            if (_songs > 0) songs = _songs;
            return this;
        }
        public CD SetPrice(float _price) { 
            if (_price > 0) price = _price;
            return this;
        }
        public CD(int _id,string _name) {
            setID(_id);
            setName(_name);
        }
        public CD(int _id, string _name,int _songs,float _price)
        {
            setID(_id);
            setName(_name);
            SetSongs(_songs);
            SetPrice(_price);
        }
        public string ToString() {
            return String.Format("{0,4} | {1,15} | {2,5} | {3,20:#,##0.00}",id,name,songs,price);
        }
    }
}
