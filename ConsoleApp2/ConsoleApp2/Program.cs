using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = 36;
        int[] a = new int[10] { 3, 4, 5, 36, 45, 2, 94, 7, 4, 2 };
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == n) Console.WriteLine("111");
        }
        for (int i = a.Length - 1; i >= 0; i--)
        {
            if (a[i] == n) Console.WriteLine("222");
        }
        foreach (int i in a) {
            if (i == n) Console.WriteLine("333");
        }

        for (int i = 0; i < a.Length; i += 3) {
            if (a[i] == n) Console.WriteLine("444");
        }
        for (int i = 1; i < a.Length; i += 3)
        {
            if (a[i] == n) Console.WriteLine("444");
        }
        for (int i = 2; i < a.Length; i += 3)
        {
            if (a[i] == n) Console.WriteLine("444");
        }
    }
    
}