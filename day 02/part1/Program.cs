using AdventCommon;
var lines = ConsoleHelpers.ReadInput();

int x = 0;
int y = 0;


for (var i = 0; i < lines.Length; i++)
{
    var parts = lines[i].Split(" ");
    var distance = int.Parse(parts[1]);

    switch (parts[0])
    {
        case "forward": x += distance; break;
        case "down": y += distance; break;
        case "up": y -= distance; break;
    }
}

Console.WriteLine(x * y);