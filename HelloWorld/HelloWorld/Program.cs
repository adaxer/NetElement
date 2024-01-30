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
        class1.Hello();
    }
}
