using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_015_LTHDT_Case_Study
{
    internal class PersonList
    {
        Person[] list;
        int n = 0;
        public PersonList(int _size) {
            list = new Person[_size];
        }
        public int FindPerson(string _code) {
            for (int i = 0; i < n; i++) {
                if (_code.Equals(list[i].GetCode())) { 
                    return i;
                }
            }
            return -1;
        }
        public void Add(Person _person)
        {
            if (n >= list.Length) Console.WriteLine("Failed: Max Persons.");
            else list[n++] = _person;
        }
        public void Remove(string _code)
        {
            if (FindPerson(_code) == -1)
            {
                Console.WriteLine("Not Existed");
                return;
            }
            Remove(FindPerson(_code));
        }
        private void Remove(int _index) {
            if (_index == list.Length-1) { n--;list[_index] = null; }
            for (int i = _index; i < n; i++) {
                list[i] = list[i + 1];
                n--;
            }
        }
        public void print() {
            for (int i = 0; i < n; i++) {
                Console.WriteLine(list[i].ToString());
            }
        }
    }
}
