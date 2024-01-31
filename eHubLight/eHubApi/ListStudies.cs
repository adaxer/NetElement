namespace eHubApi;

public class ListStudies
{
    public void Call()
    {

        var list = new List<string>();
        var things = list.Where(s => true).Select(s => s.Length).Where(l => l > 10).Distinct().OrderBy(l => l);

        //var result = things.Last();

        foreach (var thing in things)
        {

        }

        var enumerator = things.GetEnumerator();
        enumerator.Reset();
        while (enumerator.MoveNext())
        {
            var thing = enumerator.Current;
        }

        var stack = new Stack<string>();
        var queue = new Queue<string>();

        var even = new List<int> { 2,4,6,8,10 };
        var odd = new List<int> { 1, 3, 5, 7, 9 }; // zip = (2,1), (4,3), (6,5)...
        var diffs = even.Zip(odd).Select(z => z.Second - z.First).ToList();
    }
}
