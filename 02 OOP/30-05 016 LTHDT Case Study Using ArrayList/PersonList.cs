using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_016_LTHDT_Case_Study_Using_ArrayList
{
    internal class PersonList
    {
        List<Person> list;
        public PersonList()
        {
            list = new List<Person>();
        }
        public void Add(Person _person)
        {
            list.Add(_person);
        }
        public static Person InputNewPersonFromUser(PersonList _toThisList)
        {

            string _code;
            do
            {
                Console.Write("New Code: ");
                _code = Console.ReadLine().ToUpper();
                if (_toThisList.FindPerson(_code) != null) Console.WriteLine("Code Existed");

            } while (_toThisList.FindPerson(_code) != null);
            Console.Write("New Name: "); string _name = Console.ReadLine();
            int _age = -1;


            //Bắt nhập lại nếu lỗi:
            do
            {
                try
                {
                    Console.Write("New Age: ");
                    _age = Convert.ToInt32(Console.ReadLine());//Bắt nhập lại nếu lỗi input text không thể convert sang int
                }
                catch { Console.WriteLine("Age Error, retype:"); }
            } while (_age == -1);
            Person newPerson = new Person(_code, _name, _age);
            return newPerson;
        }
        public Person FindPerson(string _code)
        {
            foreach (Person _person in list)
            {
                if (_person.GetCode().Equals(_code))
                {
                    return _person;
                }
            }
            return null;
        }
        public void Remove(string _code)
        {
            list.Remove(FindPerson(_code));
        }
        public void print()
        {
            foreach (Person _person in list)
            {
                Console.WriteLine(_person.ToString());
            }
        }
    }
}
