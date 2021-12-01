using AdventCommon;
using System.Linq;

var input = ConsoleHelpers
    .ReadInput()
    .Select(i => int.Parse(i))
    .ToArray();

var gt = 0;

var getWindow = (int i) => input.Skip(i).Take(3).Sum();

for (var i = 0; i < input.Length; i++)
{
    if (getWindow(i + 1) > getWindow(i))
    {
        gt++;
    }
}

Console.WriteLine(gt);