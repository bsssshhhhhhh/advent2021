using AdventCommon;
using System.Linq;

var input = ConsoleHelpers
    .ReadInput()
    .Select(i => int.Parse(i))
    .ToArray();

var gt = 0;
for (var i = 1; i < input.Length; i++)
{
    if (input[i] > input[i - 1])
    {
        gt++;
    }
}

Console.WriteLine(gt);