using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

var crabs = lines[0].Split(",").Select(int.Parse);

var fuel = Enumerable
    .Range(0, crabs.Max())
    .Select(difference => crabs
        .Select(crab => Math.Abs(crab - difference))
        .Select(fuel => (1 + fuel) * (fuel / 2m))
    )
    .Select(fuel => fuel.Sum())
    .Min();

Console.WriteLine(Convert.ToInt32(fuel));