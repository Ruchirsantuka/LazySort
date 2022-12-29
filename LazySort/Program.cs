using ListUtil;
using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var list = new LazySortList<int>();

        Console.WriteLine("Adding items to the list...");
        list.Add(5);
        list.Add(2);
        list.Add(3);
        list.Add(1);
        list.Add(4);

        Console.WriteLine("Displaying the list...");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Removing items from the list...");
        list.Remove(3);
        list.Remove(1);

        Console.WriteLine("Displaying the list...");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        list.Add(10);
        list.Add(1);

        Console.WriteLine("Displaying the list...");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Clearing the list...");
        list.Clear();

        Console.WriteLine("Displaying the list...");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
