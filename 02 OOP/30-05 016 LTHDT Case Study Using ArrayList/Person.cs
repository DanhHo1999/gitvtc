using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_016_LTHDT_Case_Study_Using_ArrayList
{
    internal class Person
    {
        string code;
        string name;
        int age;
        public Person(string code, string name, int age)
        {
            this.code = code.ToUpper();
            this.name = name;
            this.age = age;
        }
        public void SetCode(string _code) { code = _code.ToUpper(); }
        public void SetName(string _name) { name = _name; }
        public void SetAge(int _age) { age = _age; }
        public string GetCode() { return code; }
        public string GetName() { return name; }
        public int GetAge() { return age; }
        public string ToString() { return string.Format("Code: {0}, Name: {1}, Age: {2}", code, name, age); }
    }
}
