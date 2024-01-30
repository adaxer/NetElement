using MyCompany.MyProduct.HelloLib;
using System;
using System.IO;

namespace HelloWorld;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, other branch World!");
        File.WriteAllText("somefile.txt", "Hello");
        LibClass class1 = new LibClass();
        class1.CyclePassed += new Action(LibCyclePassed); // new Delegate(Pointer = &LibCyclePas
        class1.CallOne = new Action(LibCyclePassed);
        class1.CallOne();
        class1.Hello();
        SecondLib.LibClass class2 = new SecondLib.LibClass();
        class2.Hello();

        Console.ReadLine();
    }

    private static void LibCyclePassed()
    {
        Console.WriteLine("LibClass 1 cycle");
    }
}
