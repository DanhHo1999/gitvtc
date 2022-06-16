int n = 0;
do
{
    Console.Write("N = ");
    try
    {
        n = Convert.ToInt32(Console.ReadLine());
        if (n <= 50 && n >= 10) break;  //Break loop
        
    }
    catch (Exception) { }
    Console.WriteLine("Integer Required (10-50)");
} while (true);
Console.WriteLine("Good");