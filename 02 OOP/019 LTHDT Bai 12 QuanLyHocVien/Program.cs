namespace _04_06_019_LTHDT_Bai_12_QuanLyHocVien
{
    internal class Program
    {

        static List<Course> courses = new List<Course>();
        static List<Student> students = new List<Student>();
        public static void AddStudenToCourse(string _studentName, string _courseName) {
            Course.GetCourseByName(courses, _courseName).AddStudent(Student.GetStudentByName(students, _studentName));
        }
        public static void ShowCourses() {
            foreach (Course course in courses) {
                Console.Write((courses.IndexOf(course)+1)+" : "+course.GetName());
                Console.Write(", Students: "+course.getStudentList().Count);
                Console.WriteLine();
            }
        }
        public static void ShowStudents() {
            foreach (Student _student in students) {
                Console.WriteLine(_student.ToString());
            }
        }
        public static void Show1Course(int _id) {
            Console.WriteLine();
            courses[_id-1].ShowStudent();
        }
        public static int GetAction() {
            do {
                int action = 0;
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Show All Student");
                    Console.WriteLine("2 - Show All Courses");
                    Console.WriteLine("3 - Show Student in 1 course");
                    Console.Write("Choose: ");
                    action = Convert.ToInt32(Console.ReadLine());
                    
                }
                catch (Exception e)
                {

                }
                Console.WriteLine();
                if (action >= 1 && action <= 4) return action;
            } while (true);
        }
        public static void Main(string[] args)
        {
            students.Add(new Student("NguyenVanA", "LyThuongKiet", "0909 123 456"));
            students.Add(new Student("NguyenVanB", "LyThuongKiet", "2222 222 222"));
            students.Add(new Student("NguyenVanC", "LyThuongKiet", "3333 123 456"));
            students.Add(new Student("NguyenVanD", "LyThuongKiet", "4444 123 456"));
            students.Add(new Student("NguyenVanE", "LyThuongKiet", "5555 123 456"));
            students.Add(new Student("NguyenVanF", "LyThuongKiet", "6666 123 456"));

            courses.Add(new Course("CourseA",DateOnly.FromDateTime(DateTime.Now),30));
            courses.Add(new Course("CourseB",DateOnly.FromDateTime(DateTime.Now),30));
            courses.Add(new Course("CourseC",DateOnly.FromDateTime(DateTime.Now),30));

            
            AddStudenToCourse("NguyenVanA","CourseA");
            AddStudenToCourse("NguyenVanB","CourseA");
            AddStudenToCourse("NguyenVanE","CourseA");
            AddStudenToCourse("NguyenVanF","CourseA");



            AddStudenToCourse("NguyenVanD","CourseB");
            AddStudenToCourse("NguyenVanE","CourseB");
            AddStudenToCourse("NguyenVanF","CourseB");


            AddStudenToCourse("NguyenVanA","CourseC");
            AddStudenToCourse("NguyenVanC","CourseC");
            AddStudenToCourse("NguyenVanD","CourseC");
            AddStudenToCourse("NguyenVanE","CourseC");

            

            int action;
            do {
                action = GetAction(); 
                switch (action) {
                    case 1: ShowStudents(); break;
                    case 2: ShowCourses(); break;
                    case 3: ShowCourses();
                        try { 
                            Console.Write("Course Number: ");
                            Show1Course(Convert.ToInt32(Console.ReadLine()));
                        } catch (Exception e) { }
                        break;
                }

            } while (action >= 1 && action <= 3);

            
            
            
        }
    }
}