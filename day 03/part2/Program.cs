using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

var len = lines[0].Length;
var numbers = lines.Select(x => Convert.ToInt32(x, 2)).ToArray();

var getBitAtPosition = (int num, int pos) => (num & (1 << pos)) != 0 ? 1 : 0;
var countOnesAtPosition = (int[] nums, int pos) => nums.Count((num) => getBitAtPosition(num, pos) == 1);



var co2SearchSpace = (int[]) numbers.Clone();
for (var i = len - 1; i >= 0; i--)
{
    if (co2SearchSpace.Length == 1)
    {
        break;
    }

    var leastPopular = Enumerable
        .Range(0, len)
        .Select((i) => countOnesAtPosition(co2SearchSpace, i) < co2SearchSpace.Length / 2m ? 1 : 0)
        .ToArray();

    co2SearchSpace = co2SearchSpace.Where(x => leastPopular[i] == getBitAtPosition(x, i)).ToArray();
}

var oxySearchSpace = (int[]) numbers.Clone();
for (var i = len - 1; i >= 0; i--)
{
    if (oxySearchSpace.Length == 1)
    {
        break;
    }

    var mostPopular = Enumerable
        .Range(0, len)
        .Select((i) => countOnesAtPosition(oxySearchSpace, i) >= oxySearchSpace.Length / 2m ? 1 : 0)
        .ToArray();

    oxySearchSpace = oxySearchSpace.Where(x => mostPopular[i] == getBitAtPosition(x, i)).ToArray();
}


Console.WriteLine(co2SearchSpace[0] * oxySearchSpace[0]);