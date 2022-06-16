using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_019_LTHDT_Bai_12_QuanLyHocVien
{
    internal class Course
    {
        string name;
        DateOnly startDate;
        int days;
        List<Student> studentList;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }
        public DateOnly GetStartDate() { return startDate; }
        public void SetStartDate(DateOnly startDate) { this.startDate = startDate; }
        public int GetDays() { return days; }
        public void SetDays(int days) { this.days = days; }
        public List<Student> getStudentList() { return studentList; }
        
        
        
        public Course(string _name, DateOnly _startDate, int _days) {
            studentList = new List<Student>();
            SetName(_name);
            SetStartDate(startDate);
            SetDays(days);
        }
        public void AddStudent(Student _student) { 
            if(studentList.Count <= 20) studentList.Add(_student);
        }
        public void RemoveStudent(Student _student) { 
            studentList.Remove(_student);
        }
        public static Course GetCourseByName(List<Course> _courses,String _name) {
            foreach (Course _course in _courses) { 
                if(String.Equals(_name,_course.GetName()))return _course;
            }
            return null;
        }
        public void ShowStudent() {
            Console.WriteLine("Course : "+name);
            foreach (Student _student in studentList) {
                Console.WriteLine(_student.ToString());
            }
        }
    }
}
