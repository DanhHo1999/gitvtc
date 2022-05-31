namespace _30_05_016_LTHDT_Case_Study_Using_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu(3);
            menu.AddHints("Print");
            menu.AddHints("Add");
            menu.AddHints("Remove");
            PersonList danhSach = new PersonList();
            int choice;
            do
            {
                Console.WriteLine();
                choice = menu.GetChoiceFromUser();
                switch (choice)
                {
                    case 1:
                        danhSach.print();
                        break;
                    case 2:
                        danhSach.Add(PersonList.InputNewPersonFromUser(danhSach));
                        break;
                    case 3:
                        danhSach.Remove(Console.ReadLine().ToUpper());
                        break;
                }
            } while (choice > 0 & choice < 4);


        }
    }
}