using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

var len = lines[0].Length;
var gammaRateString = "";


for (var i = 0; i < len; i++) {
    gammaRateString += Math.Round(lines.Select(x => x[i] == '0' ? 0 : 1).Average());
}

var gammaRate = Convert.ToInt32(gammaRateString, 2);
var epsilonRate = ~gammaRate & ((1 << len) - 1);

Console.WriteLine(gammaRate * epsilonRate);