using MyCompany.MyProduct.HelloLib.Helpers;
using System.Diagnostics;

namespace MyCompany.MyProduct.HelloLib;

public class LibClass // komplett öffentlich
{
    private int _counter;   // nur in der Klasse und nested Klassen
    protected int _internalId; // nur bis abgeleitete Klasse
    public string WrongName = "";  // Felder nicht public machen und nicht Groß schreiben

    private string _name = "";

    public LibClass()
    {
        AutoName = Name + WrongName + "BMW";
        //Name = AutoName = "beide";
        StartCycle();
    }

    private async void StartCycle()
    {
        while (true)
        {
            try
            {
                //SecondCycle(); // Nie!!
                //await ThirdCycle(); // Ok
                await Task.Delay(5000);
                CyclePassed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Thread.Sleep(1000);
        }
    }

    async void SecondCycle()
    {
        await Task.Delay(1000);
        throw new Exception("oops");
    }

    async Task ThirdCycle()
    {
        await Task.Delay(1000);
        throw new Exception("oops");
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public event Action CyclePassed = () => { };

    public Action? CallOne;

    public bool OptionalParams(int value, string stringVal = "", string otherStringVal = "")
    {
        return value > 0; ;
    }

    public double Max(params object[] values)
    {
        double result = double.MinValue;
        foreach (object value in values)
        {
            if (double.TryParse(value.ToString(), out var aDouble))
            {
                if (aDouble > result)
                {
                    result = aDouble;
                }
            }
        }
        return result;
    }

    public double ElegantMax(params object[] values)
    {
        double? d = null;
        Nullable<double> d2 = d;

        string[,] twoD = new string[4, 3];
        //(string[])[] alsoTwoD = 

        double? asDouble(string input)
        {
            return double.TryParse(input, out var result)
                ? result
                : null;
        }

        return values
            .Select(o => o.ToString())
            .Select(s => asDouble(s!))
            .Where(d => d != null)
            .Select(d => d!.Value)
            .Max();

        //return values
        //    .Select(o => o.ToString())
        //    .Where(s => double.TryParse(s, out var aDouble))
        //    .Select(s => double.Parse(s!))
        //    .Max();
    }

    //[Inject]
    public string? AutoName { get; }

    public void Hello()
    {
        int counter = 0;
        Console.WriteLine("HelloLib.LibClass" + counter++);
        // AutoName = null; geht nicht mehr

        Console.WriteLine(OptionalParams(1, otherStringVal: "other"));

        Console.WriteLine(Max("42", 2, false, 3.7, "Hundert"));
    }

    private class Innerclass()
    {

    }
}

public class SpecializedLibClass : LibClass
{
    public void Hello1()
    {
        this._internalId = 0;
        var helper = new HelperClass();
    }
}
