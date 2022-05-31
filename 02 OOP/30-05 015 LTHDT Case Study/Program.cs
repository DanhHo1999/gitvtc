namespace _30_05_015_LTHDT_Case_Study {
    class Program {
        static void Main(string[] args)
        {
            
            Menu a = new Menu(3);
            a.AddHints("Print");
            a.AddHints("Add");
            a.AddHints("Remove");
            PersonList danhSach = new PersonList(3);
            int choice;
            do {
                Console.WriteLine(); 
                choice = a.getChoice();
                switch (choice) {
                    case 1:
                        Console.WriteLine(); danhSach.print();
                        break;
                    case 2:
                        string newCode="";int result;
                        do {
                            Console.Write("Input New Code: ");newCode = Console.ReadLine().ToUpper();
                            result=danhSach.FindPerson(newCode);
                            if (result != -1) Console.WriteLine("Code Existed");
                        }while (result>=0);
                        Console.Write("Input New Name: ");string _name=Console.ReadLine();
                        Console.Write("Input Age: ");int _age=Convert.ToInt32(Console.ReadLine());
                        danhSach.Add(new Person(newCode,_name,_age));
                        break;
                    case 3:
                        Console.Write("Input Code: ");
                        danhSach.Remove(Console.ReadLine().ToUpper());break;
                    
                }
            } while (choice > 0&choice<4);

            
        }
    }
}