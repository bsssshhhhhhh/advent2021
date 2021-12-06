using AdventCommon;
var lines = ConsoleHelpers.ReadInput();
var lanternfish = lines[0]
    .Split(",")
    .Select(int.Parse)
    .Aggregate(new Dictionary<int, long>() {
        {0, 0}, {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0} 
    } , (acc, cur) => {
       if (!acc.TryGetValue(cur, out _))
       {
           acc[cur] = 1;
       }
       else
       {
           acc[cur]++;
       }

       return acc;
    });

var simulateDay = () => {
    foreach (var kvp in lanternfish.ToDictionary(k => k.Key, v => v.Value))
    {
        if (kvp.Key == 0)
        {
            lanternfish[kvp.Key] = 0;
            lanternfish[6] += kvp.Value;
            lanternfish[8] += kvp.Value;
        }
        else
        {
            lanternfish[kvp.Key] -= kvp.Value;
            lanternfish[kvp.Key - 1] += kvp.Value;
        }
    }
};


for (var i = 0; i < 256; i++)
{
    simulateDay();
}

Console.WriteLine(lanternfish.Values.Sum());
