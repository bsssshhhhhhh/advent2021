using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

int x = 0;
int y = 0;
int aim = 0;


for (var i = 0; i < lines.Length; i++)
{
    var parts = lines[i].Split(" ");
    var distance = int.Parse(parts[1]);

    switch (parts[0])
    {
        case "forward": {
          x += distance;
          y += aim * distance;
          break;
        }
        case "down": aim += distance; break;
        case "up": aim -= distance; break;
    }
}

Console.WriteLine(x * y);