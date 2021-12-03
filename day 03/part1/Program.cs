using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

var len = lines[0].Length;
var gammaRate = 0;


var numbers = lines.Select(x => Convert.ToInt32(x, 2)).ToArray();
var getMostPopularBit = (int pos) => (numbers.Count((num) => (num & (1 << pos)) > 0) >= numbers.Length / 2m) ? 1 : 0;

for (var i = 0; i < len; i++) {
    gammaRate |= getMostPopularBit(i) << i;
}

var epsilonRate = ~gammaRate & ((1 << len) - 1);

Console.WriteLine(gammaRate * epsilonRate);