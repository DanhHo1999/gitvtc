using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_019_LTHDT_Bai_12_QuanLyHocVien
{
    internal class Student
    {
        string name;
        string address;
        string phone;
        public string getName() { return name; }
        public string getAddress() { return address; }
        public string getPhone() { return phone; }
        public void setName(string name) { this.name = name; }
        public void setAddress(string address) { this.address = address; }
        public void setPhone(string phone) { this.phone = phone; }
        public Student(string _name, string _address, string _phone) {
            setName(_name);
            setAddress(_address);
            setPhone(_phone);
        }
        public override string ToString() {
            return String.Format("Ten : {0,10} | Dia Chi : {1,10} | SDT: {2,15}",name,address,phone);
        }
        public static Student GetStudentByName(List<Student> _studentList,string _name)
        {
            foreach (Student _student in _studentList)
            {
                if (String.Equals(_student.getName(), _name))
                {
                    return _student;
                }
            }
            return null;
        }
    }
}
