using System.Drawing;
using AdventCommon;
using System.Text;

var lines = ConsoleHelpers.ReadInput();

var answer = lines
    .Select(line => {
        var parts = line.Split(" -> ");

        
        var part1 = parts[0].Split(",").Select(int.Parse).ToArray();
        var part2 = parts[1].Split(",").Select(int.Parse).ToArray();

        var minX = Math.Min(part1[0], part2[0]);
        var minY = Math.Min(part1[1], part2[1]);

        var maxX = Math.Max(part1[0], part2[0]);
        var maxY = Math.Max(part1[1], part2[1]);

        var points = new List<Point>();

        if (!(minX == maxX || minY == maxY))
        {
            return points;
        }
        else if (minX != maxX)
        {
            for (var x = minX; x <= maxX; x++)
            {
                points.Add(new Point(x, minY));
            }
        }
        else if (minY != maxY)
        {
            for (var y = minY; y <= maxY; y++)
            {
                points.Add(new Point(minX, y));
            }
        }
        else
        {
            points.Add(new Point(minX, minY));
        }

        return points;
    })
    .SelectMany(x => x)
    .Aggregate(new Dictionary<Point, int>(), (acc, point) => {
        if (!acc.TryGetValue(point, out _))
        {
            acc.Add(point, 1);
        }
        else
        {
            acc[point] += 1;
        }
        
        return acc;
    })
    .Count((kvp) => kvp.Value > 1);

Console.WriteLine(answer);